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

            m_compactJsonHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(CompactJsonHook_KeyPressed);
            m_compactJsonHook.RegisterHotKey(KeyboardHook.ModifierKeys.Control | KeyboardHook.ModifierKeys.Shift, Keys.W);
            m_indentedJsonHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(IndentedJsonHook_KeyPressed);
            m_indentedJsonHook.RegisterHotKey(KeyboardHook.ModifierKeys.Control | KeyboardHook.ModifierKeys.Shift, Keys.Q);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Dispose();
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
            WindowState = FormWindowState.Minimized;
        }

        void CompactJsonHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Task.Delay(200).Wait();
            m_keyboardManager.SendCopyCommand();
            var text = Clipboard.GetText();
            m_model.Content = text;
            if (m_model.IsValidJson)
            {
                string formattedJson = m_model.GetCompactJson();
                TextComponent.Text = formattedJson;
                TextComponent.SelectAll();
                TextComponent.Focus();
                Task.Delay(100).Wait();
                Clipboard.SetText(formattedJson);
                Task.Delay(100).Wait();
                m_keyboardManager.SendPasteCommand();
                //Show();
                //WindowState = FormWindowState.Normal;
            }
            else
            {
                Notifier.BalloonTipText = m_model.ErrorMessage;
                Notifier.ShowBalloonTip(3000);
            }
        }

        void IndentedJsonHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Task.Delay(200).Wait();
            m_keyboardManager.SendCopyCommand();
            var text = Clipboard.GetText();
            m_model.Content = text;
            if (m_model.IsValidJson)
            {
                string formattedJson = m_model.GetIndentedJson();
                TextComponent.Text = formattedJson;
                TextComponent.SelectAll();
                TextComponent.Focus();
                Task.Delay(100).Wait();
                Clipboard.SetText(formattedJson);
                Task.Delay(100).Wait();
                m_keyboardManager.SendPasteCommand();
                //Show();
                //WindowState = FormWindowState.Normal;
            }
            else
            {
                Notifier.BalloonTipText = m_model.ErrorMessage;
                Notifier.ShowBalloonTip(3000);
            }
        }

        private void Editor_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
            else
            {
                ShowInTaskbar = true;
            }
        }

        private void Notifier_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown
                || e.CloseReason == CloseReason.ApplicationExitCall
                || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }
            e.Cancel = true;
            this.Hide();
        }

        private void Notifier_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                NotifierMenuStrip.Show();
            }
        }

        private void NotifierMenuExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void NotifierMenuShow_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
