﻿namespace NIHEI.SC4Buddy.View.Plugins
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    using log4net;

    using NIHEI.SC4Buddy.Configuration;
    using NIHEI.SC4Buddy.Control.Plugins;
    using NIHEI.SC4Buddy.DataAccess;
    using NIHEI.SC4Buddy.Installer;
    using NIHEI.SC4Buddy.Installer.InstallerEventArgs;
    using NIHEI.SC4Buddy.Localization;
    using NIHEI.SC4Buddy.Model;
    using NIHEI.SC4Buddy.Remote;
    using NIHEI.SC4Buddy.View.Helpers;

    public partial class InstallPluginsForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly UserFolder userFolder;

        private readonly IList<string> installedPlugins;

        private readonly IList<string> failedPlugins;

        private readonly IList<Plugin> tempPluginInfo;

        private readonly PluginController pluginController;

        private readonly EnterPluginInformationForm enterPluginInformationForm;

        private readonly IPluginMatcher pluginMatcher;

        public InstallPluginsForm(PluginController pluginController, string[] files, UserFolder userFolder, IPluginMatcher pluginMatcher)
        {
            this.userFolder = userFolder;
            this.pluginMatcher = pluginMatcher;
            InitializeComponent();

            installedPlugins = new List<string>();
            failedPlugins = new List<string>();
            tempPluginInfo = new List<Plugin>();

            enterPluginInformationForm =
                new EnterPluginInformationForm(new PluginGroupController(EntityFactory.Instance.Entities));

            this.pluginController = pluginController;

            OverallProgressBar.Maximum = files.Length;
            CurrentProgressBar.Maximum = 100;

            var pluginInstallerThread = new PluginInstallerThread(
                pluginController,
                new PluginFileController(EntityFactory.Instance.Entities))
                                        {
                                            Form = this,
                                            FilesToInstall = files,
                                            UserFolder = userFolder
                                        };
            pluginInstallerThread.InstallingPlugin += OnInstallingPlugin;
            pluginInstallerThread.PluginInstalled += OnPluginInstalled;
            pluginInstallerThread.PluginInstallFailed += OnPluginInstallFailed;
            pluginInstallerThread.InstallProgressChanged += OnInstallProgressChanged;
            pluginInstallerThread.AllPluginsInstalled += (sender, eventArgs) => OnAllPluginsInstalled(sender, eventArgs);
            pluginInstallerThread.ReadmeFilesFound += OnReadmeFilesFound;
            pluginInstallerThread.NotPartOneOfMultipartDetected += OnNotPartOneOfMultipartDetected;

            var installerThread = new Thread(pluginInstallerThread.Install);
            installerThread.SetApartmentState(ApartmentState.STA);
            installerThread.Start();
        }

        public bool AskToRunExecutable(FileInfo executable)
        {
            return (bool)Invoke(new Func<bool>(() => ShowAskToRunExecutable(executable)));
        }

        public void ShowInstallationDidNotStartDialog()
        {
            Invoke(
                new Action(
                    () =>
                    MessageBox.Show(
                        this,
                        LocalizationStrings.ItSeemsLikeTheInstallationDidNotStart,
                        LocalizationStrings.PossibleErrorDetected,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop)));
        }

        private void IncrementInstalledPlugins()
        {
            SetOverallProgresBar(OverallProgressBar.Value + 1);
            SetCurrentProgressBar(100);
        }

        private void ResetCurrentProgressBar()
        {
            CurrentProgressBar.BeginInvoke(new Action(
                () => CurrentProgressBar.Value = 0));
        }

        private void SetOverallProgresBar(int value)
        {
            OverallProgressBar.BeginInvoke(new Action(
                () => OverallProgressBar.Value = value));
        }

        private void SetCurrentProgressBar(int value)
        {
            CurrentProgressBar.BeginInvoke(new Action(
                () => CurrentProgressBar.Value = value));
        }

        private void Write(string text)
        {
            if (IsHandleCreated)
            {
                OutputTextBox.BeginInvoke(new Action(
                    () => OutputTextBox.AppendText(text)));
            }
        }

        private void WriteLine(string message)
        {
            Write(string.Format("\n{0}", message));
        }

        private void OnNotPartOneOfMultipartDetected(PluginInstallerThread sender, InstallPluginEventArgs args)
        {
            WriteLine(string.Format(LocalizationStrings.FileXSkipped, args.FileInfo.Name));
            WriteLine(LocalizationStrings.YouCanOnlySelectPart1OfAMultipartPlugin);
            IncrementInstalledPlugins();
        }

        private bool ShowAskToRunExecutable(FileInfo executable)
        {
            var messageString = string.Format(
                LocalizationStrings.DoYouWantToRunTheNamExecutable,
                new object[] { executable.Name, Path.Combine(userFolder.FolderPath, UserFolder.PluginFolderName) });

            return MessageBox.Show(
                this,
                messageString,
                LocalizationStrings.RunExecutable,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes;
        }

        private void OnReadmeFilesFound(PluginInstallerThread sender, ReadmeFilesEventArgs args)
        {
            Invoke(new Action(() => new ReadmeFilesForm(args.ReadmeFiles).ShowDialog(this)));
        }

        private void OnAllPluginsInstalled(object sender, EventArgs eventArgs)
        {
            WriteLine(string.Empty);
            WriteLine(LocalizationStrings.InstallationCompleted);
            WriteLine(string.Format(LocalizationStrings.NumPluginsInstalledSuccessfully, installedPlugins.Count));

            if (failedPlugins.Any())
            {
                WriteLine(string.Format(LocalizationStrings.NumPluginsFailedInstallationPleaseReview, failedPlugins.Count));
                WriteLine(LocalizationStrings.FailedPlugins);
                foreach (var failedPlugin in failedPlugins)
                {
                    WriteLine(failedPlugin);
                }
            }

            if (tempPluginInfo.Any())
            {
                Invoke(new Action(() =>
                    {
                        if (NetworkInterface.GetIsNetworkAvailable() && Settings.Get<bool>(Settings.Keys.FetchInformationFromRemoteServer))
                        {
                            var matched = new Collection<Plugin>();
                            foreach (
                                var plugin in
                                    tempPluginInfo.Where(plugin => pluginMatcher.MatchAndUpdateAsync(plugin).Result))
                            {
                                matched.Add(plugin);
                            }

                            foreach (var match in matched)
                            {
                                tempPluginInfo.Remove(match);
                            }
                        }

                        if (!tempPluginInfo.Any())
                        {
                            return;
                        }

                        if (Settings.Get<bool>(Settings.Keys.AskForAdditionalInformationAfterInstallation)
                            && ShowWouldYouLikeToEnterAdditionalDetailsDialog() != DialogResult.No)
                        {
                            foreach (var plugin in tempPluginInfo)
                            {
                                enterPluginInformationForm.Plugin = plugin;
                                var result = ShowEnterPluginInformationForm();
                                if (result == DialogResult.OK)
                                {
                                    pluginController.SaveChanges();
                                }
                            }
                        }

                        if (Settings.Get<bool>(Settings.Keys.AskToRemoveNonPluginFilesAfterInstallation))
                        {
                            var storageLocation =
                                    Path.Combine(
                                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                        "Irradiated Games",
                                        "SimCity 4 Buddy",
                                        "Configuration");

                            var nonPluginFilesScannerUi = new NonPluginFilesScannerUi(storageLocation)
                            {
                                UserFolder = userFolder
                            };

                            if (nonPluginFilesScannerUi.ShowDoYouWantToScanForNonPluginFiles(this))
                            {
                                nonPluginFilesScannerUi.ScanForCandidates();

                                if (!nonPluginFilesScannerUi.RemovalCandidateInfos.Any())
                                {
                                    nonPluginFilesScannerUi.ShowThereAreNoEntitiesToRemoveDialog(this);
                                }

                                if (nonPluginFilesScannerUi.ShowConfirmDialog(this))
                                {
                                    nonPluginFilesScannerUi.RemoveNonPluginFilesAndShowSummary(this);
                                }
                            }
                        }
                    }));
            }

            Invoke(new Action(() => closeButton.Enabled = true));
        }

        private DialogResult ShowEnterPluginInformationForm()
        {
            return enterPluginInformationForm.ShowDialog(this);
        }

        private DialogResult ShowWouldYouLikeToEnterAdditionalDetailsDialog()
        {
            return MessageBox.Show(
                this,
                LocalizationStrings.WouldYouLikeToEnterAdditionalDetailsForTheInstalledPlugins,
                LocalizationStrings.EnterAdditionalPluginInformation,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
        }

        private void OnInstallProgressChanged(PluginInstallerThread sender, InstallProgressEventArgs e)
        {
            WriteLine(e.Message);
            SetCurrentProgressBar(e.Progress);
        }

        private void OnPluginInstallFailed(PluginInstallerThread sender, InstallPluginFailureEventArgs e)
        {
            WriteLine(e.ErrorMessage);
            WriteLine(LocalizationStrings.PluginInstallFailed);
            IncrementInstalledPlugins();
            failedPlugins.Add(e.FileInfo.Name);
        }

        private void OnPluginInstalled(PluginInstallerThread sender, InstalledPluginEventArgs e)
        {
            WriteLine(LocalizationStrings.PluginInstalledSuccessfully);
            SetCurrentProgressBar(100);
            IncrementInstalledPlugins();
            installedPlugins.Add(e.FileInfo.Name);
            tempPluginInfo.Add(e.Plugin);
        }

        private void OnInstallingPlugin(PluginInstallerThread sender, InstallPluginEventArgs e)
        {
            try
            {
                WriteLine(string.Format(LocalizationStrings.InstallingPluginNam, e.FileInfo.Name));
                ResetCurrentProgressBar();
            }
            catch (Exception ex)
            {
                Log.Error("Error during OnInstallingPlugin", ex);
            }
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
