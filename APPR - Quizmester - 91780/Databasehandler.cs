using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR___Quizmester___91780
{
    internal class Databasehandler
    {
        string connectionstring = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        DataTable dataTable = null;
        int maxScore = 10;
        Score score = null;
        List<Score> scorelist = null;
        TimeSpan scoreTime = TimeSpan.Zero;
        DateTime scoreDate = DateTime.MinValue;
        string playername = string.Empty;
        int scorelistcount = 0;

        public bool UsernameExists(string username)
        {
            FillDatatableParam(
                "SELECT PlayerName FROM PlayerTable WHERE PlayerName = @username",
                new SqlParameter("@username", username));

            return dataTable.Rows.Count > 0;
        }

        public bool RegisterUser(string username, string password)
        {
            if (UsernameExists(username))
            {
                return false;
            }

            string hash = HashPassword(password);

            ExecuteQueryParam(
                "INSERT INTO [dbo].[PlayerTable] ([PlayerName], [Password]) VALUES (@username, @password)",
                new SqlParameter("@username", username),
                new SqlParameter("@password", hash));

            return true;
        }

        public bool ValidateLogin(string username, string password)
        {
            FillDatatableParam(
                "SELECT Password FROM PlayerTable WHERE PlayerName = @username",
                new SqlParameter("@username", username));

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }

            string storedHash = dataTable.Rows[0][0].ToString();
            string attemptedHash = HashPassword(password);

            return storedHash == attemptedHash;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public void FillDatatableParam(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (dataTable = new DataTable("PlayerTable"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
        }

        public void ExecuteQueryParam(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Question> GetAllQuestions()
        {
            List<Question> questions = new List<Question>();

            FillDatatableParam("SELECT * FROM QuestionsTable");

            foreach (DataRow row in dataTable.Rows)
            {
                int questionId = Convert.ToInt32(row["QuestionID"]);
                string questionText = row["Question"].ToString();
                string correctAnswer = row["CorrectAnswer"].ToString();
                string falseAnswerOne = row["FalseAnswerOne"].ToString();
                string falseAnswerTwo = row["FalseAnswerTwo"].ToString();
                string falseAnswerThree = row["FalseAnswerThree"].ToString();
                string questionType = row["QuestionType"].ToString();

                questions.Add(new Question(questionId, questionText, correctAnswer,
                                            falseAnswerOne, falseAnswerTwo, falseAnswerThree, questionType));
            }

            return questions;
        }
    }
}
