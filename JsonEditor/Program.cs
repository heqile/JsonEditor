using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditor
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware); // initial project is for .netcore 3.1, but not for net4.6.1
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);        
            KeyboardManager keyboardManager = new KeyboardManager();
            WindowManager windowManager = new WindowManager();
            ClipboardManager clipboardManager = new ClipboardManager();
            EditorModel model = new EditorModel(windowManager, keyboardManager, clipboardManager);
            Application.Run(new Editor(model));
        }
    }
}
