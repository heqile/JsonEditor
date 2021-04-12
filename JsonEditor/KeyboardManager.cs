using System;
using System.Runtime.InteropServices;

namespace JsonEditor
{
    public class KeyboardManager
    {
        public const UInt32 KEYEVENTF_KEYDOWN = 0x0;
        public const UInt32 KEYEVENTF_KEYUP = 0x2;
        public const UInt32 VK_CONTROL = 0x11;

        public void SendCopyCommand()
        {
            NativeMethods.keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, 0);
            NativeMethods.keybd_event(0x43, 0, KEYEVENTF_KEYDOWN, 0); //Send the C key
            NativeMethods.keybd_event(0x43, 0, KEYEVENTF_KEYUP, 0);
            NativeMethods.keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        }

        public void SendPasteCommand()
        {
            NativeMethods.keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, 0);
            NativeMethods.keybd_event(0x56, 0, KEYEVENTF_KEYDOWN, 0); //Send the V key
            NativeMethods.keybd_event(0x56, 0, KEYEVENTF_KEYUP, 0);
            NativeMethods.keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        }

        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern void keybd_event(UInt32 bVk, UInt32 bScan, UInt32 dwFlags, UInt32 dwExtraInfo);
        }
    }
}
