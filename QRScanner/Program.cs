using QRScanner.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRScanner
{
    static class Program
    {
        private static MainForm mainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


            mainForm = new MainForm();
            Application.Run(mainForm);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {                        
            Exception ex = (Exception)e.ExceptionObject;
            if (ex != null)
            {
                mainForm.tbQr.Text = "Unknown error: " + ex.Message + "\r\nStacktrace:\r\n" + ex.StackTrace;
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if(e.Exception is  ArgumentException)
            {
                if (e.Exception.Message == "Parameter is not valid.")
                {
                    mainForm.tbQr.Text = "You can only select an area while dragging your mouse from left to right, downwards.";
                }
            }
            else 
                mainForm.tbQr.Text = "An error has occured: " + e.Exception.Message + "\r\nStacktrace:\r\n" + e.Exception.StackTrace;
        }
    }
}
