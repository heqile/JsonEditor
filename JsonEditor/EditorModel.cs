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
            get 
            {
                return m_jsonContent.ErrorMessage;
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
