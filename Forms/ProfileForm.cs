using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using osu_launcher.Classes;

namespace osu_launcher.Forms
{
    public partial class ProfileForm : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        // This is the tooltip for audio settings
        private readonly ToolTip _toolTip = new ToolTip();

        // This is the constructor for the ProfileForm
        public ProfileForm(IEnumerable<Profile> profiles, string osuFolder, Main mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            MASTER_BAR.Value = 100;
            EFFECT_BAR.Value = 100;
            MUSIC_BAR.Value = 100;
            METERSTYLE_COMBOBOX.SelectedIndex = 0;
            var enumerable = profiles as Profile[] ?? profiles.ToArray();
            for (int i = 0; i < enumerable.Length; i++)
            {
                GenerateButton(enumerable.ElementAt(i));
            }

            string skinsPath = Path.Combine(osuFolder, "Skins");
            if (Directory.Exists(skinsPath))
            {
                SKIN_COMBOBOX.Items.Clear();
                var folders = Directory.GetDirectories(skinsPath);
                foreach (var folder in folders)
                {
                    SKIN_COMBOBOX.Items.Add(Path.GetFileName(folder));
                }
                if (SKIN_COMBOBOX.Items.Count > 0) SKIN_COMBOBOX.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("The skins folder was not found. The skin selection feature is disabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SKIN_COMBOBOX.Enabled = false;
            }
        }

        private void GenerateButton(Profile profile)
        {
            Button button = new Button
            {
                Text = profile.Name,
                Location = new Point(14, 45 * (UsersTab.Controls.OfType<Button>().Count() + 1)),
                Size = new Size(250, 42),
                Font = new Font(_mainForm.FontCollection.Families[0], 15.75F)
            };
            button.Click += (_object, _event) =>
            {
                _mainForm.CurrentProfile = profile;
                Close();
            };
            button.ContextMenuStrip = new ContextMenuStrip();
            button.ContextMenuStrip.Items.Add("Delete").Click += (_object, _event) =>
            {
                // Ask the user if they are sure they want to delete the profile
                var result = MessageBox.Show("Are you sure you want to delete this profile?", "Delete Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                _mainForm.Profiles = _mainForm.Profiles.Where(u => u.Name != profile.Name);
                UsersTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
                foreach (var p in _mainForm.Profiles)
                {
                    GenerateButton(p);
                }
                _mainForm.CurrentProfile = null;
            };
            UsersTab.Controls.Add(button);
        }

        // This is the event handler for the CREATE_BUTTON
        private void CREATE_BUTTON_Click(object sender, EventArgs e)
        {
            var reasons = CheckValue();
            if (reasons.Any())
            {
                MessageBox.Show("The profile could not be created. The reasons are as follows.\n" + string.Join("\n", reasons), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (NAME_TEXTBOX.Text == "" || USERNAME_TEXTBOX.Text == "" || PASSWORD_TEXTBOX.Text == "" || CONFIRM_TEXTBOX.Text == "")
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PASSWORD_TEXTBOX.Text == CONFIRM_TEXTBOX.Text)
            {
                // Check if the profile already exists
                if (_mainForm.Profiles.Any(userdata => userdata.Name == USERNAME_TEXTBOX.Name))
                {
                    MessageBox.Show("The profile name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NAME_TEXTBOX.Text = "";
                    return;
                }

                var profile = new Profile
                {
                    Name = NAME_TEXTBOX.Text,
                    Username = USERNAME_TEXTBOX.Text,
                    Password = Convert.ToBase64String(PasswordProtector.EncryptPassword(PASSWORD_TEXTBOX.Text))
                };

                if (SCOREMETER_TEXTBOX.Text != "")
                {
                    profile.ScoreMeter = Math.Round(Convert.ToDouble(SCOREMETER_TEXTBOX.Text), 2);
                }

                if (METERSTYLE_COMBOBOX.SelectedIndex != 0)
                {
                    profile.MeterStyle = METERSTYLE_COMBOBOX.SelectedIndex;
                }

                if (HEIGHT_TEXTBOX.Text != "" || WIDTH_TEXTBOX.Text != "")
                {
                    profile.Width = Convert.ToInt32(WIDTH_TEXTBOX.Text);
                    profile.Height = Convert.ToInt32(HEIGHT_TEXTBOX.Text);
                    profile.Fullscreen = FULLSCREEN_CHECKBOX.Checked;
                }

                if (CHANGEAUDIO_CHECKBOX.Checked)
                {
                    profile.ChangeVolume = true;
                    profile.VolumeMaster = MASTER_BAR.Value;
                    profile.VolumeEffect = EFFECT_BAR.Value;
                    profile.VolumeMusic = MUSIC_BAR.Value;
                }
                else
                {
                    profile.ChangeVolume = false;
                }

                if (OFFSET_TEXTBOX.Text != "")
                {
                    profile.Offset = Convert.ToInt32(OFFSET_TEXTBOX.Text);
                }

                if (CHANGESKIN_CHECKBOX.Checked)
                {
                    profile.ChangeSkin = true;
                    profile.Skin = SKIN_COMBOBOX.SelectedItem.ToString();
                }
                else
                {
                    profile.ChangeSkin = false;
                }

                _mainForm.Profiles = _mainForm.Profiles.Append(profile);
                MessageBox.Show("New profile created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _mainForm.CurrentProfile = profile;

                // Generate the buttons for the profiles
                UsersTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
                foreach (var p in _mainForm.Profiles)
                {
                    GenerateButton(p);
                }
                ResetValue();
            }
            else if (PASSWORD_LABEL.Text != CONFIRM_LABEL.Text)
            {
                MessageBox.Show("Passwords do not match. Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // This is the event handler for the RESET_BUTTON
        private void RESET_BUTTON_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void ResetValue()
        {
            NAME_TEXTBOX.Text = "";
            USERNAME_TEXTBOX.Text = "";
            PASSWORD_TEXTBOX.Text = "";
            CONFIRM_TEXTBOX.Text = "";
            SCOREMETER_TEXTBOX.Text = "";
            METERSTYLE_COMBOBOX.SelectedIndex = 0;
            WIDTH_TEXTBOX.Text = "";
            HEIGHT_TEXTBOX.Text = "";
            FULLSCREEN_CHECKBOX.Checked = false;
            MASTER_BAR.Value = 100;
            EFFECT_BAR.Value = 100;
            MUSIC_BAR.Value = 100;
            CHANGEAUDIO_CHECKBOX.Checked = false;
            OFFSET_TEXTBOX.Text = "";
            if (SKIN_COMBOBOX.Items.Count > 0) SKIN_COMBOBOX.SelectedIndex = 0;
            CHANGESKIN_CHECKBOX.Checked = false;
        }

        private IEnumerable<string> CheckValue()
        {
            IEnumerable<string> reasons = Array.Empty<string>();
            if (SCOREMETER_TEXTBOX.Text != "")
            {
                var result = double.TryParse(SCOREMETER_TEXTBOX.Text, out double scoreMeter);
                if (!result)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Score meter must be a number");
                }
                else if (scoreMeter < 0)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Score meter must be between 0 and 1");
                }
            }

            if (WIDTH_TEXTBOX.Text != "")
            {
                var result = int.TryParse(WIDTH_TEXTBOX.Text, out int width);
                if (!result)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Width contains non-numeric characters");
                }

                if (width < 0)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Width must be greater than 0");
                }
            }

            if (HEIGHT_TEXTBOX.Text != "")
            {
                var result = int.TryParse(HEIGHT_TEXTBOX.Text, out int height);
                if (!result)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Height contains non-numeric characters");
                }

                if (height < 0)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Height must be greater than 0");
                }
            }

            if (OFFSET_TEXTBOX.Text != "")
            {
                var result = int.TryParse(OFFSET_TEXTBOX.Text, out int offset);
                if (!result)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Offset contains non-numeric characters");
                }
            }

            return reasons;
        }

        private void MASTER_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(MASTER_BAR, $"{MASTER_BAR.Value}%");
        }

        private void EFFECT_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(EFFECT_BAR, $"{EFFECT_BAR.Value}%");
        }

        private void MUSIC_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(MUSIC_BAR, $"{MUSIC_BAR.Value}%");
        }

        private void CHANGEAUDIO_CHECKBOX_CheckedChanged(object sender, EventArgs e)
        {
            MASTER_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
            EFFECT_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
            MUSIC_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
        }

        private void CHANGESKIN_CHECKBOX_CheckedChanged(object sender, EventArgs e)
        {
            SKIN_COMBOBOX.Enabled = CHANGESKIN_CHECKBOX.Checked;
        }
    }
}
