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
    public partial class Editor : Form
    {
        private EditorModel m_model;
        private KeyboardHook m_hook = new KeyboardHook();

        public Editor(EditorModel model)
        {
            InitializeComponent();
            m_model = model;

            m_hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            m_hook.RegisterHotKey(KeyboardHook.ModifierKeys.Control | KeyboardHook.ModifierKeys.Shift, Keys.J);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void TextComponent_TextChanged(object sender, EventArgs e)
        {
            m_model.Content = TextComponent.Text;
        }

        private void CompactJsonMenuItem_Click(object sender, EventArgs e)
        {
            if (m_model.IsValidJson)
            {
                TextComponent.Text = m_model.GetCompactJson();
            }
            else
            {
                Notifier.BalloonTipText = m_model.ErrorMessage;
                Notifier.ShowBalloonTip(3000);
            }
        }

        private void IndentedJsonMenuItem_Click(object sender, EventArgs e)
        {
            if (m_model.IsValidJson)
            {
                TextComponent.Text = m_model.GetIndentedJson();
            }
            else
            {
                Notifier.BalloonTipText = m_model.ErrorMessage;
                Notifier.ShowBalloonTip(3000);
            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            Notifier.Visible = true;
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            TextComponent.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
        }
    }
}
