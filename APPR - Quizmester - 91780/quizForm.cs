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
    public partial class quizForm : Form
    {
        private loginForm login;
        private string playername;

        public quizForm(loginForm loginScherm, string username)
        {
            InitializeComponent();
            login = loginScherm;
            playername = username;
        }

        private void quizForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            login.Close();   
        }
    }
}