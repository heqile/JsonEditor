using System;
using System.Windows.Forms;

namespace JsonEditor
{
    public partial class Editor : Form
    {
        private EditorModel m_model;
        private HookManager m_hookManager = new HookManager();

        public Editor(EditorModel model)
        {
            InitializeComponent();
            m_model = model;
            TextComponent.DataBindings.Add("Text", m_model, "Text", true, DataSourceUpdateMode.OnPropertyChanged);

            m_hookManager.SetConversionShortcutHandler(new EventHandler<KeyPressedEventArgs>(JsonHook_KeyPressed));
            m_hookManager.UpdateHook();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CompactJsonMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TextComponent.Text = m_model.GetCompactJson();
            }
            catch (InvalidJsonException exc)
            {
                DisplayNotifierBallonTop(exc.Message);
                return;
            }
        }

        private void IndentedJsonMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TextComponent.Text = m_model.GetIndentedJson();
            }
            catch (InvalidJsonException exc)
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
            try
            {
                TextComponent.Text = m_model.GetFormattedJson();
            }
            catch (InvalidJsonException exc)
            {
                DisplayNotifierBallonTop(exc.Message);
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

        private void DisplayNotifierBallonTop(string text)
        {
            Notifier.BalloonTipText = text;
            Notifier.ShowBalloonTip(3000);
        }

        private void NotifierMenuSettings_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }
    }
}
