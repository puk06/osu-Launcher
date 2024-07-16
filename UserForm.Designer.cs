using System.Drawing.Text;
using System.Windows.Forms;

namespace osu_launcher
{
    partial class ProfileForm
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
            var guiFont = _mainForm.FontCollection.Families[1];
            var textFont = _mainForm.FontCollection.Families[0];

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.UsersTab = new System.Windows.Forms.TabPage();
            this.SELECTUSER_LABEL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResisterTab = new System.Windows.Forms.TabPage();
            this.CHANGESKIN_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.SKIN_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.SKIN_LABE = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CHANGEAUDIO_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.OFFSET_TEXTBOX = new System.Windows.Forms.TextBox();
            this.OFFSET_LABEL = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.OFFSETMASTER_LABEL = new System.Windows.Forms.Label();
            this.MUSIC_BAR = new System.Windows.Forms.TrackBar();
            this.MUSIC_LABEL = new System.Windows.Forms.Label();
            this.EFFECT_BAR = new System.Windows.Forms.TrackBar();
            this.EFFECT_LABEL = new System.Windows.Forms.Label();
            this.MASTER_BAR = new System.Windows.Forms.TrackBar();
            this.AUDIO_LABEL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MASTER_LABEL = new System.Windows.Forms.Label();
            this.FULLSCREEN_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.METERSTYLE_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.METERSTYLE_LABEL = new System.Windows.Forms.Label();
            this.HEIGHT_LABEL = new System.Windows.Forms.Label();
            this.HEIGHT_TEXTBOX = new System.Windows.Forms.TextBox();
            this.RESOLUTION_LABEL = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.WIDTH_LABEL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SCOREMETER_TEXTBOX = new System.Windows.Forms.TextBox();
            this.SCOREMETER_LABEL = new System.Windows.Forms.Label();
            this.WIDTH_TEXTBOX = new System.Windows.Forms.TextBox();
            this.NAME_TEXTBOX = new System.Windows.Forms.TextBox();
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RESET_BUTTON = new System.Windows.Forms.Button();
            this.CREATE_BUTTON = new System.Windows.Forms.Button();
            this.CONFIRM_TEXTBOX = new System.Windows.Forms.TextBox();
            this.CONFIRM_LABEL = new System.Windows.Forms.Label();
            this.PASSWORD_TEXTBOX = new System.Windows.Forms.TextBox();
            this.PASSWORD_LABEL = new System.Windows.Forms.Label();
            this.USERNAME_TEXTBOX = new System.Windows.Forms.TextBox();
            this.USERNAME_LABEL = new System.Windows.Forms.Label();
            this.NEWUSER_LABEL = new System.Windows.Forms.Label();
            this.USERFORM_LABEL = new System.Windows.Forms.Label();
            this.MainTab.SuspendLayout();
            this.UsersTab.SuspendLayout();
            this.ResisterTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MUSIC_BAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFFECT_BAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MASTER_BAR)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.UsersTab);
            this.MainTab.Controls.Add(this.ResisterTab);
            this.MainTab.Font = new System.Drawing.Font(guiFont, 9F);
            this.MainTab.Location = new System.Drawing.Point(12, 54);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(291, 384);
            this.MainTab.TabIndex = 0;
            // 
            // UsersTab
            // 
            this.UsersTab.AutoScroll = true;
            this.UsersTab.Controls.Add(this.SELECTUSER_LABEL);
            this.UsersTab.Controls.Add(this.label3);
            this.UsersTab.Font = new System.Drawing.Font(guiFont, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersTab.Location = new System.Drawing.Point(4, 27);
            this.UsersTab.Name = "UsersTab";
            this.UsersTab.Padding = new System.Windows.Forms.Padding(3);
            this.UsersTab.Size = new System.Drawing.Size(283, 353);
            this.UsersTab.TabIndex = 0;
            this.UsersTab.Text = "Profiles";
            // 
            // SELECTUSER_LABEL
            // 
            this.SELECTUSER_LABEL.AutoSize = true;
            this.SELECTUSER_LABEL.Font = new System.Drawing.Font(guiFont, 16F);
            this.SELECTUSER_LABEL.Location = new System.Drawing.Point(7, 0);
            this.SELECTUSER_LABEL.Name = "SELECTUSER_LABEL";
            this.SELECTUSER_LABEL.Size = new System.Drawing.Size(143, 33);
            this.SELECTUSER_LABEL.TabIndex = 31;
            this.SELECTUSER_LABEL.Text = "Select Profile";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(14, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 1);
            this.label3.TabIndex = 21;
            // 
            // ResisterTab
            // 
            this.ResisterTab.AutoScroll = true;
            this.ResisterTab.Controls.Add(this.CHANGESKIN_CHECKBOX);
            this.ResisterTab.Controls.Add(this.SKIN_COMBOBOX);
            this.ResisterTab.Controls.Add(this.SKIN_LABE);
            this.ResisterTab.Controls.Add(this.label4);
            this.ResisterTab.Controls.Add(this.CHANGEAUDIO_CHECKBOX);
            this.ResisterTab.Controls.Add(this.OFFSET_TEXTBOX);
            this.ResisterTab.Controls.Add(this.OFFSET_LABEL);
            this.ResisterTab.Controls.Add(this.label11);
            this.ResisterTab.Controls.Add(this.OFFSETMASTER_LABEL);
            this.ResisterTab.Controls.Add(this.MUSIC_BAR);
            this.ResisterTab.Controls.Add(this.MUSIC_LABEL);
            this.ResisterTab.Controls.Add(this.EFFECT_BAR);
            this.ResisterTab.Controls.Add(this.EFFECT_LABEL);
            this.ResisterTab.Controls.Add(this.MASTER_BAR);
            this.ResisterTab.Controls.Add(this.AUDIO_LABEL);
            this.ResisterTab.Controls.Add(this.label5);
            this.ResisterTab.Controls.Add(this.MASTER_LABEL);
            this.ResisterTab.Controls.Add(this.FULLSCREEN_CHECKBOX);
            this.ResisterTab.Controls.Add(this.METERSTYLE_COMBOBOX);
            this.ResisterTab.Controls.Add(this.METERSTYLE_LABEL);
            this.ResisterTab.Controls.Add(this.HEIGHT_LABEL);
            this.ResisterTab.Controls.Add(this.HEIGHT_TEXTBOX);
            this.ResisterTab.Controls.Add(this.RESOLUTION_LABEL);
            this.ResisterTab.Controls.Add(this.label9);
            this.ResisterTab.Controls.Add(this.WIDTH_LABEL);
            this.ResisterTab.Controls.Add(this.label7);
            this.ResisterTab.Controls.Add(this.label6);
            this.ResisterTab.Controls.Add(this.SCOREMETER_TEXTBOX);
            this.ResisterTab.Controls.Add(this.SCOREMETER_LABEL);
            this.ResisterTab.Controls.Add(this.WIDTH_TEXTBOX);
            this.ResisterTab.Controls.Add(this.NAME_TEXTBOX);
            this.ResisterTab.Controls.Add(this.NAME_LABEL);
            this.ResisterTab.Controls.Add(this.label1);
            this.ResisterTab.Controls.Add(this.RESET_BUTTON);
            this.ResisterTab.Controls.Add(this.CREATE_BUTTON);
            this.ResisterTab.Controls.Add(this.CONFIRM_TEXTBOX);
            this.ResisterTab.Controls.Add(this.CONFIRM_LABEL);
            this.ResisterTab.Controls.Add(this.PASSWORD_TEXTBOX);
            this.ResisterTab.Controls.Add(this.PASSWORD_LABEL);
            this.ResisterTab.Controls.Add(this.USERNAME_TEXTBOX);
            this.ResisterTab.Controls.Add(this.USERNAME_LABEL);
            this.ResisterTab.Controls.Add(this.NEWUSER_LABEL);
            this.ResisterTab.Font = new System.Drawing.Font(guiFont, 9F);
            this.ResisterTab.Location = new System.Drawing.Point(4, 27);
            this.ResisterTab.Name = "ResisterTab";
            this.ResisterTab.Padding = new System.Windows.Forms.Padding(3);
            this.ResisterTab.Size = new System.Drawing.Size(283, 353);
            this.ResisterTab.TabIndex = 1;
            this.ResisterTab.Text = "Create Profile";
            // 
            // CHANGESKIN_CHECKBOX
            // 
            this.CHANGESKIN_CHECKBOX.AutoSize = true;
            this.CHANGESKIN_CHECKBOX.Font = new System.Drawing.Font(guiFont, 12F);
            this.CHANGESKIN_CHECKBOX.Location = new System.Drawing.Point(15, 739);
            this.CHANGESKIN_CHECKBOX.Name = "CHANGESKIN_CHECKBOX";
            this.CHANGESKIN_CHECKBOX.Size = new System.Drawing.Size(120, 28);
            this.CHANGESKIN_CHECKBOX.TabIndex = 71;
            this.CHANGESKIN_CHECKBOX.Text = "Change Skin";
            this.CHANGESKIN_CHECKBOX.UseVisualStyleBackColor = true;
            this.CHANGESKIN_CHECKBOX.CheckedChanged += new System.EventHandler(this.CHANGESKIN_CHECKBOX_CheckedChanged);
            // 
            // SKIN_COMBOBOX
            // 
            this.SKIN_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SKIN_COMBOBOX.Enabled = false;
            this.SKIN_COMBOBOX.FormattingEnabled = true;
            this.SKIN_COMBOBOX.Location = new System.Drawing.Point(15, 707);
            this.SKIN_COMBOBOX.Name = "SKIN_COMBOBOX";
            this.SKIN_COMBOBOX.Size = new System.Drawing.Size(242, 26);
            this.SKIN_COMBOBOX.TabIndex = 70;
            // 
            // SKIN_LABE
            // 
            this.SKIN_LABE.AutoSize = true;
            this.SKIN_LABE.Font = new System.Drawing.Font(guiFont, 16F);
            this.SKIN_LABE.Location = new System.Drawing.Point(9, 668);
            this.SKIN_LABE.Name = "SKIN_LABE";
            this.SKIN_LABE.Size = new System.Drawing.Size(57, 33);
            this.SKIN_LABE.TabIndex = 68;
            this.SKIN_LABE.Text = "Skin";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(8, 701);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 1);
            this.label4.TabIndex = 67;
            // 
            // CHANGEAUDIO_CHECKBOX
            // 
            this.CHANGEAUDIO_CHECKBOX.AutoSize = true;
            this.CHANGEAUDIO_CHECKBOX.Font = new System.Drawing.Font(guiFont, 12F);
            this.CHANGEAUDIO_CHECKBOX.Location = new System.Drawing.Point(15, 568);
            this.CHANGEAUDIO_CHECKBOX.Name = "CHANGEAUDIO_CHECKBOX";
            this.CHANGEAUDIO_CHECKBOX.Size = new System.Drawing.Size(133, 28);
            this.CHANGEAUDIO_CHECKBOX.TabIndex = 65;
            this.CHANGEAUDIO_CHECKBOX.Text = "Change Audio";
            this.CHANGEAUDIO_CHECKBOX.UseVisualStyleBackColor = true;
            this.CHANGEAUDIO_CHECKBOX.CheckedChanged += new System.EventHandler(this.CHANGEAUDIO_CHECKBOX_CheckedChanged);
            // 
            // OFFSET_TEXTBOX
            // 
            this.OFFSET_TEXTBOX.Location = new System.Drawing.Point(100, 640);
            this.OFFSET_TEXTBOX.Name = "OFFSET_TEXTBOX";
            this.OFFSET_TEXTBOX.Size = new System.Drawing.Size(158, 22);
            this.OFFSET_TEXTBOX.TabIndex = 64;
            // 
            // OFFSET_LABEL
            // 
            this.OFFSET_LABEL.AutoSize = true;
            this.OFFSET_LABEL.Font = new System.Drawing.Font(guiFont, 16F);
            this.OFFSET_LABEL.Location = new System.Drawing.Point(9, 597);
            this.OFFSET_LABEL.Name = "OFFSET_LABEL";
            this.OFFSET_LABEL.Size = new System.Drawing.Size(76, 33);
            this.OFFSET_LABEL.TabIndex = 62;
            this.OFFSET_LABEL.Text = "Offset";
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(8, 630);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(250, 1);
            this.label11.TabIndex = 61;
            // 
            // OFFSETMASTER_LABEL
            // 
            this.OFFSETMASTER_LABEL.AutoSize = true;
            this.OFFSETMASTER_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.OFFSETMASTER_LABEL.Location = new System.Drawing.Point(10, 638);
            this.OFFSETMASTER_LABEL.Name = "OFFSETMASTER_LABEL";
            this.OFFSETMASTER_LABEL.Size = new System.Drawing.Size(60, 24);
            this.OFFSETMASTER_LABEL.TabIndex = 60;
            this.OFFSETMASTER_LABEL.Text = "Master";
            // 
            // MUSIC_BAR
            // 
            this.MUSIC_BAR.BackColor = System.Drawing.SystemColors.Control;
            this.MUSIC_BAR.Enabled = false;
            this.MUSIC_BAR.LargeChange = 1;
            this.MUSIC_BAR.Location = new System.Drawing.Point(100, 540);
            this.MUSIC_BAR.Maximum = 100;
            this.MUSIC_BAR.Name = "MUSIC_BAR";
            this.MUSIC_BAR.Size = new System.Drawing.Size(157, 45);
            this.MUSIC_BAR.TabIndex = 59;
            this.MUSIC_BAR.TickFrequency = 50;
            this.MUSIC_BAR.Scroll += new System.EventHandler(this.MUSIC_BAR_Scroll);
            // 
            // MUSIC_LABEL
            // 
            this.MUSIC_LABEL.AutoSize = true;
            this.MUSIC_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.MUSIC_LABEL.Location = new System.Drawing.Point(9, 540);
            this.MUSIC_LABEL.Name = "MUSIC_LABEL";
            this.MUSIC_LABEL.Size = new System.Drawing.Size(50, 24);
            this.MUSIC_LABEL.TabIndex = 58;
            this.MUSIC_LABEL.Text = "Music";
            // 
            // EFFECT_BAR
            // 
            this.EFFECT_BAR.BackColor = System.Drawing.SystemColors.Control;
            this.EFFECT_BAR.Enabled = false;
            this.EFFECT_BAR.LargeChange = 1;
            this.EFFECT_BAR.Location = new System.Drawing.Point(100, 509);
            this.EFFECT_BAR.Maximum = 100;
            this.EFFECT_BAR.Name = "EFFECT_BAR";
            this.EFFECT_BAR.Size = new System.Drawing.Size(157, 45);
            this.EFFECT_BAR.TabIndex = 57;
            this.EFFECT_BAR.TickFrequency = 50;
            this.EFFECT_BAR.Scroll += new System.EventHandler(this.EFFECT_BAR_Scroll);
            // 
            // EFFECT_LABEL
            // 
            this.EFFECT_LABEL.AutoSize = true;
            this.EFFECT_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.EFFECT_LABEL.Location = new System.Drawing.Point(9, 509);
            this.EFFECT_LABEL.Name = "EFFECT_LABEL";
            this.EFFECT_LABEL.Size = new System.Drawing.Size(52, 24);
            this.EFFECT_LABEL.TabIndex = 56;
            this.EFFECT_LABEL.Text = "Effect";
            // 
            // MASTER_BAR
            // 
            this.MASTER_BAR.BackColor = System.Drawing.SystemColors.Control;
            this.MASTER_BAR.Enabled = false;
            this.MASTER_BAR.LargeChange = 1;
            this.MASTER_BAR.Location = new System.Drawing.Point(100, 478);
            this.MASTER_BAR.Maximum = 100;
            this.MASTER_BAR.Name = "MASTER_BAR";
            this.MASTER_BAR.Size = new System.Drawing.Size(157, 45);
            this.MASTER_BAR.TabIndex = 55;
            this.MASTER_BAR.TickFrequency = 50;
            this.MASTER_BAR.Scroll += new System.EventHandler(this.MASTER_BAR_Scroll);
            // 
            // AUDIO_LABEL
            // 
            this.AUDIO_LABEL.AutoSize = true;
            this.AUDIO_LABEL.Font = new System.Drawing.Font(guiFont, 16F);
            this.AUDIO_LABEL.Location = new System.Drawing.Point(8, 437);
            this.AUDIO_LABEL.Name = "AUDIO_LABEL";
            this.AUDIO_LABEL.Size = new System.Drawing.Size(72, 33);
            this.AUDIO_LABEL.TabIndex = 51;
            this.AUDIO_LABEL.Text = "Audio";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(7, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 1);
            this.label5.TabIndex = 50;
            // 
            // MASTER_LABEL
            // 
            this.MASTER_LABEL.AutoSize = true;
            this.MASTER_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.MASTER_LABEL.Location = new System.Drawing.Point(9, 478);
            this.MASTER_LABEL.Name = "MASTER_LABEL";
            this.MASTER_LABEL.Size = new System.Drawing.Size(60, 24);
            this.MASTER_LABEL.TabIndex = 49;
            this.MASTER_LABEL.Text = "Master";
            // 
            // FULLSCREEN_CHECKBOX
            // 
            this.FULLSCREEN_CHECKBOX.AutoSize = true;
            this.FULLSCREEN_CHECKBOX.Font = new System.Drawing.Font(guiFont, 12F);
            this.FULLSCREEN_CHECKBOX.Location = new System.Drawing.Point(12, 408);
            this.FULLSCREEN_CHECKBOX.Name = "FULLSCREEN_CHECKBOX";
            this.FULLSCREEN_CHECKBOX.Size = new System.Drawing.Size(101, 28);
            this.FULLSCREEN_CHECKBOX.TabIndex = 47;
            this.FULLSCREEN_CHECKBOX.Text = "Fullscreen";
            this.FULLSCREEN_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // METERSTYLE_COMBOBOX
            // 
            this.METERSTYLE_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.METERSTYLE_COMBOBOX.Font = new System.Drawing.Font(guiFont, 9F);
            this.METERSTYLE_COMBOBOX.FormattingEnabled = true;
            this.METERSTYLE_COMBOBOX.Items.AddRange(new object[] {
            "Default",
            "None",
            "Hit error",
            "Colour"});
            this.METERSTYLE_COMBOBOX.Location = new System.Drawing.Point(104, 269);
            this.METERSTYLE_COMBOBOX.Name = "METERSTYLE_COMBOBOX";
            this.METERSTYLE_COMBOBOX.Size = new System.Drawing.Size(159, 26);
            this.METERSTYLE_COMBOBOX.TabIndex = 46;
            // 
            // METERSTYLE_LABEL
            // 
            this.METERSTYLE_LABEL.AutoSize = true;
            this.METERSTYLE_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.METERSTYLE_LABEL.Location = new System.Drawing.Point(11, 267);
            this.METERSTYLE_LABEL.Name = "METERSTYLE_LABEL";
            this.METERSTYLE_LABEL.Size = new System.Drawing.Size(87, 24);
            this.METERSTYLE_LABEL.TabIndex = 44;
            this.METERSTYLE_LABEL.Text = "MeterStyle";
            // 
            // HEIGHT_LABEL
            // 
            this.HEIGHT_LABEL.AutoSize = true;
            this.HEIGHT_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.HEIGHT_LABEL.Location = new System.Drawing.Point(10, 379);
            this.HEIGHT_LABEL.Name = "HEIGHT_LABEL";
            this.HEIGHT_LABEL.Size = new System.Drawing.Size(58, 24);
            this.HEIGHT_LABEL.TabIndex = 43;
            this.HEIGHT_LABEL.Text = "Height";
            // 
            // HEIGHT_TEXTBOX
            // 
            this.HEIGHT_TEXTBOX.Font = new System.Drawing.Font(textFont, 9F);
            this.HEIGHT_TEXTBOX.Location = new System.Drawing.Point(100, 381);
            this.HEIGHT_TEXTBOX.Name = "HEIGHT_TEXTBOX";
            this.HEIGHT_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.HEIGHT_TEXTBOX.TabIndex = 42;
            // 
            // RESOLUTION_LABEL
            // 
            this.RESOLUTION_LABEL.AutoSize = true;
            this.RESOLUTION_LABEL.Font = new System.Drawing.Font(guiFont, 16F);
            this.RESOLUTION_LABEL.Location = new System.Drawing.Point(9, 301);
            this.RESOLUTION_LABEL.Name = "RESOLUTION_LABEL";
            this.RESOLUTION_LABEL.Size = new System.Drawing.Size(120, 33);
            this.RESOLUTION_LABEL.TabIndex = 41;
            this.RESOLUTION_LABEL.Text = "Resolution";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(8, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 1);
            this.label9.TabIndex = 40;
            // 
            // WIDTH_LABEL
            // 
            this.WIDTH_LABEL.AutoSize = true;
            this.WIDTH_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.WIDTH_LABEL.Location = new System.Drawing.Point(10, 342);
            this.WIDTH_LABEL.Name = "WIDTH_LABEL";
            this.WIDTH_LABEL.Size = new System.Drawing.Size(53, 24);
            this.WIDTH_LABEL.TabIndex = 39;
            this.WIDTH_LABEL.Text = "Width";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font(guiFont, 16F);
            this.label7.Location = new System.Drawing.Point(9, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 33);
            this.label7.TabIndex = 38;
            this.label7.Text = "Option";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(14, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 1);
            this.label6.TabIndex = 37;
            // 
            // SCOREMETER_TEXTBOX
            // 
            this.SCOREMETER_TEXTBOX.Font = new System.Drawing.Font(textFont, 9F);
            this.SCOREMETER_TEXTBOX.Location = new System.Drawing.Point(104, 232);
            this.SCOREMETER_TEXTBOX.Name = "SCOREMETER_TEXTBOX";
            this.SCOREMETER_TEXTBOX.Size = new System.Drawing.Size(159, 25);
            this.SCOREMETER_TEXTBOX.TabIndex = 36;
            // 
            // SCOREMETER_LABEL
            // 
            this.SCOREMETER_LABEL.AutoSize = true;
            this.SCOREMETER_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.SCOREMETER_LABEL.Location = new System.Drawing.Point(10, 230);
            this.SCOREMETER_LABEL.Name = "SCOREMETER_LABEL";
            this.SCOREMETER_LABEL.Size = new System.Drawing.Size(94, 24);
            this.SCOREMETER_LABEL.TabIndex = 35;
            this.SCOREMETER_LABEL.Text = "ScoreMeter";
            // 
            // WIDTH_TEXTBOX
            // 
            this.WIDTH_TEXTBOX.Font = new System.Drawing.Font(textFont, 9F);
            this.WIDTH_TEXTBOX.Location = new System.Drawing.Point(100, 344);
            this.WIDTH_TEXTBOX.Name = "WIDTH_TEXTBOX";
            this.WIDTH_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.WIDTH_TEXTBOX.TabIndex = 34;
            // 
            // NAME_TEXTBOX
            // 
            this.NAME_TEXTBOX.Font = new System.Drawing.Font(textFont, 9F);
            this.NAME_TEXTBOX.Location = new System.Drawing.Point(104, 45);
            this.NAME_TEXTBOX.Name = "NAME_TEXTBOX";
            this.NAME_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.NAME_TEXTBOX.TabIndex = 32;
            // 
            // NAME_LABEL
            // 
            this.NAME_LABEL.AutoSize = true;
            this.NAME_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.NAME_LABEL.Location = new System.Drawing.Point(11, 43);
            this.NAME_LABEL.Name = "NAME_LABEL";
            this.NAME_LABEL.Size = new System.Drawing.Size(56, 24);
            this.NAME_LABEL.TabIndex = 31;
            this.NAME_LABEL.Text = "Name";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 1);
            this.label1.TabIndex = 30;
            // 
            // RESET_BUTTON
            // 
            this.RESET_BUTTON.Font = new System.Drawing.Font(guiFont, 11F);
            this.RESET_BUTTON.Location = new System.Drawing.Point(155, 789);
            this.RESET_BUTTON.Name = "RESET_BUTTON";
            this.RESET_BUTTON.Size = new System.Drawing.Size(102, 34);
            this.RESET_BUTTON.TabIndex = 29;
            this.RESET_BUTTON.Text = "Reset";
            this.RESET_BUTTON.UseVisualStyleBackColor = true;
            this.RESET_BUTTON.Click += new System.EventHandler(this.RESET_BUTTON_Click);
            // 
            // CREATE_BUTTON
            // 
            this.CREATE_BUTTON.Font = new System.Drawing.Font(guiFont, 11F);
            this.CREATE_BUTTON.Location = new System.Drawing.Point(12, 789);
            this.CREATE_BUTTON.Name = "CREATE_BUTTON";
            this.CREATE_BUTTON.Size = new System.Drawing.Size(105, 34);
            this.CREATE_BUTTON.TabIndex = 28;
            this.CREATE_BUTTON.Text = "Create";
            this.CREATE_BUTTON.UseVisualStyleBackColor = true;
            this.CREATE_BUTTON.Click += new System.EventHandler(this.CREATE_BUTTON_Click);
            // 
            // CONFIRM_TEXTBOX
            // 
            this.CONFIRM_TEXTBOX.Font = new System.Drawing.Font(textFont, 9F);
            this.CONFIRM_TEXTBOX.Location = new System.Drawing.Point(104, 156);
            this.CONFIRM_TEXTBOX.Name = "CONFIRM_TEXTBOX";
            this.CONFIRM_TEXTBOX.PasswordChar = '*';
            this.CONFIRM_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.CONFIRM_TEXTBOX.TabIndex = 27;
            // 
            // CONFIRM_LABEL
            // 
            this.CONFIRM_LABEL.AutoSize = true;
            this.CONFIRM_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.CONFIRM_LABEL.Location = new System.Drawing.Point(11, 154);
            this.CONFIRM_LABEL.Name = "CONFIRM_LABEL";
            this.CONFIRM_LABEL.Size = new System.Drawing.Size(70, 24);
            this.CONFIRM_LABEL.TabIndex = 26;
            this.CONFIRM_LABEL.Text = "Confirm";
            // 
            // PASSWORD_TEXTBOX
            // 
            this.PASSWORD_TEXTBOX.Font = new System.Drawing.Font(textFont, 9F);
            this.PASSWORD_TEXTBOX.Location = new System.Drawing.Point(104, 119);
            this.PASSWORD_TEXTBOX.Name = "PASSWORD_TEXTBOX";
            this.PASSWORD_TEXTBOX.PasswordChar = '*';
            this.PASSWORD_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.PASSWORD_TEXTBOX.TabIndex = 25;
            // 
            // PASSWORD_LABEL
            // 
            this.PASSWORD_LABEL.AutoSize = true;
            this.PASSWORD_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.PASSWORD_LABEL.Location = new System.Drawing.Point(11, 117);
            this.PASSWORD_LABEL.Name = "PASSWORD_LABEL";
            this.PASSWORD_LABEL.Size = new System.Drawing.Size(82, 24);
            this.PASSWORD_LABEL.TabIndex = 24;
            this.PASSWORD_LABEL.Text = "Password";
            // 
            // USERNAME_TEXTBOX
            // 
            this.USERNAME_TEXTBOX.Font = new System.Drawing.Font(textFont, 9F);
            this.USERNAME_TEXTBOX.Location = new System.Drawing.Point(104, 82);
            this.USERNAME_TEXTBOX.Name = "USERNAME_TEXTBOX";
            this.USERNAME_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.USERNAME_TEXTBOX.TabIndex = 23;
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.Font = new System.Drawing.Font(guiFont, 12F);
            this.USERNAME_LABEL.Location = new System.Drawing.Point(11, 80);
            this.USERNAME_LABEL.Name = "USERNAME_LABEL";
            this.USERNAME_LABEL.Size = new System.Drawing.Size(86, 24);
            this.USERNAME_LABEL.TabIndex = 22;
            this.USERNAME_LABEL.Text = "Username";
            // 
            // NEWUSER_LABEL
            // 
            this.NEWUSER_LABEL.AutoSize = true;
            this.NEWUSER_LABEL.Font = new System.Drawing.Font(guiFont, 16F);
            this.NEWUSER_LABEL.Location = new System.Drawing.Point(7, 0);
            this.NEWUSER_LABEL.Name = "NEWUSER_LABEL";
            this.NEWUSER_LABEL.Size = new System.Drawing.Size(128, 33);
            this.NEWUSER_LABEL.TabIndex = 0;
            this.NEWUSER_LABEL.Text = "New Profile";
            // 
            // USERFORM_LABEL
            // 
            this.USERFORM_LABEL.AutoSize = true;
            this.USERFORM_LABEL.Font = new System.Drawing.Font(guiFont, 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERFORM_LABEL.Location = new System.Drawing.Point(10, 9);
            this.USERFORM_LABEL.Name = "USERFORM_LABEL";
            this.USERFORM_LABEL.Size = new System.Drawing.Size(239, 31);
            this.USERFORM_LABEL.TabIndex = 1;
            this.USERFORM_LABEL.Text = "Select or Create Profile";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 450);
            this.Controls.Add(this.USERFORM_LABEL);
            this.Controls.Add(this.MainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.MainTab.ResumeLayout(false);
            this.UsersTab.ResumeLayout(false);
            this.UsersTab.PerformLayout();
            this.ResisterTab.ResumeLayout(false);
            this.ResisterTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MUSIC_BAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EFFECT_BAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MASTER_BAR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage UsersTab;
        private System.Windows.Forms.TabPage ResisterTab;
        private System.Windows.Forms.Label USERFORM_LABEL;
        private System.Windows.Forms.Label NEWUSER_LABEL;
        private System.Windows.Forms.Button RESET_BUTTON;
        private System.Windows.Forms.Button CREATE_BUTTON;
        private System.Windows.Forms.TextBox CONFIRM_TEXTBOX;
        private System.Windows.Forms.Label CONFIRM_LABEL;
        private System.Windows.Forms.TextBox PASSWORD_TEXTBOX;
        private System.Windows.Forms.Label PASSWORD_LABEL;
        private System.Windows.Forms.TextBox USERNAME_TEXTBOX;
        private System.Windows.Forms.Label USERNAME_LABEL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SELECTUSER_LABEL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SCOREMETER_TEXTBOX;
        private System.Windows.Forms.Label SCOREMETER_LABEL;
        private System.Windows.Forms.TextBox WIDTH_TEXTBOX;
        private System.Windows.Forms.TextBox NAME_TEXTBOX;
        private System.Windows.Forms.Label NAME_LABEL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label WIDTH_LABEL;
        private System.Windows.Forms.Label HEIGHT_LABEL;
        private System.Windows.Forms.TextBox HEIGHT_TEXTBOX;
        private System.Windows.Forms.Label RESOLUTION_LABEL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox METERSTYLE_COMBOBOX;
        private System.Windows.Forms.Label METERSTYLE_LABEL;
        private System.Windows.Forms.CheckBox FULLSCREEN_CHECKBOX;
        private System.Windows.Forms.Label AUDIO_LABEL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label MASTER_LABEL;
        private System.Windows.Forms.TrackBar MASTER_BAR;
        private System.Windows.Forms.TrackBar EFFECT_BAR;
        private System.Windows.Forms.Label EFFECT_LABEL;
        private System.Windows.Forms.TrackBar MUSIC_BAR;
        private System.Windows.Forms.Label MUSIC_LABEL;
        private System.Windows.Forms.TextBox OFFSET_TEXTBOX;
        private System.Windows.Forms.Label OFFSET_LABEL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label OFFSETMASTER_LABEL;
        private System.Windows.Forms.CheckBox CHANGEAUDIO_CHECKBOX;
        private System.Windows.Forms.Label SKIN_LABE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SKIN_COMBOBOX;
        private System.Windows.Forms.CheckBox CHANGESKIN_CHECKBOX;
    }
}