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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.LAUNCH_BUTTON = new System.Windows.Forms.Button();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.TopTab = new System.Windows.Forms.TabPage();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.OSUFOLDER_TEXTBOX = new System.Windows.Forms.TextBox();
            this.SONGSFOLDER_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.SONGSFOLDER_DELETE = new System.Windows.Forms.Button();
            this.FULLSCREEN_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.WIDTH_LABEL = new System.Windows.Forms.Label();
            this.WIDTH_TEXTBOX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.HEIGHT_LABEL = new System.Windows.Forms.Label();
            this.HEIGHT_TEXTBOX = new System.Windows.Forms.TextBox();
            this.RESOLUTION_LABEL = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SONGS_FOLDER_PATH = new System.Windows.Forms.Label();
            this.SONGSFOLDER_LABEL = new System.Windows.Forms.Label();
            this.OSUFOLDER_PATH = new System.Windows.Forms.Label();
            this.OSUFOLDER_LABEL = new System.Windows.Forms.Label();
            this.SERVERS_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.SERVER_LABEL = new System.Windows.Forms.Label();
            this.USERNAME_LABEL = new System.Windows.Forms.Label();
            this.USERNAME_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.MainTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // LAUNCH_BUTTON
            // 
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
            this.MainTab.Controls.Add(this.SettingsTab);
            this.MainTab.Location = new System.Drawing.Point(12, 12);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(816, 397);
            this.MainTab.TabIndex = 2;
            // 
            // TopTab
            // 
            this.TopTab.Location = new System.Drawing.Point(4, 22);
            this.TopTab.Name = "TopTab";
            this.TopTab.Padding = new System.Windows.Forms.Padding(3);
            this.TopTab.Size = new System.Drawing.Size(808, 371);
            this.TopTab.TabIndex = 0;
            this.TopTab.Text = "Top";
            this.TopTab.UseVisualStyleBackColor = true;
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.label1);
            this.SettingsTab.Controls.Add(this.OSUFOLDER_TEXTBOX);
            this.SettingsTab.Controls.Add(this.SONGSFOLDER_COMBOBOX);
            this.SettingsTab.Controls.Add(this.SONGSFOLDER_DELETE);
            this.SettingsTab.Controls.Add(this.FULLSCREEN_CHECKBOX);
            this.SettingsTab.Controls.Add(this.WIDTH_LABEL);
            this.SettingsTab.Controls.Add(this.WIDTH_TEXTBOX);
            this.SettingsTab.Controls.Add(this.label9);
            this.SettingsTab.Controls.Add(this.HEIGHT_LABEL);
            this.SettingsTab.Controls.Add(this.HEIGHT_TEXTBOX);
            this.SettingsTab.Controls.Add(this.RESOLUTION_LABEL);
            this.SettingsTab.Controls.Add(this.label6);
            this.SettingsTab.Controls.Add(this.SONGS_FOLDER_PATH);
            this.SettingsTab.Controls.Add(this.SONGSFOLDER_LABEL);
            this.SettingsTab.Controls.Add(this.OSUFOLDER_PATH);
            this.SettingsTab.Controls.Add(this.OSUFOLDER_LABEL);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(808, 371);
            this.SettingsTab.TabIndex = 1;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(29, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(750, 1);
            this.label1.TabIndex = 20;
            // 
            // OSUFOLDER_TEXTBOX
            // 
            this.OSUFOLDER_TEXTBOX.Location = new System.Drawing.Point(93, 47);
            this.OSUFOLDER_TEXTBOX.Name = "OSUFOLDER_TEXTBOX";
            this.OSUFOLDER_TEXTBOX.Size = new System.Drawing.Size(591, 19);
            this.OSUFOLDER_TEXTBOX.TabIndex = 19;
            // 
            // SONGSFOLDER_COMBOBOX
            // 
            this.SONGSFOLDER_COMBOBOX.FormattingEnabled = true;
            this.SONGSFOLDER_COMBOBOX.Location = new System.Drawing.Point(93, 155);
            this.SONGSFOLDER_COMBOBOX.Name = "SONGSFOLDER_COMBOBOX";
            this.SONGSFOLDER_COMBOBOX.Size = new System.Drawing.Size(597, 20);
            this.SONGSFOLDER_COMBOBOX.TabIndex = 18;
            // 
            // SONGSFOLDER_DELETE
            // 
            this.SONGSFOLDER_DELETE.Location = new System.Drawing.Point(698, 158);
            this.SONGSFOLDER_DELETE.Name = "SONGSFOLDER_DELETE";
            this.SONGSFOLDER_DELETE.Size = new System.Drawing.Size(85, 29);
            this.SONGSFOLDER_DELETE.TabIndex = 16;
            this.SONGSFOLDER_DELETE.Text = "delete";
            this.SONGSFOLDER_DELETE.UseVisualStyleBackColor = true;
            this.SONGSFOLDER_DELETE.Click += new System.EventHandler(this.SONGSFOLDER_DELETE_Click);
            // 
            // FULLSCREEN_CHECKBOX
            // 
            this.FULLSCREEN_CHECKBOX.AutoSize = true;
            this.FULLSCREEN_CHECKBOX.Location = new System.Drawing.Point(33, 291);
            this.FULLSCREEN_CHECKBOX.Name = "FULLSCREEN_CHECKBOX";
            this.FULLSCREEN_CHECKBOX.Size = new System.Drawing.Size(77, 16);
            this.FULLSCREEN_CHECKBOX.TabIndex = 14;
            this.FULLSCREEN_CHECKBOX.Text = "Fullscreen";
            this.FULLSCREEN_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // WIDTH_LABEL
            // 
            this.WIDTH_LABEL.AutoSize = true;
            this.WIDTH_LABEL.Location = new System.Drawing.Point(28, 254);
            this.WIDTH_LABEL.Name = "WIDTH_LABEL";
            this.WIDTH_LABEL.Size = new System.Drawing.Size(33, 12);
            this.WIDTH_LABEL.TabIndex = 13;
            this.WIDTH_LABEL.Text = "Width";
            // 
            // WIDTH_TEXTBOX
            // 
            this.WIDTH_TEXTBOX.Location = new System.Drawing.Point(107, 255);
            this.WIDTH_TEXTBOX.Name = "WIDTH_TEXTBOX";
            this.WIDTH_TEXTBOX.Size = new System.Drawing.Size(115, 19);
            this.WIDTH_TEXTBOX.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(29, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(750, 1);
            this.label9.TabIndex = 11;
            // 
            // HEIGHT_LABEL
            // 
            this.HEIGHT_LABEL.AutoSize = true;
            this.HEIGHT_LABEL.Location = new System.Drawing.Point(247, 254);
            this.HEIGHT_LABEL.Name = "HEIGHT_LABEL";
            this.HEIGHT_LABEL.Size = new System.Drawing.Size(38, 12);
            this.HEIGHT_LABEL.TabIndex = 10;
            this.HEIGHT_LABEL.Text = "Height";
            // 
            // HEIGHT_TEXTBOX
            // 
            this.HEIGHT_TEXTBOX.Location = new System.Drawing.Point(335, 255);
            this.HEIGHT_TEXTBOX.Name = "HEIGHT_TEXTBOX";
            this.HEIGHT_TEXTBOX.Size = new System.Drawing.Size(115, 19);
            this.HEIGHT_TEXTBOX.TabIndex = 9;
            // 
            // RESOLUTION_LABEL
            // 
            this.RESOLUTION_LABEL.AutoSize = true;
            this.RESOLUTION_LABEL.Location = new System.Drawing.Point(26, 217);
            this.RESOLUTION_LABEL.Name = "RESOLUTION_LABEL";
            this.RESOLUTION_LABEL.Size = new System.Drawing.Size(59, 12);
            this.RESOLUTION_LABEL.TabIndex = 8;
            this.RESOLUTION_LABEL.Text = "Resolution";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(29, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(750, 1);
            this.label6.TabIndex = 7;
            // 
            // SONGS_FOLDER_PATH
            // 
            this.SONGS_FOLDER_PATH.AutoSize = true;
            this.SONGS_FOLDER_PATH.Location = new System.Drawing.Point(31, 154);
            this.SONGS_FOLDER_PATH.Name = "SONGS_FOLDER_PATH";
            this.SONGS_FOLDER_PATH.Size = new System.Drawing.Size(28, 12);
            this.SONGS_FOLDER_PATH.TabIndex = 6;
            this.SONGS_FOLDER_PATH.Text = "Path";
            // 
            // SONGSFOLDER_LABEL
            // 
            this.SONGSFOLDER_LABEL.AutoSize = true;
            this.SONGSFOLDER_LABEL.Location = new System.Drawing.Point(28, 112);
            this.SONGSFOLDER_LABEL.Name = "SONGSFOLDER_LABEL";
            this.SONGSFOLDER_LABEL.Size = new System.Drawing.Size(72, 12);
            this.SONGSFOLDER_LABEL.TabIndex = 4;
            this.SONGSFOLDER_LABEL.Text = "Songs Folder";
            // 
            // OSUFOLDER_PATH
            // 
            this.OSUFOLDER_PATH.AutoSize = true;
            this.OSUFOLDER_PATH.Location = new System.Drawing.Point(31, 46);
            this.OSUFOLDER_PATH.Name = "OSUFOLDER_PATH";
            this.OSUFOLDER_PATH.Size = new System.Drawing.Size(28, 12);
            this.OSUFOLDER_PATH.TabIndex = 2;
            this.OSUFOLDER_PATH.Text = "Path";
            // 
            // OSUFOLDER_LABEL
            // 
            this.OSUFOLDER_LABEL.AutoSize = true;
            this.OSUFOLDER_LABEL.Location = new System.Drawing.Point(28, 7);
            this.OSUFOLDER_LABEL.Name = "OSUFOLDER_LABEL";
            this.OSUFOLDER_LABEL.Size = new System.Drawing.Size(59, 12);
            this.OSUFOLDER_LABEL.TabIndex = 0;
            this.OSUFOLDER_LABEL.Text = "osu Folder";
            // 
            // SERVERS_COMBOBOX
            // 
            this.SERVERS_COMBOBOX.FormattingEnabled = true;
            this.SERVERS_COMBOBOX.Location = new System.Drawing.Point(41, 442);
            this.SERVERS_COMBOBOX.Name = "SERVERS_COMBOBOX";
            this.SERVERS_COMBOBOX.Size = new System.Drawing.Size(173, 20);
            this.SERVERS_COMBOBOX.TabIndex = 3;
            // 
            // SERVER_LABEL
            // 
            this.SERVER_LABEL.AutoSize = true;
            this.SERVER_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.SERVER_LABEL.Location = new System.Drawing.Point(79, 408);
            this.SERVER_LABEL.Name = "SERVER_LABEL";
            this.SERVER_LABEL.Size = new System.Drawing.Size(38, 12);
            this.SERVER_LABEL.TabIndex = 4;
            this.SERVER_LABEL.Text = "Server";
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.BackColor = System.Drawing.Color.Transparent;
            this.USERNAME_LABEL.Location = new System.Drawing.Point(635, 408);
            this.USERNAME_LABEL.Name = "USERNAME_LABEL";
            this.USERNAME_LABEL.Size = new System.Drawing.Size(56, 12);
            this.USERNAME_LABEL.TabIndex = 5;
            this.USERNAME_LABEL.Text = "Username";
            // 
            // USERNAME_COMBOBOX
            // 
            this.USERNAME_COMBOBOX.FormattingEnabled = true;
            this.USERNAME_COMBOBOX.Location = new System.Drawing.Point(613, 442);
            this.USERNAME_COMBOBOX.Name = "USERNAME_COMBOBOX";
            this.USERNAME_COMBOBOX.Size = new System.Drawing.Size(173, 20);
            this.USERNAME_COMBOBOX.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 499);
            this.Controls.Add(this.USERNAME_COMBOBOX);
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
        private System.Windows.Forms.ComboBox USERNAME_COMBOBOX;
        private Label OSUFOLDER_LABEL;
        private Label OSUFOLDER_PATH;
        private Label label9;
        private Label HEIGHT_LABEL;
        private TextBox HEIGHT_TEXTBOX;
        private Label RESOLUTION_LABEL;
        private Label label6;
        private Label SONGS_FOLDER_PATH;
        private Label SONGSFOLDER_LABEL;
        private System.Windows.Forms.CheckBox FULLSCREEN_CHECKBOX;
        private Label WIDTH_LABEL;
        private TextBox WIDTH_TEXTBOX;
        private ComboBox SONGSFOLDER_COMBOBOX;
        private Button SONGSFOLDER_DELETE;
        private TextBox OSUFOLDER_TEXTBOX;
        private Label label1;
    }
}

