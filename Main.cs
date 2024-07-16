﻿using CefSharp;
using CefSharp.DevTools.Profiler;
using CefSharp.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace osu_launcher
{
    public partial class Main : Form
    {
        // Data Values
        private readonly JObject _data;

        // Profiles
        public IEnumerable<Profile> Profiles = Array.Empty<Profile>();

        // Softwares
        public IEnumerable<Software> Softwares = Array.Empty<Software>();

        // Current Profile
        public Profile CurrentProfile;

        // Form Font
        public readonly PrivateFontCollection FontCollection = new PrivateFontCollection();

        // Constructor
        public Main()
        {
            try
            {
                // Initialize CefSharp
                var settings = new CefSettings
                {
                    RootCachePath =
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "CefSharp\\Cache")
                };
                Cef.Initialize(settings);

                // Check if the files exist
                if (!File.Exists("./src/Fonts/Quicksand-Light.ttf") || !File.Exists("./src/Fonts/NotoSansJP-Light.ttf"))
                {
                    MessageBox.Show("The font file was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }

                if (!File.Exists("./src/data.json"))
                {
                    MessageBox.Show("The data file was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }

                // Add the font files
                FontCollection.AddFontFile("./src/Fonts/Quicksand-Light.ttf");
                FontCollection.AddFontFile("./src/Fonts/NotoSansJP-Light.ttf");

                // Initialize the components
                InitializeComponent();

                // Set meter style
                METERSTYLE_COMBOBOX.SelectedIndex = 0;

                // Set the web browser
                var webBrowser = new ChromiumWebBrowser("https://osu.ppy.sh/home/news");
                TopTab.Controls.Add(webBrowser);
                webBrowser.Dock = DockStyle.Fill;

                // Load the config file
                StreamReader streamReader = new StreamReader("./src/data.json", Encoding.GetEncoding("Shift_JIS"));
                string str = streamReader.ReadToEnd();
                streamReader.Close();
                _data = JObject.Parse(str);

                // Set the values
                foreach (var server in _data["Servers"])
                {
                    SERVERS_COMBOBOX.Items.Add(server);
                }
                if (SERVERS_COMBOBOX.Items.Count > 0) SERVERS_COMBOBOX.SelectedIndex = 0;

                foreach (var songFolder in _data["SongsFolder"])
                {
                    SONGSFOLDER_COMBOBOX.Items.Add(songFolder);
                }
                if (SONGSFOLDER_COMBOBOX.Items.Count > 0) SONGSFOLDER_COMBOBOX.SelectedIndex = 0;

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
                        VolumeMaster = userdata["VolumeMaster"].ToObject<int?>(),
                        VolumeEffect = userdata["VolumeEffect"].ToObject<int?>(),
                        VolumeMusic = userdata["VolumeMusic"].ToObject<int?>(),
                        ChangeVolume = userdata["ChangeVolume"].ToObject<bool>(),
                        Offset = userdata["Offset"].ToObject<int?>(),
                        Skin = userdata["Skin"].ToString(),
                        ChangeSkin = userdata["ChangeSkin"].ToObject<bool>()
                    };
                    AddValueToArray(ref Profiles, user);
                }
                if (Profiles.Any()) USERNAME_BUTTON.Text = Profiles.First().Name;

                OSUFOLDER_TEXTBOX.Text = _data["osuFolder"].ToString();
                if (OSUFOLDER_TEXTBOX.Text == "")
                {
                    MessageBox.Show("The osu! folder is not set. Please set it from the Settings tab!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Load the software
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
                    AddValueToArray(ref Softwares, soft);
                }
                LoadSoftwares();
            }
            catch (Exception ex)
            {
                MessageBox.Show("osu-Launcher could not be launched. The reasons are as follows.\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Launch osu!
        private void LAUNCH_BUTTON_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the values are valid
                var reasons = CheckValue();
                if (reasons.Any())
                {
                    MessageBox.Show("osu! could not be launched. The reasons are as follows.\n" + string.Join("\n", reasons), "Error",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the values
                string server = SERVERS_COMBOBOX.Text;
                string songFolder = SONGSFOLDER_COMBOBOX.Text;
                string osuFolder = OSUFOLDER_TEXTBOX.Text;

                // Add the values to the data file
                if (!ArrayContains(_data["Servers"].ToObject<string[]>(), server))
                {
                    SERVERS_COMBOBOX.Items.Add(server);
                    (_data["Servers"] as JArray).Add(server);
                }

                if (!ArrayContains(_data["SongsFolder"].ToObject<string[]>(), songFolder))
                {
                    SONGSFOLDER_COMBOBOX.Items.Add(songFolder);
                    (_data["SongsFolder"] as JArray).Add(songFolder);
                }

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

                // Change the config values
                var parameters = new Dictionary<string, string>
                {
                    {"CredentialEndpoint", server == "Bancho" ? "" : server},
                    { "BeatmapDirectory", songFolder }
                };

                if (CurrentProfile != null)
                {
                    parameters.Add("Username", CurrentProfile.Username);
                    string decryptedPassword = PasswordProtector.DecryptPassword(Convert.FromBase64String(CurrentProfile.Password));
                    Clipboard.SetText(decryptedPassword);
                }

                if (FULLSCREEN_CHECKBOX.Checked)
                {
                    if (HEIGHT_TEXTBOX.Text != "") parameters.Add("HeightFullscreen", HEIGHT_TEXTBOX.Text);
                    if (WIDTH_TEXTBOX.Text != "") parameters.Add("WidthFullscreen", WIDTH_TEXTBOX.Text);
                }
                else
                {
                    if (HEIGHT_TEXTBOX.Text != "") parameters.Add("Height", HEIGHT_TEXTBOX.Text);
                    if (WIDTH_TEXTBOX.Text != "") parameters.Add("Width", WIDTH_TEXTBOX.Text);
                }

                if (METERSCALE_TEXTBOX.Text != "")
                {
                    parameters.Add("ScoreMeterScale", METERSCALE_TEXTBOX.Text);
                }

                if (METERSTYLE_COMBOBOX.SelectedIndex != 0)
                {
                    switch (METERSTYLE_COMBOBOX.SelectedIndex)
                    {
                        case 1:
                            parameters.Add("ScoreMeter", "None");
                            break;
                        case 2:
                            parameters.Add("ScoreMeter", "Error");
                            break;
                        case 3:
                            parameters.Add("ScoreMeter", "Colour");
                            break;
                    }
                }

                if (CHANGEAUDIO_CHECKBOX.Checked)
                {
                    parameters.Add("VolumeUniversal", MASTER_BAR.Value.ToString());
                    parameters.Add("VolumeEffect", EFFECT_BAR.Value.ToString());
                    parameters.Add("VolumeMusic", AUDIO_BAR.Value.ToString());
                }

                if (OFFSET_TEXTBOX.Text != "")
                {
                    parameters.Add("Offset", OFFSET_TEXTBOX.Text);
                }

                if (CHANGESKIN_CHECKBOX.Checked)
                {
                    parameters.Add("Skin", SKIN_COMBOBOX.Text);
                }

                // Write the config values
                ChangeConfigValue(osuFolder, parameters);

                // Launch osu!
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(osuFolder, "osu!.exe"),
                    WorkingDirectory = osuFolder,
                    Arguments = server == "Bancho" ? "" : "-devserver " + server
                };
                Process.Start(startInfo);

                // software tabからソフトウェアを起動
                foreach (var checkBox in SoftwareTab.Controls.OfType<CheckBox>())
                {
                    if (!checkBox.Checked) continue;
                    foreach (var software in _data["Softwares"])
                    {
                        if (software["Name"].ToString() != checkBox.Name) continue;
                        string softwarePath = Path.Combine(osuFolder, software["Path"].ToString());
                        if (!File.Exists(softwarePath)) return;
                        ProcessStartInfo softwareStartInfo = new ProcessStartInfo
                        {
                            FileName = softwarePath,
                            WorkingDirectory = Path.GetDirectoryName(softwarePath)
                        };
                        Process.Start(softwareStartInfo);
                    }
                }

                // Save the config file
                StreamWriter streamWriter =
                    new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
                streamWriter.WriteLine(_data.ToString());
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("osu! could not be launched. The reasons are as follows.\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Change the config values
        private static void ChangeConfigValue(string osuFolder, Dictionary<string, string> param)
        {
            try
            {
                string username = Environment.UserName;
                string path = Path.Combine(osuFolder, $"osu!.{username}.cfg");
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    string key = lines[i].Split('=')[0].Trim();
                    for (int j = 0; j < param.Count; j++)
                    {
                        if (key != param.ElementAt(j).Key) continue;
                        lines[i] = $"{param.ElementAt(j).Key} = {param.ElementAt(j).Value}";
                        break;
                    }
                }

                File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Add the value to the array
        public static void AddValueToArray<T>(ref IEnumerable<T> array, T value)
        {
            array = array.Append(value).ToArray();
        }

        // Delete the song folder
        private void DeleteSongFolder()
        {
            try
            {
                if (ArrayContains(_data["SongsFolder"].ToObject<string[]>(), SONGSFOLDER_COMBOBOX.Text))
                {
                    _data["SongsFolder"] = new JArray(_data["SongsFolder"].Where(item => item.ToString() != SONGSFOLDER_COMBOBOX.Text));
                    SONGSFOLDER_COMBOBOX.Items.Remove(SONGSFOLDER_COMBOBOX.Text);
                    SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
                    StreamWriter streamWriter = new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
                    streamWriter.WriteLine(_data.ToString());
                    streamWriter.Close();
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
                AddValueToArray(ref reasons, "❌️ Songs folder not found");
            }

            if (!Directory.Exists(OSUFOLDER_TEXTBOX.Text))
            {
                AddValueToArray(ref reasons, "❌️ osu! folder not found");
            }

            if (!File.Exists(Path.Combine(OSUFOLDER_TEXTBOX.Text, "osu!.exe")))
            {
                AddValueToArray(ref reasons, "❌️ osu!.exe not found in osu! folder");
            }

            if (WIDTH_TEXTBOX.Text != "")
            {
                var result = int.TryParse(WIDTH_TEXTBOX.Text, out int width);
                if (!result)
                {
                    AddValueToArray(ref reasons, "❌️ Width contains non-numeric characters");
                }

                if (width < 0)
                {
                    AddValueToArray(ref reasons, "❌️ Width must be greater than 0");
                }
            }

            if (HEIGHT_TEXTBOX.Text != "")
            {
                var result = int.TryParse(HEIGHT_TEXTBOX.Text, out int height);
                if (!result)
                {
                    AddValueToArray(ref reasons, "❌️ Height contains non-numeric characters");
                }

                if (height < 0)
                {
                    AddValueToArray(ref reasons, "❌️ Height must be greater than 0");
                }
            }

            if (SERVERS_COMBOBOX.Text != "Bancho" && SERVERS_COMBOBOX.Text == "")
            {
                AddValueToArray(ref reasons, "❌️ Server not selected");
            }

            return reasons;
        }

        // Load the software
        private void LoadSoftwares()
        {
            try
            {
                var enumerable = Softwares as Software[] ?? Softwares.ToArray();
                for (int i = 0; i < enumerable.Length; i++)
                {
                    GenerateSoftwaresTab(enumerable[i]);
                }

                int baseLocation = 69 * (SoftwareTab.Controls.OfType<CheckBox>().Count() + 1);
                var addSoftwareButton = new Button
                {
                    Text = "Add Software",
                    AutoSize = true,
                    Location = new System.Drawing.Point(20, baseLocation - 60),
                    Name = "AddSoftwareButton",
                    Size = new System.Drawing.Size(75, 23),
                    TabIndex = 0,
                    UseVisualStyleBackColor = true,
                    Font = new System.Drawing.Font(FontCollection.Families[1], 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
                };

                addSoftwareButton.Click += (sender, e) =>
                {
                    if (Application.OpenForms.OfType<AddSoftware>().Any()) return;
                    var addSoftwareForm = new AddSoftware(this);
                    addSoftwareForm.Show();
                    addSoftwareForm.FormClosed += (_object, _event) =>
                    {
                        SoftwareTab.Controls.Clear();
                        LoadSoftwares();
                    };
                };



                SoftwareTab.Controls.Add(addSoftwareButton);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The software could not be loaded. The reasons are as follows.\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateSoftwaresTab(Software software)
        {
            int baseLocation = 69 * (SoftwareTab.Controls.OfType<CheckBox>().Count() + 1);
            var checkBox = new CheckBox
            {
                Text = "",
                AutoSize = true,
                Location = new System.Drawing.Point(20, baseLocation - 44),
                Name = software.Name,
                Size = new System.Drawing.Size(15, 14),
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
                Location = new System.Drawing.Point(41, baseLocation - 66),
                Name = "label" + software.Name,
                TabIndex = 1,
                Text = software.Name,
                Font = new System.Drawing.Font(FontCollection.Families[1], 15)

            };

            int labelWidth = TextRenderer.MeasureText(softwareNameLabel.Text, softwareNameLabel.Font).Width;
            int label2Right = softwareNameLabel.Location.X + labelWidth - 3;

            var authorLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(label2Right, baseLocation - 60),
                Name = "label2" + software.Name,
                TabIndex = 1,
                Text = "by " + software.Author,
                Font = new System.Drawing.Font(FontCollection.Families[1], 11)
            };

            var descriptionLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(41, baseLocation - 39),
                Name = "label3" + software.Name,
                TabIndex = 1,
                Text = "Description: " + software.Description,
                Font = new System.Drawing.Font(FontCollection.Families[1], 12)
            };

            SoftwareTab.Controls.Add(checkBox);
            if (software.Checked) checkBox.Checked = true;
            SoftwareTab.Controls.Add(softwareNameLabel);
            SoftwareTab.Controls.Add(authorLabel);
            SoftwareTab.Controls.Add(descriptionLabel);
        }

        // Check if the array contains the value
        private static bool ArrayContains(IEnumerable<string> array, string value) => array.Any(item => item == value);

        // Delete the song folder
        private void SONGSFOLDER_DELETE_Click(object sender, EventArgs e)
        {
            if (SONGSFOLDER_COMBOBOX.Text == "Songs") return;
            var result = MessageBox.Show("Are you sure you want to delete the selected song folder?", "Delete Song Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) DeleteSongFolder();
        }

        // Open User Manager
        private void USERNAME_BUTTON_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<ProfileForm>().Any()) return;
            var profileForm = new ProfileForm(Profiles, OSUFOLDER_TEXTBOX.Text, this);
            profileForm.Show();

            // if the form is closed, update the profile
            profileForm.FormClosed += (_object, _event) =>
            {
                USERNAME_BUTTON.Text = CurrentProfile?.Name ?? "No Profile";
                HEIGHT_TEXTBOX.Text = CurrentProfile?.Height.ToString() ?? "";
                WIDTH_TEXTBOX.Text = CurrentProfile?.Width.ToString() ?? "";
                FULLSCREEN_CHECKBOX.Checked = CurrentProfile?.Fullscreen ?? false;
                METERSCALE_TEXTBOX.Text = CurrentProfile?.ScoreMeter.ToString() ?? "";
                METERSTYLE_COMBOBOX.SelectedIndex = CurrentProfile?.MeterStyle ?? 0;
                CHANGEAUDIO_CHECKBOX.Checked = CurrentProfile?.ChangeVolume ?? false;
                MASTER_BAR.Value = CurrentProfile?.VolumeMaster ?? 0;
                EFFECT_BAR.Value = CurrentProfile?.VolumeEffect ?? 0;
                AUDIO_BAR.Value = CurrentProfile?.VolumeMusic ?? 0;
                OFFSET_TEXTBOX.Text = CurrentProfile?.Offset.ToString() ?? "";
                CHANGESKIN_CHECKBOX.Checked = CurrentProfile?.ChangeSkin ?? false;
                if (CHANGESKIN_CHECKBOX.Checked) SKIN_COMBOBOX.Text = CurrentProfile?.Skin ?? "";
            };
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
                    SKIN_COMBOBOX.SelectedIndex = 0;
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
    }
}
