using CefSharp;
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

        // Users
        public IEnumerable<User> Users = new User[] { };

        // Current User
        public User CurrentUser;

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

                // Set the font
                SetFont();

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
                if (_data["Servers"] != null)
                {
                    foreach (var server in _data["Servers"])
                    {
                        SERVERS_COMBOBOX.Items.Add(server);
                    }

                    if (SERVERS_COMBOBOX.Items.Count > 0) SERVERS_COMBOBOX.SelectedIndex = 0;
                }
                else
                {
                    SERVERS_COMBOBOX.Items.Add("Bancho");
                    SERVERS_COMBOBOX.Items.Add("mamesosu.net");
                    SERVERS_COMBOBOX.SelectedIndex = 0;
                    _data.Add("Servers", new JArray("Bancho", "mamesosu.net"));
                }

                if (_data["SongsFolder"] != null)
                {
                    foreach (var songFolder in _data["SongsFolder"])
                    {
                        SONGSFOLDER_COMBOBOX.Items.Add(songFolder);
                    }

                    if (SONGSFOLDER_COMBOBOX.Items.Count > 0) SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
                }
                else
                {
                    SONGSFOLDER_COMBOBOX.Items.Add("Songs");
                    SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
                    _data.Add("SongsFolder", new JArray("Songs"));
                }

                if (_data["Username"] != null)
                {
                    foreach (var userdata in _data["Username"])
                    {
                        var user = new User
                        {
                            Username = userdata["Username"].ToString(),
                            Password = userdata["Password"].ToString()
                        };
                        AddValueToArray(ref Users, user);
                    }
                    USERNAME_BUTTON.Text = Users.First().Username;
                }
                else
                {
                    _data.Add("Username", new JArray());
                }

                if (_data["osuFolder"] != null)
                {
                    OSUFOLDER_TEXTBOX.Text = _data["osuFolder"].ToString();
                }
                else
                {
                    OSUFOLDER_TEXTBOX.Text = "";
                    _data.Add("osuFolder", "");
                }

                if (OSUFOLDER_TEXTBOX.Text == "")
                {
                    MessageBox.Show("The osu! folder is not set. Please set it from the Settings tab!!", "Error", MessageBoxButtons.OK,
                                               MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("osu-Launcher could not be launched. The reasons are as follows.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Set the font
        private void SetFont()
        {
            TopTab.Font = new System.Drawing.Font(FontCollection.Families[1], 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OSUFOLDER_LABEL.Font = new System.Drawing.Font(FontCollection.Families[1], 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SERVER_LABEL.Font = new System.Drawing.Font(FontCollection.Families[1], 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SONGSFOLDER_DELETE.Font = new System.Drawing.Font(FontCollection.Families[1], 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            USERNAME_LABEL.Font = new System.Drawing.Font(FontCollection.Families[1], 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RESOLUTION_LABEL.Font = new System.Drawing.Font(FontCollection.Families[1], 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SONGSFOLDER_LABEL.Font = new System.Drawing.Font(FontCollection.Families[1], 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LAUNCH_BUTTON.Font = new System.Drawing.Font(FontCollection.Families[1], 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MainTab.Font = new System.Drawing.Font(FontCollection.Families[1], 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            USERNAME_BUTTON.Font = new System.Drawing.Font(FontCollection.Families[0], 15.75F);
            SONGSFOLDER_COMBOBOX.Font = new System.Drawing.Font(FontCollection.Families[0], 15.75F);
            OSUFOLDER_TEXTBOX.Font = new System.Drawing.Font(FontCollection.Families[0], 15.75F);
            WIDTH_TEXTBOX.Font = new System.Drawing.Font(FontCollection.Families[0], 14F);
            HEIGHT_TEXTBOX.Font = new System.Drawing.Font(FontCollection.Families[0], 14F);
            SERVERS_COMBOBOX.Font = new System.Drawing.Font(FontCollection.Families[0], 15.75F);
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

                _data["Username"] = new JArray();
                foreach (var user in Users)
                {
                    (_data["Username"] as JArray).Add(new JObject
                    {
                        { "Username", user.Username },
                        { "Password", user.Password }
                    });
                }

                _data["osuFolder"] = osuFolder;

                // Change the config values
                ChangeConfigValue(osuFolder, songFolder, HEIGHT_TEXTBOX.Text, WIDTH_TEXTBOX.Text);

                // Launch osu!
                Process.Start(Path.Combine(osuFolder, "osu!.exe"), server == "Bancho" ? "" : "-devserver " + server);

                // Save the config file
                StreamWriter streamWriter =
                    new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
                streamWriter.WriteLine(_data.ToString());
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("osu! could not be launched. The reasons are as follows.\n" + ex, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Change the config values
        private void ChangeConfigValue(string osuFolder, string songsFolder, string height, string width)
        {
            string username = Environment.UserName;
            string path = Path.Combine(osuFolder, $"osu!.{username}.cfg");

            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("BeatmapDirectory = ")) lines[i] = $"BeatmapDirectory = {songsFolder}";
                if (height != "" && FULLSCREEN_CHECKBOX.Checked && lines[i].Contains("HeightFullscreen = ")) lines[i] = "HeightFullscreen = " + height;
                if (width != "" && FULLSCREEN_CHECKBOX.Checked && lines[i].Contains("WidthFullscreen = ")) lines[i] = "WidthFullscreen = " + width;
                if (height != "" && !FULLSCREEN_CHECKBOX.Checked && lines[i].Contains("Height = ")) lines[i] = "Height = " + height;
                if (width != "" && !FULLSCREEN_CHECKBOX.Checked && lines[i].Contains("Width = ")) lines[i] = "Width = " + width;
            }
            File.WriteAllLines(path, lines);
        }

        // Delete the song folder
        private void SONGSFOLDER_DELETE_Click(object sender, EventArgs e)
        {
            if (SONGSFOLDER_COMBOBOX.Text == "Songs") return;
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

        // Check if the values are valid
        private IEnumerable<string> CheckValue()
        {
            IEnumerable<string> reasons = new string[] { };
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

            if (HEIGHT_TEXTBOX.Text != "" && !int.TryParse(HEIGHT_TEXTBOX.Text, out int _))
            {
                AddValueToArray(ref reasons, "❌️ Height contains non-numeric characters");
            }

            if (WIDTH_TEXTBOX.Text != "" && !int.TryParse(WIDTH_TEXTBOX.Text, out int _))
            {
                AddValueToArray(ref reasons, "❌️ Width contains non-numeric characters");
            }

            if (SERVERS_COMBOBOX.Text != "Bancho" && SERVERS_COMBOBOX.Text == "")
            {
                AddValueToArray(ref reasons, "❌️ Server not selected");
            }

            return reasons;
        }

        // Add the value to the array
        private static void AddValueToArray<T>(ref IEnumerable<T> array, T value)
        {
            array = array.Append(value).ToArray();
        }

        // Check if the array contains the value
        private static bool ArrayContains(IEnumerable<string> array, string value) => array.Any(item => item == value);

        // Open User Manager
        private void USERNAME_BUTTON_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<UserForm>().Any()) return;
            var userForm = new UserForm(Users, this);
            userForm.Show();

            // if the form is closed, update the username
            userForm.FormClosed += (senderi, ei) =>
            {
                if (CurrentUser != null)
                {
                    USERNAME_BUTTON.Text = CurrentUser.Username;
                }
            };
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
