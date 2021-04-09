﻿using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class KeyboardManager
    {
        public const UInt32 KEYEVENTF_KEYDOWN = 0x0;
        public const UInt32 KEYEVENTF_KEYUP = 0x2;
        public const UInt32 VK_CONTROL = 0x11;


        public void SendCopyCommand()
        {
            Task.Delay(200).Wait();  // keep long for applications like chrome or visualstudio
            NativeMethods.keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, 0);
            NativeMethods.keybd_event(0x43, 0, KEYEVENTF_KEYDOWN, 0); //Send the C key
            NativeMethods.keybd_event(0x43, 0, KEYEVENTF_KEYUP, 0);
            NativeMethods.keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
            Task.Delay(150).Wait();
        }

        public void SendPasteCommand()
        {
            Task.Delay(50).Wait();
            NativeMethods.keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYDOWN, 0);
            NativeMethods.keybd_event(0x56, 0, KEYEVENTF_KEYDOWN, 0); //Send the V key
            NativeMethods.keybd_event(0x56, 0, KEYEVENTF_KEYUP, 0);
            NativeMethods.keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
            Task.Delay(100).Wait();
        }

        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern void keybd_event(UInt32 bVk, UInt32 bScan, UInt32 dwFlags, UInt32 dwExtraInfo);
        }
    }
}
