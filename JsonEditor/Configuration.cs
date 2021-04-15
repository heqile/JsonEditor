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

        public string ConversionShortcutKeyBinding
        {
            get
            {
                return ConversionShortcutModifierKey.ToString() + " + " + ConversionShortcutMainKey.ToString();
            }
            //set
            //{
            //    string[] vs = value.Split('+');
            //    //KeyboardHook.ModifierKeys conversionShortcutModifierKey;
            //    Enum.TryParse(vs[0], out KeyboardHook.ModifierKeys conversionShortcutModifierKey);
            //    ConversionShortcutModifierKey = conversionShortcutModifierKey;
            //    Enum.TryParse(vs[1], out Keys conversionShortcutMainKey);
            //    ConversionShortcutMainKey = conversionShortcutMainKey;
            //}
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
