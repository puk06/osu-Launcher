﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osu_launcher
{
    public partial class AddSoftware : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        public AddSoftware(Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
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

        private void CREATE_BUTTON_Click(object sender, EventArgs e)
        {
            var reasons = CheckValue();
            if (reasons.Any())
            {
                MessageBox.Show("The software could not be saved. The reasons are as follows.\n" + string.Join("\n", reasons), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Save the software
            var software = new Software
            {
                Name = NAME_TEXTBOX.Text,
                Author = AUTHOR_TEXTBOX.Text,
                Description = DESCRIPTION_TEXTBOX.Text,
                Path = PATH_TEXTBOX.Text,
                Checked = false
            };

            _mainForm.Softwares = _mainForm.Softwares.Append(software);
            MessageBox.Show("New software created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
