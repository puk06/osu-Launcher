using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace osu_launcher
{
    public partial class UserForm : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        // This is the constructor for the UserForm
        public UserForm(IEnumerable<User> users, Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            var enumerable = users as User[] ?? users.ToArray();
            for (int i = 0; i < enumerable.Count(); i++)
            {
                User user = enumerable.ElementAt(i);
                Button button = new Button
                {
                    Text = user.Username,
                    Location = new Point(14, 45 * (i + 1)),
                    Size = new Size(250, 42),
                    Font = new Font(_mainForm.FontCollection.Families[0], 15.75F)
                };
                button.Click += (sender, e) =>
                {
                    _mainForm.CurrentUser = user;
                    Close();
                };
                UsersTab.Controls.Add(button);
            }
        }

        // This is the event handler for the CREATE_BUTTON
        private void CREATE_BUTTON_Click(object sender, EventArgs e)
        {
            if (USERNAME_TEXTBOX.Text == "" || PASSWORD_TEXTBOX.Text == "" || CONFIRM_TEXTBOX.Text == "")
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PASSWORD_TEXTBOX.Text == CONFIRM_TEXTBOX.Text)
            {
                // Check if the user already exists
                if (_mainForm.Users.Any(userdata => userdata.Username == USERNAME_TEXTBOX.Text && userdata.Password == PASSWORD_TEXTBOX.Text))
                {
                    MessageBox.Show("User already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    USERNAME_TEXTBOX.Text = "";
                    PASSWORD_TEXTBOX.Text = "";
                    CONFIRM_TEXTBOX.Text = "";
                    return;
                }

                var user = new User
                {
                    Username = USERNAME_TEXTBOX.Text,
                    Password = PASSWORD_TEXTBOX.Text
                };
                _mainForm.Users = _mainForm.Users.Append(user);
                MessageBox.Show("User created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _mainForm.CurrentUser = user;
                Close();
            }
            else if (PASSWORD_LABEL.Text != CONFIRM_LABEL.Text)
            {
                MessageBox.Show("Passwords do not match. Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // This is the event handler for the RESET_BUTTON
        private void RESET_BUTTON_Click(object sender, EventArgs e)
        {
            USERNAME_TEXTBOX.Text = "";
            PASSWORD_TEXTBOX.Text = "";
            CONFIRM_TEXTBOX.Text = "";
        }
    }
}
