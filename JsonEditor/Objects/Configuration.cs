using System;
using System.Configuration;
using System.Windows.Forms;

namespace JsonEditor
{
    public class Configuration : ApplicationSettingsBase
    {
        private static Configuration m_configuration;

        private Configuration()
        { }

        public static Configuration GetInstance()
        {
            if (m_configuration == null)
            {
                m_configuration = new Configuration();
            }
            return m_configuration;
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Control, Shift")]
        public KeyboardHook.ModifierKeys ConversionHotKeyModifierKey
        {
            get
            {
                return (KeyboardHook.ModifierKeys)this["ConversionHotKeyModifierKey"];
            }
            set
            {
                this["ConversionHotKeyModifierKey"] = (KeyboardHook.ModifierKeys)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Space")]
        public Keys ConversionHotKeyMainKey
        {
            get
            {
                return (Keys)this["ConversionHotKeyMainKey"];
            }
            set
            {
                this["ConversionHotKeyMainKey"] = (Keys)value;
            }
        }

        public void SaveConfiguration()
        {
            ConfigurationUpdatedEventArgs eventArgs = new ConfigurationUpdatedEventArgs();
            OnConfigurationUpdated(eventArgs);
            Save();
        }

        protected virtual void OnConfigurationUpdated(ConfigurationUpdatedEventArgs e)
        {
            EventHandler<ConfigurationUpdatedEventArgs> handler = ConfigurationUpdatedHandler;
            if (handler != null)
            {
                handler(this, e);
                if (!e.Success)
                {
                    throw new InvalidOperationException(e.ErrorMessage);
                }
            }
        }

        public event EventHandler<ConfigurationUpdatedEventArgs> ConfigurationUpdatedHandler;
    }

    public class ConfigurationUpdatedEventArgs : EventArgs
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
