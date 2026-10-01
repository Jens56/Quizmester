using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace APPR___Quizmester___91780
{
    public partial class quizForm : Form
    {
        private loginForm login;
        private string playername;
        private Databasehandler databasehandler = new Databasehandler();

        private List<Question> allQuestions;
        private List<Question> questionList;
        private Random random = null;
        private int currentQuestion = 0;
        private int score = 0;

        private string[] currentAnswers = new string[4];
        private string correctAnswer = "";

        int quizTime = 60;
        int currentTime = 0;

        public quizForm(loginForm loginScherm, string username)
        {
            InitializeComponent();
            login = loginScherm;
            playername = username;
        }

        private void quizForm_Load(object sender, EventArgs e)
        {
            random = new Random();

            tmrQuiz.Interval = 1000;
            tmrQuiz.Tick -= tmrQuiz_Tick;
            tmrQuiz.Tick += tmrQuiz_Tick;

            lblQuestion.Text = "Kies eerst een modus voordat de quiz begint!";
            lblTimer.Text = "";

            rbAnswer1.Enabled = false;
            rbAnswer2.Enabled = false;
            rbAnswer3.Enabled = false;
            rbAnswer4.Enabled = false;

            allQuestions = databasehandler.GetAllQuestions();

            if (allQuestions == null || allQuestions.Count == 0)
            {
                MessageBox.Show("Geen vragen gevonden.");
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            StartQuiz("Geschiedenis");
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            StartQuiz("F1");
        }

        private void btnTechnology_Click(object sender, EventArgs e)
        {
            StartQuiz("Technologie");
        }

        private void btnChaosMode_Click(object sender, EventArgs e)
        {
            StartQuiz(null);
        }

        private void StartQuiz(string questionType)
        {
            if (allQuestions == null || allQuestions.Count == 0)
            {
                MessageBox.Show("Er zijn geen vragen om te spelen.");
                return;
            }

            if (questionType == null)
            {
                questionList = new List<Question>(allQuestions);
            }
            else
            {
                questionList = allQuestions
                    .Where(q => q.GetQuestionType().Equals(questionType, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (questionList.Count == 0)
            {
                MessageBox.Show("Geen vragen gevonden voor deze modus.");
                return;
            }

            btnHistory.Enabled = false;
            btnF1.Enabled = false;
            btnTechnology.Enabled = false;
            btnChaosMode.Enabled = false;

            rbAnswer1.Enabled = true;
            rbAnswer2.Enabled = true;
            rbAnswer3.Enabled = true;
            rbAnswer4.Enabled = true;

            currentTime = quizTime;
            lblTimer.Text = currentTime.ToString();
            tmrQuiz.Start();

            ShuffleList();
            currentQuestion = 0;
            score = 0;
            ShowQuestion(currentQuestion);
        }

        private void tmrQuiz_Tick(object sender, EventArgs e)
        {
            currentTime--;
            lblTimer.Text = currentTime.ToString();

            if (currentTime <= 0)
            {
                EndGame("Tijd is op! Jouw score is: " + score + " van de " + questionList.Count);
            }
        }

        private void ShuffleList()
        {
            for (int i = questionList.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                Question temp = questionList[i];
                questionList[i] = questionList[j];
                questionList[j] = temp;
            }
        }

        private void ShowQuestion(int index)
        {
            Question q = questionList[index];

            lblQuestion.Text = q.GetQuestion();
            correctAnswer = q.GetCorrectAnswer();

            currentAnswers[0] = q.GetCorrectAnswer();
            currentAnswers[1] = q.GetFalseAnswerOne();
            currentAnswers[2] = q.GetFalseAnswerTwo();
            currentAnswers[3] = q.GetFalseAnswerThree();
            ShuffleAnswers();

            rbAnswer1.CheckedChanged -= rbAnswer_CheckedChanged;
            rbAnswer2.CheckedChanged -= rbAnswer_CheckedChanged;
            rbAnswer3.CheckedChanged -= rbAnswer_CheckedChanged;
            rbAnswer4.CheckedChanged -= rbAnswer_CheckedChanged;

            rbAnswer1.Text = currentAnswers[0];
            rbAnswer2.Text = currentAnswers[1];
            rbAnswer3.Text = currentAnswers[2];
            rbAnswer4.Text = currentAnswers[3];

            rbAnswer1.Checked = false;
            rbAnswer2.Checked = false;
            rbAnswer3.Checked = false;
            rbAnswer4.Checked = false;

            rbAnswer1.CheckedChanged += rbAnswer_CheckedChanged;
            rbAnswer2.CheckedChanged += rbAnswer_CheckedChanged;
            rbAnswer3.CheckedChanged += rbAnswer_CheckedChanged;
            rbAnswer4.CheckedChanged += rbAnswer_CheckedChanged;
        }

        private void ShuffleAnswers()
        {
            for (int i = currentAnswers.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                string temp = currentAnswers[i];
                currentAnswers[i] = currentAnswers[j];
                currentAnswers[j] = temp;
            }
        }

        private void rbAnswer_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (!rb.Checked)
            {
                return;
            }

            string selectedAnswer = rb.Text;

            if (string.Equals(selectedAnswer, correctAnswer, StringComparison.OrdinalIgnoreCase))
            {
                score++;
            }

            currentQuestion++;

            if (currentQuestion >= questionList.Count)
            {
                EndGame("Klaar! Jouw score is: " + score + " van de " + questionList.Count);
                return;
            }

            ShowQuestion(currentQuestion);
        }

        private void EndGame(string message)
        {
            lblQuestion.Text = message;

            rbAnswer1.Enabled = false;
            rbAnswer2.Enabled = false;
            rbAnswer3.Enabled = false;
            rbAnswer4.Enabled = false;

            btnHistory.Enabled = true;
            btnF1.Enabled = true;
            btnTechnology.Enabled = true;
            btnChaosMode.Enabled = true;

            tmrQuiz.Stop();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            login.Close();
        }
    }
}