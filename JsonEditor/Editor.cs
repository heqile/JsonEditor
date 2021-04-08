using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditor
{
    public partial class Editor : Form
    {
        private EditorModel m_model;
        private KeyboardHook m_jsonHook = new KeyboardHook();
        private KeyboardManager m_keyboardManager = new KeyboardManager();
        private WindowManager m_windowManager = new WindowManager();

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
            m_model.Content = TextComponent.Text;
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
            m_model.Content = TextComponent.Text;
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
            if (m_windowManager.IsMainWindowFocused())
            {
                var text = TextComponent.Text.Replace("\n", "\r\n");
                if (text == m_model.GetCompactJson())
                {
                    string formattedJson = m_model.GetIndentedJson();
                    SetTextComponentContent(formattedJson);
                    Clipboard.SetDataObject(formattedJson, true, 5, 50);
                }
                else if (text == m_model.GetIndentedJson())
                {
                    string formattedJson = m_model.GetCompactJson();
                    SetTextComponentContent(formattedJson);
                    Clipboard.SetDataObject(formattedJson, true, 5, 50);
                }
                else
                {
                    m_model.Content = text;
                    if (m_model.IsValidJson)
                    {
                        string formattedJson = m_model.GetIndentedJson();
                        SetTextComponentContent(formattedJson);
                        Clipboard.SetDataObject(formattedJson, true, 5, 50);
                    }
                    else
                    {
                        Notifier.BalloonTipText = m_model.ErrorMessage;
                        Notifier.ShowBalloonTip(3000);
                        SetTextComponentContent(text);
                    }
                }
            }
            else
            {
                m_windowManager.SetFocusedHandleForeground();
                m_keyboardManager.SendCopyCommand();
                var text = Clipboard.GetText();
                if (text == m_model.GetCompactJson())
                {
                    string formattedJson = m_model.GetIndentedJson();
                    SetTextComponentContent(formattedJson);
                    Clipboard.SetDataObject(formattedJson, true, 5, 50);
                    m_keyboardManager.SendPasteCommand();
                }
                else if (text == m_model.GetIndentedJson())
                {
                    string formattedJson = m_model.GetCompactJson();
                    SetTextComponentContent(formattedJson);
                    Clipboard.SetDataObject(formattedJson, true, 5, 50);
                    m_keyboardManager.SendPasteCommand();
                }
                else
                {
                    m_model.Content = text;
                    if (m_model.IsValidJson)
                    {
                        string formattedJson = m_model.GetIndentedJson();
                        SetTextComponentContent(formattedJson);
                        Clipboard.SetDataObject(formattedJson, true, 5, 50);
                        m_keyboardManager.SendPasteCommand();
                    }
                    else
                    {
                        Notifier.BalloonTipText = m_model.ErrorMessage;
                        Notifier.ShowBalloonTip(3000);
                        SetTextComponentContent(text);
                    }
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

        private void Notifier_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void SetTextComponentContent(string text)
        {
            TextComponent.Text = text;
            TextComponent.SelectAll();
            TextComponent.Focus();
        }
    }
}
