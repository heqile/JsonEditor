using Newtonsoft.Json;
using System;
using System.IO;

namespace JsonEditor
{
    public class JsonFormatter
    {
        public const string EmptyInputErrorMessage = "Please write a json.";
        public const string InvalidJsonErrorMessage = "Invalid json, please check.";

        private readonly JsonSerializer m_serializer;
        private readonly object m_jsonObject;


        public JsonFormatter(string textContent)
        {
            if (textContent is null || textContent.Trim() == string.Empty)
            {
                throw new EmptyJsonException(EmptyInputErrorMessage);
            }

            m_serializer = new JsonSerializer();
            try
            {
                m_jsonObject = JsonConvert.DeserializeObject(textContent);
            }
            catch (Exception)
            {
                throw new InvalidJsonException(InvalidJsonErrorMessage);
            }
        }

        public string GetCompactJson()
        {
            if (m_jsonObject is null)
            {
                return string.Empty;
            }
            StringWriter stringWriter = new StringWriter();
            JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter)
            {
                Formatting = Formatting.None
            };
            m_serializer.Serialize(jsonWriter, m_jsonObject);
            return stringWriter.ToString();
        }

        public string GetIndentedJson()
        {
            if (m_jsonObject is null)
            {
                return string.Empty;
            }

            StringWriter stringWriter = new StringWriter
            {
                NewLine = "\n"  // in richTextEditor, it stores "\n", to be consistent, use "\n" in output of json converter
            };
            JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter)
            {
                Formatting = Formatting.Indented,
                IndentChar = ' ',
                Indentation = 4
            };
            m_serializer.Serialize(jsonWriter, m_jsonObject);
            return stringWriter.ToString();
        }
    }
}
