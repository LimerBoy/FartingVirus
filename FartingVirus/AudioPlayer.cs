using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace FartingVirus
{
    internal sealed class AudioPlayer
    {
        private const int SND_SYNC = 0x0000;    // play synchronously
        private const int SND_ASYNC = 0x0001;   // play asynchronously
        private const int SND_FILENAME = 0x00020000; // name is file name

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        public static void PlayWavFile(string fileName, bool async = true)
        {
            uint flags = (uint)(SND_FILENAME | (async ? SND_ASYNC : SND_SYNC));
            if (!PlaySound(fileName, IntPtr.Zero, flags))
            {
                throw new InvalidOperationException("Playback failed.");
            }
            Thread.Sleep(1000);
        }
    }
}
