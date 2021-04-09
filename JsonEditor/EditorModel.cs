using System;
using System.ComponentModel;

namespace JsonEditor
{
    public class EditorModel
    {
        private string m_content;
        private JsonContent m_jsonContent;

        public EditorModel()
        {
            m_content = string.Empty;
            m_jsonContent = new JsonContent(string.Empty);
        }

        public string Text
        {
            set { m_content = value; }
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
        public void ValidateJson()
        {
            m_jsonContent = new JsonContent(m_content);
        }

        public string GetFormattedJson()
        {
            string formattedJson = GetFormattedJsonIfSameAsPrevious();
            if (!string.IsNullOrEmpty(formattedJson))
            {
                return formattedJson;
            }

            m_jsonContent = new JsonContent(m_content);
            if (!m_jsonContent.IsValidJson)
            {
                var exception = new ArgumentOutOfRangeException(m_jsonContent.ErrorMessage);
                throw (exception);
            }

            formattedJson = GetFormattedJsonIfSameAsPrevious();
            if (!string.IsNullOrEmpty(formattedJson))
            {
                return formattedJson;
            }
            return m_jsonContent.GetIndentedJson();
        }

        private string GetFormattedJsonIfSameAsPrevious()
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
            var exception = new ArgumentOutOfRangeException(m_jsonContent.ErrorMessage);
            throw (exception);
        }

        public string GetCompactJson()
        {
            m_jsonContent = new JsonContent(m_content);
            if (m_jsonContent.IsValidJson)
            {
                return m_jsonContent.GetCompactJson();
            }
            var exception = new ArgumentOutOfRangeException(m_jsonContent.ErrorMessage);
            throw (exception);
        }
    }
}
