using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class WindowManager
    {
        private Configuration m_configuration;
        private IntPtr m_previousForegroundWindow;

        public WindowManager()
        { }

        public WindowManager(Configuration configuration)
        {
            m_configuration = configuration;
        }

        virtual public void SetFocusedWindowForeground()
        {
            NativeMethods.GetCursorPos(out Point cursorPoint);
            IntPtr cursorHandle = NativeMethods.WindowFromPoint(cursorPoint);
            if (cursorHandle != m_previousForegroundWindow)
            {
                NativeMethods.SetForegroundWindow(cursorHandle);
                m_previousForegroundWindow = cursorHandle;
            }
            Task.Delay((int)m_configuration.WaitWindowReadyMs).Wait();  // wait window ready to receive key press
        }

        virtual public bool IsMainWindowFocused()
        {
            NativeMethods.GetCursorPos(out Point cursorPoint);
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
