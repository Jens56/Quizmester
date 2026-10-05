namespace APPR___Quizmester___91780
{
    partial class quizForm
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
            this.components = new System.ComponentModel.Container();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbAnswer1 = new System.Windows.Forms.RadioButton();
            this.rbAnswer2 = new System.Windows.Forms.RadioButton();
            this.rbAnswer3 = new System.Windows.Forms.RadioButton();
            this.rbAnswer4 = new System.Windows.Forms.RadioButton();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnF1 = new System.Windows.Forms.Button();
            this.btnTechnology = new System.Windows.Forms.Button();
            this.btnChaosMode = new System.Windows.Forms.Button();
            this.tmrQuiz = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.tmrQuestion = new System.Windows.Forms.Timer(this.components);
            this.lblQuestionTimer = new System.Windows.Forms.Label();
            this.pcbJoker = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxHighscore = new System.Windows.Forms.CheckBox();
            this.lbxHighscore = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbJoker)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(422, 258);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(219, 13);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Kies eerst een modus voordat de quiz begint!";
            // 
            // rbAnswer1
            // 
            this.rbAnswer1.AutoSize = true;
            this.rbAnswer1.Location = new System.Drawing.Point(515, 322);
            this.rbAnswer1.Name = "rbAnswer1";
            this.rbAnswer1.Size = new System.Drawing.Size(14, 13);
            this.rbAnswer1.TabIndex = 1;
            this.rbAnswer1.TabStop = true;
            this.rbAnswer1.UseVisualStyleBackColor = true;
            // 
            // rbAnswer2
            // 
            this.rbAnswer2.AutoSize = true;
            this.rbAnswer2.Location = new System.Drawing.Point(515, 345);
            this.rbAnswer2.Name = "rbAnswer2";
            this.rbAnswer2.Size = new System.Drawing.Size(14, 13);
            this.rbAnswer2.TabIndex = 2;
            this.rbAnswer2.TabStop = true;
            this.rbAnswer2.UseVisualStyleBackColor = true;
            // 
            // rbAnswer3
            // 
            this.rbAnswer3.AutoSize = true;
            this.rbAnswer3.Location = new System.Drawing.Point(515, 369);
            this.rbAnswer3.Name = "rbAnswer3";
            this.rbAnswer3.Size = new System.Drawing.Size(14, 13);
            this.rbAnswer3.TabIndex = 3;
            this.rbAnswer3.TabStop = true;
            this.rbAnswer3.UseVisualStyleBackColor = true;
            // 
            // rbAnswer4
            // 
            this.rbAnswer4.AutoSize = true;
            this.rbAnswer4.Location = new System.Drawing.Point(515, 393);
            this.rbAnswer4.Name = "rbAnswer4";
            this.rbAnswer4.Size = new System.Drawing.Size(14, 13);
            this.rbAnswer4.TabIndex = 4;
            this.rbAnswer4.TabStop = true;
            this.rbAnswer4.UseVisualStyleBackColor = true;
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(404, 288);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(80, 23);
            this.btnHistory.TabIndex = 5;
            this.btnHistory.Text = "Geschiedenis";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnF1
            // 
            this.btnF1.Location = new System.Drawing.Point(490, 288);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(69, 22);
            this.btnF1.TabIndex = 6;
            this.btnF1.Text = "F1";
            this.btnF1.UseVisualStyleBackColor = true;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // btnTechnology
            // 
            this.btnTechnology.Location = new System.Drawing.Point(565, 288);
            this.btnTechnology.Name = "btnTechnology";
            this.btnTechnology.Size = new System.Drawing.Size(76, 21);
            this.btnTechnology.TabIndex = 7;
            this.btnTechnology.Text = "Technologie";
            this.btnTechnology.UseVisualStyleBackColor = true;
            this.btnTechnology.Click += new System.EventHandler(this.btnTechnology_Click);
            // 
            // btnChaosMode
            // 
            this.btnChaosMode.Location = new System.Drawing.Point(647, 288);
            this.btnChaosMode.Name = "btnChaosMode";
            this.btnChaosMode.Size = new System.Drawing.Size(84, 20);
            this.btnChaosMode.TabIndex = 8;
            this.btnChaosMode.Text = "Chaos modus";
            this.btnChaosMode.UseVisualStyleBackColor = true;
            this.btnChaosMode.Click += new System.EventHandler(this.btnChaosMode_Click);
            // 
            // tmrQuiz
            // 
            this.tmrQuiz.Tick += new System.EventHandler(this.tmrQuiz_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(529, 170);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 13);
            this.lblTimer.TabIndex = 9;
            // 
            // lblQuestionTimer
            // 
            this.lblQuestionTimer.AutoSize = true;
            this.lblQuestionTimer.Location = new System.Drawing.Point(339, 428);
            this.lblQuestionTimer.Name = "lblQuestionTimer";
            this.lblQuestionTimer.Size = new System.Drawing.Size(0, 13);
            this.lblQuestionTimer.TabIndex = 10;
            // 
            // pcbJoker
            // 
            this.pcbJoker.Image = global::APPR___Quizmester___91780.Properties.Resources.joker;
            this.pcbJoker.Location = new System.Drawing.Point(697, 393);
            this.pcbJoker.Name = "pcbJoker";
            this.pcbJoker.Size = new System.Drawing.Size(100, 50);
            this.pcbJoker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbJoker.TabIndex = 11;
            this.pcbJoker.TabStop = false;
            this.pcbJoker.Click += new System.EventHandler(this.pcbJoker_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Joker kan je maar 1 keer gebruiken!";
            // 
            // cbxHighscore
            // 
            this.cbxHighscore.AutoSize = true;
            this.cbxHighscore.Location = new System.Drawing.Point(747, 170);
            this.cbxHighscore.Name = "cbxHighscore";
            this.cbxHighscore.Size = new System.Drawing.Size(74, 17);
            this.cbxHighscore.TabIndex = 13;
            this.cbxHighscore.Text = "Highscore";
            this.cbxHighscore.UseVisualStyleBackColor = true;
            this.cbxHighscore.CheckedChanged += new System.EventHandler(this.cbxHighscore_CheckedChanged);
            // 
            // lbxHighscore
            // 
            this.lbxHighscore.FormattingEnabled = true;
            this.lbxHighscore.Location = new System.Drawing.Point(958, 170);
            this.lbxHighscore.Name = "lbxHighscore";
            this.lbxHighscore.Size = new System.Drawing.Size(170, 264);
            this.lbxHighscore.TabIndex = 14;
            // 
            // quizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 589);
            this.Controls.Add(this.lbxHighscore);
            this.Controls.Add(this.cbxHighscore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcbJoker);
            this.Controls.Add(this.lblQuestionTimer);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnChaosMode);
            this.Controls.Add(this.btnTechnology);
            this.Controls.Add(this.btnF1);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.rbAnswer4);
            this.Controls.Add(this.rbAnswer3);
            this.Controls.Add(this.rbAnswer2);
            this.Controls.Add(this.rbAnswer1);
            this.Controls.Add(this.lblQuestion);
            this.Name = "quizForm";
            this.Text = "quizForm";
            this.Load += new System.EventHandler(this.quizForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbJoker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbAnswer1;
        private System.Windows.Forms.RadioButton rbAnswer2;
        private System.Windows.Forms.RadioButton rbAnswer3;
        private System.Windows.Forms.RadioButton rbAnswer4;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnF1;
        private System.Windows.Forms.Button btnTechnology;
        private System.Windows.Forms.Button btnChaosMode;
        private System.Windows.Forms.Timer tmrQuiz;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer tmrQuestion;
        private System.Windows.Forms.Label lblQuestionTimer;
        private System.Windows.Forms.PictureBox pcbJoker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxHighscore;
        private System.Windows.Forms.ListBox lbxHighscore;
    }
}