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
        private KeyboardHook m_compactJsonHook = new KeyboardHook();
        private KeyboardHook m_indentedJsonHook = new KeyboardHook();
        private KeyboardManager m_keyboardManager = new KeyboardManager();

        public Editor(EditorModel model)
        {
            InitializeComponent();
            m_model = model;

            m_compactJsonHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(compactJsonHook_KeyPressed);
            m_compactJsonHook.RegisterHotKey(KeyboardHook.ModifierKeys.Control | KeyboardHook.ModifierKeys.Alt, Keys.Space);
            m_indentedJsonHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(indentedJsonHook_KeyPressed);
            m_indentedJsonHook.RegisterHotKey(KeyboardHook.ModifierKeys.Control | KeyboardHook.ModifierKeys.Shift, Keys.Space);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void TextComponent_TextChanged(object sender, EventArgs e)
        {
            
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

        void compactJsonHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Task.Delay(300).Wait();
            m_keyboardManager.SendCopyCommand();
            var text = Clipboard.GetText();
            m_model.Content = text;
            if (m_model.IsValidJson)
            {
                string formattedJson = m_model.GetCompactJson();
                TextComponent.Text = formattedJson;
                //Clipboard.SetText(m_model.GetCompactJson());
                //m_keyboardManager.SendPasteCommand();
            }
            else
            {
                Notifier.BalloonTipText = m_model.ErrorMessage;
                Notifier.ShowBalloonTip(3000);
            }
        }

        void indentedJsonHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            m_keyboardManager.SendCopyCommand();
            var text = Clipboard.GetText();
            m_model.Content = text;
            if (m_model.IsValidJson)
            {
                string formattedJson = m_model.GetIndentedJson();
                TextComponent.Text = formattedJson;
                //Clipboard.SetText(v);
                //m_keyboardManager.SendPasteCommand();
            }
            else
            {
                Notifier.BalloonTipText = m_model.ErrorMessage;
                Notifier.ShowBalloonTip(3000);
            }
        }
    }
}
