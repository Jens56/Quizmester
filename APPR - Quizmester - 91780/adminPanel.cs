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
        private List<Player> playerList;
        private loginForm login;

        private Question selectedQuestion = null;
        private Player selectedPlayer = null;

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
            lbxUsers.SelectedIndexChanged -= lbxUsers_SelectedIndexChanged;
            lbxUsers.SelectedIndexChanged += lbxUsers_SelectedIndexChanged;

            cbxCategory.Items.Clear();
            cbxCategory.Items.Add("Geschiedenis");
            cbxCategory.Items.Add("F1");
            cbxCategory.Items.Add("Technologie");

            cbxIsAdmin.Items.Clear();
            cbxIsAdmin.Items.Add("Ja");
            cbxIsAdmin.Items.Add("Nee");

            txbPassword.PasswordChar = '*';

            btnDeleteQuestion.Enabled = false;
            btnDeleteUser.Enabled = false;

            LoadQuestions();
            LoadUsers();
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

        private void btnSaveAddQuestion_Click(object sender, EventArgs e)
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

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
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

        private void LoadUsers()
        {
            lbxUsers.Items.Clear();

            playerList = databasehandler.GetAllPlayers();

            foreach (Player p in playerList)
            {
                lbxUsers.Items.Add(p.GetPlayerName());
            }
        }

        private void lbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxUsers.SelectedItem == null)
            {
                return;
            }

            string selectedName = lbxUsers.SelectedItem.ToString();
            selectedPlayer = playerList.FirstOrDefault(p => p.GetPlayerName() == selectedName);

            if (selectedPlayer == null)
            {
                return;
            }

            txbUsername.Text = selectedPlayer.GetPlayerName();
            txbPassword.Text = "********"; 
            cbxIsAdmin.Text = selectedPlayer.GetIsAdmin() ? "Ja" : "Nee";

            btnDeleteUser.Enabled = true;
        }

        private void btnSaveAddUser_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || cbxIsAdmin.SelectedIndex == -1)
            {
                MessageBox.Show("Vul een naam in en kies of de gebruiker admin is.");
                return;
            }

            bool isAdmin = cbxIsAdmin.Text == "Ja";

            if (selectedPlayer == null)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vul een wachtwoord in voor de nieuwe gebruiker.");
                    return;
                }

                if (!databasehandler.AddPlayer(username, password, isAdmin))
                {
                    MessageBox.Show("Deze gebruikersnaam bestaat al.");
                    return;
                }

                MessageBox.Show("Gebruiker toegevoegd.");
            }
            else
            {
                string newPassword = (password == "********") ? "" : password;

                if (!databasehandler.UpdatePlayer(
                        selectedPlayer.GetPlayerId(),
                        selectedPlayer.GetPlayerName(),
                        username,
                        isAdmin,
                        newPassword))
                {
                    MessageBox.Show("Deze gebruikersnaam bestaat al.");
                    return;
                }

                MessageBox.Show("Gebruiker bijgewerkt.");
            }

            LoadUsers();
            ClearUserFields();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedPlayer == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "Weet je zeker dat je " + selectedPlayer.GetPlayerName() + "(en " + selectedPlayer.GetPlayerName() + "'s scores) wilt verwijderen?",
                "Bevestigen", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                databasehandler.DeletePlayer(selectedPlayer.GetPlayerId());
                LoadUsers();
                ClearUserFields();
            }
        }

        private void ClearUserFields()
        {
            selectedPlayer = null;
            lbxUsers.ClearSelected();

            txbUsername.Text = "";
            txbPassword.Text = "";
            cbxIsAdmin.SelectedIndex = -1;

            btnDeleteUser.Enabled = false;
        }
    }
}