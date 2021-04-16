using System;
using System.ComponentModel;

namespace JsonEditor
{
    public class EditorModel : INotifyPropertyChanged
    {
        private string m_content = string.Empty;
        private JsonContent m_jsonContent = new JsonContent(string.Empty);

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
                return m_jsonContent.GetIndentedJson();
            }
            throw new InvalidJsonException(m_jsonContent.ErrorMessage);
        }

        public string GetCompactJson()
        {
            m_jsonContent = new JsonContent(m_content);
            if (m_jsonContent.IsValidJson)
            {
                return m_jsonContent.GetCompactJson();
            }
            throw new InvalidJsonException(m_jsonContent.ErrorMessage);
        }
    }
}
