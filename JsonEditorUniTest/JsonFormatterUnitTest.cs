using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonEditor;
using System.Text.Json;
using System.IO;
using System;

namespace JsonEditorUnitTest
{
    [TestClass]
    public class JsonContentUnitTest
    {
        public const string validInput = "{\"key1\": \"value1\",\n \"key2\": [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
        public const string invalidInput = "{\"key1\": \"value1\",\n \"key2: [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";

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

        [TestMethod]
        public void JsonContentConstructor_NoThrow_ValidJson()
        {
            // Given

            // When
            JsonFormatter jsonContent = new JsonFormatter(validInput);

            // Then
        }

        [TestMethod]
        public void Constructor_ThrowInvalidJsonException_InvalidJson()
        {
            // Given

            // When
            Action action = () => new JsonFormatter(invalidInput);

            // Then
            Assert.ThrowsException<InvalidJsonException>(action);
        }

        [TestMethod]
        public void Constructor_ThrowEmptyJsonException_EmptyInput()
        {
            // Given
            string emptyInput = "";

            // When
            Action action = () => new JsonFormatter(emptyInput);

            // Then
            Assert.ThrowsException<EmptyJsonException>(action);
        }

        [TestMethod]
        public void Constructor_ThrowEmptyJsonException_NullInput()
        {
            // Given
            string emptyInput = null;

            // When
            Action action = () => new JsonFormatter(emptyInput);

            // Then
            Assert.ThrowsException<EmptyJsonException>(action);
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
            JsonFormatter jsonContent = new JsonFormatter(validInput);

            // Then
            Assert.AreEqual(expectedJson, jsonContent.GetCompactJson());
        }

        [TestMethod]
        public void GetIndentedJson_IndentedJsonString_ValidJson()
        {
            // Given
            string expectedJson = convertToIndentedJson(validInput);

            // When
            JsonFormatter jsonContent = new JsonFormatter(validInput);

            // Then
            Assert.AreEqual(expectedJson, jsonContent.GetIndentedJson());
        }
    }
}
