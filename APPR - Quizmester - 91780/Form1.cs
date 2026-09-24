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
    public partial class Form1 : Form
    {
        Databasehandler databasehandler = new Databasehandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            }
            else
            {
                MessageBox.Show("Deze gebruikersnaam bestaat al.");
            }
        }
    }
}
