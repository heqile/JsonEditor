namespace JsonEditor
{
    public class EditorModel
    {
        private string m_content;
        private readonly KeyboardManager m_keyboardManager;
        private readonly WindowManager m_windowManager;
        private readonly ClipboardManager m_clipboardManager;
        private JsonContent m_jsonContent = new JsonContent();

        public EditorModel(WindowManager windowManager, KeyboardManager keyboardManager, ClipboardManager clipboardManager)
        {
            m_windowManager = windowManager;
            m_keyboardManager = keyboardManager;
            m_clipboardManager = clipboardManager;
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

        public string GetIndentedJsonAndSetToClipboard()
        {
            m_jsonContent = new JsonContent(m_content);
            if (m_jsonContent.IsValidJson)
            {
                string formattedJson = m_jsonContent.GetIndentedJson();
                m_clipboardManager.SetText(formattedJson);
                return formattedJson;
            }
            throw new InvalidJsonException(m_jsonContent.ErrorMessage);
        }

        public string GetCompactJsonAndSetToClipboard()
        {
            m_jsonContent = new JsonContent(m_content);
            if (m_jsonContent.IsValidJson)
            {
                string formattedJson = m_jsonContent.GetCompactJson();
                m_clipboardManager.SetText(formattedJson);
                return formattedJson;
            }
            throw new InvalidJsonException(m_jsonContent.ErrorMessage);
        }
    }
}
