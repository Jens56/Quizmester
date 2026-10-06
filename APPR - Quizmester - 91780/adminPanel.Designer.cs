namespace APPR___Quizmester___91780
{
    partial class adminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tpAdminPanel = new System.Windows.Forms.TabControl();
            this.tpAddQuestions = new System.Windows.Forms.TabPage();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.txbAddQuestion = new System.Windows.Forms.TextBox();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveAddQuestion = new System.Windows.Forms.Button();
            this.lbxUsers = new System.Windows.Forms.ListBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.lbxQuestions = new System.Windows.Forms.ListBox();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbIsAdmin = new System.Windows.Forms.ComboBox();
            this.btnSaveAddUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbWrongAnswerA = new System.Windows.Forms.TextBox();
            this.txbWrongAnswerB = new System.Windows.Forms.TextBox();
            this.txbWrongAnswerC = new System.Windows.Forms.TextBox();
            this.txbRightAnswer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tpAdminPanel.SuspendLayout();
            this.tpAddQuestions.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpAdminPanel
            // 
            this.tpAdminPanel.Controls.Add(this.tpAddQuestions);
            this.tpAdminPanel.Controls.Add(this.tpUsers);
            this.tpAdminPanel.Location = new System.Drawing.Point(12, 12);
            this.tpAdminPanel.Name = "tpAdminPanel";
            this.tpAdminPanel.SelectedIndex = 0;
            this.tpAdminPanel.Size = new System.Drawing.Size(776, 426);
            this.tpAdminPanel.TabIndex = 0;
            // 
            // tpAddQuestions
            // 
            this.tpAddQuestions.Controls.Add(this.label8);
            this.tpAddQuestions.Controls.Add(this.label7);
            this.tpAddQuestions.Controls.Add(this.label6);
            this.tpAddQuestions.Controls.Add(this.label5);
            this.tpAddQuestions.Controls.Add(this.txbRightAnswer);
            this.tpAddQuestions.Controls.Add(this.txbWrongAnswerC);
            this.tpAddQuestions.Controls.Add(this.txbWrongAnswerB);
            this.tpAddQuestions.Controls.Add(this.txbWrongAnswerA);
            this.tpAddQuestions.Controls.Add(this.btnDeleteQuestion);
            this.tpAddQuestions.Controls.Add(this.lbxQuestions);
            this.tpAddQuestions.Controls.Add(this.btnSaveAddQuestion);
            this.tpAddQuestions.Controls.Add(this.label2);
            this.tpAddQuestions.Controls.Add(this.label1);
            this.tpAddQuestions.Controls.Add(this.cbxCategory);
            this.tpAddQuestions.Controls.Add(this.txbAddQuestion);
            this.tpAddQuestions.Location = new System.Drawing.Point(4, 22);
            this.tpAddQuestions.Name = "tpAddQuestions";
            this.tpAddQuestions.Padding = new System.Windows.Forms.Padding(3);
            this.tpAddQuestions.Size = new System.Drawing.Size(768, 400);
            this.tpAddQuestions.TabIndex = 0;
            this.tpAddQuestions.Text = "Vragen toevoegen";
            this.tpAddQuestions.UseVisualStyleBackColor = true;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.label4);
            this.tpUsers.Controls.Add(this.label3);
            this.tpUsers.Controls.Add(this.btnSaveAddUser);
            this.tpUsers.Controls.Add(this.cmbIsAdmin);
            this.tpUsers.Controls.Add(this.textBox1);
            this.tpUsers.Controls.Add(this.btnDeleteUser);
            this.tpUsers.Controls.Add(this.lbxUsers);
            this.tpUsers.Location = new System.Drawing.Point(4, 22);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsers.Size = new System.Drawing.Size(768, 400);
            this.tpUsers.TabIndex = 1;
            this.tpUsers.Text = "Gebruikers";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // txbAddQuestion
            // 
            this.txbAddQuestion.Location = new System.Drawing.Point(32, 63);
            this.txbAddQuestion.Name = "txbAddQuestion";
            this.txbAddQuestion.Size = new System.Drawing.Size(100, 20);
            this.txbAddQuestion.TabIndex = 0;
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(32, 109);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(100, 21);
            this.cbxCategory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vraag:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Categorie:";
            // 
            // btnSaveAddQuestion
            // 
            this.btnSaveAddQuestion.Location = new System.Drawing.Point(32, 289);
            this.btnSaveAddQuestion.Name = "btnSaveAddQuestion";
            this.btnSaveAddQuestion.Size = new System.Drawing.Size(110, 23);
            this.btnSaveAddQuestion.TabIndex = 4;
            this.btnSaveAddQuestion.Text = "Opslaan/toevoegen";
            this.btnSaveAddQuestion.UseVisualStyleBackColor = true;
            // 
            // lbxUsers
            // 
            this.lbxUsers.FormattingEnabled = true;
            this.lbxUsers.Location = new System.Drawing.Point(246, 26);
            this.lbxUsers.Name = "lbxUsers";
            this.lbxUsers.Size = new System.Drawing.Size(148, 342);
            this.lbxUsers.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(31, 149);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.TabIndex = 1;
            this.btnDeleteUser.Text = "Verwijder";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // lbxQuestions
            // 
            this.lbxQuestions.FormattingEnabled = true;
            this.lbxQuestions.Location = new System.Drawing.Point(190, 20);
            this.lbxQuestions.Name = "lbxQuestions";
            this.lbxQuestions.Size = new System.Drawing.Size(124, 342);
            this.lbxQuestions.TabIndex = 5;
            this.lbxQuestions.SelectedIndexChanged += new System.EventHandler(this.lbxQuestions_SelectedIndexChanged);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(32, 318);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteQuestion.TabIndex = 6;
            this.btnDeleteQuestion.Text = "Verwijder";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // cmbIsAdmin
            // 
            this.cmbIsAdmin.FormattingEnabled = true;
            this.cmbIsAdmin.Location = new System.Drawing.Point(31, 79);
            this.cmbIsAdmin.Name = "cmbIsAdmin";
            this.cmbIsAdmin.Size = new System.Drawing.Size(100, 21);
            this.cmbIsAdmin.TabIndex = 3;
            // 
            // btnSaveAddUser
            // 
            this.btnSaveAddUser.Location = new System.Drawing.Point(31, 120);
            this.btnSaveAddUser.Name = "btnSaveAddUser";
            this.btnSaveAddUser.Size = new System.Drawing.Size(118, 23);
            this.btnSaveAddUser.TabIndex = 4;
            this.btnSaveAddUser.Text = "Opslaan/toevoegen";
            this.btnSaveAddUser.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Naam:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Is admin:";
            // 
            // txbWrongAnswerA
            // 
            this.txbWrongAnswerA.Location = new System.Drawing.Point(32, 152);
            this.txbWrongAnswerA.Name = "txbWrongAnswerA";
            this.txbWrongAnswerA.Size = new System.Drawing.Size(100, 20);
            this.txbWrongAnswerA.TabIndex = 7;
            // 
            // txbWrongAnswerB
            // 
            this.txbWrongAnswerB.Location = new System.Drawing.Point(32, 188);
            this.txbWrongAnswerB.Name = "txbWrongAnswerB";
            this.txbWrongAnswerB.Size = new System.Drawing.Size(100, 20);
            this.txbWrongAnswerB.TabIndex = 8;
            // 
            // txbWrongAnswerC
            // 
            this.txbWrongAnswerC.Location = new System.Drawing.Point(32, 224);
            this.txbWrongAnswerC.Name = "txbWrongAnswerC";
            this.txbWrongAnswerC.Size = new System.Drawing.Size(100, 20);
            this.txbWrongAnswerC.TabIndex = 9;
            // 
            // txbRightAnswer
            // 
            this.txbRightAnswer.Location = new System.Drawing.Point(32, 263);
            this.txbRightAnswer.Name = "txbRightAnswer";
            this.txbRightAnswer.Size = new System.Drawing.Size(100, 20);
            this.txbRightAnswer.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Foute antwoord A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Foute antwoord B";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Foute antwoord C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Juiste antwoord";
            // 
            // adminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 444);
            this.Controls.Add(this.tpAdminPanel);
            this.Name = "adminPanel";
            this.Text = "adminPanel";
            this.Load += new System.EventHandler(this.adminPanel_Load);
            this.tpAdminPanel.ResumeLayout(false);
            this.tpAddQuestions.ResumeLayout(false);
            this.tpAddQuestions.PerformLayout();
            this.tpUsers.ResumeLayout(false);
            this.tpUsers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tpAddQuestions;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabControl tpAdminPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.TextBox txbAddQuestion;
        private System.Windows.Forms.Button btnSaveAddQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.ListBox lbxQuestions;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.ListBox lbxUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveAddUser;
        private System.Windows.Forms.ComboBox cmbIsAdmin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbRightAnswer;
        private System.Windows.Forms.TextBox txbWrongAnswerC;
        private System.Windows.Forms.TextBox txbWrongAnswerB;
        private System.Windows.Forms.TextBox txbWrongAnswerA;
        private System.Windows.Forms.Label label8;
    }
}