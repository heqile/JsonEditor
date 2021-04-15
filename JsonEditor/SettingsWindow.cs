using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditor
{
    public partial class SettingsWindow : Form
    {
        private Configuration m_configuration;
        private KeyboardHook.ModifierKeys m_modifierKeys;
        private Keys m_mainKeys;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            m_configuration = Configuration.GetInstance();
            ModifierKeyBindingTextBox.DataBindings.Add("Text", m_configuration, "ConversionShortcutModifierKey");
            MainKeyBindingTextBox.DataBindings.Add("Text", m_configuration, "ConversionShortcutMainKey");
        }

        KeyboardHook.ModifierKeys modifiers;
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
            m_configuration.ConversionShortcutModifierKey = m_modifierKeys;
            m_configuration.ConversionShortcutMainKey = m_mainKeys;
            try
            {
                m_configuration.SaveConfiguration();
            }
            catch(Exception)
            {
                // should display an error dialog box
            }
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
