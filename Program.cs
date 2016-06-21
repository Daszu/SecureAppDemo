using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Secure_Library;
using System.Threading;

namespace Secure_Application_Demo
{
    public static class Context
    {
        public static IUserCtx myCtx = null;
    }

    static class Program
    {
        internal static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            string msg = System.DateTime.Now + " : Wystąpił krytyczny błąd wewnątrz aplikacji. Skontaktuj się z producentem.\n\n";
            msg += "Exception Message:\n";
            msg += t.Exception.Message + "\n";
            msg += "Stack Trace:\n";
            msg += t.Exception.StackTrace + "\n";

            if (t.Exception.InnerException != null)
            {
                Exception ie = t.Exception.InnerException;
                msg += "InnerException Message:\n";
                msg += t.Exception.Message + "\n";
            }
            else
                msg += "\n\r\n\rNo InnerException.\n";

            Clipboard.SetText(msg);
            msg += "\n\nKomunikat o błędzie został skopiowany do  schowka.";
            MessageBox.Show(msg);

            Application.Exit();

        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.Run(new Form1());
        }
    }
}
