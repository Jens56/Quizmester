using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

        int questionTime = 5;
        int currentQuestionTime = 0;

        int wrongAnswerPenalty = 5;

        bool jokerUsed = false;
        Image jokerOriginalImage = null;

        private string currentQuizName = "";

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

            tmrQuestion.Interval = 1000;
            tmrQuestion.Tick -= tmrQuestion_Tick;
            tmrQuestion.Tick += tmrQuestion_Tick;

            lblQuestion.Text = "Kies eerst een modus voordat de quiz begint!";
            lblTimer.Text = "";
            lblTimer.ForeColor = Color.Black;
            lblQuestionTimer.Text = "";

            rbAnswer1.Enabled = false;
            rbAnswer2.Enabled = false;
            rbAnswer3.Enabled = false;
            rbAnswer4.Enabled = false;

            pcbJoker.Enabled = false;
            jokerOriginalImage = pcbJoker.Image;

            cbxHighscore.Checked = false;
            lbxHighscore.Visible = false;

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

            currentQuizName = questionType ?? "Chaos modus";

            btnHistory.Enabled = false;
            btnF1.Enabled = false;
            btnTechnology.Enabled = false;
            btnChaosMode.Enabled = false;

            rbAnswer1.Enabled = true;
            rbAnswer2.Enabled = true;
            rbAnswer3.Enabled = true;
            rbAnswer4.Enabled = true;

            jokerUsed = false;
            pcbJoker.Enabled = true;
            pcbJoker.Image = jokerOriginalImage;

            cbxHighscore.Checked = false;
            lbxHighscore.Visible = false;

            currentTime = quizTime;
            lblTimer.Text = currentTime.ToString();
            lblTimer.ForeColor = Color.Black;
            tmrQuiz.Start();

            ShuffleList();
            currentQuestion = 0;
            score = 0;
            ShowQuestion(currentQuestion);
        }

        private void tmrQuiz_Tick(object sender, EventArgs e)
        {
            currentTime--;
            if (currentTime < 0)
            {
                currentTime = 0;
            }

            lblTimer.Text = currentTime.ToString();
            lblTimer.ForeColor = (currentTime <= 10) ? Color.Red : Color.Black;

            if (currentTime <= 0)
            {
                EndGame("Tijd is op!");
            }
        }

        private void tmrQuestion_Tick(object sender, EventArgs e)
        {
            currentQuestionTime--;
            lblQuestionTimer.Text = currentQuestionTime.ToString();

            if (currentQuestionTime <= 0)
            {
                bool gameEnded = ApplyWrongAnswerPenalty();

                if (!gameEnded)
                {
                    GoToNextQuestion();
                }
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

            currentQuestionTime = questionTime;
            lblQuestionTimer.Text = currentQuestionTime.ToString();
            tmrQuestion.Stop();
            tmrQuestion.Start();
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
            bool gameEnded = false;

            if (string.Equals(selectedAnswer, correctAnswer, StringComparison.OrdinalIgnoreCase))
            {
                score++;
            }
            else
            {
                gameEnded = ApplyWrongAnswerPenalty();
            }

            if (!gameEnded)
            {
                GoToNextQuestion();
            }
        }

        private bool ApplyWrongAnswerPenalty()
        {
            currentTime -= wrongAnswerPenalty;
            if (currentTime < 0)
            {
                currentTime = 0;
            }

            lblTimer.Text = currentTime.ToString();
            lblTimer.ForeColor = (currentTime <= 10) ? Color.Red : Color.Black;

            if (currentTime <= 0)
            {
                EndGame("Tijd is op!");
                return true;
            }

            return false;
        }

        private void GoToNextQuestion()
        {
            tmrQuestion.Stop();

            currentQuestion++;

            if (currentQuestion >= questionList.Count)
            {
                EndGame("Klaar!");
                return;
            }

            ShowQuestion(currentQuestion);
        }

        private void EndGame(string message)
        {
            lblQuestion.Text = message + " Jouw score is " + score;

            rbAnswer1.Enabled = false;
            rbAnswer2.Enabled = false;
            rbAnswer3.Enabled = false;
            rbAnswer4.Enabled = false;

            pcbJoker.Enabled = false;

            btnHistory.Enabled = true;
            btnF1.Enabled = true;
            btnTechnology.Enabled = true;
            btnChaosMode.Enabled = true;

            tmrQuiz.Stop();
            tmrQuestion.Stop();

            lblQuestionTimer.Text = "";

            databasehandler.AddNewScore(score, playername, currentQuizName);
        }

        private void pcbJoker_Click(object sender, EventArgs e)
        {
            if (jokerUsed)
            {
                return;
            }

            jokerUsed = true;
            pcbJoker.Enabled = false;
            pcbJoker.Image = SetImageOpacity(jokerOriginalImage, 0.35f);

            GoToNextQuestion();
        }

        private Image SetImageOpacity(Image original, float opacity)
        {
            if (original == null)
            {
                return null;
            }

            Bitmap bmp = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(original,
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel, attributes);
            }

            return bmp;
        }

        private void cbxHighscore_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxHighscore.Checked)
            {
                databasehandler.ShowHighScore(lbxHighscore);
                lbxHighscore.Visible = true;
            }
            else
            {
                lbxHighscore.Visible = false;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            login.Close();
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            adminPanel admin = new adminPanel(login);
            admin.Show();
        }
    }
}