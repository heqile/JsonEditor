using System;
using System.Windows.Forms;

namespace JsonEditor
{
    public partial class SettingsWindow : Form
    {
        private readonly Configuration m_configuration;
        private KeyboardHook.ModifierKeys m_modifierKeys;
        private Keys m_mainKeys;

        public SettingsWindow(Configuration configuration)
        {
            InitializeComponent();
            m_configuration = configuration;
            m_modifierKeys = m_configuration.ConversionHotKeyModifierKey;
            m_mainKeys = m_configuration.ConversionHotKeyMainKey;
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            ModifierKeyBindingTextBox.Text = m_modifierKeys.ToString();
            MainKeyBindingTextBox.Text = m_mainKeys.ToString();
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
    }
}
