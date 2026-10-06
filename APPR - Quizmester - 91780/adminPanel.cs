using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace APPR___Quizmester___91780
{
    public partial class adminPanel : Form
    {
        private Databasehandler databasehandler = new Databasehandler();
        private List<Question> questionList;
        private loginForm login;

        private Question selectedQuestion = null;

        public adminPanel(loginForm loginScherm)
        {
            InitializeComponent();
            login = loginScherm;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            login.Show();
        }

        private void adminPanel_Load(object sender, EventArgs e)
        {
            cbxCategory.Items.Clear();
            cbxCategory.Items.Add("Geschiedenis");
            cbxCategory.Items.Add("F1");
            cbxCategory.Items.Add("Technologie");

            btnDeleteQuestion.Enabled = false;

            LoadQuestions();
        }

        private void LoadQuestions()
        {
            lbxQuestions.Items.Clear();

            questionList = databasehandler.GetAllQuestions();

            foreach (Question q in questionList)
            {
                lbxQuestions.Items.Add(q.GetQuestion());
            }
        }

        private void lbxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxQuestions.SelectedItem == null)
            {
                return;
            }

            string selectedText = lbxQuestions.SelectedItem.ToString();
            selectedQuestion = questionList.FirstOrDefault(q => q.GetQuestion() == selectedText);

            if (selectedQuestion == null)
            {
                return;
            }

            txbAddQuestion.Text = selectedQuestion.GetQuestion();
            cbxCategory.Text = selectedQuestion.GetQuestionType();
            txbRightAnswer.Text = selectedQuestion.GetCorrectAnswer();
            txbWrongAnswerA.Text = selectedQuestion.GetFalseAnswerOne();
            txbWrongAnswerB.Text = selectedQuestion.GetFalseAnswerTwo();
            txbWrongAnswerC.Text = selectedQuestion.GetFalseAnswerThree();

            btnDeleteQuestion.Enabled = true;
        }

        private void btnOpslaanToevoegen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbAddQuestion.Text) ||
                string.IsNullOrWhiteSpace(txbRightAnswer.Text) ||
                string.IsNullOrWhiteSpace(txbWrongAnswerA.Text) ||
                string.IsNullOrWhiteSpace(txbWrongAnswerB.Text) ||
                string.IsNullOrWhiteSpace(txbWrongAnswerC.Text) ||
                cbxCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Vul de vraag, de categorie en alle vier de antwoorden in.");
                return;
            }

            if (selectedQuestion == null)
            {
                databasehandler.AddQuestion(
                    txbAddQuestion.Text.Trim(),
                    txbRightAnswer.Text.Trim(),
                    txbWrongAnswerA.Text.Trim(),
                    txbWrongAnswerB.Text.Trim(),
                    txbWrongAnswerC.Text.Trim(),
                    cbxCategory.Text);

                MessageBox.Show("Vraag toegevoegd.");
            }
            else
            {
                databasehandler.UpdateQuestion(
                    selectedQuestion.GetQuestionId(),
                    txbAddQuestion.Text.Trim(),
                    txbRightAnswer.Text.Trim(),
                    txbWrongAnswerA.Text.Trim(),
                    txbWrongAnswerB.Text.Trim(),
                    txbWrongAnswerC.Text.Trim(),
                    cbxCategory.Text);

                MessageBox.Show("Vraag bijgewerkt.");
            }

            LoadQuestions();
            ClearFields();
        }

        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            if (selectedQuestion == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "Weet je zeker dat je deze vraag wilt verwijderen?\n\n" + selectedQuestion.GetQuestion(),
                "Bevestigen", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                databasehandler.DeleteQuestion(selectedQuestion.GetQuestionId());
                LoadQuestions();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            selectedQuestion = null;
            lbxQuestions.ClearSelected();

            txbAddQuestion.Text = "";
            txbRightAnswer.Text = "";
            txbWrongAnswerA.Text = "";
            txbWrongAnswerB.Text = "";
            txbWrongAnswerC.Text = "";
            cbxCategory.SelectedIndex = -1;

            btnDeleteQuestion.Enabled = false;
        }
    }
}