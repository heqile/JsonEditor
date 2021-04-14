using System;
using System.Windows.Forms;

namespace JsonEditor
{
    public class HookManager
    {
        private KeyboardHook m_conversionShortcut = new KeyboardHook();

        public HookManager()
        {
            m_conversionShortcut.RegisterHotKey(KeyboardHook.ModifierKeys.Control | KeyboardHook.ModifierKeys.Shift, Keys.Space);
        }

        public void SetConversionShortcutHandler(EventHandler<KeyPressedEventArgs> handler)
        {
            m_conversionShortcut.KeyPressed += handler;
        }
    }
}
