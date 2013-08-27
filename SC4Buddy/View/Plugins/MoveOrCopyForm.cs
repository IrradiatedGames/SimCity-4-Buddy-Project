﻿using System.Windows.Forms;

namespace NIHEI.SC4Buddy.View.Plugins
{
    using System;
    using System.Linq;
    using NIHEI.SC4Buddy.DataAccess;
    using NIHEI.SC4Buddy.Entities;
    using NIHEI.SC4Buddy.View.Elements;

    public partial class MoveOrCopyForm : Form
    {

        private readonly UserFolder currentUserFolder;

        private UserFolder selectedUserFolder;

        public event EventHandler PluginCopied;

        public event EventHandler PluginMoved;

        public event EventHandler ErrorDuringCopyOrMove;

        public MoveOrCopyForm(UserFolder currentUserFolder)
        {
            this.currentUserFolder = currentUserFolder;
            InitializeComponent();
        }

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

            var userFolders = RegistryFactory.UserFolderRegistry.UserFolders;

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
    }
}
