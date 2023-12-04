using System;
using System.IO;
using System.Net;

namespace FartingVirus
{
    internal sealed class Downloader
    {
        private static string TempDirectory = Path.Combine(Path.GetTempPath(), "FartSounds");

        private static int[] SoundIds = new int[]
        {
            86105,
            46773,
            46739,
            46778,
            46754,
            46744,
            46755,
        };



        /// <summary>
        /// Download all availble sound files
        /// </summary>
        /// <returns>Path's to files</returns>
        public static string[] DownloadAll()
        {
            foreach (int identifier in SoundIds)
            {
                try
                {
                    DownloadSound(identifier);
                } catch (Exception ex)
                {
                    Console.WriteLine("Sound download failed: " + ex.ToString());
                }
            }
            return Directory.GetFiles(TempDirectory, "*.wav");
        }

        /// <summary>
        /// Download sound by it's identifier
        /// </summary>
        /// <param name="identifier">Sound id</param>
        private static void DownloadSound(int identifier)
        {
            // Create temp dir if not exists
            if (!Directory.Exists(TempDirectory))
            {
                Directory.CreateDirectory(TempDirectory);
            }
            string filePath = Path.Combine(TempDirectory, identifier + ".wav");
            // Download sound file if not exists
            if (!File.Exists(filePath))
            {
                string endpoint = string.Format("https://zvukogram.com/index.php?r=site/download&id={0}&type=wav", identifier);
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(endpoint, filePath);
                }
            }
        }

    }
}
