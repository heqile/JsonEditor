using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JsonEditor
{
    public class EditorModel
    {
        private string m_content;
        private JsonElement m_jsonElement;
        private string m_errorMessage;
        private bool m_isValidJson;

        public EditorModel()
        {
            m_isValidJson = false;
        }

        public bool IsValidJson
        {
            get { return m_isValidJson; }
        }

        public string Content
        {
            set 
            { 
                m_content = value;
                try
                {
                    m_jsonElement = JsonSerializer.Deserialize<JsonElement>(value);
                    m_isValidJson = true;
                }
                catch (JsonException)
                {
                    m_errorMessage = "Invalid Json";
                    m_isValidJson = false;
                }
            }
            get { return m_content; }
        }

        public string ErrorMessage
        {
            get { return m_errorMessage; }
        }

        public string GetIndentedJson()
        {
            if (!m_isValidJson)
            {
                return null;
            }

            return SerializeJsonElement(true);
        }

        public string GetCompactJson()
        {
            if (!m_isValidJson)
            {
                return null;
            }

            return SerializeJsonElement(false);
        }

        private string SerializeJsonElement(bool writeIndented)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = writeIndented
            };

            return JsonSerializer.Serialize(m_jsonElement, options);
        }
    }
}
