using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonEditor;
using System.Text.Json;

namespace JsonEditorUnitTest
{
    [TestClass]
    public class JsonContentUnitTest
    {
        public const string validInput = "{\"key1\": \"value1\",\n \"key2\": [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
        public const string invalidInput = "{\"key1\": \"value1\",\n \"key2: [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";

        [TestMethod]
        public void JsonContentConstructor_NoThrow_ValidJson()
        {
            // Given

            // When
            JsonContent jsonContent = new JsonContent(validInput);

            // Then
        }

        [TestMethod]
        public void ErrorMessage_Null_ValidJson()
        {
            // Given

            // When
            JsonContent jsonContent = new JsonContent(validInput);

            // Then
            Assert.AreEqual(string.Empty, jsonContent.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessage_InvalidJsonErrorMessage_InvalidJson()
        {
            // Given

            // When
            JsonContent jsonContent = new JsonContent(invalidInput);

            // Then
            Assert.AreEqual(JsonContent.InvalidJsonErrorMessage, jsonContent.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessage_EmptyErrorMessage_EmptyInput()
        {
            // Given
            string emptyInput = "";

            // When
            JsonContent jsonContent = new JsonContent(emptyInput);

            // Then
            Assert.AreEqual(JsonContent.EmptyInputErrorMessage, jsonContent.ErrorMessage);
        }

        [TestMethod]
        public void ErrorMessage_EmptyErrorMessage_NullInput()
        {
            // Given
            string emptyInput = null;

            // When
            JsonContent jsonContent = new JsonContent(emptyInput);

            // Then
            Assert.AreEqual(JsonContent.EmptyInputErrorMessage, jsonContent.ErrorMessage);
        }

        [TestMethod]
        public void IsValidJson_True_ValidJson()
        {
            // Given

            // When
            JsonContent jsonContent = new JsonContent(validInput);

            // Then
            Assert.IsTrue(jsonContent.IsValidJson);
        }

        [TestMethod]
        public void IsValidJson_False_InvalidJson()
        {
            // Given

            // When
            JsonContent jsonContent = new JsonContent(invalidInput);

            // Then
            Assert.IsFalse(jsonContent.IsValidJson);
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
            JsonContent jsonContent = new JsonContent(validInput);

            // Then
            Assert.AreEqual(expectedJson, jsonContent.GetCompactJson());
        }

        [TestMethod]
        public void GetCompactJson_Null_InvalidJson()
        {
            // Given

            // When
            JsonContent jsonContent = new JsonContent(invalidInput);

            // Then
            Assert.AreEqual(string.Empty, jsonContent.GetCompactJson());
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
            JsonContent jsonContent = new JsonContent(validInput);

            // Then
            Assert.AreEqual(expectedJson, jsonContent.GetIndentedJson());
        }

        [TestMethod]
        public void GetIndentedJson_Null_InvalidJson()
        {
            // Given

            // When
            JsonContent jsonContent = new JsonContent(invalidInput);

            // Then
            Assert.AreEqual(string.Empty, jsonContent.GetIndentedJson());
        }
    }
}
