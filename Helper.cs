using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace osu_launcher
{
    internal class Helper
    {
        public static void SetControlText(Control control, string text, string defaultText = "")
        {
            control.Text = text ?? defaultText;
        }

        public static void SetControlChecked(CheckBox checkBox, bool? isChecked)
        {
            checkBox.Checked = isChecked ?? false;
        }

        public static void SetControlValue(TrackBar trackBar, int value)
        {
            trackBar.Value = value;
        }

        public static void SetControlSelectedIndex(ListControl comboBox, int selectedIndex)
        {
            comboBox.SelectedIndex = selectedIndex;
        }

        public static void InitializeCefSharp()
        {
            var settings = new CefSettings
            {
                RootCachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };
            Cef.Initialize(settings);
        }

        public static void ValidateRequiredFiles()
        {
            if (!File.Exists("./src/Fonts/Quicksand-Light.ttf") || !File.Exists("./src/Fonts/NotoSansJP-Light.ttf"))
            {
                ShowErrorMessage("The font file was not found.");
                Environment.Exit(1);
            }

            if (!File.Exists("./src/data.json"))
            {
                ShowErrorMessage("The data file was not found.");
                Environment.Exit(1);
            }
        }

        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ArrayContains(IEnumerable<string> array, string value) => array.Any(item => item == value);

        public static void ChangeConfigValue(string osuFolder, Dictionary<string, string> param)
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

        public static void AddValueToArray<T>(ref IEnumerable<T> array, T value)
        {
            array = array.Append(value).ToArray();
        }

        public static void AddParameterIfNotEmpty(IDictionary<string, string> parameters, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                parameters.Add(key, value);
            }
        }

        public static bool IsEnglish(string text)
        {
            return text.All(c => c < 128);
        }
    }
}
