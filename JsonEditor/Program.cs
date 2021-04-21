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
            Configuration configuration = Configuration.GetInstance();
            HookManager hookManager = new HookManager(configuration);
            KeyboardManager keyboardManager = new KeyboardManager();
            WindowManager windowManager = new WindowManager(configuration);
            ClipboardManager clipboardManager = new ClipboardManager();
            EditorModel model = new EditorModel(configuration, windowManager, keyboardManager, clipboardManager, hookManager);
            Application.Run(new EditorWindow(model, configuration));
        }
    }
}
