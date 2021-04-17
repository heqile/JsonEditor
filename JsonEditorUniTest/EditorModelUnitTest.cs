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
            hookManager.Setup(o => o.SetConversionShortcutHandler(It.IsAny<EventHandler<KeyPressedEventArgs>>()));
            hookManager.Setup(o => o.UpdateHook());
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
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputContent;

            // Then
            Assert.AreEqual(inputContent, model.Text);
        }


        [TestMethod]
        public void GetIndentedJsonAndSetToClipboard_IndentedJsonString_ValidJson()
        {
            // Given            
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetIndentedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
        }

        [TestMethod]
        public void GetIndentedJsonAndSetToClipboard_EmptyString_InvalidValidJson()
        {
            // Given
            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = invalidInput;

            // Then
            Assert.ThrowsException<InvalidJsonException>(model.GetCompactJsonAndSetToClipboard);
            clipboardManager.Verify(o => o.SetText(It.IsAny<string>()), Times.Never);
        }


        [TestMethod]
        public void GetCompactJsonAndSetToClipboard_CompactJsonString_ValidJson()
        {
            // Given
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(validInput);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = false
            };
            string expectedJson = JsonSerializer.Serialize(jsonElement, options);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = validInput;

            // Then
            Assert.AreEqual(expectedJson, model.GetCompactJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
        }

        [TestMethod]
        public void GetCompactJsonAndSetToClipboard_EmptyString_InvalidJson()
        {
            // Given

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = invalidInput;

            // Then
            Assert.ThrowsException<InvalidJsonException>(model.GetCompactJsonAndSetToClipboard);
            clipboardManager.Verify(o => o.SetText(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_IndentedJson_GotCompactJsonPreviously_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);
            
            // Give
            string inputJson = convertToCompactJson(validInput);
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;
            model.GetCompactJsonAndSetToClipboard();

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenMainWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_CompactJson_GotIndentedJsonPreviously_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);

            // Give
            string inputJson = convertToIndentedJson(validInput);
            string expectedJson = convertToCompactJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;
            model.GetIndentedJsonAndSetToClipboard();

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenMainWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_IndentedJson_NewJsonInputAndIsCompactJson_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);

            // Give
            string inputJson = convertToCompactJson(validInput);
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenMainWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_CompactJson_NewJsonInputAndIsIndentedJson_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);

            // Give
            string inputJson = convertToIndentedJson(validInput);
            string expectedJson = convertToCompactJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenMainWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_IndentedJson_NewJsonInputAndNeitherIndentedFormatNorCompactFormat_MainWindowFocused()
        {
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(true);

            // Give
            string inputJson = convertToCompactJson(validInput).Replace(":", "   :  \r\n");
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenMainWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_IndentedJson_GotCompactJsonPreviously_ForeignWindowFocused()
        {
            string inputJson = convertToCompactJson(validInput);

            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Give
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;
            model.GetCompactJsonAndSetToClipboard();

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenForeignWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_CompactJson_GotIndentedJsonPreviously_ForeignWindowFocused()
        {
            string inputJson = convertToIndentedJson(validInput);

            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Give
            string expectedJson = convertToCompactJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;
            model.GetIndentedJsonAndSetToClipboard();

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenForeignWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_IndentedJson_NewJsonInputAndIsCompactJson_ForeignWindowFocused()
        {
            string inputJson = convertToCompactJson(validInput);
            
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Give
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenForeignWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_CompactJson_NewJsonInputAndIsIndentedJson_ForeignWindowFocused()
        {
            string inputJson = convertToIndentedJson(validInput);

            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Give
            string expectedJson = convertToCompactJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenForeignWindowFocused();
        }

        [TestMethod]
        public void GetFormattedJsonAndSetToClipboard_IndentedJson_NewJsonInputAndNeitherIndentedFormatNorCompactFormat_ForeignWindowFocused()
        {
            string inputJson = convertToCompactJson(validInput).Replace(":", "   :  \r\n");
            
            // Mock
            windowManager.Setup(o => o.IsMainWindowFocused()).Returns(false);
            clipboardManager.Setup(o => o.GetText()).Returns(inputJson);

            // Give
            string expectedJson = convertToIndentedJson(validInput);

            // When
            EditorModel model = new EditorModel(windowManager.Object, keyboardManager.Object, clipboardManager.Object, hookManager.Object);
            model.Text = inputJson;

            // Then
            Assert.AreEqual(expectedJson, model.GetFormattedJsonAndSetToClipboard());
            clipboardManager.Verify(o => o.SetText(expectedJson));
            AssertionsWhenForeignWindowFocused();
        }
    }
}
