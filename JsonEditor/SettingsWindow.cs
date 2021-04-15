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
        Configuration m_configuration;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            m_configuration = Configuration.GetInstance();
            KeyBindingTextBox.DataBindings.Add("Text", m_configuration, "ConversionShortcutKeyBinding");
        }
    }
}
