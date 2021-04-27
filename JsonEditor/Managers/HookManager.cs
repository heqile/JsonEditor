using System;
using System.Windows.Forms;

namespace JsonEditor
{
    public class HookManager
    {
        private KeyboardHook m_indentedFormattingHotKey;
        private EventHandler<KeyPressedEventArgs> m_indentedFormattingHotKeyHandler;
        private KeyboardHook m_compactFormattingHotKey;
        private EventHandler<KeyPressedEventArgs> m_compactFormattingHotKeyHandler;
        private readonly Configuration m_configuration;
        
        public HookManager()
        { }

        public HookManager(Configuration configuration)
        {
            m_configuration = configuration;
            m_configuration.ConfigurationUpdatedHandler += ConfigurationUpdatedHandler;
        }

        virtual public void SetConversionHotKeyHandler(
            EventHandler<KeyPressedEventArgs> indentedFormattingHotKeyHandler,
            EventHandler<KeyPressedEventArgs> compactFormattingHotKeyHandler
        )
        {
            m_indentedFormattingHotKeyHandler = indentedFormattingHotKeyHandler;
            m_compactFormattingHotKeyHandler = compactFormattingHotKeyHandler;
        }

        virtual public void UpdateHook()
        {
            UpdatingHook(ref m_indentedFormattingHotKey, m_indentedFormattingHotKeyHandler,
                m_configuration.IndentedFormattingConversionHotKeyModifierKey, m_configuration.IndentedFormattingConversionHotKeyMainKey);
            UpdatingHook(ref m_compactFormattingHotKey, m_compactFormattingHotKeyHandler,
                m_configuration.CompactFormattingConversionHotKeyModifierKey, m_configuration.CompactFormattingConversionHotKeyMainKey);
        }

        private void UpdatingHook(ref KeyboardHook hook, EventHandler<KeyPressedEventArgs> handler, KeyboardHook.ModifierKeys modifierKeys, Keys mainKeys)
        {
            if (modifierKeys == KeyboardHook.ModifierKeys.None || mainKeys == Keys.None)
            {
                return;
            }

            if (hook != null)
            {
                hook.Dispose();
            }
            hook = new KeyboardHook();
            hook.RegisterHotKey(modifierKeys, mainKeys);
            hook.KeyPressed += handler;
        }

        public void ConfigurationUpdatedHandler(object sender, ConfigurationUpdatedEventArgs e)
        {
            try
            {
                UpdateHook();
                e.Success = true;
            }
            catch (Exception exc)
            {
                e.Success = false;
                e.ErrorMessage = exc.Message;
            }
        }
    }
}
