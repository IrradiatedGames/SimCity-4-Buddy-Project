﻿namespace NIHEI.SC4Buddy.View.Admin.ManagePlugins
{
    using System.Collections.Generic;
    using System.Data.Objects.DataClasses;
    using System.IO;
    using System.Windows.Forms;

    using NIHEI.Common.IO;
    using NIHEI.Common.UI.Elements;
    using NIHEI.SC4Buddy.Control.Remote;
    using NIHEI.SC4Buddy.Entities.Remote;
    using NIHEI.SC4Buddy.Localization;

    public partial class ManagePluginFilesForm : Form
    {
        public ManagePluginFilesForm(RemotePluginController remotePluginController, RemotePlugin remotePlugin)
        {
            InitializeComponent();

            Plugin = remotePlugin;
            PluginFiles = Plugin.PluginFiles;
        }

        public RemotePlugin Plugin { get; set; }

        public ICollection<RemotePluginFile> PluginFiles { get; private set; }

        private void UpdateListView(IEnumerable<RemotePluginFile> files)
        {
            filesListView.BeginUpdate();
            filesListView.Items.Clear();

            foreach (var file in files)
            {
                var item = new ListViewItemWithObjectValue<RemotePluginFile>(Path.GetFileName(file.Name), file);
                item.SubItems.Add(file.Checksum);
                filesListView.Items.Add(item);
            }

            filesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            filesListView.EndUpdate();
        }

        private void FilesListViewSelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (filesListView.SelectedItems.Count < 1)
            {
                removeButton.Enabled = false;
            }

            removeButton.Enabled = true;
        }

        private void RemoveButtonClick(object sender, System.EventArgs e)
        {
            var selectedItem = ((ListViewItemWithObjectValue<RemotePluginFile>)filesListView.SelectedItems[0]).Value;

            PluginFiles.Remove(selectedItem);

            UpdateListView(PluginFiles);
        }

        private void AddButtonClick(object sender, System.EventArgs e)
        {
            if (selectFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var files = selectFileDialog.FileNames;

            foreach (var file in files)
            {
                var remoteFile = new RemotePluginFile
                                     {
                                         Name = Path.GetFileName(file),
                                         Checksum = Md5ChecksumUtility.CalculateChecksum(file).ToHex(),
                                         Plugin = Plugin
                                     };

                if (!PluginFiles.Contains(remoteFile))
                {
                    PluginFiles.Add(remoteFile);
                }
            }
        }

        private void OkButtonClick(object sender, System.EventArgs e)
        {
        }

        private void CancelButtonClick(object sender, System.EventArgs e)
        {

        }
    }
}
