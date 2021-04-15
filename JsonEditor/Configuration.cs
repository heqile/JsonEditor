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
                return new Configuration();
            }
            return m_configuration;
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Control, Shift")]
        public KeyboardHook.ModifierKeys ConversionShortcutModifierKey
        {
            get
            {
                return (KeyboardHook.ModifierKeys)this["ConversionShortcutModifierKey"];
            }
            set
            {
                this["ConversionShortcutModifierKey"] = (KeyboardHook.ModifierKeys)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Space")]
        public Keys ConversionShortcutMainKey
        {
            get
            {
                return (Keys)this["ConversionShortcutMainKey"];
            }
            set
            {
                this["ConversionShortcutMainKey"] = (Keys)value;
            }
        }

        public void SaveConfiguration()
        {
            OnConfigurationUpdated(EventArgs.Empty);
            Save();
        }

        protected virtual void OnConfigurationUpdated(EventArgs e)
        {
            EventHandler handler = ConfigurationUpdatedHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler ConfigurationUpdatedHandler;
    }
}
