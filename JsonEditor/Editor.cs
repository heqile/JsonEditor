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
            try
            {
                string formattedJson = m_model.GetCompactJson();
                SetTextComponentContent(formattedJson);
            }
            catch (ArgumentOutOfRangeException exc)
            {
                DisplayNotifierBallonTop(exc.Message);
                return;
            }
        }

        private void IndentedJsonMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string formattedJson = m_model.GetIndentedJson();
                SetTextComponentContent(formattedJson);
            }
            catch (ArgumentOutOfRangeException exc)
            {
                DisplayNotifierBallonTop(exc.Message);
                return;
            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            Notifier.Visible = true;
            WindowState = FormWindowState.Minimized;
        }

        private void JsonHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            bool isForeignWindowFocused = !m_windowManager.IsMainWindowFocused();
            if (isForeignWindowFocused)
            {
                TextComponent.Text = getTextFromClipboard();
            }

            string formattedJson;
            try
            {
                formattedJson = m_model.GetFormattedJson();
                SetTextComponentContent(formattedJson);
            }
            catch (ArgumentOutOfRangeException exc)
            {
                DisplayNotifierBallonTop(exc.Message);
                return;
            }

            Clipboard.SetDataObject(formattedJson, true, 5, 50);

            if (isForeignWindowFocused)
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
        }

        private string getTextFromClipboard()
        {
            m_windowManager.SetFocusedWindowForeground();
            m_keyboardManager.SendCopyCommand();
            return Clipboard.GetText();
        }

        private void DisplayNotifierBallonTop(string text)
        {
            Notifier.BalloonTipText = text;
            Notifier.ShowBalloonTip(3000);
        }
    }
}
