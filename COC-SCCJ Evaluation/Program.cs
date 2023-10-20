using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using COC_SCCJ_Evaluation.Models;
using COC_SCCJ_Evaluation.Views;

namespace COC_SCCJ_Evaluation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Views.LoginView());
        }
    }
}
