using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JsonEditor
{
    public class JsonContent
    {
        private bool m_isValidJson;
        private JsonElement m_jsonElement;

        public JsonContent(string textContent)
        {
            m_isValidJson = false;
            try
            {
                m_jsonElement = JsonSerializer.Deserialize<JsonElement>(textContent);
                m_isValidJson = true;
            }
            catch (JsonException)
            {}
        }

        public bool IsValidJson
        {
            get { return m_isValidJson; }
        }

        public string GetCompactJson()
        {
            if (!m_isValidJson)
            {
                return null;
            }

            var options = new JsonSerializerOptions()
            {
                WriteIndented = false
            };
            return JsonSerializer.Serialize(m_jsonElement, options);
        }

        public string GetIndentedJson()
        {
            if (!m_isValidJson)
            {
                return null;
            }

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(m_jsonElement, options);
        }
    }
}
