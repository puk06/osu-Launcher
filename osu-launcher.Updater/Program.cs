using System.Diagnostics;
using Octokit;

namespace osu_launcher.Updater
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    Console.WriteLine("バージョン情報が取得できませんでした。ソフト内から実行するようにしてください！");
                    Thread.Sleep(3000);
                    return;
                }

                var currentVersion = args[0];

                if (string.IsNullOrEmpty(currentVersion))
                {
                    Console.WriteLine("バージョン情報が取得できませんでした。ソフト内から実行するようにしてください！");
                    Thread.Sleep(3000);
                    return;
                }

                Console.WriteLine("アップデートを確認します。");

                var latestVersion = await GithubUpdateChecker(currentVersion);

                if (latestVersion == currentVersion)
                {
                    Console.WriteLine("最新バージョンです！ソフトを使ってくれてありがとうございます！");
                    Thread.Sleep(3000);
                    return;
                }

                Console.WriteLine($"最新バージョンが見つかりました({currentVersion} → {latestVersion})");
                Console.ReadLine();
                Console.WriteLine("osu-Launcher関係のソフトをすべて終了します。");

                var processes = Process.GetProcessesByName("osu-launcher");
                foreach (var process in processes)
                {
                    process.Kill();
                }

                Console.WriteLine("osu-Launcherを終了しました。アップデートを開始します。");
                var updater = new Classes.Updater(latestVersion);

                await updater.Update();

                Console.WriteLine("アップデートが完了しました！ソフトを使ってくれてありがとうございます！");
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                Console.WriteLine("アップデート中にエラーが発生しました: " + e.Message);
                Thread.Sleep(3000);
            }
        }

        private static async Task<string> GithubUpdateChecker(string currentVersion)
        {
            var latestRelease = await GetVersion(currentVersion);
            return latestRelease == currentVersion ? currentVersion : latestRelease;
        }

        private static async Task<string> GetVersion(string currentVersion)
        {
            var releaseType = currentVersion.Split('-')[1];
            var githubClient = new GitHubClient(new ProductHeaderValue("osu-Launcher"));
            var tags = await githubClient.Repository.GetAllTags("puk06", "osu-Launcher");
            string latestVersion = currentVersion;
            foreach (var tag in tags)
            {
                if (releaseType == "Release")
                {
                    if (tag.Name.Split('-')[1] != "Release") continue;
                    latestVersion = tag.Name;
                    break;
                }

                latestVersion = tag.Name;
                break;
            }

            return latestVersion;
        }
    }
}