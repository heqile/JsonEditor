using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditor
{
    public static class ClipboardManager
    {
        private const int MaxRetry = 5;
        private const int RetryIntervalMs = 10;

        public static void SetText(string text)
        {
            for (int retryCounter = 0; retryCounter < MaxRetry; retryCounter++)
            {
                try
                {
                    Clipboard.SetText(text);
                    return;
                }
                catch (Exception)
                {}
                Task.Delay(RetryIntervalMs).Wait();
            }
        }

        public static string GetText()
        {
            string initialValue = string.Empty;
            string clipboardContent = string.Empty;
            for (int retryCounter = 0; retryCounter < MaxRetry; retryCounter++)
            {
                try
                {
                    clipboardContent = Clipboard.GetText();
                    if (string.IsNullOrEmpty(initialValue))
                    {
                        initialValue = clipboardContent;
                    }

                    if (clipboardContent != initialValue)
                    {
                        break;
                    }
                }
                catch (Exception)
                {}
                Task.Delay(RetryIntervalMs).Wait();
            }
            return clipboardContent.Replace("\r\n", "\n");
        }
    }
}
