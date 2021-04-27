using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonEditor;
using System.Text.Json;
using System.IO;
using System;
using Moq;

namespace JsonEditorUnitTest
{
    [TestClass]
    public class EditorModelUnitTest
    {
        private const string validInput = "{\"key1\": \"value1\",\n \"key2\": [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
        private const string invalidInput = "{\"key1\": \"value1\",\n \"key2: [\n\"value2-1\",\n \"value2-2\"],\n \"key3\": {\n\"key3-1\": \"value3-1\",\n \"key3-2\": \"value3-2\"}\n}";
        private const string FakeClipboardContent = "Mocked clipboard content";
        private Mock<KeyboardManager> keyboardManager;
        private Mock<WindowManager> windowManager;
        private Mock<ClipboardManager> clipboardManager;
        private Mock<HookManager> hookManager;
        private Mock<Configuration> configuration;

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

        [TestInitialize]
        public void SetUp()
        {
            windowManager = new Mock<WindowManager>();
            windowManager.Setup(o => o.SetFocusedWindowForeground());
            
            keyboardManager = new Mock<KeyboardManager>();
            keyboardManager.Setup(o => o.SendPasteCommand());
            keyboardManager.Setup(o => o.SendCopyCommand());
            
            clipboardManager = new Mock<ClipboardManager>();
            clipboardManager.Setup(o => o.SetText(It.IsAny<string>()));

            hookManager = new Mock<HookManager>();
            hookManager.Setup(o => o.SetConversionHotKeyHandler(It.IsAny<EventHandler<KeyPressedEventArgs>>(), It.IsAny<EventHandler<KeyPressedEventArgs>>()));
            hookManager.Setup(o => o.UpdateHook());

            configuration = new Mock<Configuration>();
        }

        public void AssertionsWhenMainWindowFocused()
        {
            clipboardManager.Verify(o => o.GetText(), Times.Never);
            windowManager.Verify(o => o.SetFocusedWindowForeground(), Times.Never);
            keyboardManager.Verify(o => o.SendPasteCommand(), Times.Never);
            keyboardManager.Verify(o => o.SendCopyCommand(), Times.Never);
        }
        public void AssertionsWhenForeignWindowFocused()
        {
            clipboardManager.Verify(o => o.GetText(), Times.Once);
            windowManager.Verify(o => o.SetFocusedWindowForeground(), Times.Once);
            keyboardManager.Verify(o => o.SendPasteCommand(), Times.Once);
            keyboardManager.Verify(o => o.SendCopyCommand(), Times.Once);
        }

        [TestMethod]
        public void ContentSetterAndGetter_ChangeContentValue_SetContent()
        {
            // Given
            string inputContent = "test";

            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputContent;

            // Then
            Assert.AreEqual(inputContent, model.Text);
        }


        [TestMethod]
        public void GetIndentedJsonAndSetToClipboard_IndentedJsonString_ValidJson_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);

            // Given            
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetIndentedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
        }

        [TestMethod]
        public void GetIndentedJsonAndSetToClipboard_IndentedJsonString_ValidJson_ForeignWindowFocused()
        {
            string inputJson = validInput;

            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Given            
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);

            // Then
            Assert.AreEqual(expectedJson, model.GetIndentedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
        }

        [TestMethod]
        public void GetIndentedJsonAndSetToClipboard_EmptyString_InvalidValidJson_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);

            // Given
            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = invalidInput;

            // Then
            Assert.ThrowsException<InvalidJsonException>(model.GetCompactJsonAndSetToClipboard);
            clipboardManager.Verify(o => o.SetText(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void GetIndentedJsonAndSetToClipboard_EmptyString_InvalidValidJson_ForeignWindowFocused()
        {
            string inputJson = invalidInput;

            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Given
            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);

            // Then
            Assert.ThrowsException<InvalidJsonException>(model.GetCompactJsonAndSetToClipboard);
            clipboardManager.Verify(o => o.SetText(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void GetCompactJsonAndSetToClipboard_CompactJsonString_ValidJson_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);

            // Given
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(validInput);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = false
            };
            string expectedJson = JsonSerializer.Serialize(jsonElement, options);

            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetCompactJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
        }

        [TestMethod]
        public void GetCompactJsonAndSetToClipboard_CompactJsonString_ValidJson_ForeignWindowFocused()
        {
            string inputJson = validInput;

            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Given
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(validInput);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = false
            };
            string expectedJson = JsonSerializer.Serialize(jsonElement, options);

            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);

            // Then
            Assert.AreEqual(expectedJson, model.GetCompactJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
        }

        [TestMethod]
        public void GetCompactJsonAndSetToClipboard_EmptyString_InvalidJson_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);

            // Given

            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = invalidInput;

            // Then
            Assert.ThrowsException<InvalidJsonException>(model.GetCompactJsonAndSetToClipboard);
            clipboardManager.Verify(o => o.SetText(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void GetCompactJsonAndSetToClipboard_EmptyString_InvalidJson_ForeignWindowFocused()
        {
            string inputJson = invalidInput;

            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Given

            // When
            EditorModel model = new EditorModel(configuration.Object, windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);

            // Then
            Assert.ThrowsException<InvalidJsonException>(model.GetCompactJsonAndSetToClipboard);
            clipboardManager.Verify(o => o.SetText(It.IsAny<string>()), Times.Never);
        }
    }
}
