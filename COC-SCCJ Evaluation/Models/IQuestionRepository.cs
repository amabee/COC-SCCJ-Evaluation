using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COC_SCCJ_Evaluation.Models
{
    public interface IQuestionRepository
    {

        void Add(QuestionModel questionModel);

        void Edit(QuestionModel questionModel);

        void Delete(QuestionModel questionModel);

        IEnumerable<QuestionModel> GetAll();

        IEnumerable<QuestionModel> GetByValue();
    }
}
