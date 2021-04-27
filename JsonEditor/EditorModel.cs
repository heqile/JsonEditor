using System;

namespace JsonEditor
{
    public class EditorModel
    {
        private readonly KeyboardManager m_keyboardManager;
        private readonly WindowManager m_windowManager;
        private readonly ClipboardManager m_clipboardManager;
        private readonly HookManager m_hookManager;
        private readonly Configuration m_configuration;
        private string m_content;
        private JsonFormatter m_jsonFormatter;

        public EditorModel(Configuration configuration, WindowManager windowManager, KeyboardManager keyboardManager, ClipboardManager clipboardManager, HookManager hookManager)
        {
            m_configuration = configuration;
            m_windowManager = windowManager;
            m_keyboardManager = keyboardManager;
            m_clipboardManager = clipboardManager;
            m_hookManager = hookManager;
        }

        public string Text
        {
            set { m_content = value; }
            get { return m_content; }
        }

        public void SetHotKeyHandlerAndUpdateHook(
            EventHandler<KeyPressedEventArgs> indentedFormattingHotKeyHandler,
            EventHandler<KeyPressedEventArgs> compactFormattingHotKeyHandler
        )
        {
            m_hookManager.SetConversionHotKeyHandler(indentedFormattingHotKeyHandler, compactFormattingHotKeyHandler);
            m_hookManager.UpdateHook();
        }

        public string GetIndentedJsonAndSetToClipboard()
        {
            bool isForeignWindowFocused = !m_windowManager.IsMainWindowFocused();
            if (isForeignWindowFocused)
            {
                m_content = GetTextFromClipboard();
            }

            m_jsonFormatter = new JsonFormatter(m_content);
            string formattedJson = m_jsonFormatter.GetIndentedJson();
            m_clipboardManager.SetText(formattedJson);

            if (isForeignWindowFocused)
            {
                m_keyboardManager.SendPasteCommand();
            }

            return formattedJson;
        }

        public string GetCompactJsonAndSetToClipboard()
        {
            bool isForeignWindowFocused = !m_windowManager.IsMainWindowFocused();
            if (isForeignWindowFocused)
            {
                m_content = GetTextFromClipboard();
            }

            m_jsonFormatter = new JsonFormatter(m_content);
            string formattedJson = m_jsonFormatter.GetCompactJson();
            m_clipboardManager.SetText(formattedJson);

            if (isForeignWindowFocused)
            {
                m_keyboardManager.SendPasteCommand();
            }

            return formattedJson;
        }

        private string GetTextFromClipboard()
        {
            m_windowManager.SetFocusedWindowForeground();
            m_keyboardManager.SendCopyCommand();
            return m_clipboardManager.GetText();
        }
    }
}
