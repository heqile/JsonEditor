using Newtonsoft.Json;
using System;
using System.IO;

namespace JsonEditor
{
    public class JsonContent
    {
        public const string EmptyInputErrorMessage = "Please write a json.";
        public const string InvalidJsonErrorMessage = "Invalid json, please check.";

        private string m_errorMessage;
        private JsonSerializer m_serializer;
        private object m_jsonObject;

        public JsonContent(string textContent)
        {
            m_errorMessage = string.Empty;

            if (textContent is null || textContent.Trim() == string.Empty)
            {
                m_errorMessage = EmptyInputErrorMessage;
                return;
            }

            m_serializer = new JsonSerializer();
            try
            {
                m_jsonObject = JsonConvert.DeserializeObject(textContent);
            }
            catch (Exception)
            {
                m_errorMessage = InvalidJsonErrorMessage;
            }
        }

        public string ErrorMessage
        {
            get { return m_errorMessage; }
        }

        public bool IsValidJson
        {
            get { return m_jsonObject != null; }
        }

        public string GetCompactJson()
        {
            if (m_jsonObject is null)
            {
                return string.Empty;
            }
            StringWriter stringWriter = new StringWriter();
            JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter);
            jsonWriter.Formatting = Formatting.None;
            m_serializer.Serialize(jsonWriter, m_jsonObject);
            return stringWriter.ToString();
        }

        public string GetIndentedJson()
        {
            if (m_jsonObject is null)
            {
                return string.Empty;
            }

            StringWriter stringWriter = new StringWriter();
            stringWriter.NewLine = "\n";  // in richTextEditor, it stores "\n", to be consistent, use "\n" in output of json converter
            JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter);
            jsonWriter.Formatting = Formatting.Indented;
            jsonWriter.IndentChar = ' ';
            jsonWriter.Indentation = 4;
            m_serializer.Serialize(jsonWriter, m_jsonObject);
            return stringWriter.ToString();
        }
    }
}
