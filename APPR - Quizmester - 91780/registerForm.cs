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
    public partial class registerForm : Form
    {
        Databasehandler databasehandler = new Databasehandler();
        private loginForm login;   

        public registerForm(loginForm loginScherm)
        {
            InitializeComponent();
            login = loginScherm;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txbPassword.PasswordChar = '•';
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vul zowel een gebruikersnaam als wachtwoord in.");
                return;
            }

            bool success = databasehandler.RegisterUser(username, password);

            if (success)
            {
                MessageBox.Show("Account aangemaakt! Je kan nu inloggen.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Deze gebruikersnaam bestaat al.");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            login.Show();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
