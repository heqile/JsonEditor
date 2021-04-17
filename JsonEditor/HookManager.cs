using System;

namespace JsonEditor
{
    public class HookManager
    {
        private KeyboardHook m_conversionShortcut;
        private EventHandler<KeyPressedEventArgs> m_conversionShortcutHandler;
        private readonly Configuration m_configuration;

        public HookManager(Configuration configuration)
        {
            m_configuration = configuration;
            m_configuration.ConfigurationUpdatedHandler += ConfigurationUpdatedHandler;
        }

        public void SetConversionShortcutHandler(EventHandler<KeyPressedEventArgs> handler)
        {
            m_conversionShortcutHandler = handler;
        }

        public void UpdateHook()
        {
            if (m_conversionShortcut != null)
            {
                m_conversionShortcut.Dispose();
            }
            m_conversionShortcut = new KeyboardHook();
            m_conversionShortcut.RegisterHotKey(
                m_configuration.ConversionShortcutModifierKey, m_configuration.ConversionShortcutMainKey);
            m_conversionShortcut.KeyPressed += m_conversionShortcutHandler;
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
