using System;
using CefSharp.WinForms;
using System.Drawing.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using CefSharp;

namespace osu_launcher
{
    public partial class Main : Form
    {
        private readonly JObject _configFiles;
        private readonly PrivateFontCollection _fontCollection = new PrivateFontCollection();

        public Main()
        {
            var settings = new CefSettings
            {
                RootCachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };
            Cef.Initialize(settings);
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

        private void LAUNCH_BUTTON_Click(object sender, System.EventArgs e)
        {
            string[] reasons = CheckValue();
            if (reasons.Length > 0)
            {
                MessageBox.Show("osu!を起動できませんでした。理由は以下の通りです。\n" + string.Join("\n", reasons), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string server = SERVERS_COMBOBOX.Text;
            string songFolder = SONGSFOLDER_COMBOBOX.Text;
            string username = USERNAME_COMBOBOX.Text;
            string osuFolder = OSUFOLDER_TEXTBOX.Text;

            if (!ArrayContains(_configFiles["Servers"].ToObject<string[]>(), server))
            {
                SERVERS_COMBOBOX.Items.Add(server);
                _configFiles["Servers"].Last.AddAfterSelf(server);
            }

            if (songFolder != "Songs" && !Directory.Exists(songFolder))
            {
                MessageBox.Show("Songsフォルダが見つかりませんでした。");
                return;
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
            ChangeConfigValue(osuFolder, songFolder, HEIGHT_TEXTBOX.Text, WIDTH_TEXTBOX.Text);
            Process.Start(Path.Combine(osuFolder, "osu!.exe"), server == "Bancho" ? "" : server);
            StreamWriter streamWriter = new StreamWriter("./src/data.json", false, Encoding.GetEncoding("Shift_JIS"));
            streamWriter.WriteLine(_configFiles.ToString());
            streamWriter.Close();
        }

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

        private string[] CheckValue()
        {
            string[] reasons = { };
            if (!Directory.Exists(SONGSFOLDER_COMBOBOX.Text) && SONGSFOLDER_COMBOBOX.Text != "Songs")
            {
                reasons = reasons.Append("❌️ Songsフォルダが見つかりませんでした").ToArray();
            }

            if (!Directory.Exists(OSUFOLDER_TEXTBOX.Text))
            {
                reasons = reasons.Append("❌️ osu!フォルダが見つかりませんでした").ToArray();
            }

            if (!File.Exists(Path.Combine(OSUFOLDER_TEXTBOX.Text, "osu!.exe")))
            {
                reasons = reasons.Append("❌️ osu!フォルダからosu!.exeが見つかりませんでした").ToArray();
            }

            if (HEIGHT_TEXTBOX.Text != "" && !int.TryParse(HEIGHT_TEXTBOX.Text, out int _))
            {
                reasons = reasons.Append("❌️ Heightに数字以外が入力されています").ToArray();
            }

            if (WIDTH_TEXTBOX.Text != "" && !int.TryParse(WIDTH_TEXTBOX.Text, out int _))
            {
                reasons = reasons.Append("❌️ Widthに数字以外が入力されています").ToArray();
            }

            if (SERVERS_COMBOBOX.Text != "Bancho" && SERVERS_COMBOBOX.Text == "")
            {
                reasons = reasons.Append("❌️ サーバーが選択されていません").ToArray();
            }

            return reasons;
        }

        private static bool ArrayContains(IEnumerable<string> array, string value) => array.Any(item => item == value);
    }
}
