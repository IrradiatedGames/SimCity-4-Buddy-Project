﻿namespace Nihei.SC4Buddy.Application.View
{
    using System;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Threading;
    using System.Windows.Forms;
    using Asser.Sc4Buddy.Server.Api.V1.Client;
    using log4net;
    using Nihei.Common.UI.Elements;
    using Nihei.SC4Buddy.Application.Control;
    using Nihei.SC4Buddy.Configuration;
    using Nihei.SC4Buddy.Model;
    using Nihei.SC4Buddy.Plugins.Control;
    using Nihei.SC4Buddy.Plugins.DataAccess;
    using Nihei.SC4Buddy.Plugins.Services;
    using Nihei.SC4Buddy.Plugins.View;
    using Nihei.SC4Buddy.Properties;
    using Nihei.SC4Buddy.Remote.Utils;
    using Nihei.SC4Buddy.Resources;
    using Nihei.SC4Buddy.UserFolders.Control;
    using Nihei.SC4Buddy.UserFolders.View;
    using Nihei.SC4Buddy.Utils;
    using Nihei.SC4Buddy.View.Elements;

    public partial class Sc4Buddy : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ResourceManager localizationManager;

        private readonly IUserFoldersController userFoldersController;

        private readonly PluginGroupController pluginGroupController;

        private readonly IPluginMatcher pluginMatcher;

        private readonly Collection<UserFolderForm> userFolderForms;

        private ManageUserFoldersForm manageUserFoldersForm;

        private AboutBox aboutBox;

        private SettingsForm settingsForm;

        private SelectUserFolderForm selectUserFolderForm;

        private ChangelogForm changelogForm;

        public Sc4Buddy(
            IUserFoldersController userFoldersController,
            PluginGroupController pluginGroupController,
            IPluginMatcher pluginMatcher)
        {
            this.userFoldersController = userFoldersController;
            this.pluginGroupController = pluginGroupController;
            this.pluginMatcher = pluginMatcher;

            InitializeComponent();

            userFolderForms = new Collection<UserFolderForm>();

            localizationManager = new System.ComponentModel.ComponentResourceManager(typeof(Sc4Buddy));
        }

        private static UserFolder GetSelectedUserFolder(object sender)
        {
            return ((UserFolderToolStripMenuItem)sender).UserFolder;
        }

        private void UserFolderComboBoxCheckSelectedValue(object sender, EventArgs e)
        {
            var selectUserFolderText = localizationManager.GetString("userFolderComboBox.Text");
            if (userFolderComboBox.SelectedItem == null
                || userFolderComboBox.Text.Equals(selectUserFolderText))
            {
                userFolderComboBox.Text = selectUserFolderText;
                userFolderComboBox.ForeColor = Color.Gray;
            }
            else
            {
                userFolderComboBox.ForeColor = Color.Black;
            }
        }

        private void UserFolderComboBoxDropDown(object sender, EventArgs e)
        {
            userFolderComboBox.ForeColor = Color.Black;
        }

        private void ManageFoldersToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (manageUserFoldersForm == null)
            {
                manageUserFoldersForm = new ManageUserFoldersForm(userFoldersController);
            }

            manageUserFoldersForm.Show(this);

            RepopulateUserFolderRelatives();
        }

        private void RepopulateUserFolderRelatives()
        {
            Log.Info("Repopulating user folder lists");

            userFolderComboBox.BeginUpdate();
            userFolderComboBox.Items.Clear();

            var remove = userFoldersToolStripMenuItem.DropDownItems.OfType<UserFolderToolStripMenuItem>().ToList();
            foreach (var item in remove)
            {
                userFoldersToolStripMenuItem.DropDownItems.Remove(item);
            }

            var insertIndex = 0;
            var comboboxIndex = 0;
            var startupFolderIndex = -1;
            foreach (var userFolder in userFoldersController.UserFolders)
            {
                if (!userFolder.IsMainFolder)
                {
                    userFolderComboBox.Items.Add(new ComboBoxItem<UserFolder>(userFolder.Alias, userFolder));

                    if (userFolder.IsStartupFolder)
                    {
                        startupFolderIndex = comboboxIndex;
                    }

                    comboboxIndex++;
                }

                if (userFolder.Alias.Equals("?"))
                {
                    userFolder.Alias = LocalizationStrings.GameUserFolderName;
                    userFoldersController.Update(userFolder);
                }

                userFoldersToolStripMenuItem.DropDownItems.Insert(insertIndex, new UserFolderToolStripMenuItem(userFolder, UserFolderMenuItemClick));
                insertIndex++;
            }

            if (startupFolderIndex >= 0)
            {
                userFolderComboBox.SelectedIndex = startupFolderIndex;
            }
            else
            {
                userFolderComboBox.SelectedItem = null;
                userFolderComboBox.Text = localizationManager.GetString("userFolderComboBox.Text");
                userFolderComboBox.ForeColor = Color.Gray;
            }

            userFolderComboBox.EndUpdate();
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Log.Info("Application closing (menu item click)");
            Close();
        }

        private void Sc4BuddyLoad(object sender, EventArgs e)
        {
            RepopulateUserFolderRelatives();

            UpdateBackground();
        }

        private void UpdateBackground()
        {
            Bitmap image;
            switch (Settings.GetInt(Settings.Keys.Wallpaper))
            {
                case 13:
                    image = Resources.Wallpaper13;
                    break;
                case 12:
                    image = Resources.Wallpaper12;
                    break;
                case 11:
                    image = Resources.Wallpaper11;
                    break;
                case 10:
                    image = Resources.Wallpaper10;
                    break;
                case 9:
                    image = Resources.Wallpaper9;
                    break;
                case 8:
                    image = Resources.Wallpaper8;
                    break;
                case 7:
                    image = Resources.Wallpaper7;
                    break;
                case 6:
                    image = Resources.Wallpaper6;
                    break;
                case 5:
                    image = Resources.Wallpaper5;
                    break;
                case 4:
                    image = Resources.Wallpaper4;
                    break;
                case 3:
                    image = Resources.Wallpaper3;
                    break;
                case 2:
                    image = Resources.Wallpaper2;
                    break;
                default:
                    image = Resources.Wallpaper1;
                    break;
            }

            backgroundPanel.BackgroundImage = image;
        }

        private void UserFolderMenuItemClick(object sender, EventArgs e)
        {
            var userFolder = GetSelectedUserFolder(sender);

            var form = userFolderForms.FirstOrDefault(x => x.UserFolder.Id == userFolder.Id);

            if (form == null)
            {
                var client = new BuddyServerClient(ApiConnect.GetClient());
                var dependencyChecker = new DependencyChecker(client);
                form = new UserFolderForm(
                    userFolder,
                    pluginGroupController,
                    userFoldersController,
                    pluginMatcher,
                    new PluginsController(
                        new PluginsDataAccess(userFolder, new JsonFileWriter(), pluginGroupController),
                        new PluginsDataAccess(userFoldersController.GetMainUserFolder(), new JsonFileWriter(), pluginGroupController),
                        userFolder,
                        new PluginMatcher(client),
                        client,
                        dependencyChecker));
                userFolderForms.Add(form);
            }

            form.UpdateData();

            form.Show();
            form.Focus();
        }

        private void PlayButtonClick(object sender, EventArgs e)
        {
            Log.Info("Launching game");
            playButton.Enabled = false;
            playButton.Text = LocalizationStrings.StartingGame;
            playButton.ForeColor = Color.Gray;
            playButton.Update();

            UserFolder selectedUserFolder = null;
            if (userFolderComboBox.SelectedItem != null)
            {
                selectedUserFolder = ((ComboBoxItem<UserFolder>)userFolderComboBox.SelectedItem).Value;
                Log.Info(
                    string.Format(
                        "Selected user folder is {0} (id: {1})",
                        selectedUserFolder.Alias,
                        selectedUserFolder.Id));
            }
            else
            {
                Log.Info("No user folder selected.");
            }

            var arguments = new GameArgumentsHelper().GetArgumentString(selectedUserFolder);

            var gameProcessStartInfo = new ProcessStartInfo
                                           {
                                               FileName =
                                                   Path.Combine(
                                                       Settings.Get(Settings.Keys.GameLocation),
                                                       "Apps",
                                                       "SimCity 4.exe"),
                                               Arguments = arguments,
                                               WorkingDirectory = Settings.Get(Settings.Keys.GameLocation)
                                           };

            var gameLauncher = new GameLauncher(gameProcessStartInfo, LauncherSettings.GetInt(LauncherSettings.Keys.AutoSaveWaitTime));
            var gameLauncherThread = new Thread(gameLauncher.Start) { Name = "SC4Buddy AutoSaver" };

            gameLauncherThread.Start();

            Thread.Sleep(5000);

            playButton.Enabled = true;
            playButton.Text = localizationManager.GetString("playButton.Text");
            playButton.ForeColor = Color.Black;
        }

        private void SettingsToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm(userFoldersController);
            }

            settingsForm.ShowDialog(this);

            UpdateBackground();
        }

        private void SupportToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start(ConfigurationManager.AppSettings.Get("SupportWeblink"));
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (aboutBox == null)
            {
                aboutBox = new AboutBox();
            }

            aboutBox.ShowDialog(this);
        }

        private void BugsAndFeedbackToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start(ConfigurationManager.AppSettings.Get("BugReportWeblink"));
        }

        private void OpenLogFileToolStripMenuItemClick(object sender, EventArgs e)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Irradiated Games", "SimCity 4 Buddy", "Logs");

            var file = string.Format("log-{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));

            var filePath = Path.Combine(path, file);

            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    this,
                    string.Format("No log file was found. Check the folder ({0}) manually.", path),
                    @"No logfile was found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            Process.Start(filePath);
        }

        private void Sc4BuddyDragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Log.Info("User dropped the following files into the main window.");
            foreach (var file in files)
            {
                Log.Info(file);
            }

            if (selectUserFolderForm == null)
            {
                selectUserFolderForm = new SelectUserFolderForm(userFoldersController);
            }

            if (selectUserFolderForm.ShowDialog(this) != DialogResult.OK)
            {
                Log.Info("Drag and drop installation cancelled.");
                return;
            }

            var userFolder = selectUserFolderForm.UserFolder;
            Log.Info(string.Format("Installing in user folder {0}", userFolder.FolderPath));

            var client = new BuddyServerClient(ApiConnect.GetClient());
            var dependencyChecker = new DependencyChecker(client);
            var form = new InstallPluginsForm(
                new PluginsController(
                    new PluginsDataAccess(userFolder, new JsonFileWriter(), pluginGroupController),
                    new PluginsDataAccess(userFoldersController.GetMainUserFolder(), new JsonFileWriter(), pluginGroupController),
                    userFolder,
                    new PluginMatcher(client),
                    client,
                    dependencyChecker),
                files,
                userFolder,
                pluginMatcher);

            form.ShowDialog(this);
        }

        private void Sc4BuddyDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void ChangelogMenuItemClick(object sender, EventArgs e)
        {
            if (changelogForm == null)
            {
                changelogForm = new ChangelogForm();
            }

            changelogForm.ShowDialog(this);
        }
    }
}
