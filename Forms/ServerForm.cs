﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using osu_launcher.Classes;

namespace osu_launcher.Forms
{
    public partial class ServerForm : Form
    {
        // This is the main form
        private readonly Main _mainForm;

        // This is the tooltip for audio settings
        private readonly ToolTip _toolTip = new ToolTip();

        // This is the constructor for the ServerForm
        public ServerForm(IEnumerable<Server> servers, Main mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            var enumerable = servers as Server[] ?? servers.ToArray();
            for (int i = 0; i < enumerable.Length; i++)
            {
                GenerateButton(enumerable.ElementAt(i));
                SERVEREDIT_COMBOBOX.Items.Add(enumerable.ElementAt(i).Name);
            }

            // Highlight the current server
            HightLightCurrentServer();

            if (SERVEREDIT_COMBOBOX.Items.Count > 0)
            {
                ChangeEditFormStatus(true);
                SERVEREDIT_COMBOBOX.SelectedIndex = 0;
            }
            else
            {
                ResetValueEdit();
                ChangeEditFormStatus(false);
            }
        }

        // Change the status of the edit form
        private void ChangeEditFormStatus(bool value)
        {
            IPEDIT_TEXTBOX.Enabled = value;
            EDIT_BUTTON.Enabled = value;
            EDITRESET_BUTTON.Enabled = value;
        }

        // Generate a button for each server
        private void GenerateButton(Server server)
        {
            Button button = new Button
            {
                Text = server.Name,
                Location = new Point(14, 45 * (ServersTab.Controls.OfType<Button>().Count() + 1)),
                Size = new Size(250, 42),
                Font = new Font(_mainForm.GuiFont, 15.75F)
            };
            button.Click += (_object, _event) =>
            {
                _mainForm.CurrentServer = server;
                Close();
            };
            button.ContextMenuStrip = new ContextMenuStrip();
            button.ContextMenuStrip.Items.Add("Delete").Click += (_object, _event) =>
            {
                // Ask the user if they are sure they want to delete the server
                var result = MessageBox.Show("Are you sure you want to delete this server?", "Delete Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                _mainForm.Servers = _mainForm.Servers.Where(u => u.Name != server.Name);
                ServersTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
                SERVEREDIT_COMBOBOX.Items.Clear();
                foreach (var s in _mainForm.Servers)
                {
                    GenerateButton(s);
                    SERVEREDIT_COMBOBOX.Items.Add(s.Name);
                }

                if (SERVEREDIT_COMBOBOX.Items.Count > 0)
                {
                    ChangeEditFormStatus(true);
                    SERVEREDIT_COMBOBOX.SelectedIndex = 0;
                }
                else
                {
                    ResetValueEdit();
                    ChangeEditFormStatus(false);
                }

                _mainForm.SaveConfigData();
                _mainForm.CurrentServer = null;
            };
            ServersTab.Controls.Add(button);
        }

        // This is the event handler for the CREATE_BUTTON
        private void CREATE_BUTTON_Click(object sender, EventArgs e)
        {
            if (IsAnyFieldEmpty())
            {
                Helper.ShowErrorMessage("Please fill in all fields");
                return;
            }

            if (IsServerNameDuplicate())
            {
                Helper.ShowErrorMessage("The profile name already exists");
                NAME_TEXTBOX.Text = string.Empty;
                return;
            }

            var server = CreateServer();

            _mainForm.Servers = _mainForm.Servers.Append(server);
            MessageBox.Show("New server created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _mainForm.CurrentServer = server;
            _mainForm.SaveConfigData();
            UpdateServer();
            ResetValue();
        }

        // This is the event handler for the EDIT_BUTTON
        private void EDIT_BUTTON_Click(object sender, EventArgs e)
        {
            if (IsAnyFieldEmptyEdit())
            {
                Helper.ShowErrorMessage("Please fill in all fields");
                return;
            }

            var server = EditServer();
            _mainForm.Servers = _mainForm.Servers.Where(u => u.Name != server.Name);
            _mainForm.Servers = _mainForm.Servers.Append(server);
            MessageBox.Show("Profile edited successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _mainForm.CurrentServer = server;
            _mainForm.SaveConfigData();
            UpdateServer();

            if (SERVEREDIT_COMBOBOX.Items.Count > 0)
            {
                ChangeEditFormStatus(true);
                var index = SERVEREDIT_COMBOBOX.Items.IndexOf(server.Name);
                SERVEREDIT_COMBOBOX.SelectedIndex = index != -1 ? index : 0;
            }
            else
            {
                ResetValueEdit();
                ChangeEditFormStatus(false);
            }
        }

        // Check if any required field is empty
        private bool IsAnyFieldEmpty()
        {
            return string.IsNullOrEmpty(NAME_TEXTBOX.Text) ||
                   string.IsNullOrEmpty(IP_TEXTBOX.Text);
        }

        // Check if any required field is empty for editing
        private bool IsAnyFieldEmptyEdit()
        {
            return string.IsNullOrEmpty(NAMEEDIT_TEXTBOX.Text) ||
                   string.IsNullOrEmpty(IPEDIT_TEXTBOX.Text);
        }

        // Check if the server name already exists
        private bool IsServerNameDuplicate()
        {
            return _mainForm.Servers.Any(server => server.Name == NAME_TEXTBOX.Text);
        }

        // Create a new server based on form input
        private Server CreateServer()
        {
            var server = new Server
            {
                Name = NAME_TEXTBOX.Text,
                Ip = IP_TEXTBOX.Text
            };

            return server;
        }

        // Edit a server based on form input
        private Server EditServer()
        {
            var server = new Server
            {
                Name = NAMEEDIT_TEXTBOX.Text,
                Ip = IPEDIT_TEXTBOX.Text
            };

            return server;
        }

        // Update the server on the Users tab and edit combobox
        private void UpdateServer()
        {
            ServersTab.Controls.OfType<Button>().ToList().ForEach(c => c.Dispose());
            SERVEREDIT_COMBOBOX.Items.Clear();
            foreach (var s in _mainForm.Servers)
            {
                GenerateButton(s);
                SERVEREDIT_COMBOBOX.Items.Add(s.Name);
            }

            if (SERVEREDIT_COMBOBOX.Items.Count > 0)
            {
                ChangeEditFormStatus(true);
                SERVEREDIT_COMBOBOX.SelectedIndex = 0;
            }
            else
            {
                ResetValueEdit();
                ChangeEditFormStatus(false);
            }

            // Highlight the current server
            HightLightCurrentServer();
        }

        // Highlight the current server
        private void HightLightCurrentServer()
        {
            if (_mainForm.CurrentServer == null) return;
            foreach (Button button in ServersTab.Controls.OfType<Button>())
            {
                if (button.Text == _mainForm.CurrentServer.Name)
                {
                    button.BackColor = Color.LightGreen;
                }
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
            NAME_TEXTBOX.Text = string.Empty;
            IP_TEXTBOX.Text = string.Empty;
        }

        private void ResetValueEdit()
        {
            NAMEEDIT_TEXTBOX.Text = string.Empty;
            IPEDIT_TEXTBOX.Text = string.Empty;
        }

        // This is the event handler for the PROFILEEDIT_COMBOBOX
        private void PROFILEEDIT_COMBOBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            var server = _mainForm.Servers.FirstOrDefault(p => p.Name == SERVEREDIT_COMBOBOX.Text);
            if (server == null) return;
            NAMEEDIT_TEXTBOX.Text = server.Name;
            IPEDIT_TEXTBOX.Text = server.Ip;
        }
    }
}
