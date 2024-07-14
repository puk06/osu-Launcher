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
        // Config Values
        private readonly JObject _configFiles;

        // Form Font
        private readonly PrivateFontCollection _fontCollection = new PrivateFontCollection();

        // Constructor
        public Main()
        {
            var settings = new CefSettings
            {
                RootCachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };
            Cef.Initialize(settings);

            if (!File.Exists("./src/Fonts/Quicksand-Light.ttf") || !File.Exists("./src/Fonts/NotoSansJP-Light.ttf"))
            {
                MessageBox.Show("フォントファイルが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            if (!File.Exists("./src/data.json"))
            {
                MessageBox.Show("設定ファイルが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            _fontCollection.AddFontFile("./src/Fonts/Quicksand-Light.ttf");
            _fontCollection.AddFontFile("./src/Fonts/NotoSansJP-Light.ttf");
            InitializeComponent();
            SetFont();
            var webBrowser = new ChromiumWebBrowser("https://osu.ppy.sh/home/news");
            TopTab.Controls.Add(webBrowser);
            webBrowser.Dock = DockStyle.Fill;

            StreamReader streamReader = new StreamReader("./src/data.json", Encoding.GetEncoding("Shift_JIS"));
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            _configFiles = JObject.Parse(str);

            if (_configFiles["Servers"] != null)
            {
                foreach (var server in _configFiles["Servers"])
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
                _configFiles.Add("Servers", new JArray("Bancho", "mamesosu.net"));
            }

            if (_configFiles["SongsFolder"] != null)
            {
                foreach (var songFolder in _configFiles["SongsFolder"])
                {
                    SONGSFOLDER_COMBOBOX.Items.Add(songFolder);
                }
                if (SONGSFOLDER_COMBOBOX.Items.Count > 0) SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
            }
            else
            {
                SONGSFOLDER_COMBOBOX.Items.Add("Songs");
                SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
                _configFiles.Add("SongsFolder", new JArray("Songs"));
            }

            if (_configFiles["Username"] != null)
            {
                foreach (var username in _configFiles["Username"])
                {
                    USERNAME_COMBOBOX.Items.Add(username);
                }
                if (USERNAME_COMBOBOX.Items.Count > 0) USERNAME_COMBOBOX.SelectedIndex = 0;
            }

            if (_configFiles["osuFolder"] != null)
            {
                OSUFOLDER_TEXTBOX.Text = _configFiles["osuFolder"].ToString();
            }
            else
            {
                OSUFOLDER_TEXTBOX.Text = "";
                _configFiles.Add("osuFolder", "");
            }

            if (OSUFOLDER_TEXTBOX.Text == "")
            {
                MessageBox.Show("osu!フォルダが設定されていません。Settingsタブから設定してください！！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Set the font
        private void SetFont()
        {
            TopTab.Font = new System.Drawing.Font(_fontCollection.Families[1], 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OSUFOLDER_LABEL.Font = new System.Drawing.Font(_fontCollection.Families[1], 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SERVER_LABEL.Font = new System.Drawing.Font(_fontCollection.Families[1], 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SONGSFOLDER_DELETE.Font = new System.Drawing.Font(_fontCollection.Families[1], 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            USERNAME_LABEL.Font = new System.Drawing.Font(_fontCollection.Families[1], 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RESOLUTION_LABEL.Font = new System.Drawing.Font(_fontCollection.Families[1], 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SONGSFOLDER_LABEL.Font = new System.Drawing.Font(_fontCollection.Families[1], 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LAUNCH_BUTTON.Font = new System.Drawing.Font(_fontCollection.Families[1], 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MainTab.Font = new System.Drawing.Font(_fontCollection.Families[1], 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            USERNAME_COMBOBOX.Font = new System.Drawing.Font(_fontCollection.Families[0], 15.75F);
            SONGSFOLDER_COMBOBOX.Font = new System.Drawing.Font(_fontCollection.Families[0], 15.75F);
            OSUFOLDER_TEXTBOX.Font = new System.Drawing.Font(_fontCollection.Families[0], 15.75F);
            WIDTH_TEXTBOX.Font = new System.Drawing.Font(_fontCollection.Families[0], 14F);
            HEIGHT_TEXTBOX.Font = new System.Drawing.Font(_fontCollection.Families[0], 14F);
            SERVERS_COMBOBOX.Font = new System.Drawing.Font(_fontCollection.Families[0], 15.75F);
        }

        // Launch osu!
        private void LAUNCH_BUTTON_Click(object sender, EventArgs e)
        {
            // Check if the values are valid
            string[] reasons = CheckValue();
            if (reasons.Length > 0)
            {
                MessageBox.Show("osu!を起動できませんでした。理由は以下の通りです。\n" + string.Join("\n", reasons), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the values
            string server = SERVERS_COMBOBOX.Text;
            string songFolder = SONGSFOLDER_COMBOBOX.Text;
            string username = USERNAME_COMBOBOX.Text;
            string osuFolder = OSUFOLDER_TEXTBOX.Text;

            // Add the values to the config file
            if (!ArrayContains(_configFiles["Servers"].ToObject<string[]>(), server))
            {
                SERVERS_COMBOBOX.Items.Add(server);
                _configFiles["Servers"].Last.AddAfterSelf(server);
            }

            if (!ArrayContains(_configFiles["SongsFolder"].ToObject<string[]>(), songFolder))
            {
                SONGSFOLDER_COMBOBOX.Items.Add(songFolder);
                _configFiles["SongsFolder"].Last.AddAfterSelf(songFolder);
            }

            if (username != "" && (_configFiles["Username"] == null || !ArrayContains(_configFiles["Username"].ToObject<string[]>(), username)))
            {
                if (_configFiles["Username"] == null) _configFiles.Add("Username", new JArray(username));
                else _configFiles["Username"].Last.AddAfterSelf(username);
                USERNAME_COMBOBOX.Items.Add(username);
            }
            if (username != "") Clipboard.SetText(username);

            _configFiles["osuFolder"] = osuFolder;

            // Change the config values
            ChangeConfigValue(osuFolder, songFolder, HEIGHT_TEXTBOX.Text, WIDTH_TEXTBOX.Text);

            // Launch osu!
            Process.Start(Path.Combine(osuFolder, "osu!.exe"), server == "Bancho" ? "" : "-devserver " + server);

            // Save the config file
            StreamWriter streamWriter = new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
            streamWriter.WriteLine(_configFiles.ToString());
            streamWriter.Close();
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
            if (ArrayContains(_configFiles["SongsFolder"].ToObject<string[]>(), SONGSFOLDER_COMBOBOX.Text))
            {
                _configFiles["SongsFolder"] = new JArray(_configFiles["SongsFolder"].Where(item => item.ToString() != SONGSFOLDER_COMBOBOX.Text));
                SONGSFOLDER_COMBOBOX.Items.Remove(SONGSFOLDER_COMBOBOX.Text);
                SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
                StreamWriter streamWriter = new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
                streamWriter.WriteLine(_configFiles.ToString());
                streamWriter.Close();
            }
            else
            {
                SONGSFOLDER_COMBOBOX.SelectedIndex = 0;
            }
        }

        // Check if the values are valid
        private string[] CheckValue()
        {
            string[] reasons = Array.Empty<string>();
            if (!Directory.Exists(SONGSFOLDER_COMBOBOX.Text) && SONGSFOLDER_COMBOBOX.Text != "Songs")
            {
                AddValueToArray(ref reasons, "❌️ Songsフォルダが見つかりませんでした");
            }

            if (!Directory.Exists(OSUFOLDER_TEXTBOX.Text))
            {
                AddValueToArray(ref reasons, "❌️ osu!フォルダが見つかりませんでした");
            }

            if (!File.Exists(Path.Combine(OSUFOLDER_TEXTBOX.Text, "osu!.exe")))
            {
                AddValueToArray(ref reasons, "❌️ osu!フォルダからosu!.exeが見つかりませんでした");
            }

            if (HEIGHT_TEXTBOX.Text != "" && !int.TryParse(HEIGHT_TEXTBOX.Text, out int _))
            {
                AddValueToArray(ref reasons, "❌️ Heightに数字以外が入力されています");
            }

            if (WIDTH_TEXTBOX.Text != "" && !int.TryParse(WIDTH_TEXTBOX.Text, out int _))
            {
                AddValueToArray(ref reasons, "❌️ Widthに数字以外が入力されています");
            }

            if (SERVERS_COMBOBOX.Text != "Bancho" && SERVERS_COMBOBOX.Text == "")
            {
                AddValueToArray(ref reasons, "❌️ サーバーが選択されていません");
            }

            return reasons;
        }

        // Add the value to the array
        private static void AddValueToArray(ref string[] array, string value)
        {
            array = array.Append(value).ToArray();
        }

        // Check if the array contains the value
        private static bool ArrayContains(IEnumerable<string> array, string value) => array.Any(item => item == value);
    }
}
