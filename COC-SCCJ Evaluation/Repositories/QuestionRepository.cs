using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using COC_SCCJ_Evaluation.Models;

namespace COC_SCCJ_Evaluation.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {

        public QuestionRepository(string connectionString) { 
        
            this.connectionString = connectionString;
        }
        public void Add(QuestionModel questionModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(QuestionModel questionModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionModel> GetAll()
        {
            var questionList = new List<QuestionModel>();

            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();

                command.Connection = connection;
                command.CommandText = "SELECT * FROM tbl_questions ORDER BY id";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) {

                        var questionModel = new QuestionModel();

                        questionModel.QuestionId = (int)reader[0];
                        questionModel.CategoryId = (int)reader[1];
                        questionModel.HasImage = (bool)reader[2];
                        questionModel.ImageUri = reader[3].ToString();
                        questionModel.Question = reader[4].ToString();
                        questionModel.Answer = reader[5].ToString();
                        questionModel.Option1 = reader[6].ToString();
                        questionModel.Option2 = reader[7].ToString();
                        questionModel.Option3 = reader[8].ToString();
                        questionModel.Option4 = reader[9].ToString();

                        questionList.Add(questionModel);

                    }
                }

            }

            return questionList;
        }

        public IEnumerable<QuestionModel> GetByValue(string value)
        {
            var questionList = new List<QuestionModel>();

            var questionId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            var question = value;

            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                connection.Open();

                command.Connection = connection;
                command.CommandText = @"SELECT * FROM tbl_questions WHERE id=@id OR question like @question+'%' ORDER BY id desc";

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = questionId; // Use "@id" to match the parameter in the SQL query
                command.Parameters.Add("@question", MySqlDbType.String).Value = question; // Use "@question" to match the parameter in the SQL query

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var questionModel = new QuestionModel();

                        questionModel.QuestionId = (int)reader[0];
                        questionModel.CategoryId = (int)reader[1];
                        questionModel.HasImage = (bool)reader[2];
                        questionModel.ImageUri = reader[3].ToString();
                        questionModel.Question = reader[4].ToString();
                        questionModel.Answer = reader[5].ToString();
                        questionModel.Option1 = reader[6].ToString();
                        questionModel.Option2 = reader[7].ToString();
                        questionModel.Option3 = reader[8].ToString();
                        questionModel.Option4 = reader[9].ToString();

                        questionList.Add(questionModel);
                    }
                }
            }

            return questionList;

        }
    }
}
