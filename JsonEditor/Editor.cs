using System;
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
            // do data binding
            m_model = model;
            TextComponent.DataBindings.Add("Text", m_model, "Text", true, DataSourceUpdateMode.OnPropertyChanged);

            m_jsonHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(JsonHook_KeyPressed);
            m_jsonHook.RegisterHotKey(KeyboardHook.ModifierKeys.Control | KeyboardHook.ModifierKeys.Shift, Keys.Space);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CompactJsonMenuItem_Click(object sender, EventArgs e)
        {
            m_model.ValidateJson();
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
            m_model.ValidateJson();
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

        private string getTextFromTextComponent()
        {
            return TextComponent.Text.Replace("\n", "\r\n");
        }

        private string getTextFromClipboard()
        {
            m_windowManager.SetFocusedHandleForeground();
            m_keyboardManager.SendCopyCommand();
            return Clipboard.GetText();
        }

        private string getFormattedJson(string inputText)
        {
            string formattedJson;
            if (inputText == m_model.GetCompactJson())
            {
                formattedJson = m_model.GetIndentedJson();
            }
            else if (inputText == m_model.GetIndentedJson())
            {
                formattedJson = m_model.GetCompactJson();
            }
            else
            {
                m_model.ValidateJson();
                if (m_model.IsValidJson)
                {
                    formattedJson = m_model.GetIndentedJson();
                }
                else
                {
                    var exception = new ArgumentOutOfRangeException(m_model.ErrorMessage);
                    throw (exception);
                }
            }
            return formattedJson;
        }

        void DisplayNotifierBallonTop(string text)
        {
            Notifier.BalloonTipText = text;
            Notifier.ShowBalloonTip(3000);
        }

        void JsonHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // todo:
            // 1. take all process logic to model
            // 2. in form, we only interact with the form component
            bool isMainWindowFocused = m_windowManager.IsMainWindowFocused();
            string inputText;
            if (isMainWindowFocused)
            {
                inputText = getTextFromTextComponent();
            }
            else
            {
                inputText = getTextFromClipboard();
            }

            string formattedJson;
            try
            {
                formattedJson = getFormattedJson(inputText);
                SetTextComponentContent(formattedJson);
            }
            catch (ArgumentOutOfRangeException exc)
            {
                DisplayNotifierBallonTop(exc.Message);
                SetTextComponentContent(inputText);
                return;
            }


            Clipboard.SetDataObject(formattedJson, true, 5, 50);

            bool needSendPasteCommand = !isMainWindowFocused;
            if (needSendPasteCommand)
            {
                m_keyboardManager.SendPasteCommand();
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
