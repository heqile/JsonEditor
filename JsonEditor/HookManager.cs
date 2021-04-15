﻿using System;
using System.Windows.Forms;

namespace JsonEditor
{
    public class HookManager
    {
        private KeyboardHook m_conversionShortcut;
        private EventHandler<KeyPressedEventArgs> m_conversionShortcutHandler;
        private Configuration m_configuration = Configuration.GetInstance();

        public HookManager()
        {
            m_configuration.ConfigurationUpdatedHandler += ConfigurationUpdated;
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

        public void ConfigurationUpdated(object sender, EventArgs e)
        {
            UpdateHook();
        }
    }
}
