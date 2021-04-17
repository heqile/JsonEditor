namespace JsonEditor
{
    public class EditorModel
    {
        private string m_content;
        private KeyboardManager m_keyboardManager;
        private WindowManager m_windowManager;
        private JsonContent m_jsonContent = new JsonContent();

        public EditorModel(WindowManager windowManager, KeyboardManager keyboardManager)
        {
            m_windowManager = windowManager;
            m_keyboardManager = keyboardManager;
        }

        public string Text
        {
            set { m_content = value; }
            get { return m_content; }
        }

        public string ErrorMessage
        {
            get { return m_jsonContent.ErrorMessage; }
        }

        public bool IsValidJson
        {
            get { return m_jsonContent.IsValidJson; }
        }

        public string GetFormattedJson()
        {
            bool isForeignWindowFocused = !m_windowManager.IsMainWindowFocused();
            if (isForeignWindowFocused)
            {
                m_content = GetTextFromClipboard();
            }

            string formattedJson = FormatJson();
            ClipboardManager.SetText(formattedJson);

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
            return ClipboardManager.GetText();
        }

        private string FormatJson()
        {
            string formattedJson = GetFormattedJsonIfContentIsKnown();
            if (!string.IsNullOrEmpty(formattedJson))
            {
                return formattedJson;
            }

            m_jsonContent = new JsonContent(m_content);
            if (!m_jsonContent.IsValidJson)
            {
                throw new InvalidJsonException(m_jsonContent.ErrorMessage);
            }

            formattedJson = GetFormattedJsonIfContentIsKnown();
            if (!string.IsNullOrEmpty(formattedJson))
            {
                return formattedJson;
            }
            return m_jsonContent.GetIndentedJson();
        }

        private string GetFormattedJsonIfContentIsKnown()
        {
            if (m_content == m_jsonContent.GetCompactJson())
            {
                return m_jsonContent.GetIndentedJson();
            }
            else if (m_content == m_jsonContent.GetIndentedJson())
            {
                return m_jsonContent.GetCompactJson();
            }
            return string.Empty;
        }

        public string GetIndentedJson()
        {
            m_jsonContent = new JsonContent(m_content);
            if (m_jsonContent.IsValidJson)
            {
                string formattedJson = m_jsonContent.GetIndentedJson();
                ClipboardManager.SetText(formattedJson);
                return formattedJson;
            }
            throw new InvalidJsonException(m_jsonContent.ErrorMessage);
        }

        public string GetCompactJson()
        {
            m_jsonContent = new JsonContent(m_content);
            if (m_jsonContent.IsValidJson)
            {
                string formattedJson = m_jsonContent.GetCompactJson();
                ClipboardManager.SetText(formattedJson);
                return formattedJson;
            }
            throw new InvalidJsonException(m_jsonContent.ErrorMessage);
        }
    }
}
