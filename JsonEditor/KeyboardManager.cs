using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class KeyboardManager
    {
        public const UInt32 KEYEVENTF_KEYDOWN = 0x0;
        public const UInt32 KEYEVENTF_KEYUP = 0x2;
        public const UInt32 VK_SHIFT = 0x10;
        public const UInt32 VK_CONTROL = 0x11;
        public const UInt32 VK_MENU = 0x12;
        public const UInt32 WM_KEYDOWN = 0x0100;
        public const UInt32 WM_COPY = 0x0301;
        public const UInt32 WM_PASTE = 0x0302;
        public const UInt32 WM_KEYUP = 0x0101;
        public const UInt32 WM_CHAR = 0x0102;


        [DllImport("user32.dll")]
        static extern void keybd_event(UInt32 bVk, UInt32 bScan, UInt32 dwFlags, UInt32 dwExtraInfo);

        public void SendCopyCommand()
        {
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(0x43, 0, KEYEVENTF_KEYDOWN, 0); //Send the C key
            keybd_event(0x43, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
            
            Task.Delay(150).Wait();
        }

        public void SendPasteCommand()
        {
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, 0);
            keybd_event(0x56, 0, KEYEVENTF_KEYDOWN, 0); //Send the V key
            keybd_event(0x56, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
            
            Task.Delay(100).Wait();
        }
    }
}
