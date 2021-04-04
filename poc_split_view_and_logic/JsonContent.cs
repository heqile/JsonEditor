using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JsonEditor
{
    public class JsonContent
    {
        public const string EmptyInputErrorMessage = "Please write a json string.";
        public const string InvalidJsonErrorMessage = "Invalid json, please check your json.";

        private bool m_isValidJson;
        private JsonElement m_jsonElement;
        private string m_errorMessage;

        public JsonContent(string textContent)
        {
            m_isValidJson = false;
            m_errorMessage = string.Empty;
            if (string.IsNullOrEmpty(textContent))
            {
                m_errorMessage = EmptyInputErrorMessage;
                return;
            }

            try
            {
                m_jsonElement = JsonSerializer.Deserialize<JsonElement>(textContent);
                m_isValidJson = true;
            }
            catch (JsonException)
            {
                m_errorMessage = InvalidJsonErrorMessage;
            }
            catch (ArgumentNullException)
            {
                m_errorMessage = EmptyInputErrorMessage;
            }
        }

        public string ErrorMessage
        {
            get { return m_errorMessage; }
        }

        public bool IsValidJson
        {
            get { return m_isValidJson; }
        }

        public string GetCompactJson()
        {
            if (!m_isValidJson)
            {
                return string.Empty;
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
                return string.Empty;
            }

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(m_jsonElement, options);
        }
    }
}
