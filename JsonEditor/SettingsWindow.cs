using System;
using System.Windows.Forms;

namespace JsonEditor
{
    public partial class SettingsWindow : Form
    {
        private readonly Configuration m_configuration;
        private KeyboardHook.ModifierKeys m_modifierKeys;
        private Keys m_mainKeys;
        private bool m_compactConversionEnabled;
        private uint m_waitWindowReadyMs;
        private uint m_previousWaitWindowReadyMs;

        public SettingsWindow(Configuration configuration)
        {
            InitializeComponent();
            m_configuration = configuration;
            m_modifierKeys = m_configuration.ConversionHotKeyModifierKey;
            m_mainKeys = m_configuration.ConversionHotKeyMainKey;
            m_compactConversionEnabled = m_configuration.CompactConversionEnabled;
            m_waitWindowReadyMs = m_configuration.WaitWindowReadyMs;
            m_previousWaitWindowReadyMs = m_waitWindowReadyMs;
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            ModifierKeyBindingTextBox.Text = m_modifierKeys.ToString();
            MainKeyBindingTextBox.Text = m_mainKeys.ToString();
            CompactConversionEnabled.Checked = m_compactConversionEnabled;
            TimeWaitingMs.Text = m_waitWindowReadyMs.ToString();
        }

        private void ModifierKeyBindingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool isModifierKeys = e.Control || e.Alt || e.Shift;
            if (isModifierKeys)
            {
                Enum.TryParse(e.Modifiers.ToString(), out m_modifierKeys);
                ModifierKeyBindingTextBox.Text = m_modifierKeys.ToString();
            }
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            m_configuration.ConversionHotKeyModifierKey = m_modifierKeys;
            m_configuration.ConversionHotKeyMainKey = m_mainKeys;
            m_configuration.CompactConversionEnabled = m_compactConversionEnabled;
            m_configuration.WaitWindowReadyMs = m_waitWindowReadyMs;
            try
            {
                m_configuration.SaveConfiguration();
            }
            catch(InvalidOperationException exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dispose();
        }

        private void MainKeyBindingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool isModifierKeys = e.Control || e.Alt || e.Shift;
            if (!isModifierKeys)
            {
                m_mainKeys = e.KeyData;
                MainKeyBindingTextBox.Text = m_mainKeys.ToString();
            }
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CompactConversionEnabled_CheckedChanged(object sender, EventArgs e)
        {
            m_compactConversionEnabled = CompactConversionEnabled.Checked;
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
    }
}
