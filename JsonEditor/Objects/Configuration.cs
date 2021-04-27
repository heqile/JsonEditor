using System;
using System.Configuration;
using System.Windows.Forms;

namespace JsonEditor
{
    public class Configuration : ApplicationSettingsBase
    {
        private static Configuration m_configuration;

        public Configuration()
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
        public KeyboardHook.ModifierKeys IndentedFormattingConversionHotKeyModifierKey
        {
            get
            {
                return (KeyboardHook.ModifierKeys)this["IndentedFormattingConversionHotKeyModifierKey"];
            }
            set
            {
                this["IndentedFormattingConversionHotKeyModifierKey"] = (KeyboardHook.ModifierKeys)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("Space")]
        public Keys IndentedFormattingConversionHotKeyMainKey
        {
            get
            {
                return (Keys)this["IndentedFormattingConversionHotKeyMainKey"];
            }
            set
            {
                this["IndentedFormattingConversionHotKeyMainKey"] = (Keys)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("None")]
        public KeyboardHook.ModifierKeys CompactFormattingConversionHotKeyModifierKey
        {
            get
            {
                if (this["CompactFormattingConversionHotKeyModifierKey"] is null)
                {
                    return KeyboardHook.ModifierKeys.None;
                }
                return (KeyboardHook.ModifierKeys)this["CompactFormattingConversionHotKeyModifierKey"];
            }
            set
            {
                this["CompactFormattingConversionHotKeyModifierKey"] = (KeyboardHook.ModifierKeys)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("None")]
        public Keys CompactFormattingConversionHotKeyMainKey
        {
            get
            {
                if (this["CompactFormattingConversionHotKeyMainKey"] is null)
                {
                    return Keys.None;
                }
                return (Keys)this["CompactFormattingConversionHotKeyMainKey"];
            }
            set
            {
                this["CompactFormattingConversionHotKeyMainKey"] = (Keys)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("false")]
        virtual public bool CompactConversionEnabled
        {
            get
            {
                return (bool)this["CompactConversionEnabled"];
            }
            set
            {
                this["CompactConversionEnabled"] = (bool)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("300")]
        public uint WaitWindowReadyMs
        {
            get
            {
                return (uint)this["WaitWindowReadyMs"];
            }
            set
            {
                this["WaitWindowReadyMs"] = (uint)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("true")]
        public bool DisplaySuccessNotificationEnabled
        {
            get
            {
                return (bool)this["DisplaySuccessNotificationEnabled"];
            }
            set
            {
                this["DisplaySuccessNotificationEnabled"] = (bool)value;
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
