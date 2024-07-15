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
            for (int i = 0; i < enumerable.Length; i++)
            {
                GenerateButton(enumerable.ElementAt(i));
            }
        }

        private void GenerateButton(User user)
        {
            Button button = new Button
            {
                Text = user.Username,
                Location = new Point(14, 45 * (UsersTab.Controls.OfType<Button>().Count() + 1)),
                Size = new Size(250, 42),
                Font = new Font(_mainForm.FontCollection.Families[0], 15.75F)
            };
            button.Click += (sender, e) =>
            {
                _mainForm.CurrentUser = user;
                Close();
            };
            button.ContextMenuStrip = new ContextMenuStrip();
            button.ContextMenuStrip.Items.Add("Delete").Click += (sender, e) =>
            {
                // Ask the user if they are sure they want to delete the user
                var result = MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                _mainForm.Users = _mainForm.Users.Where(u => u.Username != user.Username && u.Password != user.Password);
                UsersTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
                foreach (var u in _mainForm.Users)
                {
                    GenerateButton(u);
                }
                _mainForm.CurrentUser = null;
            };
            UsersTab.Controls.Add(button);
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

                // Generate the buttons for the users
                UsersTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
                foreach (var u in _mainForm.Users)
                {
                    GenerateButton(u);
                }
                USERNAME_TEXTBOX.Text = "";
                PASSWORD_TEXTBOX.Text = "";
                CONFIRM_TEXTBOX.Text = "";
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
