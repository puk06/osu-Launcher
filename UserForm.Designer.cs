namespace osu_launcher
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.UsersTab = new System.Windows.Forms.TabPage();
            this.SELECTUSER_LABEL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResisterTab = new System.Windows.Forms.TabPage();
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
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.UsersTab);
            this.MainTab.Controls.Add(this.ResisterTab);
            this.MainTab.Font = new System.Drawing.Font("Quicksand Light", 9F);
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
            this.UsersTab.Font = new System.Drawing.Font("Quicksand Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersTab.Location = new System.Drawing.Point(4, 27);
            this.UsersTab.Name = "UsersTab";
            this.UsersTab.Padding = new System.Windows.Forms.Padding(3);
            this.UsersTab.Size = new System.Drawing.Size(283, 353);
            this.UsersTab.TabIndex = 0;
            this.UsersTab.Text = "Users";
            this.UsersTab.UseVisualStyleBackColor = true;
            // 
            // SELECTUSER_LABEL
            // 
            this.SELECTUSER_LABEL.AutoSize = true;
            this.SELECTUSER_LABEL.Font = new System.Drawing.Font("Quicksand Light", 16F);
            this.SELECTUSER_LABEL.Location = new System.Drawing.Point(7, 0);
            this.SELECTUSER_LABEL.Name = "SELECTUSER_LABEL";
            this.SELECTUSER_LABEL.Size = new System.Drawing.Size(126, 33);
            this.SELECTUSER_LABEL.TabIndex = 31;
            this.SELECTUSER_LABEL.Text = "Select User";
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
            this.ResisterTab.Font = new System.Drawing.Font("Quicksand Light", 9F);
            this.ResisterTab.Location = new System.Drawing.Point(4, 27);
            this.ResisterTab.Name = "ResisterTab";
            this.ResisterTab.Padding = new System.Windows.Forms.Padding(3);
            this.ResisterTab.Size = new System.Drawing.Size(283, 353);
            this.ResisterTab.TabIndex = 1;
            this.ResisterTab.Text = "Register User";
            this.ResisterTab.UseVisualStyleBackColor = true;
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
            this.RESET_BUTTON.Font = new System.Drawing.Font("Quicksand Light", 11F);
            this.RESET_BUTTON.Location = new System.Drawing.Point(162, 147);
            this.RESET_BUTTON.Name = "RESET_BUTTON";
            this.RESET_BUTTON.Size = new System.Drawing.Size(102, 34);
            this.RESET_BUTTON.TabIndex = 29;
            this.RESET_BUTTON.Text = "Reset";
            this.RESET_BUTTON.UseVisualStyleBackColor = true;
            this.RESET_BUTTON.Click += new System.EventHandler(this.RESET_BUTTON_Click);
            // 
            // CREATE_BUTTON
            // 
            this.CREATE_BUTTON.Font = new System.Drawing.Font("Quicksand Light", 11F);
            this.CREATE_BUTTON.Location = new System.Drawing.Point(13, 147);
            this.CREATE_BUTTON.Name = "CREATE_BUTTON";
            this.CREATE_BUTTON.Size = new System.Drawing.Size(105, 34);
            this.CREATE_BUTTON.TabIndex = 28;
            this.CREATE_BUTTON.Text = "Create";
            this.CREATE_BUTTON.UseVisualStyleBackColor = true;
            this.CREATE_BUTTON.Click += new System.EventHandler(this.CREATE_BUTTON_Click);
            // 
            // CONFIRM_TEXTBOX
            // 
            this.CONFIRM_TEXTBOX.Font = new System.Drawing.Font("Noto Sans JP", 9F);
            this.CONFIRM_TEXTBOX.Location = new System.Drawing.Point(104, 116);
            this.CONFIRM_TEXTBOX.Name = "CONFIRM_TEXTBOX";
            this.CONFIRM_TEXTBOX.PasswordChar = '*';
            this.CONFIRM_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.CONFIRM_TEXTBOX.TabIndex = 27;
            // 
            // CONFIRM_LABEL
            // 
            this.CONFIRM_LABEL.AutoSize = true;
            this.CONFIRM_LABEL.Font = new System.Drawing.Font("Quicksand Light", 12F);
            this.CONFIRM_LABEL.Location = new System.Drawing.Point(11, 114);
            this.CONFIRM_LABEL.Name = "CONFIRM_LABEL";
            this.CONFIRM_LABEL.Size = new System.Drawing.Size(70, 24);
            this.CONFIRM_LABEL.TabIndex = 26;
            this.CONFIRM_LABEL.Text = "Confirm";
            // 
            // PASSWORD_TEXTBOX
            // 
            this.PASSWORD_TEXTBOX.Font = new System.Drawing.Font("Noto Sans JP", 9F);
            this.PASSWORD_TEXTBOX.Location = new System.Drawing.Point(104, 77);
            this.PASSWORD_TEXTBOX.Name = "PASSWORD_TEXTBOX";
            this.PASSWORD_TEXTBOX.PasswordChar = '*';
            this.PASSWORD_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.PASSWORD_TEXTBOX.TabIndex = 25;
            // 
            // PASSWORD_LABEL
            // 
            this.PASSWORD_LABEL.AutoSize = true;
            this.PASSWORD_LABEL.Font = new System.Drawing.Font("Quicksand Light", 12F);
            this.PASSWORD_LABEL.Location = new System.Drawing.Point(11, 75);
            this.PASSWORD_LABEL.Name = "PASSWORD_LABEL";
            this.PASSWORD_LABEL.Size = new System.Drawing.Size(82, 24);
            this.PASSWORD_LABEL.TabIndex = 24;
            this.PASSWORD_LABEL.Text = "Password";
            // 
            // USERNAME_TEXTBOX
            // 
            this.USERNAME_TEXTBOX.Font = new System.Drawing.Font("Noto Sans JP", 9F);
            this.USERNAME_TEXTBOX.Location = new System.Drawing.Point(104, 38);
            this.USERNAME_TEXTBOX.Name = "USERNAME_TEXTBOX";
            this.USERNAME_TEXTBOX.Size = new System.Drawing.Size(160, 25);
            this.USERNAME_TEXTBOX.TabIndex = 23;
            // 
            // USERNAME_LABEL
            // 
            this.USERNAME_LABEL.AutoSize = true;
            this.USERNAME_LABEL.Font = new System.Drawing.Font("Quicksand Light", 12F);
            this.USERNAME_LABEL.Location = new System.Drawing.Point(11, 36);
            this.USERNAME_LABEL.Name = "USERNAME_LABEL";
            this.USERNAME_LABEL.Size = new System.Drawing.Size(86, 24);
            this.USERNAME_LABEL.TabIndex = 22;
            this.USERNAME_LABEL.Text = "Username";
            // 
            // NEWUSER_LABEL
            // 
            this.NEWUSER_LABEL.AutoSize = true;
            this.NEWUSER_LABEL.Font = new System.Drawing.Font("Quicksand Light", 16F);
            this.NEWUSER_LABEL.Location = new System.Drawing.Point(7, 0);
            this.NEWUSER_LABEL.Name = "NEWUSER_LABEL";
            this.NEWUSER_LABEL.Size = new System.Drawing.Size(111, 33);
            this.NEWUSER_LABEL.TabIndex = 0;
            this.NEWUSER_LABEL.Text = "New User";
            // 
            // USERFORM_LABEL
            // 
            this.USERFORM_LABEL.AutoSize = true;
            this.USERFORM_LABEL.Font = new System.Drawing.Font("Quicksand Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USERFORM_LABEL.Location = new System.Drawing.Point(10, 9);
            this.USERFORM_LABEL.Name = "USERFORM_LABEL";
            this.USERFORM_LABEL.Size = new System.Drawing.Size(223, 31);
            this.USERFORM_LABEL.TabIndex = 1;
            this.USERFORM_LABEL.Text = "Select or Create User";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 450);
            this.Controls.Add(this.USERFORM_LABEL);
            this.Controls.Add(this.MainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.MainTab.ResumeLayout(false);
            this.UsersTab.ResumeLayout(false);
            this.UsersTab.PerformLayout();
            this.ResisterTab.ResumeLayout(false);
            this.ResisterTab.PerformLayout();
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
    }
}