﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using Newtonsoft.Json.Linq;
using osu_launcher.Classes;
using Profile = osu_launcher.Classes.Profile;

namespace osu_launcher.Forms
{
    public partial class Main : Form
    {
        // Data Values
        private JObject _data;

        // Profiles
        public IEnumerable<Profile> Profiles = Array.Empty<Profile>();

        // Softwares
        public IEnumerable<Software> Softwares = Array.Empty<Software>();

        // GUI Font
        public FontFamily GuiFont;

        // Text Font
        public FontFamily TextFont;

        // Current Profile
        public Profile CurrentProfile;

        // Form Font
        private readonly PrivateFontCollection _fontCollection = new PrivateFontCollection();

        // Meter Style Dictionary
        private readonly Dictionary<int, string> _meterStyleDict = new Dictionary<int, string>
        {
            { 1, "None" },
            { 2, "Error" },
            { 3, "Colour" }
        };

        // Constructor
        public Main()
        {
            try
            {
                Helper.InitializeCefSharp();
                Helper.ValidateRequiredFiles();
                AddFontFile();
                InitializeComponent();
                InitializeDefaults();
                InitializeWebBrowser();
                LoadConfigFile();
                InitializeComboboxes();
                SetInitialProfile();
                ValidateOsuFolder();
                SetPasswordAutoCopy();
                LoadSoftwares();
            }
            catch (Exception ex)
            {
                Helper.ShowErrorMessage("osu-Launcher could not be launched. The reasons are as follows.\n" + ex);
            }
        }

        private void InitializeDefaults()
        {
            METERSTYLE_COMBOBOX.SelectedIndex = 0;
            MASTER_BAR.Value = 100;
            EFFECT_BAR.Value = 100;
            AUDIO_BAR.Value = 100;
        }

        private void InitializeWebBrowser()
        {
            var webBrowser = new ChromiumWebBrowser("https://osu.ppy.sh/home/news");
            TopTab.Controls.Add(webBrowser);
            webBrowser.Dock = DockStyle.Fill;
        }

        private void LoadConfigFile()
        {
            StreamReader streamReader = new StreamReader("./src/data.json", Encoding.GetEncoding("Shift_JIS"));
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            _data = JObject.Parse(str);
        }

        private void InitializeComboboxes()
        {
            InitializeCombobox(SERVERS_COMBOBOX, _data["Servers"]);
            InitializeCombobox(SONGSFOLDER_COMBOBOX, _data["SongsFolder"]);
            InitializeProfiles();
        }

        private static void InitializeCombobox(ComboBox comboBox, JToken items)
        {
            if (items == null) items = new JArray();
            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }
            if (comboBox.Items.Count > 0) comboBox.SelectedIndex = 0;
        }

        private void InitializeProfiles()
        {
            if (_data["Profiles"] == null) _data["Profiles"] = new JArray();
            foreach (var userdata in _data["Profiles"])
            {
                var user = new Profile
                {
                    Name = userdata["Name"].ToString(),
                    Username = userdata["Username"].ToString(),
                    Password = userdata["Password"].ToString(),
                    ScoreMeter = userdata["ScoreMeter"].ToObject<double?>(),
                    MeterStyle = userdata["MeterStyle"].ToObject<int?>(),
                    Width = userdata["Width"].ToObject<int?>(),
                    Height = userdata["Height"].ToObject<int?>(),
                    Fullscreen = userdata["Fullscreen"].ToObject<bool>(),
                    VolumeMaster = userdata["VolumeMaster"].ToObject<int>(),
                    VolumeEffect = userdata["VolumeEffect"].ToObject<int>(),
                    VolumeMusic = userdata["VolumeMusic"].ToObject<int>(),
                    ChangeVolume = userdata["ChangeVolume"].ToObject<bool>(),
                    Offset = userdata["Offset"].ToObject<int?>(),
                    Skin = userdata["Skin"].ToString(),
                    ChangeSkin = userdata["ChangeSkin"].ToObject<bool>()
                };
                Helper.AddValueToArray(ref Profiles, user);
            }
        }

        private void SetInitialProfile()
        {
            var enumerable = Profiles as Profile[] ?? Profiles.ToArray();
            if (enumerable.Length > 0)
            {
                CurrentProfile = enumerable.First();
                PROFILE_BUTTON.Text = CurrentProfile.Name;
                RefreshProfile();
            }
        }

        private void ValidateOsuFolder()
        {
            if (_data["osuFolder"] == null) _data["osuFolder"] = string.Empty;
            OSUFOLDER_TEXTBOX.Text = _data["osuFolder"].ToString();
            if (string.IsNullOrEmpty(OSUFOLDER_TEXTBOX.Text))
            {
                Helper.ShowErrorMessage("The osu! folder is not set. Please set it from the Settings tab!!");
            }
        }

        private void SetPasswordAutoCopy()
        {
            if (_data["PasswordAutoCopy"] == null) _data["PasswordAutoCopy"] = true;
            else if (_data["PasswordAutoCopy"].ToObject<bool>())
            {
                PASSWORDAUTOCOPY_CHECKBOX.Checked = true;
            }
        }

        private void LoadSoftwares()
        {
            if (_data["Softwares"] == null) _data["Softwares"] = new JArray();
            foreach (var software in _data["Softwares"])
            {
                var soft = new Software
                {
                    Name = software["Name"].ToString(),
                    Author = software["Author"].ToString(),
                    Description = software["Description"].ToString(),
                    Path = software["Path"].ToString(),
                    Checked = software["Checked"].ToObject<bool>(),
                };
                Helper.AddValueToArray(ref Softwares, soft);
            }
            LoadSoftwaresButton();
        }

        // Add the font file
        private void AddFontFile()
        {
            // Add the font files
            _fontCollection.AddFontFile("./src/Fonts/Quicksand-Light.ttf");
            _fontCollection.AddFontFile("./src/Fonts/NotoSansJP-Light.ttf");

            // Set the font
            foreach (FontFamily font in _fontCollection.Families)
            {
                Console.WriteLine(font.Name);
                switch (font.Name)
                {
                    case "Quicksand Light":
                        GuiFont = font;
                        break;
                    case "Noto Sans JP Light":
                        TextFont = font;
                        break;
                }
            }
        }

        // Launch osu!
        private void LAUNCH_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the values are valid
                var reasons = CheckValue();
                var enumerable = reasons as string[] ?? reasons.ToArray();
                if (enumerable.Length > 0)
                {
                    MessageBox.Show("osu! could not be launched. The reasons are as follows.\n" + string.Join("\n", enumerable), "Error",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the values
                string server = SERVERS_COMBOBOX.Text;
                string osuFolder = OSUFOLDER_TEXTBOX.Text;

                // Save the config data
                SaveConfigData();

                // Change the config values
                var parameters = AddParameters();

                // Write the config values
                Helper.ChangeConfigValue(osuFolder, parameters);

                // Copy the password
                if (CurrentProfile != null && PASSWORDAUTOCOPY_CHECKBOX.Checked)
                {
                    try
                    {
                        string decryptedPassword =
                            PasswordProtector.DecryptPassword(Convert.FromBase64String(CurrentProfile.Password));
                        Clipboard.SetText(decryptedPassword);
                    }
                    catch
                    {
                        MessageBox.Show("The password could not be copied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Launch osu!
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(osuFolder, "osu!.exe"),
                    WorkingDirectory = osuFolder,
                    Arguments = server == "Bancho" ? string.Empty : "-devserver " + server
                };
                Process.Start(startInfo);

                // Launch the software
                LaunchSoftwares();
            }
            catch (Exception ex)
            {
                MessageBox.Show("osu! could not be launched. The reasons are as follows.\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Save the config data
        public void SaveConfigData()
        {
            string server = SERVERS_COMBOBOX.Text;
            string songFolder = SONGSFOLDER_COMBOBOX.Text;
            string osuFolder = OSUFOLDER_TEXTBOX.Text;

            if (!Helper.ArrayContains(_data["Servers"].ToObject<string[]>(), server))
            {
                SERVERS_COMBOBOX.Items.Add(server);
                (_data["Servers"] as JArray).Add(server);
            }

            if (!Helper.ArrayContains(_data["SongsFolder"].ToObject<string[]>(), songFolder))
            {
                SONGSFOLDER_COMBOBOX.Items.Add(songFolder);
                (_data["SongsFolder"] as JArray).Add(songFolder);
            }

            // Save the password
            _data["PasswordAutoCopy"] = PASSWORDAUTOCOPY_CHECKBOX.Checked;

            _data["Profiles"] = new JArray();
            foreach (var profile in Profiles)
            {
                (_data["Profiles"] as JArray).Add(new JObject
                {
                    { "Name", profile.Name },
                    { "Username", profile.Username },
                    { "Password", profile.Password },
                    { "ScoreMeter", profile.ScoreMeter },
                    { "MeterStyle", profile.MeterStyle },
                    { "Width", profile.Width },
                    { "Height", profile.Height },
                    { "Fullscreen", profile.Fullscreen },
                    { "VolumeMaster", profile.VolumeMaster },
                    { "VolumeEffect", profile.VolumeEffect },
                    { "VolumeMusic", profile.VolumeMusic },
                    { "ChangeVolume", profile.ChangeVolume },
                    { "Offset", profile.Offset },
                    { "Skin", profile.Skin },
                    { "ChangeSkin", profile.ChangeSkin }
                });
            }

            _data["Softwares"] = new JArray();
            foreach (var software in Softwares)
            {
                (_data["Softwares"] as JArray).Add(new JObject
                {
                    { "Name", software.Name },
                    { "Author", software.Author },
                    { "Description", software.Description },
                    { "Path", software.Path },
                    { "Checked", software.Checked }
                });
            }

            _data["osuFolder"] = osuFolder;

            StreamWriter streamWriter =
                new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
            streamWriter.WriteLine(_data.ToString());
            streamWriter.Close();
        }

        // Add the parameters
        private Dictionary<string, string> AddParameters()
        {
            var parameters = new Dictionary<string, string>
            {
                { "CredentialEndpoint", SERVERS_COMBOBOX.Text == "Bancho" ? string.Empty : SERVERS_COMBOBOX.Text },
                { "BeatmapDirectory", SONGSFOLDER_COMBOBOX.Text },
                { "SavePassword", "1" },
                { "SaveUsername", "1" }
            };

            AddResolutionParameters(parameters);
            AddProfileParameters(parameters);
            AddOptionalParameters(parameters);
            AddAudioParameters(parameters);

            return parameters;
        }

        // Add the resolution parameters
        private void AddResolutionParameters(IDictionary<string, string> parameters)
        {
            string heightKey = FULLSCREEN_CHECKBOX.Checked ? "HeightFullscreen" : "Height";
            string widthKey = FULLSCREEN_CHECKBOX.Checked ? "WidthFullscreen" : "Width";

            Helper.AddParameterIfNotEmpty(parameters, heightKey, HEIGHT_TEXTBOX.Text);
            Helper.AddParameterIfNotEmpty(parameters, widthKey, WIDTH_TEXTBOX.Text);
        }

        // Add the profile parameters
        private void AddProfileParameters(IDictionary<string, string> parameters)
        {
            if (CurrentProfile != null)
            {
                parameters.Add("Username", CurrentProfile.Username);
            }
        }
        
        // Add the optional parameters
        private void AddOptionalParameters(IDictionary<string, string> parameters)
        {
            Helper.AddParameterIfNotEmpty(parameters, "ScoreMeterScale", METERSCALE_TEXTBOX.Text);
            Helper.AddParameterIfNotEmpty(parameters, "Offset", OFFSET_TEXTBOX.Text);

            if (CHANGESKIN_CHECKBOX.Checked)
            {
                parameters.Add("Skin", SKIN_COMBOBOX.Text);
            }

            if (METERSTYLE_COMBOBOX.SelectedIndex != 0 && _meterStyleDict.TryGetValue(METERSTYLE_COMBOBOX.SelectedIndex, out string meterStyle))
            {
                parameters.Add("ScoreMeter", meterStyle);
            }
        }

        // Add the audio parameters
        private void AddAudioParameters(IDictionary<string, string> parameters)
        {
            if (CHANGEAUDIO_CHECKBOX.Checked)
            {
                parameters.Add("VolumeUniversal", MASTER_BAR.Value.ToString());
                parameters.Add("VolumeEffect", EFFECT_BAR.Value.ToString());
                parameters.Add("VolumeMusic", AUDIO_BAR.Value.ToString());
            }
        }

        // Launch the software
        private void LaunchSoftwares()
        {
            foreach (var checkBox in SoftwareTab.Controls.OfType<CheckBox>())
            {
                try
                {
                    if (!checkBox.Checked) continue;
                    foreach (var software in Softwares)
                    {
                        if (software.Name != checkBox.Name) continue;
                        string softwarePath = software.Path;
                        string workingDirectory = Path.GetDirectoryName(softwarePath);
                        if (!File.Exists(softwarePath) || string.IsNullOrEmpty(workingDirectory))
                            throw new Exception("The software could not be found.");
                        ProcessStartInfo softwareStartInfo = new ProcessStartInfo
                        {
                            FileName = softwarePath,
                            WorkingDirectory = workingDirectory
                        };
                        Process.Start(softwareStartInfo);
                    }
                }
                catch
                {
                    MessageBox.Show($"The \"{checkBox.Name}\" could not be launched.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Delete the song folder
        private void DeleteSongFolder()
        {
            try
            {
                if (Helper.ArrayContains(_data["SongsFolder"].ToObject<string[]>(), SONGSFOLDER_COMBOBOX.Text))
                {
                    _data["SongsFolder"] = new JArray(_data["SongsFolder"].Where(item => item.ToString() != SONGSFOLDER_COMBOBOX.Text));
                    SONGSFOLDER_COMBOBOX.Items.Remove(SONGSFOLDER_COMBOBOX.Text);
                    SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
                    StreamWriter streamWriter = new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
                    streamWriter.WriteLine(_data.ToString());
                    streamWriter.Close();
                    SaveConfigData();
                }
                else
                {
                    SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The song folder could not be deleted. The reasons are as follows.\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Check if the values are valid
        private IEnumerable<string> CheckValue()
        {
            IEnumerable<string> reasons = Array.Empty<string>();
            if (!Directory.Exists(SONGSFOLDER_COMBOBOX.Text) && SONGSFOLDER_COMBOBOX.Text != "Songs")
            {
                Helper.AddValueToArray(ref reasons, "❌️ Songs folder not found");
            }

            if (!Directory.Exists(OSUFOLDER_TEXTBOX.Text))
            {
                Helper.AddValueToArray(ref reasons, "❌️ osu! folder not found");
            }

            if (!File.Exists(Path.Combine(OSUFOLDER_TEXTBOX.Text, "osu!.exe")))
            {
                Helper.AddValueToArray(ref reasons, "❌️ osu!.exe not found in osu! folder");
            }

            if (!string.IsNullOrEmpty(WIDTH_TEXTBOX.Text))
            {
                var result = int.TryParse(WIDTH_TEXTBOX.Text, out int width);
                if (!result)
                {
                    Helper.AddValueToArray(ref reasons, "❌️ Width contains non-numeric characters");
                }

                if (width < 0)
                {
                    Helper.AddValueToArray(ref reasons, "❌️ Width must be greater than 0");
                }
            }

            if (!string.IsNullOrEmpty(HEIGHT_TEXTBOX.Text))
            {
                var result = int.TryParse(HEIGHT_TEXTBOX.Text, out int height);
                if (!result)
                {
                    Helper.AddValueToArray(ref reasons, "❌️ Height contains non-numeric characters");
                }

                if (height < 0)
                {
                    Helper.AddValueToArray(ref reasons, "❌️ Height must be greater than 0");
                }
            }

            if (SERVERS_COMBOBOX.Text != "Bancho" && string.IsNullOrEmpty(SERVERS_COMBOBOX.Text))
            {
                Helper.AddValueToArray(ref reasons, "❌️ Server not selected");
            }

            return reasons;
        }

        // Load the software
        private void LoadSoftwaresButton()
        {
            try
            {
                Softwares = Softwares.OrderBy(s => s.Name).ToArray();
                var enumerable = Softwares as Software[] ?? Softwares.ToArray();
                for (int i = 0; i < enumerable.Length; i++)
                {
                    GenerateSoftwaresTab(enumerable.ElementAt(i));
                }

                int baseLocation = 69 * (SoftwareTab.Controls.OfType<CheckBox>().Count() + 1);
                var addSoftwareButton = new Button
                {
                    Text = "Add Software",
                    AutoSize = true,
                    Location = new Point(20, baseLocation - 60),
                    Name = "AddSoftwareButton",
                    Size = new Size(75, 23),
                    TabIndex = 0,
                    UseVisualStyleBackColor = true,
                    Font = new Font(_fontCollection.Families[1], 13F, FontStyle.Regular, GraphicsUnit.Point, 0)
                };

                addSoftwareButton.Click += (sender, e) =>
                {
                    if (Application.OpenForms.OfType<AddSoftware>().Any()) return;
                    var addSoftwareForm = new AddSoftware(this);
                    addSoftwareForm.Show();

                    // Disable the form
                    Enabled = false;

                    addSoftwareForm.FormClosed += (_object, _event) =>
                    {
                        SoftwareTab.Controls.Clear();
                        LoadSoftwaresButton();
                        SaveConfigData();

                        // Enable the form
                        Enabled = true;
                    };
                };

                SoftwareTab.Controls.Add(addSoftwareButton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The software could not be loaded. The reasons are as follows.\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Generate the software tab
        private void GenerateSoftwaresTab(Software software)
        {
            int baseLocation = 69 * (SoftwareTab.Controls.OfType<CheckBox>().Count() + 1);
            var checkBox = new CheckBox
            {
                Text = string.Empty,
                AutoSize = true,
                Location = new Point(20, baseLocation - 44),
                Name = software.Name,
                Size = new Size(15, 14),
                TabIndex = 0,
                UseVisualStyleBackColor = true
            };

            checkBox.CheckedChanged += (sender, e) =>
            {
                foreach (var soft in Softwares)
                {
                    if (soft.Name != checkBox.Name) continue;
                    soft.Checked = checkBox.Checked;
                    break;
                }
            };

            var softwareNameLabel = new Label
            {
                AutoSize = true,
                Location = new Point(41, baseLocation - 66),
                Name = "label" + software.Name,
                TabIndex = 1,
                Text = software.Name,
                Font = new Font(_fontCollection.Families[1], 15),
                ContextMenuStrip = new ContextMenuStrip()
            };

            softwareNameLabel.ContextMenuStrip.Items.Add("Edit").Click += (_object, _event) =>
            {
                if (Application.OpenForms.OfType<AddSoftware>().Any()) return;
                var editSoftwareForm = new EditSoftware(this, software);
                editSoftwareForm.Show();
                editSoftwareForm.FormClosed += (__object, __event) =>
                {
                    SoftwareTab.Controls.Clear();
                    LoadSoftwaresButton();
                };
            };

            softwareNameLabel.ContextMenuStrip.Items.Add("Delete").Click += (_object, _event) =>
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected software?", "Delete Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                Softwares = Softwares.Where(s => s.Name != software.Name).ToArray();
                SoftwareTab.Controls.Clear();
                LoadSoftwaresButton();
                SaveConfigData();
            };

            // Get the width of the label
            int labelWidth = TextRenderer.MeasureText(softwareNameLabel.Text, softwareNameLabel.Font).Width;
            int label2Right = softwareNameLabel.Location.X + labelWidth - 3;

            var authorLabel = new Label
            {
                AutoSize = true,
                Location = new Point(label2Right, baseLocation - 60),
                Name = "label2" + software.Name,
                TabIndex = 1,
                Text = "by " + software.Author,
                Font = new Font(_fontCollection.Families[1], 11)
            };

            var descriptionLabel = new Label
            {
                AutoSize = true,
                Location = new Point(41, baseLocation - 39),
                Name = "label3" + software.Name,
                TabIndex = 1,
                Text = "Description: " + software.Description,
                Font = new Font(_fontCollection.Families[1], 12)
            };

            SoftwareTab.Controls.Add(checkBox);
            if (software.Checked) checkBox.Checked = true;
            SoftwareTab.Controls.Add(softwareNameLabel);
            SoftwareTab.Controls.Add(authorLabel);
            SoftwareTab.Controls.Add(descriptionLabel);
        }

        // Delete the song folder
        private void SONGSFOLDER_DELETE_Click(object sender, EventArgs e)
        {
            if (SONGSFOLDER_COMBOBOX.Text == "Songs") return;
            var result = MessageBox.Show("Are you sure you want to delete the selected song folder?", "Delete Song Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) DeleteSongFolder();
        }

        // Open Profile Manager
        private void PROFILE_BUTTON_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<ProfileForm>().Any()) return;
            var profileForm = new ProfileForm(Profiles, OSUFOLDER_TEXTBOX.Text, this);
            profileForm.Show();

            // Disable the form
            Enabled = false;

            // if the form is closed, update the profile
            profileForm.FormClosed += (_object, _event) =>
            {
                RefreshProfile();

                // Enable the form
                Enabled = true;
            };
        }

        // Refresh the profile
        private void RefreshProfile()
        {
            Helper.SetControlText(PROFILE_BUTTON, CurrentProfile?.Name, "No Profile");
            Helper.SetControlText(HEIGHT_TEXTBOX, CurrentProfile?.Height?.ToString());
            Helper.SetControlText(WIDTH_TEXTBOX, CurrentProfile?.Width?.ToString());
            Helper.SetControlChecked(FULLSCREEN_CHECKBOX, CurrentProfile?.Fullscreen);
            Helper.SetControlText(METERSCALE_TEXTBOX, CurrentProfile?.ScoreMeter?.ToString());
            Helper.SetControlSelectedIndex(METERSTYLE_COMBOBOX, CurrentProfile?.MeterStyle ?? 0);
            Helper.SetControlChecked(CHANGEAUDIO_CHECKBOX, CurrentProfile?.ChangeVolume);
            Helper.SetControlValue(MASTER_BAR, CurrentProfile?.VolumeMaster ?? 100);
            Helper.SetControlValue(EFFECT_BAR, CurrentProfile?.VolumeEffect ?? 100);
            Helper.SetControlValue(AUDIO_BAR, CurrentProfile?.VolumeMusic ?? 100);
            UpdateVolumeLabels();
            Helper.SetControlText(OFFSET_TEXTBOX, CurrentProfile?.Offset?.ToString());
            Helper.SetControlChecked(CHANGESKIN_CHECKBOX, CurrentProfile?.ChangeSkin);

            if (CurrentProfile?.ChangeSkin == true)
            {
                SetSkinComboBox();
            }
        }

        private void UpdateVolumeLabels()
        {
            MASTERVALUE_LABEL.Text = MASTER_BAR.Value + "%";
            EFFECTVALUE_LABEL.Text = EFFECT_BAR.Value + "%";
            AUDIOVALUE_LABEL.Text = AUDIO_BAR.Value + "%";
        }

        private void SetSkinComboBox()
        {
            var skinIndex = SKIN_COMBOBOX.Items.IndexOf(CurrentProfile.Skin);
            if (skinIndex != -1)
            {
                SKIN_COMBOBOX.SelectedIndex = skinIndex;
            }
        }

        // Change the audio values
        private void MASTER_BAR_Scroll(object sender, EventArgs e)
        {
            MASTERVALUE_LABEL.Text = MASTER_BAR.Value + "%";
        }

        private void EFFECT_BAR_Scroll(object sender, EventArgs e)
        {
            EFFECTVALUE_LABEL.Text = EFFECT_BAR.Value + "%";
        }

        private void AUDIO_BAR_Scroll(object sender, EventArgs e)
        {
            AUDIOVALUE_LABEL.Text = AUDIO_BAR.Value + "%";
        }

        // Enable the text box
        private void CHANGESKIN_CHECKBOX_CheckedChanged(object sender, EventArgs e)
        {
            if (!CHANGESKIN_CHECKBOX.Checked)
            {
                SKIN_COMBOBOX.Enabled = false;
                return;
            }

            string skinsPath = Path.Combine(OSUFOLDER_TEXTBOX.Text, "Skins");
            if (Directory.Exists(skinsPath))
            {
                // Save the selected skin
                string selectedSkin = SKIN_COMBOBOX.Text;

                SKIN_COMBOBOX.Items.Clear();
                var folders = Directory.GetDirectories(skinsPath);
                foreach (var folder in folders)
                {
                    SKIN_COMBOBOX.Items.Add(Path.GetFileName(folder));
                }

                if (SKIN_COMBOBOX.Items.Count > 0)
                {
                    // Skins found
                    CHANGESKIN_CHECKBOX.Checked = true;
                    SKIN_COMBOBOX.Enabled = true;
                    SKIN_COMBOBOX.SelectedIndex = SKIN_COMBOBOX.Items.Contains(selectedSkin) ? SKIN_COMBOBOX.Items.IndexOf(selectedSkin) : 0;
                }
                else
                {
                    //No skins found
                    MessageBox.Show("No skins were found in the skins folder. The skin selection feature is disabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SKIN_COMBOBOX.Enabled = false;
                    CHANGESKIN_CHECKBOX.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("The skins folder was not found. The skin selection feature is disabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SKIN_COMBOBOX.Enabled = false;
                CHANGESKIN_CHECKBOX.Checked = false;
            }
        }

        private void CHANGEAUDIO_CHECKBOX_CheckedChanged(object sender, EventArgs e)
        {
            MASTER_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
            EFFECT_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
            AUDIO_BAR.Enabled = CHANGEAUDIO_CHECKBOX.Checked;
        }

        private void OSUFOLDER_FOLDEROPEN_BUTTON_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the osu! folder";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                OSUFOLDER_TEXTBOX.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
