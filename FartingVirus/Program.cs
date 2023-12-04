using System;
using System.Threading;

namespace FartingVirus
{
    internal sealed class Program
    {
        public static void Main(string[] args)
        {
            int timeout = 120; // Fart every N seconds

            // Init random provider
            Random random = new Random();
            // Download all available sounds
            string[] availableSounds = Downloader.DownloadAll();

           
            // Infinite loop
            while (true)
            {
                // Increse volume level
                for (int i = 0; i < 100; i++)
                {
                    VolumeController.VolumeUp();
                }

                // Get random sound file
                string randomSound = availableSounds[random.Next(0, availableSounds.Length)];

                // Play it
                AudioPlayer.PlayWavFile(randomSound);
                
                // Wait
                Thread.Sleep(timeout * 1000);
            }
            
            
        }
    }
}
