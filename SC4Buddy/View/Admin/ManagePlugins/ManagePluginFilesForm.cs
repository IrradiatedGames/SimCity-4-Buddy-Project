﻿namespace NIHEI.SC4Buddy.View.Admin.ManagePlugins
{
    using System.Collections.Generic;
    using System.Data.Objects.DataClasses;
    using System.IO;
    using System.Windows.Forms;

    using NIHEI.Common.UI.Elements;
    using NIHEI.SC4Buddy.Entities.Remote;

    public partial class ManagePluginFilesForm : Form
    {
        private EntityCollection<RemotePluginFile> pluginFiles;

        public ManagePluginFilesForm(EntityCollection<RemotePluginFile> pluginFiles)
        {
            PluginFiles = pluginFiles;
            InitializeComponent();
        }

        public EntityCollection<RemotePluginFile> PluginFiles
        {
            get
            {
                return pluginFiles;
            }

            private set
            {
                pluginFiles = value;

                UpdateListView(pluginFiles);
            }
        }

        private void UpdateListView(IEnumerable<RemotePluginFile> pluginFiles)
        {
            filesListView.BeginUpdate();
            filesListView.Items.Clear();

            foreach (var file in pluginFiles)
            {
                var item = new ListViewItemWithObjectValue<RemotePluginFile>(Path.GetFileName(file.Name), file);
                item.SubItems.Add(file.Checksum);
                filesListView.Items.Add(item);
            }

            filesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            filesListView.EndUpdate();
        }
    }
}
