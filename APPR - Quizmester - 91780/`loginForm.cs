using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR___Quizmester___91780
{
    public partial class loginForm : Form
    {
        Databasehandler databasehandler = new Databasehandler();

        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            txbPassword.PasswordChar = '•';
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            registerForm register = new registerForm(this);   
            register.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vul zowel een gebruikersnaam als wachtwoord in.");
                return;
            }

            bool isAdmin;
            if (databasehandler.ValidateLogin(username, password, out isAdmin))
            {
                if (isAdmin)
                {
                    adminPanel admin = new adminPanel(this);
                    admin.Show();
                }
                else
                {
                    quizForm quiz = new quizForm(this, username);
                    quiz.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Onjuiste gebruikersnaam of wachtwoord.");
            }
        }
    }
}