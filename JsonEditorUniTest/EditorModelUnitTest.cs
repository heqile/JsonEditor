using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonEditor;
using System.Text.Json;

namespace JsonEditorUnitTest
{
    [TestClass]
    public class EditorModelUnitTest
    {
        private const string validInput = "{\"key1\": \"value1\",\n \"key2\": [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
        private const string invalidInput = "{\"key1\": \"value1\",\n \"key2: [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";

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
            model.Content = inputContent;

            // Then
            Assert.AreEqual(inputContent, model.Content);
        }

        [TestMethod]
        public void SetContent_JsonParsed_ValidJson()
        {
            // Given

            // When
            EditorModel model = new EditorModel();
            model.Content = validInput;

            // Then
            Assert.IsTrue(model.IsValidJson);
            Assert.AreEqual(string.Empty, model.ErrorMessage);
        }

        [TestMethod]
        public void SetContent_ErrorMessage_InvalidValidJson()
        {
            // Given

            // When
            EditorModel model = new EditorModel();
            model.Content = invalidInput;

            // Then
            Assert.IsFalse(model.IsValidJson);
            Assert.AreEqual(JsonContent.InvalidJsonErrorMessage, model.ErrorMessage);
        }

        [TestMethod]
        public void GetIndentedJson_IndentedJsonString_ValidJson()
        {
            // Given            
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
            // When
            EditorModel model = new EditorModel();
            model.Content = invalidInput;

            // Then
            Assert.AreEqual(string.Empty, model.GetIndentedJson());
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
            model.Content = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetCompactJson());
        }

        [TestMethod]
        public void GetCompactJson_EmptyString_InvalidValidJson()
        {
            // Given

            // When
            EditorModel model = new EditorModel();
            model.Content = invalidInput;

            // Then
            Assert.AreEqual(string.Empty, model.GetCompactJson());
        }
    }
}
