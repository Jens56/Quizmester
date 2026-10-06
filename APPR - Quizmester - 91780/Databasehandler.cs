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

        public bool ValidateLogin(string username, string password, out bool isAdmin)
        {
            FillDatatableParam(
                "SELECT Password, IsAdmin FROM PlayerTable WHERE PlayerName = @username",
                new SqlParameter("@username", username));

            isAdmin = false;

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }

            string storedHash = dataTable.Rows[0][0].ToString();
            string attemptedHash = HashPassword(password);

            if (storedHash != attemptedHash)
            {
                return false;
            }

            isAdmin = Convert.ToBoolean(dataTable.Rows[0][1]);
            return true;
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
                using (dataTable = new DataTable("ResultTable"))
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

        public int GetQuizId(string quizName)
        {
            FillDatatableParam(
                "SELECT QuizID FROM QuizzesTable WHERE QuizName = @quizName",
                new SqlParameter("@quizName", quizName));

            if (dataTable.Rows.Count == 0)
            {
                return -1;
            }

            return Convert.ToInt32(dataTable.Rows[0][0]);
        }

        public int GetPlayerId(string playername)
        {
            FillDatatableParam(
                "SELECT PlayerID FROM PlayerTable WHERE PlayerName = @playername",
                new SqlParameter("@playername", playername));

            if (dataTable.Rows.Count == 0)
            {
                return -1;
            }

            return Convert.ToInt32(dataTable.Rows[0][0]);
        }

        public void AddNewScore(int correctAnswers, string playername, string quizName)
        {
            int playerId = GetPlayerId(playername);
            int quizId = GetQuizId(quizName);

            if (playerId == -1 || quizId == -1)
            {
                return;
            }

            int newRankingId = GetNextRankingId();

            ExecuteQueryParam(
                "INSERT INTO [dbo].[QuizRankingsTable] ([RankingID], [PlayerID], [QuizID], [Score], [DateDone]) VALUES (@rankingId, @playerId, @quizId, @score, @dateDone)",
                new SqlParameter("@rankingId", newRankingId),
                new SqlParameter("@playerId", playerId),
                new SqlParameter("@quizId", quizId),
                new SqlParameter("@score", correctAnswers),
                new SqlParameter("@dateDone", DateTime.Now));
        }

        private int GetNextRankingId()
        {
            FillDatatableParam("SELECT ISNULL(MAX(RankingID), 0) + 1 FROM QuizRankingsTable");
            return Convert.ToInt32(dataTable.Rows[0][0]);
        }

        public void ShowHighScore(ListBox updateListbox)
        {
            updateListbox.Items.Clear();

            FillDatatableParam(
                "SELECT r.Score, r.DateDone, p.PlayerName " +
                "FROM QuizRankingsTable r " +
                "JOIN PlayerTable p ON r.PlayerID = p.PlayerID " +
                "ORDER BY r.Score DESC, r.DateDone ASC");

            int count = Math.Min(dataTable.Rows.Count, 10);

            for (int i = 0; i < count; i++)
            {
                int scoreValue = Convert.ToInt32(dataTable.Rows[i]["Score"]);
                DateTime dateDone = Convert.ToDateTime(dataTable.Rows[i]["DateDone"]);
                string playerName = dataTable.Rows[i]["PlayerName"].ToString();

                updateListbox.Items.Add("Number: " + (i + 1));
                updateListbox.Items.Add("Player: " + playerName);
                updateListbox.Items.Add("Score: " + scoreValue);
                updateListbox.Items.Add("Date played: " + dateDone);
                updateListbox.Items.Add(" ");
            }
        }
        public void UpdateQuestion(int questionId, string question, string correctAnswer,
                            string falseAnswerOne, string falseAnswerTwo, string falseAnswerThree,
                            string questionType)
        {
            ExecuteQueryParam(
                "UPDATE QuestionsTable SET Question = @question, CorrectAnswer = @correctAnswer, " +
                "FalseAnswerOne = @falseAnswerOne, FalseAnswerTwo = @falseAnswerTwo, FalseAnswerThree = @falseAnswerThree, " +
                "QuestionType = @questionType WHERE QuestionID = @questionId",
                new SqlParameter("@question", question),
                new SqlParameter("@correctAnswer", correctAnswer),
                new SqlParameter("@falseAnswerOne", falseAnswerOne),
                new SqlParameter("@falseAnswerTwo", falseAnswerTwo),
                new SqlParameter("@falseAnswerThree", falseAnswerThree),
                new SqlParameter("@questionType", questionType),
                new SqlParameter("@questionId", questionId));
        }

        public void AddQuestion(string question, string correctAnswer, string falseAnswerOne,
                                 string falseAnswerTwo, string falseAnswerThree, string questionType)
        {
            ExecuteQueryParam(
                "INSERT INTO [dbo].[QuestionsTable] ([Question], [CorrectAnswer], [FalseAnswerOne], [FalseAnswerTwo], [FalseAnswerThree], [QuestionType]) " +
                "VALUES (@question, @correctAnswer, @falseAnswerOne, @falseAnswerTwo, @falseAnswerThree, @questionType)",
                new SqlParameter("@question", question),
                new SqlParameter("@correctAnswer", correctAnswer),
                new SqlParameter("@falseAnswerOne", falseAnswerOne),
                new SqlParameter("@falseAnswerTwo", falseAnswerTwo),
                new SqlParameter("@falseAnswerThree", falseAnswerThree),
                new SqlParameter("@questionType", questionType));
        }

        public void DeleteQuestion(int questionId)
        {
            ExecuteQueryParam(
                "DELETE FROM QuestionsTable WHERE QuestionID = @questionId",
                new SqlParameter("@questionId", questionId));
        }
    }
}