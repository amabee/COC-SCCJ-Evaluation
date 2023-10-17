using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using COC_SCCJ_Evaluation.Models;
using COC_SCCJ_Evaluation.Presenter;
using COC_SCCJ_Evaluation.Presenter.FacultyPresenter;
using COC_SCCJ_Evaluation.Repositories;
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


            var loginForm = new Views.LoginView();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {

                IQuestionView questionView = new HomeView();
                IQuestionRepository repository = new QuestionRepository(Properties.Resources.connectionString);
                new QuestionPresenter(questionView, repository);

                Application.Run((Form)questionView);
            }

            else
            {
                Application.Exit();
            }

            //Application.Run(new AdminView());
        }
    }
}
