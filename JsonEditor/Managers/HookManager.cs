using System;

namespace JsonEditor
{
    public class HookManager
    {
        private KeyboardHook m_conversionHotKey;
        private EventHandler<KeyPressedEventArgs> m_conversionHotKeyHandler;
        private readonly Configuration m_configuration;
        
        public HookManager()
        { }

        public HookManager(Configuration configuration)
        {
            m_configuration = configuration;
            m_configuration.ConfigurationUpdatedHandler += ConfigurationUpdatedHandler;
        }

        virtual public void SetConversionHotKeyHandler(EventHandler<KeyPressedEventArgs> handler)
        {
            m_conversionHotKeyHandler = handler;
        }

        virtual public void UpdateHook()
        {
            if (m_conversionHotKey != null)
            {
                m_conversionHotKey.Dispose();
            }
            m_conversionHotKey = new KeyboardHook();
            m_conversionHotKey.RegisterHotKey(
                m_configuration.IndentedFormattingConversionHotKeyModifierKey, m_configuration.IndentedFormattingConversionHotKeyMainKey);
            m_conversionHotKey.KeyPressed += m_conversionHotKeyHandler;
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
