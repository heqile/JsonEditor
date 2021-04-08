using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace JsonEditor
{
    public class WindowManager
    {

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(System.Drawing.Point p);
        [DllImport("User32.dll")]
        static extern IntPtr SetForegroundWindow(IntPtr point);
        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();

        public void SetFocusedHandleForeground()
        {
            Point cursorPoint;
            GetCursorPos(out cursorPoint);
            IntPtr cursorHandle = WindowFromPoint(cursorPoint);
            SetForegroundWindow(cursorHandle);
        }

        public bool IsMainWindowFocused()
        {
            Point cursorPoint;
            GetCursorPos(out cursorPoint);
            IntPtr cursorHandle = WindowFromPoint(cursorPoint);
            IntPtr focusedHandle = GetFocus();
            return cursorHandle == focusedHandle;
        }
    }
}
