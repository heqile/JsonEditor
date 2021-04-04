using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JsonEditor
{
    public class EditorModel
    {
        private string m_content;
        private JsonContent m_jsonContent;

        public string Content
        {
            set 
            { 
                m_content = value;
                m_jsonContent = new JsonContent(value);
            }
            get { return m_content; }
        }

        public string ErrorMessage
        {
            get {
                if (IsValidJson)
                {
                    return null;
                }
                return "Invalid Json";
            }
        }

        public bool IsValidJson
        {
            get { return m_jsonContent.IsValidJson; }
        }

        public string GetIndentedJson()
        {
            return m_jsonContent.GetIndentedJson();
        }

        public string GetCompactJson()
        {
            return m_jsonContent.GetCompactJson();
        }
    }
}
