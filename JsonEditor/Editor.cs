﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditor
{
    public partial class Editor : Form
    {
        private EditorModel m_model;
        private KeyboardHook m_jsonHook = new KeyboardHook();
        private KeyboardManager m_keyboardManager = new KeyboardManager();

        public Editor(EditorModel model)
        {
            InitializeComponent();
            m_model = model;

            m_jsonHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(JsonHook_KeyPressed);
            m_jsonHook.RegisterHotKey(KeyboardHook.ModifierKeys.Control | KeyboardHook.ModifierKeys.Shift, Keys.Space);
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

        void JsonHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Task.Delay(200).Wait();  // keep long for applications like chrome or visualstudio
            m_keyboardManager.SendCopyCommand();
            Task.Delay(50).Wait();
            var text = Clipboard.GetText();
            Task.Delay(50).Wait();
            if (text == m_model.GetCompactJson())
            {
                string formattedJson = m_model.GetIndentedJson();
                TextComponent.Text = formattedJson;
                TextComponent.SelectAll();
                TextComponent.Focus();
                Task.Delay(50).Wait();
                Clipboard.SetText(formattedJson);
                Task.Delay(50).Wait();
                m_keyboardManager.SendPasteCommand();
            }
            else if (text == m_model.GetIndentedJson())
            {
                string formattedJson = m_model.GetCompactJson();
                TextComponent.Text = formattedJson;
                TextComponent.SelectAll();
                TextComponent.Focus();
                Task.Delay(50).Wait();
                Clipboard.SetText(formattedJson);
                Task.Delay(50).Wait();
                m_keyboardManager.SendPasteCommand();
            }
            else
            {
                m_model.Content = text;
                if (m_model.IsValidJson)
                {
                    string formattedJson = m_model.GetIndentedJson();
                    TextComponent.Text = formattedJson;
                    TextComponent.SelectAll();
                    TextComponent.Focus();
                    Task.Delay(50).Wait();
                    Clipboard.SetText(formattedJson);
                    Task.Delay(50).Wait();
                    m_keyboardManager.SendPasteCommand();
                }
                else
                {
                    Notifier.BalloonTipText = m_model.ErrorMessage;
                    Notifier.ShowBalloonTip(3000);
                    TextComponent.Text = text;
                }
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
            Show();
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
            Hide();
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
            Show();
            WindowState = FormWindowState.Normal;
        }
    }
}
