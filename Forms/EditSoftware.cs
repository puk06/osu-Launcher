﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using osu_launcher.Classes;

namespace osu_launcher.Forms
{
    public partial class EditSoftware : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        // Edit the software
        private readonly Software _software;

        public EditSoftware(Main mainForm, Software software)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _software = software;
            NAME_TEXTBOX.Text = software.Name;
            AUTHOR_TEXTBOX.Text = software.Author;
            DESCRIPTION_TEXTBOX.Text = software.Description;
            PATH_TEXTBOX.Text = software.Path;
        }

        // Check if the values are valid
        private IEnumerable<string> CheckValue()
        {
            IEnumerable<string> reasons = Array.Empty<string>();
            if (NAME_TEXTBOX.Text == "")
            {
                Main.AddValueToArray(ref reasons, "❌️ Name is empty");
            }

            if (AUTHOR_TEXTBOX.Text == "")
            {
                Main.AddValueToArray(ref reasons, "❌️ Author is empty");
            }

            if (DESCRIPTION_TEXTBOX.Text == "")
            {
                Main.AddValueToArray(ref reasons, "❌️ Description is empty");
            }

            if (PATH_TEXTBOX.Text == "")
            {
                Main.AddValueToArray(ref reasons, "❌️ Path is empty");
            }

            if (!File.Exists(PATH_TEXTBOX.Text))
            {
                Main.AddValueToArray(ref reasons, "❌️ Path does not exist");
            }

            return reasons;
        }

        private void EDIT_BUTTON_Click(object sender, EventArgs e)
        {
            var reasons = CheckValue();
            if (reasons.Any())
            {
                MessageBox.Show("The software could not be saved. The reasons are as follows.\n" + string.Join("\n", reasons), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Check if the software already exists
            if (_mainForm.Softwares.Any(s => s.Name == NAME_TEXTBOX.Text))
            {
                MessageBox.Show("The software name alread exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Overwrite the software
            var software = new Software
            {
                Name = NAME_TEXTBOX.Text,
                Author = AUTHOR_TEXTBOX.Text,
                Description = DESCRIPTION_TEXTBOX.Text,
                Path = PATH_TEXTBOX.Text
            };

            _mainForm.Softwares = _mainForm.Softwares.Where(s => s.Name != _software.Name).ToArray();
            _mainForm.Softwares = _mainForm.Softwares.Append(software);
            MessageBox.Show("Software edited successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void OPEN_BUTTON_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable files (*.exe)|*.exe",
                Title = "Select the software"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PATH_TEXTBOX.Text = openFileDialog.FileName;
            }
        }
    }
}
