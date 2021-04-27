using System;
using System.Windows.Forms;

namespace JsonEditor
{
    public partial class SettingsWindow : Form
    {
        private readonly Configuration m_configuration;
        private KeyboardHook.ModifierKeys m_indentedFormattingModifierKeys;
        private Keys m_indentedFormattingMainKeys;
        private KeyboardHook.ModifierKeys m_compactFormattingModifierKeys;
        private Keys m_compactFormattingMainKeys;
        private bool m_displaySuccessMessageEnabled;
        private uint m_waitWindowReadyMs;
        private uint m_previousWaitWindowReadyMs;

        public SettingsWindow(Configuration configuration)
        {
            InitializeComponent();
            m_configuration = configuration;
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            LoadConfigurationAndRefreshComponents(m_configuration);
        }

        private void IndentedFormattingModifierKeyBindingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool isModifierKeys = e.Control || e.Alt || e.Shift;
            if (isModifierKeys)
            {
                Enum.TryParse(e.Modifiers.ToString(), out m_indentedFormattingModifierKeys);
                IndentedFormattingModifierKeyBindingTextBox.Text = m_indentedFormattingModifierKeys.ToString();
            }
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void IndentedFormattingMainKeyBindingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool isModifierKeys = e.Control || e.Alt || e.Shift;
            if (!isModifierKeys)
            {
                m_indentedFormattingMainKeys = e.KeyData;
                IndentedFormattingMainKeyBindingTextBox.Text = m_indentedFormattingMainKeys.ToString();
            }
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void CompactFormattingModifierKeyBindingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool isModifierKeys = e.Control || e.Alt || e.Shift;
            if (isModifierKeys)
            {
                Enum.TryParse(e.Modifiers.ToString(), out m_compactFormattingModifierKeys);
                CompactFormattingModifierKeyBindingTextBox.Text = m_compactFormattingModifierKeys.ToString();
            }
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void CompactFormattingMainKeyBindingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool isModifierKeys = e.Control || e.Alt || e.Shift;
            if (!isModifierKeys)
            {
                m_compactFormattingMainKeys = e.KeyData;
                CompactFormattingMainKeyBindingTextBox.Text = m_compactFormattingMainKeys.ToString();
            }
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void TimeWaitingMs_TextChanged(object sender, EventArgs e)
        {
            if (!uint.TryParse(TimeWaitingMs.Text, out m_waitWindowReadyMs))
            {
                m_waitWindowReadyMs = m_previousWaitWindowReadyMs;
                TimeWaitingMs.Text = m_previousWaitWindowReadyMs.ToString();
                errorProvider1.SetError(TimeWaitingMs, "Please set a number");
                return;
            }
            m_previousWaitWindowReadyMs = m_waitWindowReadyMs;
            errorProvider1.SetError(TimeWaitingMs, "");
            return;
        }

        private void DisplayMessageIfJsonIsValidEnabled_CheckedChanged(object sender, EventArgs e)
        {
            m_displaySuccessMessageEnabled = DisplaySuccessNotificationEnabled.Checked;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            const string message =
                "Are you sure that you would like to reset the settings?";
            const string caption = "Reset Settings";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                m_configuration.Reset();
                LoadConfigurationAndRefreshComponents(m_configuration);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveConfiguration(m_configuration);
            Dispose();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveConfiguration(m_configuration);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void SaveConfiguration(Configuration configuration)
        {
            configuration.IndentedFormattingConversionHotKeyModifierKey = m_indentedFormattingModifierKeys;
            configuration.IndentedFormattingConversionHotKeyMainKey = m_indentedFormattingMainKeys;
            configuration.CompactFormattingConversionHotKeyModifierKey = m_compactFormattingModifierKeys;
            configuration.CompactFormattingConversionHotKeyMainKey = m_compactFormattingMainKeys;
            configuration.DisplaySuccessNotificationEnabled = m_displaySuccessMessageEnabled;
            configuration.WaitWindowReadyMs = m_waitWindowReadyMs;
            try
            {
                configuration.SaveConfiguration();
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LoadConfigurationAndRefreshComponents(Configuration configuration)
        {
            m_indentedFormattingModifierKeys = configuration.IndentedFormattingConversionHotKeyModifierKey;
            m_indentedFormattingMainKeys = configuration.IndentedFormattingConversionHotKeyMainKey;
            m_compactFormattingModifierKeys = configuration.CompactFormattingConversionHotKeyModifierKey;
            m_compactFormattingMainKeys = configuration.CompactFormattingConversionHotKeyMainKey;
            m_displaySuccessMessageEnabled = configuration.DisplaySuccessNotificationEnabled;
            m_waitWindowReadyMs = configuration.WaitWindowReadyMs;
            m_previousWaitWindowReadyMs = m_waitWindowReadyMs;

            IndentedFormattingModifierKeyBindingTextBox.Text = m_indentedFormattingModifierKeys.ToString();
            IndentedFormattingMainKeyBindingTextBox.Text = m_indentedFormattingMainKeys.ToString();
            CompactFormattingModifierKeyBindingTextBox.Text = m_compactFormattingModifierKeys.ToString();
            CompactFormattingMainKeyBindingTextBox.Text = m_compactFormattingMainKeys.ToString();
            DisplaySuccessNotificationEnabled.Checked = m_displaySuccessMessageEnabled;
            TimeWaitingMs.Text = m_waitWindowReadyMs.ToString();
        }
    }
}
