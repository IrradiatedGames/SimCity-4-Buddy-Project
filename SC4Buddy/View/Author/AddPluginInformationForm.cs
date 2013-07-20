﻿namespace NIHEI.SC4Buddy.View.Author
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using NIHEI.SC4Buddy.Control;
    using NIHEI.SC4Buddy.DataAccess.Remote;
    using NIHEI.SC4Buddy.Entities.Remote;
    using NIHEI.SC4Buddy.Localization;
    using NIHEI.SC4Buddy.View.Elements;

    public partial class AddPluginInformationForm : Form
    {
        private readonly AuthorRegistry authorRegistry;

        private IList<RemotePluginFile> files;

        public AddPluginInformationForm()
        {
            authorRegistry = RemoteRegistryFactory.AuthorRegistry;

            InitializeComponent();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AddPluginInformationFormLoad(object sender, EventArgs e)
        {
            var authors = authorRegistry.Authors.Where(x => x.UserId == SessionController.Instance.User.Id).ToList();

            if (!authors.Any())
            {
                MessageBox.Show(
                    this,
                    LocalizationStrings.YouNeedToAddAtLeastOneAuthorInOrderToAddPluginInformationToTheCentralDatabase,
                    LocalizationStrings.NoAuthorsDefined,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                Close();
            }

            ReloadSiteAndAuthorComboBoxItems(authors);
        }

        private void ReloadSiteAndAuthorComboBoxItems(IEnumerable<Author> authors)
        {
            siteAndAuthorComboBox.BeginUpdate();
            siteAndAuthorComboBox.Items.Clear();
            foreach (var author in authors)
            {
                siteAndAuthorComboBox.Items.Add(
                    new ComboBoxItem<Author>(
                        string.Format("{1} ({0})", author.Name, author.Site), author));
            }

            siteAndAuthorComboBox.EndUpdate();
        }

        private void FilesButtonClick(object sender, EventArgs e)
        {
            var dialog = new AddFilesForm();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                files = dialog.Files;
            }
        }

        private void SelectInstalledPluginButtonClick(object sender, EventArgs e)
        {
            var dialog = new SelectInstalledPluginForm();

            if (dialog.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
