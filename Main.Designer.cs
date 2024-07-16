using CefSharp.WinForms;
using System.Drawing.Text;
using System.Windows.Forms;

namespace osu_launcher
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var guiFont = FontCollection.Families[1];
            var textFont = FontCollection.Families[0];

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.LAUNCH_BUTTON = new System.Windows.Forms.Button();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.TopTab = new System.Windows.Forms.TabPage();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.CHANGEAUDIO_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.OSUFOLDER_FOLDEROPEN_BUTTON = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SKIN_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.CHANGESKIN_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.OFFSETMASTER_LABEL = new System.Windows.Forms.Label();
            this.OFFSET_TEXTBOX = new System.Windows.Forms.TextBox();
            this.OFFSET_LABEL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AUDIOVALUE_LABEL = new System.Windows.Forms.Label();
            this.EFFECTVALUE_LABEL = new System.Windows.Forms.Label();
            this.MASTERVALUE_LABEL = new System.Windows.Forms.Label();
            this.AUDIO_BAR = new System.Windows.Forms.TrackBar();
            this.AUDIOBAR_LABEL = new System.Windows.Forms.Label();
            this.EFFECT_BAR = new System.Windows.Forms.TrackBar();
            this.EFFECTBAR_LABEL = new System.Windows.Forms.Label();
            this.MASTER_BAR = new System.Windows.Forms.TrackBar();
            this.MASTERBAR_LABEL = new System.Windows.Forms.Label();
            this.AUDIO_LABEL = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.METERSTYLE_LABEL = new System.Windows.Forms.Label();
            this.METERSTYLE_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.METERSCALE_LABEL = new System.Windows.Forms.Label();
            this.METERSCALE_TEXTBOX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SONGSFOLDER_DELETE = new System.Windows.Forms.Button();
            this.FULLSCREEN_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.WIDTH_LABEL = new System.Windows.Forms.Label();
            this.WIDTH_TEXTBOX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.HEIGHT_LABEL = new System.Windows.Forms.Label();
            this.HEIGHT_TEXTBOX = new System.Windows.Forms.TextBox();
            this.OSUFOLDER_TEXTBOX = new System.Windows.Forms.TextBox();
            this.SONGSFOLDER_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.RESOLUTION_LABEL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SONGSFOLDER_LABEL = new System.Windows.Forms.Label();
            this.SONGS_FOLDER_PATH = new System.Windows.Forms.Label();
            this.OSUFOLDER_PATH = new System.Windows.Forms.Label();
            this.OSUFOLDER_LABEL = new System.Windows.Forms.Label();
            this.SERVERS_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.SERVER_LABEL = new System.Windows.Forms.Label();
            this.USERNAME_LABEL = new System.Windows.Forms.Label();
            this.USERNAME_BUTTON = new System.Windows.Forms.Button();
            this.SoftwareTab = new System.Windows.Forms.TabPage();
            this.MainTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AUDIO_BAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFFECT_BAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MASTER_BAR)).BeginInit();
            this.SuspendLayout();
            // 
            // LAUNCH_BUTTON
            // 
            this.LAUNCH_BUTTON.Font = new System.Drawing.Font(guiFont, 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LAUNCH_BUTTON.Location = new System.Drawing.Point(281, 418);
            this.LAUNCH_BUTTON.Name = "LAUNCH_BUTTON";
            this.LAUNCH_BUTTON.Size = new System.Drawing.Size(269, 69);
            this.LAUNCH_BUTTON.TabIndex = 0;
            this.LAUNCH_BUTTON.Text = "LAUNCH";
            this.LAUNCH_BUTTON.UseVisualStyleBackColor = true;
            this.LAUNCH_BUTTON.Click += new System.EventHandler(this.LAUNCH_BUTTON_Click);
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.TopTab);
            this.MainTab.Controls.Add(this.SoftwareTab);
            this.MainTab.Controls.Add(this.SettingsTab);
            this.MainTab.Font = new System.Drawing.Font(guiFont, 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTab.Location = new System.Drawing.Point(12, 12);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(816, 397);
            this.MainTab.TabIndex = 2;
            // 
            // TopTab
            // 
            this.TopTab.Font = new System.Drawing.Font(guiFont, 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopTab.Location = new System.Drawing.Point(4, 40);
            this.TopTab.Name = "TopTab";
            this.TopTab.Padding = new System.Windows.Forms.Padding(3);
            this.TopTab.Size = new System.Drawing.Size(808, 353);
            this.TopTab.TabIndex = 0;
            this.TopTab.Text = "Top";
            this.TopTab.UseVisualStyleBackColor = true;
            // 
            // SettingsTab
            // 
            this.SettingsTab.AutoScroll = true;
            this.SettingsTab.Controls.Add(this.CHANGEAUDIO_CHECKBOX);
            this.SettingsTab.Controls.Add(this.OSUFOLDER_FOLDEROPEN_BUTTON);
            this.SettingsTab.Controls.Add(this.label3);
            this.SettingsTab.Controls.Add(this.SKIN_COMBOBOX);
            this.SettingsTab.Controls.Add(this.CHANGESKIN_CHECKBOX);
            this.SettingsTab.Controls.Add(this.label5);
            this.SettingsTab.Controls.Add(this.label10);
            this.SettingsTab.Controls.Add(this.OFFSETMASTER_LABEL);
            this.SettingsTab.Controls.Add(this.OFFSET_TEXTBOX);
            this.SettingsTab.Controls.Add(this.OFFSET_LABEL);
            this.SettingsTab.Controls.Add(this.label7);
            this.SettingsTab.Controls.Add(this.AUDIOVALUE_LABEL);
            this.SettingsTab.Controls.Add(this.EFFECTVALUE_LABEL);
            this.SettingsTab.Controls.Add(this.MASTERVALUE_LABEL);
            this.SettingsTab.Controls.Add(this.AUDIO_BAR);
            this.SettingsTab.Controls.Add(this.AUDIOBAR_LABEL);
            this.SettingsTab.Controls.Add(this.EFFECT_BAR);
            this.SettingsTab.Controls.Add(this.EFFECTBAR_LABEL);
            this.SettingsTab.Controls.Add(this.MASTER_BAR);
            this.SettingsTab.Controls.Add(this.MASTERBAR_LABEL);
            this.SettingsTab.Controls.Add(this.AUDIO_LABEL);
            this.SettingsTab.Controls.Add(this.label8);
            this.SettingsTab.Controls.Add(this.label2);
            this.SettingsTab.Controls.Add(this.METERSTYLE_LABEL);
            this.SettingsTab.Controls.Add(this.METERSTYLE_COMBOBOX);
            this.SettingsTab.Controls.Add(this.METERSCALE_LABEL);
            this.SettingsTab.Controls.Add(this.METERSCALE_TEXTBOX);
            this.SettingsTab.Controls.Add(this.label4);
            this.SettingsTab.Controls.Add(this.label1);
            this.SettingsTab.Controls.Add(this.SONGSFOLDER_DELETE);
            this.SettingsTab.Controls.Add(this.FULLSCREEN_CHECKBOX);
            this.SettingsTab.Controls.Add(this.WIDTH_LABEL);
            this.SettingsTab.Controls.Add(this.WIDTH_TEXTBOX);
            this.SettingsTab.Controls.Add(this.label9);
            this.SettingsTab.Controls.Add(this.HEIGHT_LABEL);
            this.SettingsTab.Controls.Add(this.HEIGHT_TEXTBOX);
            this.SettingsTab.Controls.Add(this.OSUFOLDER_TEXTBOX);
            this.SettingsTab.Controls.Add(this.SONGSFOLDER_COMBOBOX);
            this.SettingsTab.Controls.Add(this.RESOLUTION_LABEL);
            this.SettingsTab.Controls.Add(this.label6);
            this.SettingsTab.Controls.Add(this.SONGSFOLDER_LABEL);
            this.SettingsTab.Controls.Add(this.SONGS_FOLDER_PATH);
            this.SettingsTab.Controls.Add(this.OSUFOLDER_PATH);
            this.SettingsTab.Controls.Add(this.OSUFOLDER_LABEL);
            this.SettingsTab.Location = new System.Drawing.Point(4, 40);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(808, 353);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            // 
            // CHANGEAUDIO_CHECKBOX
            // 
            this.CHANGEAUDIO_CHECKBOX.AutoSize = true;
            this.CHANGEAUDIO_CHECKBOX.Location = new System.Drawing.Point(34, 588);
            this.CHANGEAUDIO_CHECKBOX.Name = "CHANGEAUDIO_CHECKBOX";
            this.CHANGEAUDIO_CHECKBOX.Size = new System.Drawing.Size(176, 37);
            this.CHANGEAUDIO_CHECKBOX.TabIndex = 75;
            this.CHANGEAUDIO_CHECKBOX.Text = "Change Audio";
            this.CHANGEAUDIO_CHECKBOX.UseVisualStyleBackColor = true;
            this.CHANGEAUDIO_CHECKBOX.CheckedChanged += new System.EventHandler(this.CHANGEAUDIO_CHECKBOX_CheckedChanged);
            // 
            // OSUFOLDER_FOLDEROPEN_BUTTON
            // 
            this.OSUFOLDER_FOLDEROPEN_BUTTON.Font = new System.Drawing.Font(guiFont, 11F);
            this.OSUFOLDER_FOLDEROPEN_BUTTON.Location = new System.Drawing.Point(696, 57);
            this.OSUFOLDER_FOLDEROPEN_BUTTON.Name = "OSUFOLDER_FOLDEROPEN_BUTTON";
            this.OSUFOLDER_FOLDEROPEN_BUTTON.Size = new System.Drawing.Size(75, 32);
            this.OSUFOLDER_FOLDEROPEN_BUTTON.TabIndex = 74;
            this.OSUFOLDER_FOLDEROPEN_BUTTON.Text = "open";
            this.OSUFOLDER_FOLDEROPEN_BUTTON.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(31, 845);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(750, 1);
            this.label3.TabIndex = 73;
            // 
            // SKIN_COMBOBOX
            // 
            this.SKIN_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SKIN_COMBOBOX.Enabled = false;
            this.SKIN_COMBOBOX.Font = new System.Drawing.Font(guiFont, 14F);
            this.SKIN_COMBOBOX.FormattingEnabled = true;
            this.SKIN_COMBOBOX.Location = new System.Drawing.Point(34, 781);
            this.SKIN_COMBOBOX.Name = "SKIN_COMBOBOX";
            this.SKIN_COMBOBOX.Size = new System.Drawing.Size(416, 36);
            this.SKIN_COMBOBOX.TabIndex = 72;
            // 
            // CHANGESKIN_CHECKBOX
            // 
            this.CHANGESKIN_CHECKBOX.AutoSize = true;
            this.CHANGESKIN_CHECKBOX.Location = new System.Drawing.Point(473, 779);
            this.CHANGESKIN_CHECKBOX.Name = "CHANGESKIN_CHECKBOX";
            this.CHANGESKIN_CHECKBOX.Size = new System.Drawing.Size(161, 37);
            this.CHANGESKIN_CHECKBOX.TabIndex = 71;
            this.CHANGESKIN_CHECKBOX.Text = "Change Skin";
            this.CHANGESKIN_CHECKBOX.UseVisualStyleBackColor = true;
            this.CHANGESKIN_CHECKBOX.CheckedChanged += new System.EventHandler(this.CHANGESKIN_CHECKBOX_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font(guiFont, 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 725);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 35);
            this.label5.TabIndex = 69;
            this.label5.Text = "Skin";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(29, 763);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(750, 1);
            this.label10.TabIndex = 68;
            // 
            // OFFSETMASTER_LABEL
            // 
            this.OFFSETMASTER_LABEL.AutoSize = true;
            this.OFFSETMASTER_LABEL.Location = new System.Drawing.Point(30, 681);
            this.OFFSETMASTER_LABEL.Name = "OFFSETMASTER_LABEL";
            this.OFFSETMASTER_LABEL.Size = new System.Drawing.Size(99, 33);
            this.OFFSETMASTER_LABEL.TabIndex = 67;
            this.OFFSETMASTER_LABEL.Text = "MASTER";
            // 
            // OFFSET_TEXTBOX
            // 
            this.OFFSET_TEXTBOX.Font = new System.Drawing.Font(textFont, 14F);
            this.OFFSET_TEXTBOX.Location = new System.Drawing.Point(135, 680);
            this.OFFSET_TEXTBOX.Name = "OFFSET_TEXTBOX";
            this.OFFSET_TEXTBOX.Size = new System.Drawing.Size(115, 35);
            this.OFFSET_TEXTBOX.TabIndex = 66;
            // 
            // OFFSET_LABEL
            // 
            this.OFFSET_LABEL.AutoSize = true;
            this.OFFSET_LABEL.Font = new System.Drawing.Font(guiFont, 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OFFSET_LABEL.Location = new System.Drawing.Point(23, 629);
            this.OFFSET_LABEL.Name = "OFFSET_LABEL";
            this.OFFSET_LABEL.Size = new System.Drawing.Size(81, 35);
            this.OFFSET_LABEL.TabIndex = 65;
            this.OFFSET_LABEL.Text = "Offset";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(29, 667);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(750, 1);
            this.label7.TabIndex = 64;
            // 
            // AUDIOVALUE_LABEL
            // 
            this.AUDIOVALUE_LABEL.AutoSize = true;
            this.AUDIOVALUE_LABEL.Font = new System.Drawing.Font(guiFont, 13F);
            this.AUDIOVALUE_LABEL.Location = new System.Drawing.Point(457, 557);
            this.AUDIOVALUE_LABEL.Name = "AUDIOVALUE_LABEL";
            this.AUDIOVALUE_LABEL.Size = new System.Drawing.Size(37, 26);
            this.AUDIOVALUE_LABEL.TabIndex = 63;
            this.AUDIOVALUE_LABEL.Text = "0%";
            // 
            // EFFECTVALUE_LABEL
            // 
            this.EFFECTVALUE_LABEL.AutoSize = true;
            this.EFFECTVALUE_LABEL.Font = new System.Drawing.Font(guiFont, 13F);
            this.EFFECTVALUE_LABEL.Location = new System.Drawing.Point(456, 528);
            this.EFFECTVALUE_LABEL.Name = "EFFECTVALUE_LABEL";
            this.EFFECTVALUE_LABEL.Size = new System.Drawing.Size(37, 26);
            this.EFFECTVALUE_LABEL.TabIndex = 62;
            this.EFFECTVALUE_LABEL.Text = "0%";
            // 
            // MASTERVALUE_LABEL
            // 
            this.MASTERVALUE_LABEL.AutoSize = true;
            this.MASTERVALUE_LABEL.Font = new System.Drawing.Font(guiFont, 13F);
            this.MASTERVALUE_LABEL.Location = new System.Drawing.Point(456, 498);
            this.MASTERVALUE_LABEL.Name = "MASTERVALUE_LABEL";
            this.MASTERVALUE_LABEL.Size = new System.Drawing.Size(37, 26);
            this.MASTERVALUE_LABEL.TabIndex = 61;
            this.MASTERVALUE_LABEL.Text = "0%";
            // 
            // AUDIO_BAR
            // 
            this.AUDIO_BAR.BackColor = System.Drawing.SystemColors.Control;
            this.AUDIO_BAR.Enabled = false;
            this.AUDIO_BAR.LargeChange = 1;
            this.AUDIO_BAR.Location = new System.Drawing.Point(117, 563);
            this.AUDIO_BAR.Maximum = 100;
            this.AUDIO_BAR.Name = "AUDIO_BAR";
            this.AUDIO_BAR.Size = new System.Drawing.Size(333, 45);
            this.AUDIO_BAR.TabIndex = 60;
            this.AUDIO_BAR.TickFrequency = 25;
            this.AUDIO_BAR.Scroll += new System.EventHandler(this.AUDIO_BAR_Scroll);
            // 
            // AUDIOBAR_LABEL
            // 
            this.AUDIOBAR_LABEL.AutoSize = true;
            this.AUDIOBAR_LABEL.Location = new System.Drawing.Point(28, 552);
            this.AUDIOBAR_LABEL.Name = "AUDIOBAR_LABEL";
            this.AUDIOBAR_LABEL.Size = new System.Drawing.Size(72, 33);
            this.AUDIOBAR_LABEL.TabIndex = 59;
            this.AUDIOBAR_LABEL.Text = "Audio";
            // 
            // EFFECT_BAR
            // 
            this.EFFECT_BAR.BackColor = System.Drawing.SystemColors.Control;
            this.EFFECT_BAR.Enabled = false;
            this.EFFECT_BAR.LargeChange = 1;
            this.EFFECT_BAR.Location = new System.Drawing.Point(117, 533);
            this.EFFECT_BAR.Maximum = 100;
            this.EFFECT_BAR.Name = "EFFECT_BAR";
            this.EFFECT_BAR.Size = new System.Drawing.Size(333, 45);
            this.EFFECT_BAR.TabIndex = 58;
            this.EFFECT_BAR.TickFrequency = 25;
            this.EFFECT_BAR.Scroll += new System.EventHandler(this.EFFECT_BAR_Scroll);
            // 
            // EFFECTBAR_LABEL
            // 
            this.EFFECTBAR_LABEL.AutoSize = true;
            this.EFFECTBAR_LABEL.Location = new System.Drawing.Point(28, 523);
            this.EFFECTBAR_LABEL.Name = "EFFECTBAR_LABEL";
            this.EFFECTBAR_LABEL.Size = new System.Drawing.Size(72, 33);
            this.EFFECTBAR_LABEL.TabIndex = 57;
            this.EFFECTBAR_LABEL.Text = "Effect";
            // 
            // MASTER_BAR
            // 
            this.MASTER_BAR.BackColor = System.Drawing.SystemColors.Control;
            this.MASTER_BAR.Enabled = false;
            this.MASTER_BAR.LargeChange = 1;
            this.MASTER_BAR.Location = new System.Drawing.Point(117, 503);
            this.MASTER_BAR.Maximum = 100;
            this.MASTER_BAR.Name = "MASTER_BAR";
            this.MASTER_BAR.Size = new System.Drawing.Size(333, 45);
            this.MASTER_BAR.TabIndex = 56;
            this.MASTER_BAR.TickFrequency = 25;
            this.MASTER_BAR.Scroll += new System.EventHandler(this.MASTER_BAR_Scroll);
            // 
            // MASTERBAR_LABEL
            // 
            this.MASTERBAR_LABEL.AutoSize = true;
            this.MASTERBAR_LABEL.Location = new System.Drawing.Point(28, 493);
            this.MASTERBAR_LABEL.Name = "MASTERBAR_LABEL";
            this.MASTERBAR_LABEL.Size = new System.Drawing.Size(83, 33);
            this.MASTERBAR_LABEL.TabIndex = 31;
            this.MASTERBAR_LABEL.Text = "Master";
            // 
            // AUDIO_LABEL
            // 
            this.AUDIO_LABEL.AutoSize = true;
            this.AUDIO_LABEL.Font = new System.Drawing.Font(guiFont, 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AUDIO_LABEL.Location = new System.Drawing.Point(23, 438);
            this.AUDIO_LABEL.Name = "AUDIO_LABEL";
            this.AUDIO_LABEL.Size = new System.Drawing.Size(78, 35);
            this.AUDIO_LABEL.TabIndex = 29;
            this.AUDIO_LABEL.Text = "Audio";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(29, 476);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(750, 1);
            this.label8.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(29, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(750, 1);
            this.label2.TabIndex = 27;
            // 
            // METERSTYLE_LABEL
            // 
            this.METERSTYLE_LABEL.AutoSize = true;
            this.METERSTYLE_LABEL.Location = new System.Drawing.Point(248, 390);
            this.METERSTYLE_LABEL.Name = "METERSTYLE_LABEL";
            this.METERSTYLE_LABEL.Size = new System.Drawing.Size(63, 33);
            this.METERSTYLE_LABEL.TabIndex = 26;
            this.METERSTYLE_LABEL.Text = "Style";
            // 
            // METERSTYLE_COMBOBOX
            // 
            this.METERSTYLE_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.METERSTYLE_COMBOBOX.Font = new System.Drawing.Font(guiFont, 14F);
            this.METERSTYLE_COMBOBOX.FormattingEnabled = true;
            this.METERSTYLE_COMBOBOX.Items.AddRange(new object[] {
            "Default",
            "None",
            "Hit error",
            "Colour"});
            this.METERSTYLE_COMBOBOX.Location = new System.Drawing.Point(327, 390);
            this.METERSTYLE_COMBOBOX.Name = "METERSTYLE_COMBOBOX";
            this.METERSTYLE_COMBOBOX.Size = new System.Drawing.Size(174, 36);
            this.METERSTYLE_COMBOBOX.TabIndex = 25;
            // 
            // METERSCALE_LABEL
            // 
            this.METERSCALE_LABEL.AutoSize = true;
            this.METERSCALE_LABEL.Location = new System.Drawing.Point(30, 390);
            this.METERSCALE_LABEL.Name = "METERSCALE_LABEL";
            this.METERSCALE_LABEL.Size = new System.Drawing.Size(68, 33);
            this.METERSCALE_LABEL.TabIndex = 24;
            this.METERSCALE_LABEL.Text = "Scale";
            // 
            // METERSCALE_TEXTBOX
            // 
            this.METERSCALE_TEXTBOX.Font = new System.Drawing.Font(textFont, 14F);
            this.METERSCALE_TEXTBOX.Location = new System.Drawing.Point(109, 389);
            this.METERSCALE_TEXTBOX.Name = "METERSCALE_TEXTBOX";
            this.METERSCALE_TEXTBOX.Size = new System.Drawing.Size(115, 35);
            this.METERSCALE_TEXTBOX.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font(guiFont, 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 35);
            this.label4.TabIndex = 21;
            this.label4.Text = "Score Meter";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(29, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(750, 1);
            this.label1.TabIndex = 20;
            // 
            // SONGSFOLDER_DELETE
            // 
            this.SONGSFOLDER_DELETE.Font = new System.Drawing.Font(guiFont, 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SONGSFOLDER_DELETE.Location = new System.Drawing.Point(696, 154);
            this.SONGSFOLDER_DELETE.Name = "SONGSFOLDER_DELETE";
            this.SONGSFOLDER_DELETE.Size = new System.Drawing.Size(85, 33);
            this.SONGSFOLDER_DELETE.TabIndex = 16;
            this.SONGSFOLDER_DELETE.Text = "delete";
            this.SONGSFOLDER_DELETE.UseVisualStyleBackColor = true;
            this.SONGSFOLDER_DELETE.Click += new System.EventHandler(this.SONGSFOLDER_DELETE_Click);
            // 
            // FULLSCREEN_CHECKBOX
            // 
            this.FULLSCREEN_CHECKBOX.AutoSize = true;
            this.FULLSCREEN_CHECKBOX.Location = new System.Drawing.Point(35, 294);
            this.FULLSCREEN_CHECKBOX.Name = "FULLSCREEN_CHECKBOX";
            this.FULLSCREEN_CHECKBOX.Size = new System.Drawing.Size(134, 37);
            this.FULLSCREEN_CHECKBOX.TabIndex = 14;
            this.FULLSCREEN_CHECKBOX.Text = "Fullscreen";
            this.FULLSCREEN_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // WIDTH_LABEL
            // 
            this.WIDTH_LABEL.AutoSize = true;
            this.WIDTH_LABEL.Location = new System.Drawing.Point(28, 258);
            this.WIDTH_LABEL.Name = "WIDTH_LABEL";
            this.WIDTH_LABEL.Size = new System.Drawing.Size(73, 33);
            this.WIDTH_LABEL.TabIndex = 13;
            this.WIDTH_LABEL.Text = "Width";
            // 
            // WIDTH_TEXTBOX
            // 
            this.WIDTH_TEXTBOX.Font = new System.Drawing.Font(textFont, 14F);
            this.WIDTH_TEXTBOX.Location = new System.Drawing.Point(107, 257);
            this.WIDTH_TEXTBOX.Name = "WIDTH_TEXTBOX";
            this.WIDTH_TEXTBOX.Size = new System.Drawing.Size(115, 35);
            this.WIDTH_TEXTBOX.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(29, 376);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(750, 1);
            this.label9.TabIndex = 11;
            // 
            // HEIGHT_LABEL
            // 
            this.HEIGHT_LABEL.AutoSize = true;
            this.HEIGHT_LABEL.Location = new System.Drawing.Point(248, 258);
            this.HEIGHT_LABEL.Name = "HEIGHT_LABEL";
            this.HEIGHT_LABEL.Size = new System.Drawing.Size(81, 33);
            this.HEIGHT_LABEL.TabIndex = 10;
            this.HEIGHT_LABEL.Text = "Height";
            // 
            // HEIGHT_TEXTBOX
            // 
            this.HEIGHT_TEXTBOX.Font = new System.Drawing.Font(textFont, 14F);
            this.HEIGHT_TEXTBOX.Location = new System.Drawing.Point(335, 257);
            this.HEIGHT_TEXTBOX.Name = "HEIGHT_TEXTBOX";
            this.HEIGHT_TEXTBOX.Size = new System.Drawing.Size(115, 35);
            this.HEIGHT_TEXTBOX.TabIndex = 9;
            // 
            // OSUFOLDER_TEXTBOX
            // 
            this.OSUFOLDER_TEXTBOX.Font = new System.Drawing.Font(textFont, 15.75F);
            this.OSUFOLDER_TEXTBOX.Location = new System.Drawing.Point(93, 52);
            this.OSUFOLDER_TEXTBOX.Name = "OSUFOLDER_TEXTBOX";
            this.OSUFOLDER_TEXTBOX.Size = new System.Drawing.Size(597, 38);
            this.OSUFOLDER_TEXTBOX.TabIndex = 19;
            // 
            // SONGSFOLDER_COMBOBOX
            // 
            this.SONGSFOLDER_COMBOBOX.Font = new System.Drawing.Font(textFont, 15.75F);
            this.SONGSFOLDER_COMBOBOX.FormattingEnabled = true;
            this.SONGSFOLDER_COMBOBOX.Location = new System.Drawing.Point(93, 151);
            this.SONGSFOLDER_COMBOBOX.Name = "SONGSFOLDER_COMBOBOX";
            this.SONGSFOLDER_COMBOBOX.Size = new System.Drawing.Size(597, 38);
            this.SONGSFOLDER_COMBOBOX.TabIndex = 18;
            // 
            // RESOLUTION_LABEL
            // 
            this.RESOLUTION_LABEL.AutoSize = true;
            this.RESOLUTION_LABEL.Font = new System.Drawing.Font(guiFont, 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESOLUTION_LABEL.Location = new System.Drawing.Point(23, 209);
            this.RESOLUTION_LABEL.Name = "RESOLUTION_LABEL";
            this.RESOLUTION_LABEL.Size = new System.Drawing.Size(129, 35);
            this.RESOLUTION_LABEL.TabIndex = 8;
            this.RESOLUTION_LABEL.Text = "Resolution";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(29, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(750, 1);
            this.label6.TabIndex = 7;
            // 
            // SONGSFOLDER_LABEL
            // 
            this.SONGSFOLDER_LABEL.AutoSize = true;
            this.SONGSFOLDER_LABEL.Font = new System.Drawing.Font(guiFont, 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SONGSFOLDER_LABEL.Location = new System.Drawing.Point(23, 104);
            this.SONGSFOLDER_LABEL.Name = "SONGSFOLDER_LABEL";
            this.SONGSFOLDER_LABEL.Size = new System.Drawing.Size(157, 35);
            this.SONGSFOLDER_LABEL.TabIndex = 4;
            this.SONGSFOLDER_LABEL.Text = "Songs Folder";
            // 
            // SONGS_FOLDER_PATH
            // 
            this.SONGS_FOLDER_PATH.AutoSize = true;
            this.SONGS_FOLDER_PATH.Location = new System.Drawing.Point(31, 152);
            this.SONGS_FOLDER_PATH.Name = "SONGS_FOLDER_PATH";
            this.SONGS_FOLDER_PATH.Size = new System.Drawing.Size(60, 33);
            this.SONGS_FOLDER_PATH.TabIndex = 6;
            this.SONGS_FOLDER_PATH.Text = "Path";
            // 
            // OSUFOLDER_PATH
            // 
            this.OSUFOLDER_PATH.AutoSize = true;
            this.OSUFOLDER_PATH.Location = new System.Drawing.Point(31, 53);
            this.OSUFOLDER_PATH.Name = "OSUFOLDER_PATH";
            this.OSUFOLDER_PATH.Size = new System.Drawing.Size(60, 33);
            this.OSUFOLDER_PATH.TabIndex = 2;
            this.OSUFOLDER_PATH.Text = "Path";
            // 
            // OSUFOLDER_LABEL
            // 
            this.OSUFOLDER_LABEL.AutoSize = true;
            this.OSUFOLDER_LABEL.Font = new System.Drawing.Font(guiFont, 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSUFOLDER_LABEL.Location = new System.Drawing.Point(23, 3);
            this.OSUFOLDER_LABEL.Name = "OSUFOLDER_LABEL";
            this.OSUFOLDER_LABEL.Size = new System.Drawing.Size(129, 35);
            this.OSUFOLDER_LABEL.TabIndex = 0;
            this.OSUFOLDER_LABEL.Text = "osu Folder";
            // 
            // SERVERS_COMBOBOX
            // 
            this.SERVERS_COMBOBOX.Font = new System.Drawing.Font(textFont, 15.75F);
            this.SERVERS_COMBOBOX.FormattingEnabled = true;
            this.SERVERS_COMBOBOX.Location = new System.Drawing.Point(41, 442);
            this.SERVERS_COMBOBOX.Name = "SERVERS_COMBOBOX";
            this.SERVERS_COMBOBOX.Size = new System.Drawing.Size(173, 38);
            this.SERVERS_COMBOBOX.TabIndex = 3;
            // 
            // SERVER_LABEL
            // 
            this.SERVER_LABEL.AutoSize = true;
            this.SERVER_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.SERVER_LABEL.Font = new System.Drawing.Font(guiFont, 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SERVER_LABEL.Location = new System.Drawing.Point(86, 408);
            this.SERVER_LABEL.Name = "SERVER_LABEL";
            this.SERVER_LABEL.Size = new System.Drawing.Size(83, 34);
            this.SERVER_LABEL.TabIndex = 4;
            this.SERVER_LABEL.Text = "Server";
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.USERNAME_LABEL.Font = new System.Drawing.Font(guiFont, 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERNAME_LABEL.Location = new System.Drawing.Point(671, 405);
            this.USERNAME_LABEL.Name = "USERNAME_LABEL";
            this.USERNAME_LABEL.Size = new System.Drawing.Size(80, 34);
            this.USERNAME_LABEL.TabIndex = 5;
            this.USERNAME_LABEL.Text = "Profile";
            // 
            // USERNAME_BUTTON
            // 
            this.USERNAME_BUTTON.Font = new System.Drawing.Font(textFont, 15.75F);
            this.USERNAME_BUTTON.Location = new System.Drawing.Point(622, 442);
            this.USERNAME_BUTTON.Name = "USERNAME_BUTTON";
            this.USERNAME_BUTTON.Size = new System.Drawing.Size(173, 38);
            this.USERNAME_BUTTON.TabIndex = 8;
            this.USERNAME_BUTTON.Text = "No Profile";
            this.USERNAME_BUTTON.UseVisualStyleBackColor = true;
            this.USERNAME_BUTTON.Click += new System.EventHandler(this.USERNAME_BUTTON_Click);
            // 
            // SoftwareTab
            // 
            this.SoftwareTab.AutoScroll = true;
            this.SoftwareTab.Location = new System.Drawing.Point(4, 40);
            this.SoftwareTab.Name = "SoftwareTab";
            this.SoftwareTab.Size = new System.Drawing.Size(808, 353);
            this.SoftwareTab.TabIndex = 2;
            this.SoftwareTab.Text = "Softwares";
            this.SoftwareTab.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 499);
            this.Controls.Add(this.USERNAME_BUTTON);
            this.Controls.Add(this.USERNAME_LABEL);
            this.Controls.Add(this.SERVER_LABEL);
            this.Controls.Add(this.SERVERS_COMBOBOX);
            this.Controls.Add(this.MainTab);
            this.Controls.Add(this.LAUNCH_BUTTON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "osu! Launcher";
            this.MainTab.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AUDIO_BAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFFECT_BAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MASTER_BAR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TabPage TopTab;

        #endregion

        private System.Windows.Forms.Button LAUNCH_BUTTON;
        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.ComboBox SERVERS_COMBOBOX;
        private System.Windows.Forms.Label SERVER_LABEL;
        private System.Windows.Forms.Label USERNAME_LABEL;
        private Label OSUFOLDER_LABEL;
        private Label OSUFOLDER_PATH;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label HEIGHT_LABEL;
        private System.Windows.Forms.TextBox HEIGHT_TEXTBOX;
        private System.Windows.Forms.Label RESOLUTION_LABEL;
        private System.Windows.Forms.Label label6;
        private Label SONGS_FOLDER_PATH;
        private Label SONGSFOLDER_LABEL;
        private System.Windows.Forms.CheckBox FULLSCREEN_CHECKBOX;
        private System.Windows.Forms.Label WIDTH_LABEL;
        private System.Windows.Forms.TextBox WIDTH_TEXTBOX;
        private ComboBox SONGSFOLDER_COMBOBOX;
        private Button SONGSFOLDER_DELETE;
        private TextBox OSUFOLDER_TEXTBOX;
        private Label label1;
        private Button USERNAME_BUTTON;
        private System.Windows.Forms.Label METERSCALE_LABEL;
        private System.Windows.Forms.TextBox METERSCALE_TEXTBOX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label METERSTYLE_LABEL;
        private System.Windows.Forms.ComboBox METERSTYLE_COMBOBOX;
        private Label MASTERBAR_LABEL;
        private Label AUDIO_LABEL;
        private Label label8;
        private Label label2;
        private TrackBar EFFECT_BAR;
        private Label EFFECTBAR_LABEL;
        private TrackBar MASTER_BAR;
        private Label AUDIOVALUE_LABEL;
        private Label EFFECTVALUE_LABEL;
        private Label MASTERVALUE_LABEL;
        private TrackBar AUDIO_BAR;
        private Label AUDIOBAR_LABEL;
        private Label OFFSETMASTER_LABEL;
        private TextBox OFFSET_TEXTBOX;
        private Label OFFSET_LABEL;
        private Label label7;
        private CheckBox CHANGESKIN_CHECKBOX;
        private Label label5;
        private Label label10;
        private ComboBox SKIN_COMBOBOX;
        private Label label3;
        private Button OSUFOLDER_FOLDEROPEN_BUTTON;
        private CheckBox CHANGEAUDIO_CHECKBOX;
        private TabPage SoftwareTab;
    }
}

