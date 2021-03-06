﻿namespace Nihei.SC4Buddy.Plugins.View
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Asser.Sc4Buddy.Server.Api.V1.Client;
    using log4net;
    using Nihei.SC4Buddy.Model;
    using Nihei.SC4Buddy.Plugins.Control;
    using Nihei.SC4Buddy.Plugins.DataAccess;
    using Nihei.SC4Buddy.Plugins.Services;
    using Nihei.SC4Buddy.Remote.Utils;
    using Nihei.SC4Buddy.UserFolders.Control;
    using Nihei.SC4Buddy.Utils;
    using Nihei.SC4Buddy.View.Elements;

    public partial class MoveOrCopyForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly UserFolder currentUserFolder;

        private readonly IUserFoldersController userFoldersController;

        private readonly IPluginsController pluginsController;

        private readonly PluginGroupController pluginGroupController;

        private UserFolder selectedUserFolder;

        public MoveOrCopyForm(
            UserFolder currentUserFolder,
            IUserFoldersController userFoldersController,
            IPluginsController pluginsController,
            PluginGroupController pluginGroupController)
        {
            this.currentUserFolder = currentUserFolder;
            this.userFoldersController = userFoldersController;
            this.pluginsController = pluginsController;
            this.pluginGroupController = pluginGroupController;

            InitializeComponent();
        }

        public event EventHandler PluginCopied;

        public event EventHandler PluginMoved;

        public event EventHandler ErrorDuringCopyOrMove;

        public Plugin Plugin { get; set; }

        protected virtual void OnPluginCopied()
        {
            var handler = PluginCopied;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnPluginMoved()
        {
            var handler = PluginMoved;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnErrorDuringCopyOrMove()
        {
            var handler = ErrorDuringCopyOrMove;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void MoveOrCopyFormLoad(object sender, EventArgs e)
        {
            userFolderListView.BeginUpdate();
            userFolderListView.Items.Clear();

            var userFolders = userFoldersController.UserFolders;

            foreach (var userFolder in userFolders.Where(userFolder => !userFolder.Equals(currentUserFolder)))
            {
                userFolderListView.Items.Add(new ListViewItemWithObjectValue<UserFolder>(userFolder.Alias, userFolder));
            }

            userFolderListView.EndUpdate();
        }

        private void UserFolderListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (userFolderListView.SelectedItems.Count > 0)
            {
                selectedUserFolder = ((ListViewItemWithObjectValue<UserFolder>)userFolderListView.SelectedItems[0]).Value;

                moveButton.Enabled = true;
                copyButton.Enabled = true;
            }
            else
            {
                moveButton.Enabled = false;
                copyButton.Enabled = false;
            }
        }

        private void CopyButtonClick(object sender, EventArgs e)
        {
            var client = new BuddyServerClient(ApiConnect.GetClient());
            var dependencyChecker = new DependencyChecker(client);
            var copier = new PluginCopier(
                pluginsController,
                new PluginsController(
                    new PluginsDataAccess(selectedUserFolder, new JsonFileWriter(), pluginGroupController),
                    new PluginsDataAccess(userFoldersController.GetMainUserFolder(), new JsonFileWriter(), pluginGroupController),
                    selectedUserFolder,
                    new PluginMatcher(client),
                    client,
                    dependencyChecker));
            try
            {
                copier.CopyPlugin(Plugin, currentUserFolder, selectedUserFolder);
                OnPluginCopied();
            }
            catch (Exception ex)
            {
                Log.Error(
                    string.Format(
                        "Error during copy plugin {0} (id: {1}) to folder {2}",
                        Plugin.Name,
                        Plugin.Id,
                        selectedUserFolder.PluginFolderPath),
                    ex);
                OnErrorDuringCopyOrMove();
            }

            Close();
        }

        private void MoveButtonClick(object sender, EventArgs e)
        {
            var client = new BuddyServerClient(ApiConnect.GetClient());
            var dependencyChecker = new DependencyChecker(client);
            var copier = new PluginCopier(
                pluginsController,
                new PluginsController(
                    new PluginsDataAccess(selectedUserFolder, new JsonFileWriter(), pluginGroupController),
                    new PluginsDataAccess(userFoldersController.GetMainUserFolder(), new JsonFileWriter(), pluginGroupController),
                    selectedUserFolder,
                    new PluginMatcher(client),
                    client,
                    dependencyChecker));
            try
            {
                copier.MovePlugin(Plugin, currentUserFolder, selectedUserFolder);
                OnPluginMoved();
            }
            catch (Exception ex)
            {
                Log.Error(
                    string.Format(
                        "Error during moving plugin {0} (id: {1}) to folder {2}",
                        Plugin.Name,
                        Plugin.Id,
                        selectedUserFolder.PluginFolderPath),
                    ex);
                OnErrorDuringCopyOrMove();
            }

            Close();
        }
    }
}
