using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COC_SCCJ_Evaluation.Views
{
    public interface IQuestionView
    {
        // PROPS FIELDS

        int QuestionId { get; set; }
        string CategoryId { get; set; }

        bool HasImage { get; set; }

        string ImageUri { get; set; }

        string Question { get; set; }

        string Answer { get; set; }

        string Option1 { get; set; }

        string Option2 { get; set; }

        string Option3 { get; set; }

        string Option4 { get; set; }

        string SearchValue { get; set; }
        bool IsEditable {  get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // EVENTS
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetQuestionBindingSource(BindingSource questionList);
        void Show(); // This is optional
    }
}
