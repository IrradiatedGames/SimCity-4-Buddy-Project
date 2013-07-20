﻿namespace NIHEI.SC4Buddy.View.Author
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using NIHEI.Common.UI.Elements;
    using NIHEI.SC4Buddy.DataAccess.Remote;
    using NIHEI.SC4Buddy.Entities.Remote;

    public partial class DependenciesForm : Form
    {
        private readonly RemotePluginRegistry remotePluginRegistry;

        public DependenciesForm()
        {
            Dependencies = new List<RemotePlugin>();

            remotePluginRegistry = RemoteRegistryFactory.RemotePluginRegistry;

            InitializeComponent();
        }

        protected ICollection<RemotePlugin> Dependencies { get; set; }

        private void SearchBoxTextChanged(object sender, EventArgs e)
        {
            var text = searchBox.Text.Trim().ToUpper().Replace("//WWW.", "//");

            if (text.Length < 3)
            {
                searchResultListView.Items.Clear();
                return;
            }

            var plugins =
                remotePluginRegistry.RemotePlugins.Where(x
                    => x.Name.ToUpper().Contains(text)
                    || x.Author.Name.ToUpper().Contains(text)
                    || x.Link.ToUpper().Replace("//WWW.", "//").Contains(text));

            searchResultListView.BeginUpdate();
            searchResultListView.Items.Clear();
            foreach (var remotePlugin in plugins)
            {
                var item = new ListViewItemWithObjectValue<RemotePlugin>(remotePlugin.Name, remotePlugin);
                item.SubItems.Add(remotePlugin.Author.Name);
                item.SubItems.Add(remotePlugin.Link);
                searchResultListView.Items.Add(item);
            }

            searchResultListView.EndUpdate();
            searchResultListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void SearchResultListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            var items = searchResultListView.SelectedItems;

            addAsDependencyButton.Enabled = items.Count > 0;
        }

        private void AddAsDependencyButtonClick(object sender, EventArgs e)
        {
            var items = searchResultListView.SelectedItems;
            var removingItems = new List<ListViewItemWithObjectValue<RemotePlugin>>();

            foreach (ListViewItemWithObjectValue<RemotePlugin> item in items)
            {
                if (Dependencies.Any(x => x.Id == item.Value.Id))
                {
                    return;
                }

                Dependencies.Add(item.Value);
                removingItems.Add(item);
            }

            foreach (var item in removingItems)
            {
                searchResultListView.Items.Remove(item);
            }

            UpdateDependenciesList();
            addAsDependencyButton.Enabled = false;
        }

        private void UpdateDependenciesList()
        {
            dependenciesListView.BeginUpdate();
            dependenciesListView.Items.Clear();

            foreach (var dependency in Dependencies)
            {
                var item = new ListViewItemWithObjectValue<RemotePlugin>(dependency.Name, dependency);
                item.SubItems.Add(dependency.Author.Name);
                item.SubItems.Add(dependency.Link);
                dependenciesListView.Items.Add(item);
            }

            dependenciesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            dependenciesListView.EndUpdate();
        }

        private void DependenciesListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            removeButton.Enabled = dependenciesListView.Items.Count > 0;
        }

        private void RemoveButtonClick(object sender, EventArgs e)
        {
            var items = dependenciesListView.SelectedItems;
            var addItems = new List<ListViewItemWithObjectValue<RemotePlugin>>(items.Count);

            foreach (ListViewItemWithObjectValue<RemotePlugin> item in items)
            {
                Dependencies.Remove(item.Value);
                addItems.Add(item);
            }

            UpdateDependenciesList();

            removeButton.Enabled = false;

            var text = searchBox.Text.Trim().ToUpper().Replace("//WWW.", "//");

            if (text.Length < 3)
            {
                searchResultListView.Items.Clear();
                return;
            }

            foreach (
                var item in
                    addItems.Where(
                        item =>
                        item.Value.Name.ToUpper().Contains(text) || item.Value.Author.Name.ToUpper().Contains(text)
                        || item.Value.Link.ToUpper().Contains(text)))
            {
                searchResultListView.Items.Add(item);
            }
        }
    }
}