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

        public void SetConversionHotKeyHandlerAndUpdateHook(EventHandler<KeyPressedEventArgs> eventHandler)
        {
            m_hookManager.SetConversionHotKeyHandler(eventHandler);
            m_hookManager.UpdateHook();
        }

        public string GetFormattedJsonAndSetToClipboard()
        {
            bool isForeignWindowFocused = !m_windowManager.IsMainWindowFocused();
            if (isForeignWindowFocused)
            {
                m_content = GetTextFromClipboard();
            }

            string formattedJson = FormatJson();
            m_clipboardManager.SetText(formattedJson);

            if (isForeignWindowFocused)
            {
                m_keyboardManager.SendPasteCommand();
            }

            return formattedJson;
        }

        public string GetIndentedJsonAndSetToClipboard()
        {
            m_jsonFormatter = new JsonFormatter(m_content);
            string formattedJson = m_jsonFormatter.GetIndentedJson();
            m_clipboardManager.SetText(formattedJson);
            return formattedJson;
        }

        public string GetCompactJsonAndSetToClipboard()
        {
            m_jsonFormatter = new JsonFormatter(m_content);
            string formattedJson = m_jsonFormatter.GetCompactJson();
            m_clipboardManager.SetText(formattedJson);
            return formattedJson;
        }

        private string GetTextFromClipboard()
        {
            m_windowManager.SetFocusedWindowForeground();
            m_keyboardManager.SendCopyCommand();
            return m_clipboardManager.GetText();
        }

        private string FormatJson()
        {
            string formattedJson = GetFormattedJsonIfContentIsKnown();
            if (!string.IsNullOrEmpty(formattedJson))
            {
                return formattedJson;
            }

            m_jsonFormatter = new JsonFormatter(m_content);

            formattedJson = GetFormattedJsonIfContentIsKnown();
            if (!string.IsNullOrEmpty(formattedJson))
            {
                return formattedJson;
            }
            return m_jsonFormatter.GetIndentedJson();
        }

        private string GetFormattedJsonIfContentIsKnown()
        {
            if (m_jsonFormatter is null)
            {
                return string.Empty;
            }

            if (m_content == m_jsonFormatter.GetCompactJson())
            {
                return m_jsonFormatter.GetIndentedJson();
            }

            bool notIntendedJson = m_content != m_jsonFormatter.GetIndentedJson();
            if (notIntendedJson)
            {
                return string.Empty;
            }

            if (m_configuration.CompactConversionEnabled)
            {
                return m_jsonFormatter.GetCompactJson();
            }
            else
            {
                return m_content;
            }
        }
    }
}
