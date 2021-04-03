using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonEditor;
using System.Text.Json;

namespace JsonEditorUnitTest
{
    [TestClass]
    public class EditorModelUnitTest
    {
        [TestMethod]
        public void ContentSetterAndGetter_ChangeContentValue_SetContent()
        {
            // Given
            string inputContent = "test";

            // When
            EditorModel model = new EditorModel();
            model.Content = inputContent;

            // Then
            Assert.AreEqual(inputContent, model.Content);
        }

        [TestMethod]
        public void SetContent_JsonParsed_ValidJson()
        {
            // Given
            // string inputString = "{\"key1\": \"value1\", \"key2\": [\"value2-1\", \"value2-2\"], \"key3\": {\"key3-1\": \"value3-1\", \"key3-2\": \"value3-2\"}}";
            string validInput = "{\"key1\": \"value1\",\n \"key2\": [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";

            // When
            EditorModel model = new EditorModel();
            model.Content = validInput;

            // Then
            Assert.IsTrue(model.IsValidJson);
            Assert.AreEqual(null, model.ErrorMessage);
        }

        [TestMethod]
        public void SetContent_ErrorMessage_InvalidValidJson()
        {
            // Given
            // string inputString = "{\"key1\": \"value1\", \"key2\": [\"value2-1\", \"value2-2\"], \"key3\": {\"key3-1\": \"value3-1\", \"key3-2\": \"value3-2\"}}";
            string invalidInput = "{\"key1\": \"value1\",\n \"key2: [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";

            // When
            EditorModel model = new EditorModel();
            model.Content = invalidInput;

            // Then
            Assert.IsFalse(model.IsValidJson);
            Assert.AreEqual("Invalid Json", model.ErrorMessage);
        }

        [TestMethod]
        public void GetIndentedJson_IndentedJsonString_ValidJson()
        {
            // Given
            string validInput = "{\"key1\": \"value1\",\n \"key2\": [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
            
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(validInput);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string expectedJson = JsonSerializer.Serialize(jsonElement, options);

            // When
            EditorModel model = new EditorModel();
            model.Content = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetIndentedJson());
        }

        [TestMethod]
        public void GetIndentedJson_EmptyString_InvalidValidJson()
        {
            // Given
            string invalidInput = "{\"key1\": \"value1\",\n \"key2: [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
            string expectedEmptyString = null;

            // When
            EditorModel model = new EditorModel();
            model.Content = invalidInput;

            // Then
            Assert.AreEqual(expectedEmptyString, model.GetIndentedJson());
        }


        [TestMethod]
        public void GetCompactJson_CompactJsonString_ValidJson()
        {
            // Given
            string validInput = "{\"key1\": \"value1\",\n \"key2\": [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(validInput);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = false
            };
            string expectedJson = JsonSerializer.Serialize(jsonElement, options);

            // When
            EditorModel model = new EditorModel();
            model.Content = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetCompactJson());
        }

        [TestMethod]
        public void GetCompactJson_EmptyString_InvalidValidJson()
        {
            // Given
            string invalidInput = "{\"key1\": \"value1\",\n \"key2: [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
            string expectedEmptyString = null;

            // When
            EditorModel model = new EditorModel();
            model.Content = invalidInput;

            // Then
            Assert.AreEqual(expectedEmptyString, model.GetCompactJson());
        }
    }
}
