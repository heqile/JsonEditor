using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace JsonEditor
{
    public class WindowManager
    {
        private IntPtr m_previousForegroundWindow;

        public void SetFocusedWindowForeground()
        {
            Point cursorPoint;
            NativeMethods.GetCursorPos(out cursorPoint);
            IntPtr cursorHandle = NativeMethods.WindowFromPoint(cursorPoint);
            if (cursorHandle != m_previousForegroundWindow) 
            {
                NativeMethods.SetForegroundWindow(cursorHandle);
                m_previousForegroundWindow = cursorHandle;
            }
        }

        public bool IsMainWindowFocused()
        {
            Point cursorPoint;
            NativeMethods.GetCursorPos(out cursorPoint);
            IntPtr cursorHandle = NativeMethods.WindowFromPoint(cursorPoint);
            IntPtr focusedHandle = NativeMethods.GetFocus();
            return cursorHandle == focusedHandle;
        }
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern bool GetCursorPos(out Point lpPoint);
            [DllImport("user32.dll")]
            internal static extern IntPtr WindowFromPoint(System.Drawing.Point p);
            [DllImport("User32.dll")]
            internal static extern IntPtr SetForegroundWindow(IntPtr point);
            [DllImport("user32.dll")]
            internal static extern IntPtr GetFocus();
        }
    }

}
