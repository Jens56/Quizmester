using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public void SetOrCreateNewUsername(string username)
        {
            FillDatatable("SELECT Playername FROM PlayerTable WHERE Playername = '" + username + "'");

            if (dataTable.Rows.Count == 0)
            {
                ExecuteQuery("INSERT INTO [dbo].[PlayerTable] ([Playername], [AccountCreatedDate]) VALUES (N'" + username + "', N'" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "')");
            }
        }

        public void AddNewScore(TimeSpan score, string playername)
        {
            ExecuteQuery("INSERT INTO [dbo].[ScoreTable] ([Testscore], [TestDateTime], [Playername]) VALUES (N'" + score + "', N'" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "', N'" + playername + "')");
        }

        public void ShowHighScore(ListBox updateListbox)
        {
            updateListbox.Items.Clear();
            scorelist = new List<Score>();
            FillDatatable("SELECT * FROM ScoreTable");
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    int scoreId = i;
                    scoreTime = (TimeSpan)dataTable.Rows[i][1];
                    scoreDate = (DateTime)dataTable.Rows[i][2];
                    playername = dataTable.Rows[i][3].ToString();
                    score = new Score(scoreId, scoreTime, scoreDate, playername);
                    scorelist.Add(score);
                }
            }
            scorelist = scorelist.OrderBy(o => o.GetScore()).ThenBy(o => o.GetDatePlayed()).ToList();
            scorelistcount = scorelist.Count;

            if (scorelistcount > 10)
            {
                scorelistcount = 10;
            }
            for (int i = 0; i < scorelistcount; i++)
            {
                updateListbox.Items.Add("Number: " + (i + 1));
                updateListbox.Items.Add("Player: " + scorelist[i].GetPlayername());
                updateListbox.Items.Add("Score: " + scorelist[i].GetScore().Seconds + ":" + scorelist[i].GetScore().Milliseconds);
                updateListbox.Items.Add("Date played " + scorelist[i].GetDatePlayed());
                updateListbox.Items.Add(" ");
            }
        }

        public void FillDatatable(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (dataTable = new DataTable("FormulaOneDataTable"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
            }
        }

        public void ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                using (dataTable = new DataTable("FormulaOneDatatable"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
