using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COC_SCCJ_Evaluation.Models;
using COC_SCCJ_Evaluation.Views;


namespace COC_SCCJ_Evaluation.Presenter.FacultyPresenter
{
    public class QuestionPresenter
    {
        // FOOTBALL FIELD
        private IQuestionView questionView;
        private IQuestionRepository questionRepository;
        private BindingSource questionBindingSource;
        private IEnumerable<QuestionModel> questionList;


        // CONSTRUCTION WORKER
        public QuestionPresenter(IQuestionView questionView, IQuestionRepository questionRepository)
        {

            this.questionBindingSource = new BindingSource();
            this.questionView = questionView;
            this.questionRepository = questionRepository;

            //SUBSCRIBE EVENT HANDLER METHOD TO VIEW METHODS

            this.questionView.SearchEvent += SearchQuestion;
            this.questionView.AddNewEvent += AddNewQuestion;
            this.questionView.EditEvent += LoadSelectedQuestionToEdit;
            this.questionView.DeleteEvent += DeleteSelectedQuestion;
            this.questionView.SaveEvent += SaveQuestion;
            this.questionView.CancelEvent += CancelAction;

            //SET QUESTION BINDING SOURCE
            this.questionView.SetQuestionBindingSource(questionBindingSource);

            //LOAD ALL QUESTION
            LoadAllQuestions();

            //SHOW THE NICE VIEW
            this.questionView.Show();
        }

        private void LoadAllQuestions()
        {
            questionList = questionRepository.GetAll();
            questionBindingSource.DataSource = questionList;
        }

        private void SearchQuestion(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.questionView.SearchValue);

            if (emptyValue == false)
            {
                questionList = questionRepository.GetByValue(this.questionView.SearchValue);
            }
            else
            {
                questionList = questionRepository.GetAll();
                questionBindingSource.DataSource = questionList;
            }
        }
        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveQuestion(object sender, EventArgs e)
        {
            var model = new QuestionModel();
            model.QuestionId= Convert.ToInt32(questionView.QuestionId);
            model.Question = questionView.Question;
            model.CategoryId = Convert.ToInt32(questionView.CategoryId);
            model.HasImage = questionView.HasImage;
            model.ImageUri = questionView.ImageUri;
            model.Answer = questionView.Answer;
            model.Option1 = questionView.Option1;
            model.Option2 = questionView.Option2;
            model.Option3 = questionView.Option3;
            model.Option4 = questionView.Option4;
            try
            {
                new Common.ModelValidation().Validate(model);
                if (questionView.IsEditable)
                {
                    questionRepository.Edit(model);
                    questionView.Message = "Question edited successfuly";
                }
                else 
                {
                    questionRepository.Add(model);
                    questionView.Message = "Question added sucessfully";
                }
                questionView.IsSuccessful = true;
                LoadAllQuestions();
                //CleanviewFields();
            }
            catch (Exception ex)
            {
                questionView.IsSuccessful = false;
                questionView.Message = ex.Message;
            }
        }

        private void DeleteSelectedQuestion(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedQuestionToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewQuestion(object sender, EventArgs e)
        {
            var question = (QuestionModel)questionBindingSource.Current;

            questionView.QuestionId = question.QuestionId;
            questionView.Question = question.Question;
            //questionView.Cate
            

        }


    }
}
