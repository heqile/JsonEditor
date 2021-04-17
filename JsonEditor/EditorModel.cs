using System;
using System.ComponentModel;

namespace JsonEditor
{
    public class EditorModel : INotifyPropertyChanged
    {
        private string m_content = string.Empty;
        private JsonContent m_jsonContent = new JsonContent(string.Empty);
        private KeyboardManager m_keyboardManager = new KeyboardManager();
        private WindowManager m_windowManager = new WindowManager();

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            set 
            {
                if (value == Text)
                {
                    return;
                }
                m_content = value;
                OnPropertyChanged("Text");
            }
            get { return m_content; }
        }


        public string ErrorMessage
        {
            get 
            {
                return m_jsonContent.ErrorMessage;
            }
        }

        public bool IsValidJson
        {
            get { return m_jsonContent.IsValidJson; }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string GetFormattedJson()
        {
            bool isForeignWindowFocused = !m_windowManager.IsMainWindowFocused();
            if (isForeignWindowFocused)
            {
                m_content = getTextFromClipboard();
            }

            string formattedJson = FormatJson();
            ClipboardManager.SetText(formattedJson);

            if (isForeignWindowFocused)
            {
                m_keyboardManager.SendPasteCommand();
            }

            return formattedJson;
        }
        private string getTextFromClipboard()
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
