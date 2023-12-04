using System.Runtime.InteropServices;

namespace FartingVirus
{
    internal sealed class VolumeController
    {
        // Virtual-Key Codes
        /*
        private const byte VK_VOLUME_MUTE = 0xAD;
        private const byte VK_VOLUME_DOWN = 0xAE;
        */
        private const byte VK_VOLUME_UP = 0xAF;

        // Keybd_event Flags
        private const int KEYEVENTF_EXTENDEDKEY = 0x1;
        private const int KEYEVENTF_KEYUP = 0x2;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void VolumeUp()
        {
            // Simulate key press and release
            keybd_event(VK_VOLUME_UP, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_VOLUME_UP, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        /*
        public static void VolumeDown()
        {
            // Simulate key press and release
            keybd_event(VK_VOLUME_DOWN, 0, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_VOLUME_DOWN, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        */
    }
}
