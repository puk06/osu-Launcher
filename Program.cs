using System;
using System.Windows.Forms;
using osu_launcher.Forms;

namespace osu_launcher
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Program could not be launched. The reasons are as follows.\n" + ex, "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
