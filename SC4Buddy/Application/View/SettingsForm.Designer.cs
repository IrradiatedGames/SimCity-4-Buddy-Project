﻿// <auto-generated/>
namespace NIHEI.SC4Buddy.Application.View
{
    public partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.closeButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.browseQuarantinedButton = new System.Windows.Forms.Button();
            this.quarantinedFilesLocationTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.backgroundImageListView = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.gameLocationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.shortAutosaveIntervalsLabel = new System.Windows.Forms.Label();
            this.autoSaveIntervalLabel = new System.Windows.Forms.Label();
            this.autoSaveIntervalTrackBar = new System.Windows.Forms.TrackBar();
            this.enableAutoSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ignoreMissingModelsCheckBox = new System.Windows.Forms.CheckBox();
            this.writeLogCheckBox = new System.Windows.Forms.CheckBox();
            this.disableIMECheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cpuPriorityComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pauseMinimizedCheckBox = new System.Windows.Forms.CheckBox();
            this.disableBackgroundLoaderCheckBox = new System.Windows.Forms.CheckBox();
            this.skipIntroCheckBox = new System.Windows.Forms.CheckBox();
            this.disableExceptionHandlingCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cpuCountComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.windowModeCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cursorColourComboBox = new System.Windows.Forms.ComboBox();
            this.colourDepthComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.resolutionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.renderModeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customResolutionCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.disableSoundsCheckBox = new System.Windows.Forms.CheckBox();
            this.disableMusicCheckBox = new System.Windows.Forms.CheckBox();
            this.disableAudioCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.apiBaseUrlTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.allowCheckMissingDependenciesCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.fetchInformationFromRemoteCheckbox = new System.Windows.Forms.CheckBox();
            this.RemoveNonPluginFilesAfterInstallCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoRunInstallerExecutablesCheckBox = new System.Windows.Forms.CheckBox();
            this.AskForAdditionalInfoAfterInstallCheckBox = new System.Windows.Forms.CheckBox();
            this.gameLocationDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.storeLocationDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoSaveIntervalTrackBar)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Controls.Add(this.browseQuarantinedButton);
            this.groupBox8.Controls.Add(this.quarantinedFilesLocationTextBox);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // browseQuarantinedButton
            // 
            resources.ApplyResources(this.browseQuarantinedButton, "browseQuarantinedButton");
            this.browseQuarantinedButton.Name = "browseQuarantinedButton";
            this.browseQuarantinedButton.UseVisualStyleBackColor = true;
            this.browseQuarantinedButton.Click += new System.EventHandler(this.BrowseQuarantinedButtonClick);
            // 
            // quarantinedFilesLocationTextBox
            // 
            resources.ApplyResources(this.quarantinedFilesLocationTextBox, "quarantinedFilesLocationTextBox");
            this.quarantinedFilesLocationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.quarantinedFilesLocationTextBox.Name = "quarantinedFilesLocationTextBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox6
            // 
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Controls.Add(this.backgroundImageListView);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // backgroundImageListView
            // 
            resources.ApplyResources(this.backgroundImageListView, "backgroundImageListView");
            this.backgroundImageListView.MultiSelect = false;
            this.backgroundImageListView.Name = "backgroundImageListView";
            this.backgroundImageListView.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.scanButton);
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Controls.Add(this.gameLocationTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // scanButton
            // 
            resources.ApplyResources(this.scanButton, "scanButton");
            this.scanButton.CausesValidation = false;
            this.scanButton.Name = "scanButton";
            this.toolTip1.SetToolTip(this.scanButton, resources.GetString("scanButton.ToolTip"));
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.ScanButtonClick);
            // 
            // browseButton
            // 
            resources.ApplyResources(this.browseButton, "browseButton");
            this.browseButton.Name = "browseButton";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButtonClick);
            // 
            // gameLocationTextBox
            // 
            resources.ApplyResources(this.gameLocationTextBox, "gameLocationTextBox");
            this.gameLocationTextBox.ForeColor = System.Drawing.Color.Gray;
            this.gameLocationTextBox.Name = "gameLocationTextBox";
            this.gameLocationTextBox.TextChanged += new System.EventHandler(this.GameLocationTextBoxTextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.shortAutosaveIntervalsLabel);
            this.groupBox5.Controls.Add(this.autoSaveIntervalLabel);
            this.groupBox5.Controls.Add(this.autoSaveIntervalTrackBar);
            this.groupBox5.Controls.Add(this.enableAutoSaveCheckBox);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // shortAutosaveIntervalsLabel
            // 
            resources.ApplyResources(this.shortAutosaveIntervalsLabel, "shortAutosaveIntervalsLabel");
            this.shortAutosaveIntervalsLabel.ForeColor = System.Drawing.Color.Red;
            this.shortAutosaveIntervalsLabel.Name = "shortAutosaveIntervalsLabel";
            // 
            // autoSaveIntervalLabel
            // 
            resources.ApplyResources(this.autoSaveIntervalLabel, "autoSaveIntervalLabel");
            this.autoSaveIntervalLabel.Name = "autoSaveIntervalLabel";
            // 
            // autoSaveIntervalTrackBar
            // 
            resources.ApplyResources(this.autoSaveIntervalTrackBar, "autoSaveIntervalTrackBar");
            this.autoSaveIntervalTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.autoSaveIntervalTrackBar.Maximum = 60;
            this.autoSaveIntervalTrackBar.Minimum = 5;
            this.autoSaveIntervalTrackBar.Name = "autoSaveIntervalTrackBar";
            this.autoSaveIntervalTrackBar.Value = 15;
            this.autoSaveIntervalTrackBar.Scroll += new System.EventHandler(this.AutoSaveIntervalTrackBarScroll);
            // 
            // enableAutoSaveCheckBox
            // 
            resources.ApplyResources(this.enableAutoSaveCheckBox, "enableAutoSaveCheckBox");
            this.enableAutoSaveCheckBox.Name = "enableAutoSaveCheckBox";
            this.enableAutoSaveCheckBox.UseVisualStyleBackColor = true;
            this.enableAutoSaveCheckBox.CheckedChanged += new System.EventHandler(this.EnableAutoSaveButtonCheckedChanged);
            // 
            // groupBox7
            // 
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Controls.Add(this.languageComboBox);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.ignoreMissingModelsCheckBox);
            this.groupBox7.Controls.Add(this.writeLogCheckBox);
            this.groupBox7.Controls.Add(this.disableIMECheckBox);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // languageComboBox
            // 
            resources.ApplyResources(this.languageComboBox, "languageComboBox");
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Name = "languageComboBox";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // ignoreMissingModelsCheckBox
            // 
            resources.ApplyResources(this.ignoreMissingModelsCheckBox, "ignoreMissingModelsCheckBox");
            this.ignoreMissingModelsCheckBox.Name = "ignoreMissingModelsCheckBox";
            this.ignoreMissingModelsCheckBox.UseVisualStyleBackColor = true;
            // 
            // writeLogCheckBox
            // 
            resources.ApplyResources(this.writeLogCheckBox, "writeLogCheckBox");
            this.writeLogCheckBox.Name = "writeLogCheckBox";
            this.writeLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // disableIMECheckBox
            // 
            resources.ApplyResources(this.disableIMECheckBox, "disableIMECheckBox");
            this.disableIMECheckBox.Name = "disableIMECheckBox";
            this.disableIMECheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.cpuPriorityComboBox);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.pauseMinimizedCheckBox);
            this.groupBox4.Controls.Add(this.disableBackgroundLoaderCheckBox);
            this.groupBox4.Controls.Add(this.skipIntroCheckBox);
            this.groupBox4.Controls.Add(this.disableExceptionHandlingCheckBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cpuCountComboBox);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // cpuPriorityComboBox
            // 
            resources.ApplyResources(this.cpuPriorityComboBox, "cpuPriorityComboBox");
            this.cpuPriorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cpuPriorityComboBox.FormattingEnabled = true;
            this.cpuPriorityComboBox.Name = "cpuPriorityComboBox";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // pauseMinimizedCheckBox
            // 
            resources.ApplyResources(this.pauseMinimizedCheckBox, "pauseMinimizedCheckBox");
            this.pauseMinimizedCheckBox.Name = "pauseMinimizedCheckBox";
            this.pauseMinimizedCheckBox.UseVisualStyleBackColor = true;
            // 
            // disableBackgroundLoaderCheckBox
            // 
            resources.ApplyResources(this.disableBackgroundLoaderCheckBox, "disableBackgroundLoaderCheckBox");
            this.disableBackgroundLoaderCheckBox.Name = "disableBackgroundLoaderCheckBox";
            this.disableBackgroundLoaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // skipIntroCheckBox
            // 
            resources.ApplyResources(this.skipIntroCheckBox, "skipIntroCheckBox");
            this.skipIntroCheckBox.Name = "skipIntroCheckBox";
            this.skipIntroCheckBox.UseVisualStyleBackColor = true;
            // 
            // disableExceptionHandlingCheckBox
            // 
            resources.ApplyResources(this.disableExceptionHandlingCheckBox, "disableExceptionHandlingCheckBox");
            this.disableExceptionHandlingCheckBox.Name = "disableExceptionHandlingCheckBox";
            this.disableExceptionHandlingCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // cpuCountComboBox
            // 
            resources.ApplyResources(this.cpuCountComboBox, "cpuCountComboBox");
            this.cpuCountComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cpuCountComboBox.FormattingEnabled = true;
            this.cpuCountComboBox.Name = "cpuCountComboBox";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.windowModeCheckBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cursorColourComboBox);
            this.groupBox3.Controls.Add(this.colourDepthComboBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.resolutionComboBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.renderModeComboBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.customResolutionCheckBox);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // windowModeCheckBox
            // 
            resources.ApplyResources(this.windowModeCheckBox, "windowModeCheckBox");
            this.windowModeCheckBox.Name = "windowModeCheckBox";
            this.windowModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // cursorColourComboBox
            // 
            resources.ApplyResources(this.cursorColourComboBox, "cursorColourComboBox");
            this.cursorColourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cursorColourComboBox.FormattingEnabled = true;
            this.cursorColourComboBox.Name = "cursorColourComboBox";
            // 
            // colourDepthComboBox
            // 
            resources.ApplyResources(this.colourDepthComboBox, "colourDepthComboBox");
            this.colourDepthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colourDepthComboBox.FormattingEnabled = true;
            this.colourDepthComboBox.Name = "colourDepthComboBox";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // resolutionComboBox
            // 
            resources.ApplyResources(this.resolutionComboBox, "resolutionComboBox");
            this.resolutionComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.resolutionComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.resolutionComboBox.FormattingEnabled = true;
            this.resolutionComboBox.Items.AddRange(new object[] {
            resources.GetString("resolutionComboBox.Items"),
            resources.GetString("resolutionComboBox.Items1"),
            resources.GetString("resolutionComboBox.Items2")});
            this.resolutionComboBox.Name = "resolutionComboBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // renderModeComboBox
            // 
            resources.ApplyResources(this.renderModeComboBox, "renderModeComboBox");
            this.renderModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderModeComboBox.FormattingEnabled = true;
            this.renderModeComboBox.Name = "renderModeComboBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // customResolutionCheckBox
            // 
            resources.ApplyResources(this.customResolutionCheckBox, "customResolutionCheckBox");
            this.customResolutionCheckBox.Name = "customResolutionCheckBox";
            this.customResolutionCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.disableSoundsCheckBox);
            this.groupBox2.Controls.Add(this.disableMusicCheckBox);
            this.groupBox2.Controls.Add(this.disableAudioCheckBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // disableSoundsCheckBox
            // 
            resources.ApplyResources(this.disableSoundsCheckBox, "disableSoundsCheckBox");
            this.disableSoundsCheckBox.Name = "disableSoundsCheckBox";
            this.disableSoundsCheckBox.UseVisualStyleBackColor = true;
            // 
            // disableMusicCheckBox
            // 
            resources.ApplyResources(this.disableMusicCheckBox, "disableMusicCheckBox");
            this.disableMusicCheckBox.Name = "disableMusicCheckBox";
            this.disableMusicCheckBox.UseVisualStyleBackColor = true;
            // 
            // disableAudioCheckBox
            // 
            resources.ApplyResources(this.disableAudioCheckBox, "disableAudioCheckBox");
            this.disableAudioCheckBox.Name = "disableAudioCheckBox";
            this.disableAudioCheckBox.UseVisualStyleBackColor = true;
            this.disableAudioCheckBox.CheckedChanged += new System.EventHandler(this.DisableAudioCheckBoxCheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.apiBaseUrlTextBox);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.allowCheckMissingDependenciesCheckBox);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // apiBaseUrlTextBox
            // 
            resources.ApplyResources(this.apiBaseUrlTextBox, "apiBaseUrlTextBox");
            this.apiBaseUrlTextBox.Name = "apiBaseUrlTextBox";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // allowCheckMissingDependenciesCheckBox
            // 
            resources.ApplyResources(this.allowCheckMissingDependenciesCheckBox, "allowCheckMissingDependenciesCheckBox");
            this.allowCheckMissingDependenciesCheckBox.Name = "allowCheckMissingDependenciesCheckBox";
            this.allowCheckMissingDependenciesCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.fetchInformationFromRemoteCheckbox);
            this.tabPage5.Controls.Add(this.RemoveNonPluginFilesAfterInstallCheckBox);
            this.tabPage5.Controls.Add(this.AutoRunInstallerExecutablesCheckBox);
            this.tabPage5.Controls.Add(this.AskForAdditionalInfoAfterInstallCheckBox);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // fetchInformationFromRemoteCheckbox
            // 
            resources.ApplyResources(this.fetchInformationFromRemoteCheckbox, "fetchInformationFromRemoteCheckbox");
            this.fetchInformationFromRemoteCheckbox.Checked = true;
            this.fetchInformationFromRemoteCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fetchInformationFromRemoteCheckbox.Name = "fetchInformationFromRemoteCheckbox";
            this.fetchInformationFromRemoteCheckbox.UseVisualStyleBackColor = true;
            // 
            // RemoveNonPluginFilesAfterInstallCheckBox
            // 
            resources.ApplyResources(this.RemoveNonPluginFilesAfterInstallCheckBox, "RemoveNonPluginFilesAfterInstallCheckBox");
            this.RemoveNonPluginFilesAfterInstallCheckBox.Checked = true;
            this.RemoveNonPluginFilesAfterInstallCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RemoveNonPluginFilesAfterInstallCheckBox.Name = "RemoveNonPluginFilesAfterInstallCheckBox";
            this.RemoveNonPluginFilesAfterInstallCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoRunInstallerExecutablesCheckBox
            // 
            resources.ApplyResources(this.AutoRunInstallerExecutablesCheckBox, "AutoRunInstallerExecutablesCheckBox");
            this.AutoRunInstallerExecutablesCheckBox.Name = "AutoRunInstallerExecutablesCheckBox";
            this.AutoRunInstallerExecutablesCheckBox.UseVisualStyleBackColor = true;
            // 
            // AskForAdditionalInfoAfterInstallCheckBox
            // 
            resources.ApplyResources(this.AskForAdditionalInfoAfterInstallCheckBox, "AskForAdditionalInfoAfterInstallCheckBox");
            this.AskForAdditionalInfoAfterInstallCheckBox.Checked = true;
            this.AskForAdditionalInfoAfterInstallCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AskForAdditionalInfoAfterInstallCheckBox.Name = "AskForAdditionalInfoAfterInstallCheckBox";
            this.AskForAdditionalInfoAfterInstallCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameLocationDialog
            // 
            resources.ApplyResources(this.gameLocationDialog, "gameLocationDialog");
            this.gameLocationDialog.ShowNewFolderButton = false;
            // 
            // storeLocationDialog
            // 
            resources.ApplyResources(this.storeLocationDialog, "storeLocationDialog");
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.closeButton);
            this.Name = "SettingsForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFormFormClosing);
            this.Load += new System.EventHandler(this.SettingsFormLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoSaveIntervalTrackBar)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox gameLocationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog gameLocationDialog;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox disableMusicCheckBox;
        private System.Windows.Forms.CheckBox disableAudioCheckBox;
        private System.Windows.Forms.CheckBox disableSoundsCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox customResolutionCheckBox;
        private System.Windows.Forms.ComboBox renderModeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox resolutionComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox colourDepthComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cpuCountComboBox;
        private System.Windows.Forms.CheckBox disableExceptionHandlingCheckBox;
        private System.Windows.Forms.CheckBox skipIntroCheckBox;
        private System.Windows.Forms.CheckBox disableBackgroundLoaderCheckBox;
        private System.Windows.Forms.CheckBox ignoreMissingModelsCheckBox;
        private System.Windows.Forms.ComboBox cursorColourComboBox;
        private System.Windows.Forms.CheckBox writeLogCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox disableIMECheckBox;
        private System.Windows.Forms.CheckBox pauseMinimizedCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView backgroundImageListView;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox allowCheckMissingDependenciesCheckBox;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox RemoveNonPluginFilesAfterInstallCheckBox;
        private System.Windows.Forms.CheckBox AutoRunInstallerExecutablesCheckBox;
        private System.Windows.Forms.CheckBox AskForAdditionalInfoAfterInstallCheckBox;
        private System.Windows.Forms.ComboBox cpuPriorityComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox windowModeCheckBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button browseQuarantinedButton;
        private System.Windows.Forms.TextBox quarantinedFilesLocationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog storeLocationDialog;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label shortAutosaveIntervalsLabel;
        private System.Windows.Forms.Label autoSaveIntervalLabel;
        private System.Windows.Forms.TrackBar autoSaveIntervalTrackBar;
        private System.Windows.Forms.CheckBox enableAutoSaveCheckBox;
        private System.Windows.Forms.CheckBox fetchInformationFromRemoteCheckbox;
        private System.Windows.Forms.TextBox apiBaseUrlTextBox;
        private System.Windows.Forms.Label label9;
    }
}