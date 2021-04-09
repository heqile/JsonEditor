using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonEditor;
using System.Text.Json;
using System.IO;
using System;

namespace JsonEditorUnitTest
{
    [TestClass]
    public class EditorModelUnitTest
    {
        private const string validInput = "{\"key1\": \"value1\",\n \"key2\": [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
        private const string invalidInput = "{\"key1\": \"value1\",\n \"key2: [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";

        string convertToIndentedJson(string input)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            object jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(validInput);
            StringWriter sw = new StringWriter();
            sw.NewLine = "\n";
            Newtonsoft.Json.JsonTextWriter jw = new Newtonsoft.Json.JsonTextWriter(sw);
            jw.Formatting = Newtonsoft.Json.Formatting.Indented;
            jw.IndentChar = ' ';
            jw.Indentation = 4;
            serializer.Serialize(jw, jsonObj);
            return sw.ToString();
        }
        string convertToCompactJson(string input)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            object jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(validInput);
            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonTextWriter jw = new Newtonsoft.Json.JsonTextWriter(sw);
            jw.Formatting = Newtonsoft.Json.Formatting.None;
            serializer.Serialize(jw, jsonObj);
            return sw.ToString();
        }

        [TestMethod]
        public void IsValidJson_False_InitialState()
        {
            // Given

            // When
            EditorModel model = new EditorModel();

            // Then
            Assert.AreEqual(false, model.IsValidJson);
        }

        [TestMethod]
        public void GetErrorMessage_EmptyInputErrorMessage_InitialState()
        {
            // Given

            // When
            EditorModel model = new EditorModel();

            // Then
            Assert.AreEqual(JsonContent.EmptyInputErrorMessage, model.ErrorMessage);
        }

        [TestMethod]
        public void ContentSetterAndGetter_ChangeContentValue_SetContent()
        {
            // Given
            string inputContent = "test";

            // When
            EditorModel model = new EditorModel();
            model.Text = inputContent;

            // Then
            Assert.AreEqual(inputContent, model.Text);
        }

        [TestMethod]
        public void SetContent_JsonParsed_ValidJson()
        {
            // Given

            // When
            EditorModel model = new EditorModel();
            model.Text = validInput;

            // Then
            Assert.AreEqual(validInput, model.Text);
        }

        [TestMethod]
        public void GetIndentedJson_IndentedJsonString_ValidJson()
        {
            // Given            
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel();
            model.Text = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetIndentedJson());
        }

        [TestMethod]
        public void GetIndentedJson_EmptyString_InvalidValidJson()
        {
            // Given
            // When
            EditorModel model = new EditorModel();
            model.Text = invalidInput;

            // Then
            Assert.ThrowsException<ArgumentOutOfRangeException>(model.GetCompactJson);
            Assert.IsTrue(model.ErrorMessage.Contains("Invalid character after parsing property name"));
        }


        [TestMethod]
        public void GetCompactJson_CompactJsonString_ValidJson()
        {
            // Given
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(validInput);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = false
            };
            string expectedJson = JsonSerializer.Serialize(jsonElement, options);

            // When
            EditorModel model = new EditorModel();
            model.Text = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetCompactJson());
        }

        [TestMethod]
        public void GetCompactJson_EmptyString_InvalidJson()
        {
            // Given

            // When
            EditorModel model = new EditorModel();
            model.Text = invalidInput;

            // Then
            Assert.ThrowsException<ArgumentOutOfRangeException>(model.GetCompactJson);
            Assert.IsTrue(model.ErrorMessage.Contains("Invalid character after parsing property name"));
        }

        [TestMethod]
        public void GetFormattedJson_IndentedJson_GotCompactJsonPreviously()
        {
            // Give
            string inputJson = convertToCompactJson(validInput);
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel();
            model.Text = inputJson;
            model.GetCompactJson();

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJson());
        }

        [TestMethod]
        public void GetFormattedJson_CompactJson_GotIndentedJsonPreviously()
        {
            // Give
            string inputJson = convertToIndentedJson(validInput);
            string expectedJson = convertToCompactJson(validInput);

            // When
            EditorModel model = new EditorModel();
            model.Text = inputJson;
            model.GetIndentedJson();

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJson());
        }

        [TestMethod]
        public void GetFormattedJson_IndentedJson_NewJsonInputAndIsCompactJson()
        {
            // Give
            string inputJson = convertToCompactJson(validInput);
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel();
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJson());
        }

        [TestMethod]
        public void GetFormattedJson_CompactJson_NewJsonInputAndIsIndentedJson()
        {
            // Give
            string inputJson = convertToIndentedJson(validInput);
            string expectedJson = convertToCompactJson(validInput);

            // When
            EditorModel model = new EditorModel();
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJson());
        }

        [TestMethod]
        public void GetFormattedJson_IndentedJson_NewJsonInputAndNeitherIndentedFormatNorCompactFormat()
        {
            // Give
            string inputJson = convertToCompactJson(validInput).Replace(":", "   :  \r\n");
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel();
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJson());
        }
    }
}
