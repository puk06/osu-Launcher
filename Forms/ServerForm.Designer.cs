using System.Windows.Forms;

namespace osu_launcher.Forms
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.ServersTab = new System.Windows.Forms.TabPage();
            this.SELECTUSER_LABEL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateTab = new System.Windows.Forms.TabPage();
            this.NAME_TEXTBOX = new System.Windows.Forms.TextBox();
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RESET_BUTTON = new System.Windows.Forms.Button();
            this.CREATE_BUTTON = new System.Windows.Forms.Button();
            this.NEWSERVER_LABEL = new System.Windows.Forms.Label();
            this.EditTab = new System.Windows.Forms.TabPage();
            this.SERVEREDIT_LABEL = new System.Windows.Forms.Label();
            this.SERVEREDIT_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.NAMEEDIT_TEXTBOX = new System.Windows.Forms.TextBox();
            this.NAMEEDIT_LABEL = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.EDITRESET_BUTTON = new System.Windows.Forms.Button();
            this.EDIT_BUTTON = new System.Windows.Forms.Button();
            this.IPEDIT_TEXTBOX = new System.Windows.Forms.TextBox();
            this.IPEDIT_LABEL = new System.Windows.Forms.Label();
            this.EDITPROFILE_LABEL = new System.Windows.Forms.Label();
            this.USERFORM_LABEL = new System.Windows.Forms.Label();
            this.IP_LABEL = new System.Windows.Forms.Label();
            this.IP_TEXTBOX = new System.Windows.Forms.TextBox();
            this.MainTab.SuspendLayout();
            this.ServersTab.SuspendLayout();
            this.CreateTab.SuspendLayout();
            this.EditTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.ServersTab);
            this.MainTab.Controls.Add(this.CreateTab);
            this.MainTab.Controls.Add(this.EditTab);
            this.MainTab.Font = new System.Drawing.Font(_mainForm.GuiFont, 9F);
            this.MainTab.Location = new System.Drawing.Point(12, 54);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(291, 384);
            this.MainTab.TabIndex = 0;
            // 
            // ServersTab
            // 
            this.ServersTab.AutoScroll = true;
            this.ServersTab.Controls.Add(this.SELECTUSER_LABEL);
            this.ServersTab.Controls.Add(this.label3);
            this.ServersTab.Font = new System.Drawing.Font(_mainForm.GuiFont, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServersTab.Location = new System.Drawing.Point(4, 27);
            this.ServersTab.Name = "ServersTab";
            this.ServersTab.Padding = new System.Windows.Forms.Padding(3);
            this.ServersTab.Size = new System.Drawing.Size(283, 353);
            this.ServersTab.TabIndex = 0;
            this.ServersTab.Text = "Servers";
            // 
            // SELECTUSER_LABEL
            // 
            this.SELECTUSER_LABEL.AutoSize = true;
            this.SELECTUSER_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 16F);
            this.SELECTUSER_LABEL.Location = new System.Drawing.Point(7, 0);
            this.SELECTUSER_LABEL.Name = "SELECTUSER_LABEL";
            this.SELECTUSER_LABEL.Size = new System.Drawing.Size(144, 33);
            this.SELECTUSER_LABEL.TabIndex = 31;
            this.SELECTUSER_LABEL.Text = "Select Server";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(14, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 1);
            this.label3.TabIndex = 21;
            // 
            // CreateTab
            // 
            this.CreateTab.AutoScroll = true;
            this.CreateTab.Controls.Add(this.NAME_TEXTBOX);
            this.CreateTab.Controls.Add(this.NAME_LABEL);
            this.CreateTab.Controls.Add(this.label1);
            this.CreateTab.Controls.Add(this.RESET_BUTTON);
            this.CreateTab.Controls.Add(this.CREATE_BUTTON);
            this.CreateTab.Controls.Add(this.IP_TEXTBOX);
            this.CreateTab.Controls.Add(this.IP_LABEL);
            this.CreateTab.Controls.Add(this.NEWSERVER_LABEL);
            this.CreateTab.Font = new System.Drawing.Font(_mainForm.GuiFont, 9F);
            this.CreateTab.Location = new System.Drawing.Point(4, 27);
            this.CreateTab.Name = "CreateTab";
            this.CreateTab.Padding = new System.Windows.Forms.Padding(3);
            this.CreateTab.Size = new System.Drawing.Size(283, 353);
            this.CreateTab.TabIndex = 1;
            this.CreateTab.Text = "Create Server";
            // 
            // NAME_TEXTBOX
            // 
            this.NAME_TEXTBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 9F);
            this.NAME_TEXTBOX.Location = new System.Drawing.Point(104, 45);
            this.NAME_TEXTBOX.Name = "NAME_TEXTBOX";
            this.NAME_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.NAME_TEXTBOX.TabIndex = 32;
            // 
            // NAME_LABEL
            // 
            this.NAME_LABEL.AutoSize = true;
            this.NAME_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
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
            this.RESET_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.RESET_BUTTON.Location = new System.Drawing.Point(162, 124);
            this.RESET_BUTTON.Name = "RESET_BUTTON";
            this.RESET_BUTTON.Size = new System.Drawing.Size(102, 34);
            this.RESET_BUTTON.TabIndex = 29;
            this.RESET_BUTTON.Text = "Reset";
            this.RESET_BUTTON.UseVisualStyleBackColor = true;
            this.RESET_BUTTON.Click += new System.EventHandler(this.RESET_BUTTON_Click);
            // 
            // CREATE_BUTTON
            // 
            this.CREATE_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.CREATE_BUTTON.Location = new System.Drawing.Point(19, 124);
            this.CREATE_BUTTON.Name = "CREATE_BUTTON";
            this.CREATE_BUTTON.Size = new System.Drawing.Size(105, 34);
            this.CREATE_BUTTON.TabIndex = 28;
            this.CREATE_BUTTON.Text = "Create";
            this.CREATE_BUTTON.UseVisualStyleBackColor = true;
            this.CREATE_BUTTON.Click += new System.EventHandler(this.CREATE_BUTTON_Click);
            // 
            // NEWSERVER_LABEL
            // 
            this.NEWSERVER_LABEL.AutoSize = true;
            this.NEWSERVER_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 16F);
            this.NEWSERVER_LABEL.Location = new System.Drawing.Point(7, 0);
            this.NEWSERVER_LABEL.Name = "NEWSERVER_LABEL";
            this.NEWSERVER_LABEL.Size = new System.Drawing.Size(129, 33);
            this.NEWSERVER_LABEL.TabIndex = 0;
            this.NEWSERVER_LABEL.Text = "New Server";
            // 
            // EditTab
            // 
            this.EditTab.AutoScroll = true;
            this.EditTab.Controls.Add(this.SERVEREDIT_LABEL);
            this.EditTab.Controls.Add(this.SERVEREDIT_COMBOBOX);
            this.EditTab.Controls.Add(this.NAMEEDIT_TEXTBOX);
            this.EditTab.Controls.Add(this.NAMEEDIT_LABEL);
            this.EditTab.Controls.Add(this.label28);
            this.EditTab.Controls.Add(this.EDITRESET_BUTTON);
            this.EditTab.Controls.Add(this.EDIT_BUTTON);
            this.EditTab.Controls.Add(this.IPEDIT_TEXTBOX);
            this.EditTab.Controls.Add(this.IPEDIT_LABEL);
            this.EditTab.Controls.Add(this.EDITPROFILE_LABEL);
            this.EditTab.Location = new System.Drawing.Point(4, 27);
            this.EditTab.Name = "EditTab";
            this.EditTab.Size = new System.Drawing.Size(283, 353);
            this.EditTab.TabIndex = 2;
            this.EditTab.Text = "Edit Server";
            // 
            // SERVEREDIT_LABEL
            // 
            this.SERVEREDIT_LABEL.AutoSize = true;
            this.SERVEREDIT_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 13F);
            this.SERVEREDIT_LABEL.Location = new System.Drawing.Point(16, 12);
            this.SERVEREDIT_LABEL.Name = "SERVEREDIT_LABEL";
            this.SERVEREDIT_LABEL.Size = new System.Drawing.Size(66, 26);
            this.SERVEREDIT_LABEL.TabIndex = 115;
            this.SERVEREDIT_LABEL.Text = "Server";
            // 
            // SERVEREDIT_COMBOBOX
            // 
            this.SERVEREDIT_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SERVEREDIT_COMBOBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 10F);
            this.SERVEREDIT_COMBOBOX.FormattingEnabled = true;
            this.SERVEREDIT_COMBOBOX.Location = new System.Drawing.Point(100, 15);
            this.SERVEREDIT_COMBOBOX.Name = "SERVEREDIT_COMBOBOX";
            this.SERVEREDIT_COMBOBOX.Size = new System.Drawing.Size(158, 27);
            this.SERVEREDIT_COMBOBOX.TabIndex = 114;
            this.SERVEREDIT_COMBOBOX.SelectedIndexChanged += new System.EventHandler(this.PROFILEEDIT_COMBOBOX_SelectedIndexChanged);
            // 
            // NAMEEDIT_TEXTBOX
            // 
            this.NAMEEDIT_TEXTBOX.Enabled = false;
            this.NAMEEDIT_TEXTBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 9F);
            this.NAMEEDIT_TEXTBOX.Location = new System.Drawing.Point(104, 92);
            this.NAMEEDIT_TEXTBOX.Name = "NAMEEDIT_TEXTBOX";
            this.NAMEEDIT_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.NAMEEDIT_TEXTBOX.TabIndex = 83;
            // 
            // NAMEEDIT_LABEL
            // 
            this.NAMEEDIT_LABEL.AutoSize = true;
            this.NAMEEDIT_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.NAMEEDIT_LABEL.Location = new System.Drawing.Point(11, 90);
            this.NAMEEDIT_LABEL.Name = "NAMEEDIT_LABEL";
            this.NAMEEDIT_LABEL.Size = new System.Drawing.Size(56, 24);
            this.NAMEEDIT_LABEL.TabIndex = 82;
            this.NAMEEDIT_LABEL.Text = "Name";
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Location = new System.Drawing.Point(14, 80);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(250, 1);
            this.label28.TabIndex = 81;
            // 
            // EDITRESET_BUTTON
            // 
            this.EDITRESET_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.EDITRESET_BUTTON.Location = new System.Drawing.Point(158, 176);
            this.EDITRESET_BUTTON.Name = "EDITRESET_BUTTON";
            this.EDITRESET_BUTTON.Size = new System.Drawing.Size(102, 34);
            this.EDITRESET_BUTTON.TabIndex = 80;
            this.EDITRESET_BUTTON.Text = "Reset";
            this.EDITRESET_BUTTON.UseVisualStyleBackColor = true;
            this.EDITRESET_BUTTON.Click += new System.EventHandler(this.EDITRESET_BUTTON_Click);
            // 
            // EDIT_BUTTON
            // 
            this.EDIT_BUTTON.Font = new System.Drawing.Font(_mainForm.GuiFont, 11F);
            this.EDIT_BUTTON.Location = new System.Drawing.Point(15, 176);
            this.EDIT_BUTTON.Name = "EDIT_BUTTON";
            this.EDIT_BUTTON.Size = new System.Drawing.Size(105, 34);
            this.EDIT_BUTTON.TabIndex = 79;
            this.EDIT_BUTTON.Text = "Edit";
            this.EDIT_BUTTON.UseVisualStyleBackColor = true;
            this.EDIT_BUTTON.Click += new System.EventHandler(this.EDIT_BUTTON_Click);
            // 
            // IPEDIT_TEXTBOX
            // 
            this.IPEDIT_TEXTBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 9F);
            this.IPEDIT_TEXTBOX.Location = new System.Drawing.Point(104, 129);
            this.IPEDIT_TEXTBOX.Name = "IPEDIT_TEXTBOX";
            this.IPEDIT_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.IPEDIT_TEXTBOX.TabIndex = 74;
            // 
            // IPEDIT_LABEL
            // 
            this.IPEDIT_LABEL.AutoSize = true;
            this.IPEDIT_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.IPEDIT_LABEL.Location = new System.Drawing.Point(11, 127);
            this.IPEDIT_LABEL.Name = "IPEDIT_LABEL";
            this.IPEDIT_LABEL.Size = new System.Drawing.Size(24, 24);
            this.IPEDIT_LABEL.TabIndex = 73;
            this.IPEDIT_LABEL.Text = "IP";
            // 
            // EDITPROFILE_LABEL
            // 
            this.EDITPROFILE_LABEL.AutoSize = true;
            this.EDITPROFILE_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 16F);
            this.EDITPROFILE_LABEL.Location = new System.Drawing.Point(7, 47);
            this.EDITPROFILE_LABEL.Name = "EDITPROFILE_LABEL";
            this.EDITPROFILE_LABEL.Size = new System.Drawing.Size(121, 33);
            this.EDITPROFILE_LABEL.TabIndex = 72;
            this.EDITPROFILE_LABEL.Text = "Edit Profile";
            // 
            // USERFORM_LABEL
            // 
            this.USERFORM_LABEL.AutoSize = true;
            this.USERFORM_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERFORM_LABEL.Location = new System.Drawing.Point(10, 9);
            this.USERFORM_LABEL.Name = "USERFORM_LABEL";
            this.USERFORM_LABEL.Size = new System.Drawing.Size(242, 31);
            this.USERFORM_LABEL.TabIndex = 1;
            this.USERFORM_LABEL.Text = "Select or Create Server";
            // 
            // IP_LABEL
            // 
            this.IP_LABEL.AutoSize = true;
            this.IP_LABEL.Font = new System.Drawing.Font(_mainForm.GuiFont, 12F);
            this.IP_LABEL.Location = new System.Drawing.Point(11, 80);
            this.IP_LABEL.Name = "IP_LABEL";
            this.IP_LABEL.Size = new System.Drawing.Size(24, 24);
            this.IP_LABEL.TabIndex = 22;
            this.IP_LABEL.Text = "IP";
            // 
            // IP_TEXTBOX
            // 
            this.IP_TEXTBOX.Font = new System.Drawing.Font(_mainForm.TextFont, 9F);
            this.IP_TEXTBOX.Location = new System.Drawing.Point(104, 82);
            this.IP_TEXTBOX.Name = "IP_TEXTBOX";
            this.IP_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.IP_TEXTBOX.TabIndex = 23;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 450);
            this.Controls.Add(this.USERFORM_LABEL);
            this.Controls.Add(this.MainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerForm";
            this.MainTab.ResumeLayout(false);
            this.ServersTab.ResumeLayout(false);
            this.ServersTab.PerformLayout();
            this.CreateTab.ResumeLayout(false);
            this.CreateTab.PerformLayout();
            this.EditTab.ResumeLayout(false);
            this.EditTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage ServersTab;
        private System.Windows.Forms.TabPage CreateTab;
        private System.Windows.Forms.Label USERFORM_LABEL;
        private System.Windows.Forms.Label NEWSERVER_LABEL;
        private System.Windows.Forms.Button RESET_BUTTON;
        private System.Windows.Forms.Button CREATE_BUTTON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SELECTUSER_LABEL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NAME_TEXTBOX;
        private System.Windows.Forms.Label NAME_LABEL;
        private TabPage EditTab;
        private Label SERVEREDIT_LABEL;
        private ComboBox SERVEREDIT_COMBOBOX;
        private TextBox NAMEEDIT_TEXTBOX;
        private Label NAMEEDIT_LABEL;
        private Label label28;
        private Button EDITRESET_BUTTON;
        private Button EDIT_BUTTON;
        private TextBox IPEDIT_TEXTBOX;
        private Label IPEDIT_LABEL;
        private Label EDITPROFILE_LABEL;
        private TextBox IP_TEXTBOX;
        private Label IP_LABEL;
    }
}