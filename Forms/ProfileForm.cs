﻿using System;
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
                PROFILEEDIT_COMBOBOX.Items.Add(enumerable.ElementAt(i).Name);
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

        // Generate a button for each profile
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
                ShowErrorMessage("The profile could not be created. The reasons are as follows.\n" + string.Join("\n", reasons));
                return;
            }

            if (IsAnyFieldEmpty())
            {
                ShowErrorMessage("Please fill in all fields");
                return;
            }

            if (ArePasswordsMismatch())
            {
                ShowErrorMessage("Passwords do not match. Try Again");
                return;
            }

            if (IsProfileNameDuplicate())
            {
                ShowErrorMessage("The profile name already exists");
                NAME_TEXTBOX.Text = "";
                return;
            }

            var profile = CreateProfile();

            _mainForm.Profiles = _mainForm.Profiles.Append(profile);
            MessageBox.Show("New profile created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _mainForm.CurrentProfile = profile;
            _mainForm.SaveConfigData();
            UpdateProfileButtons();
            ResetValue();
        }

        // This is the event handler for the EDIT_BUTTON
        private void EDIT_BUTTON_Click(object sender, EventArgs e)
        {
            var reasons = CheckValueEdit();
            if (reasons.Any())
            {
                ShowErrorMessage("The profile could not be saved. The reasons are as follows.\n" + string.Join("\n", reasons));
                return;
            }

            if (IsAnyFieldEmpty())
            {
                ShowErrorMessage("Please fill in all fields");
                return;
            }

            if (ArePasswordsMismatch())
            {
                ShowErrorMessage("Passwords do not match. Try Again");
                return;
            }

            if (IsProfileNameDuplicate())
            {
                ShowErrorMessage("The profile name already exists");
                NAMEEDIT_TEXTBOX.Text = "";
                return;
            }

            var profile = EditProfile();

            _mainForm.Profiles = _mainForm.Profiles.Where(p => p.Name != PROFILEEDIT_COMBOBOX.SelectedItem.ToString());
            _mainForm.Profiles = _mainForm.Profiles.Append(profile);
            MessageBox.Show("Profile edited successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _mainForm.CurrentProfile = profile;
            _mainForm.SaveConfigData();
            UpdateProfileButtons();
            ResetValueEdit();
        }

        // Show error messages
        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Check if any required field is empty
        private bool IsAnyFieldEmpty()
        {
            return string.IsNullOrEmpty(NAME_TEXTBOX.Text) ||
                   string.IsNullOrEmpty(USERNAME_TEXTBOX.Text) ||
                   string.IsNullOrEmpty(PASSWORD_TEXTBOX.Text) ||
                   string.IsNullOrEmpty(CONFIRM_TEXTBOX.Text);
        }

        // Check if passwords do not match
        private bool ArePasswordsMismatch()
        {
            return PASSWORD_TEXTBOX.Text != CONFIRM_TEXTBOX.Text;
        }

        // Check if the profile name already exists
        private bool IsProfileNameDuplicate()
        {
            return _mainForm.Profiles.Any(userdata => userdata.Name == NAME_TEXTBOX.Text);
        }

        // Create a new profile based on form input
        private Profile CreateProfile()
        {
            var profile = new Profile
            {
                Name = NAME_TEXTBOX.Text,
                Username = USERNAME_TEXTBOX.Text,
                Password = Convert.ToBase64String(PasswordProtector.EncryptPassword(PASSWORD_TEXTBOX.Text))
            };

            // Add optional parameters
            AddOptionalParameters(profile);

            return profile;
        }

        // Edit a profile based on form input
        private Profile EditProfile()
        {
            var profile = new Profile
            {
                Name = NAMEEDIT_TEXTBOX.Text,
                Username = USERNAMEEDIT_TEXTBOX.Text,
                Password = Convert.ToBase64String(PasswordProtector.EncryptPassword(PASSWORDEDIT_TEXTBOX.Text))
            };

            // Add optional parameters
            AddOptionalParametersEdit(profile);

            return profile;
        }

        // Add optional parameters to the profile
        private void AddOptionalParameters(Profile profile)
        {
            if (!string.IsNullOrEmpty(SCOREMETER_TEXTBOX.Text))
            {
                profile.ScoreMeter = Math.Round(Convert.ToDouble(SCOREMETER_TEXTBOX.Text), 2);
            }

            if (METERSTYLE_COMBOBOX.SelectedIndex != 0)
            {
                profile.MeterStyle = METERSTYLE_COMBOBOX.SelectedIndex;
            }

            if (!string.IsNullOrEmpty(HEIGHT_TEXTBOX.Text) || !string.IsNullOrEmpty(WIDTH_TEXTBOX.Text))
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

            if (!string.IsNullOrEmpty(OFFSET_TEXTBOX.Text))
            {
                profile.Offset = Convert.ToInt32(OFFSET_TEXTBOX.Text);
            }

            if (CHANGESKIN_CHECKBOX.Checked)
            {
                profile.ChangeSkin = true;
                profile.Skin = SKIN_COMBOBOX.SelectedItem.ToString();
            }
        }

        // Add optional parameters to the profile for editing
        private void AddOptionalParametersEdit(Profile profile)
        {
            if (!string.IsNullOrEmpty(SCOREMETEREDIT_TEXTBOX.Text))
            {
                profile.ScoreMeter = Math.Round(Convert.ToDouble(SCOREMETEREDIT_TEXTBOX.Text), 2);
            }

            if (METERSTYLEEDIT_COMBOBOX.SelectedIndex != 0)
            {
                profile.MeterStyle = METERSTYLEEDIT_COMBOBOX.SelectedIndex;
            }

            if (!string.IsNullOrEmpty(HEIGHTEDIT_TEXTBOX.Text) || !string.IsNullOrEmpty(WIDTHEDIT_TEXTBOX.Text))
            {
                profile.Width = Convert.ToInt32(WIDTHEDIT_TEXTBOX.Text);
                profile.Height = Convert.ToInt32(HEIGHTEDIT_TEXTBOX.Text);
                profile.Fullscreen = FULLSCREENEDIT_CHECKBOX.Checked;
            }

            if (CHANGEAUDIOEDIT_CHECKBOX.Checked)
            {
                profile.ChangeVolume = true;
                profile.VolumeMaster = MASTEREDIT_BAR.Value;
                profile.VolumeEffect = EFFECTEDIT_BAR.Value;
                profile.VolumeMusic = MUSICEDIT_BAR.Value;
            }

            if (!string.IsNullOrEmpty(OFFSETEDIT_TEXTBOX.Text))
            {
                profile.Offset = Convert.ToInt32(OFFSETEDIT_TEXTBOX.Text);
            }

            if (CHANGESKINEDIT_CHECKBOX.Checked)
            {
                profile.ChangeSkin = true;
                profile.Skin = SKINEDIT_COMBOBOX.SelectedItem.ToString();
            }
        }

        // Update the profile buttons on the Users tab
        private void UpdateProfileButtons()
        {
            UsersTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
            foreach (var p in _mainForm.Profiles)
            {
                GenerateButton(p);
            }
        }

        // This is the event handler for the RESET_BUTTON
        private void RESET_BUTTON_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        // This is the event handler for the EDITRESET_BUTTON
        private void EDITRESET_BUTTON_Click(object sender, EventArgs e)
        {
            ResetValueEdit();
        }

        // Reset the values of the form
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

        private void ResetValueEdit()
        {
            NAMEEDIT_TEXTBOX.Text = "";
            USERNAMEEDIT_TEXTBOX.Text = "";
            PASSWORDEDIT_TEXTBOX.Text = "";
            CONFIRMEDIT_TEXTBOX.Text = "";
            SCOREMETEREDIT_TEXTBOX.Text = "";
            METERSTYLEEDIT_COMBOBOX.SelectedIndex = 0;
            WIDTHEDIT_TEXTBOX.Text = "";
            HEIGHTEDIT_TEXTBOX.Text = "";
            FULLSCREENEDIT_CHECKBOX.Checked = false;
            MASTEREDIT_BAR.Value = 100;
            EFFECTEDIT_BAR.Value = 100;
            MUSICEDIT_BAR.Value = 100;
            CHANGEAUDIOEDIT_CHECKBOX.Checked = false;
            OFFSETEDIT_TEXTBOX.Text = "";
            if (SKINEDIT_COMBOBOX.Items.Count > 0) SKINEDIT_COMBOBOX.SelectedIndex = 0;
            CHANGESKINEDIT_CHECKBOX.Checked = false;
        }

        // Check if the values are valid
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

        private IEnumerable<string> CheckValueEdit()
        {
            IEnumerable<string> reasons = Array.Empty<string>();
            if (SCOREMETEREDIT_TEXTBOX.Text != "")
            {
                var result = double.TryParse(SCOREMETEREDIT_TEXTBOX.Text, out double scoreMeter);
                if (!result)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Score meter must be a number");
                }
                else if (scoreMeter < 0)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Score meter must be between 0 and 1");
                }
            }

            if (WIDTHEDIT_TEXTBOX.Text != "")
            {
                var result = int.TryParse(WIDTHEDIT_TEXTBOX.Text, out int width);
                if (!result)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Width contains non-numeric characters");
                }

                if (width < 0)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Width must be greater than 0");
                }
            }

            if (HEIGHTEDIT_TEXTBOX.Text != "")
            {
                var result = int.TryParse(HEIGHTEDIT_TEXTBOX.Text, out int height);
                if (!result)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Height contains non-numeric characters");
                }

                if (height < 0)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Height must be greater than 0");
                }
            }

            if (OFFSETEDIT_TEXTBOX.Text != "")
            {
                var result = int.TryParse(OFFSETEDIT_TEXTBOX.Text, out int offset);
                if (!result)
                {
                    Main.AddValueToArray(ref reasons, "❌️ Offset contains non-numeric characters");
                }
            }

            return reasons;

        }

        // This is the event handler for the MASTER_BAR
        private void MASTER_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(MASTER_BAR, $"{MASTER_BAR.Value}%");
        }

        // This is the event handler for the EFFECT_BAR
        private void EFFECT_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(EFFECT_BAR, $"{EFFECT_BAR.Value}%");
        }

        // This is the event handler for the MUSIC_BAR
        private void MUSIC_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(MUSIC_BAR, $"{MUSIC_BAR.Value}%");
        }

        // This is the event handler for the MASTEREDIT_BAR
        private void MASTEREDIT_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(MASTEREDIT_BAR, $"{MASTEREDIT_BAR.Value}%");
        }

        // This is the event handler for the EFFECTEDIT_BAR
        private void EFFECTEDIT_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(EFFECTEDIT_BAR, $"{EFFECTEDIT_BAR.Value}%");
        }

        // This is the event handler for the MUSICEDIT_BAR
        private void MUSICEDIT_BAR_Scroll(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(MUSICEDIT_BAR, $"{MUSICEDIT_BAR.Value}%");
        }

        // This is the event handler for the CHANGEAUDIO_CHECKBOX
        private void CHANGEAUDIO_CHECKBOX_CheckedChanged(object sender, EventArgs e)
        {
            MASTER_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
            EFFECT_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
            MUSIC_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
        }

        // This is the event handler for the CHANGESKIN_CHECKBOX
        private void CHANGEAUDIOEDIT_CHECKBOX_CheckedChanged(object sender, EventArgs e)
        {
            MASTEREDIT_BAR.Enabled = CHANGEAUDIOEDIT_CHECKBOX.Checked;
            EFFECTEDIT_BAR.Enabled = CHANGEAUDIOEDIT_CHECKBOX.Checked;
            MUSICEDIT_BAR.Enabled = CHANGEAUDIOEDIT_CHECKBOX.Checked;
        }

        // This is the event handler for the CHANGESKIN_CHECKBOX
        private void CHANGESKIN_CHECKBOX_CheckedChanged(object sender, EventArgs e)
        {
            SKIN_COMBOBOX.Enabled = CHANGESKIN_CHECKBOX.Checked;
        }

        // This is the event handler for the CHANGESKINEDIT_CHECKBOX
        private void CHANGESKINEDIT_CHECKBOX_CheckedChanged(object sender, EventArgs e)
        {
            SKINEDIT_COMBOBOX.Enabled = CHANGESKINEDIT_CHECKBOX.Checked;
        }

        // This is the event handler for the PROFILEEDIT_COMBOBOX
        private void PROFILEEDIT_COMBOBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = _mainForm.Profiles.FirstOrDefault(p => p.Name == PROFILEEDIT_COMBOBOX.SelectedItem.ToString());
            if (profile == null) return;
            NAMEEDIT_TEXTBOX.Text = profile.Name;
            USERNAMEEDIT_TEXTBOX.Text = profile.Username;
            PASSWORDEDIT_TEXTBOX.Text = profile.Password;
            CONFIRMEDIT_TEXTBOX.Text = profile.Password;
            SCOREMETEREDIT_TEXTBOX.Text = profile.ScoreMeter.ToString();
            METERSTYLEEDIT_COMBOBOX.SelectedIndex = profile.MeterStyle ?? 0;
            WIDTHEDIT_TEXTBOX.Text = profile.Width.ToString();
            HEIGHTEDIT_TEXTBOX.Text = profile.Height.ToString();
            FULLSCREENEDIT_CHECKBOX.Checked = profile.Fullscreen;
            MASTEREDIT_BAR.Value = profile.VolumeMaster ?? 100;
            EFFECTEDIT_BAR.Value = profile.VolumeEffect ?? 100;
            MUSICEDIT_BAR.Value = profile.VolumeMusic ?? 100;
            CHANGEAUDIOEDIT_CHECKBOX.Checked = profile.ChangeVolume;
            OFFSETEDIT_TEXTBOX.Text = profile.Offset.ToString();
            SKINEDIT_COMBOBOX.SelectedIndex = SKINEDIT_COMBOBOX.Items.IndexOf(profile.Skin);
            CHANGESKINEDIT_CHECKBOX.Checked = profile.ChangeSkin;
        }
    }
}
