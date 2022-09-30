namespace Ex05_01.GameUI
{
    partial class FormGameSettingsD
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxSeconedPlayerName = new System.Windows.Forms.TextBox();
            this.buttonAgainstOpponent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.difficultyLevelLable = new System.Windows.Forms.Label();
            this.hardLevelPicked = new System.Windows.Forms.RadioButton();
            this.mediumLevelPicked = new System.Windows.Forms.RadioButton();
            this.EasyLevelPicked = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Second Player Name:";
            // 
            // textBoxFirstPlayerName
            // 
            this.textBoxFirstPlayerName.Location = new System.Drawing.Point(197, 21);
            this.textBoxFirstPlayerName.Name = "textBoxFirstPlayerName";
            this.textBoxFirstPlayerName.Size = new System.Drawing.Size(167, 26);
            this.textBoxFirstPlayerName.TabIndex = 2;
            // 
            // textBoxSeconedPlayerName
            // 
            this.textBoxSeconedPlayerName.Enabled = false;
            this.textBoxSeconedPlayerName.Location = new System.Drawing.Point(197, 60);
            this.textBoxSeconedPlayerName.Name = "textBoxSeconedPlayerName";
            this.textBoxSeconedPlayerName.Size = new System.Drawing.Size(167, 26);
            this.textBoxSeconedPlayerName.TabIndex = 3;
            this.textBoxSeconedPlayerName.Text = "-computer-";
            // 
            // buttonAgainstOpponent
            // 
            this.buttonAgainstOpponent.Location = new System.Drawing.Point(370, 60);
            this.buttonAgainstOpponent.Name = "buttonAgainstOpponent";
            this.buttonAgainstOpponent.Size = new System.Drawing.Size(179, 35);
            this.buttonAgainstOpponent.TabIndex = 4;
            this.buttonAgainstOpponent.Text = "Against a Friend";
            this.buttonAgainstOpponent.UseVisualStyleBackColor = true;
            this.buttonAgainstOpponent.Click += new System.EventHandler(this.buttonAgainstFriend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Board Size:";
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonBoardSize.Location = new System.Drawing.Point(22, 206);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(138, 106);
            this.buttonBoardSize.TabIndex = 6;
            this.buttonBoardSize.Text = "4 x 4";
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // StartGame
            // 
            this.StartGame.BackColor = System.Drawing.Color.LimeGreen;
            this.StartGame.Location = new System.Drawing.Point(370, 276);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(179, 36);
            this.StartGame.TabIndex = 7;
            this.StartGame.Text = "Start!";
            this.StartGame.UseVisualStyleBackColor = false;
            this.StartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // difficultyLevelLable
            // 
            this.difficultyLevelLable.AutoSize = true;
            this.difficultyLevelLable.Location = new System.Drawing.Point(18, 131);
            this.difficultyLevelLable.Name = "difficultyLevelLable";
            this.difficultyLevelLable.Size = new System.Drawing.Size(108, 20);
            this.difficultyLevelLable.TabIndex = 9;
            this.difficultyLevelLable.Text = "Difficulty level:";
            // 
            // hardLevelPicked
            // 
            this.hardLevelPicked.AutoSize = true;
            this.hardLevelPicked.Location = new System.Drawing.Point(146, 129);
            this.hardLevelPicked.Name = "hardLevelPicked";
            this.hardLevelPicked.Size = new System.Drawing.Size(69, 24);
            this.hardLevelPicked.TabIndex = 12;
            this.hardLevelPicked.TabStop = true;
            this.hardLevelPicked.Text = "Hard";
            this.hardLevelPicked.UseVisualStyleBackColor = true;
            this.hardLevelPicked.CheckedChanged += new System.EventHandler(this.setLevelOfGame);
            // 
            // mediumLevelPicked
            // 
            this.mediumLevelPicked.AutoSize = true;
            this.mediumLevelPicked.Location = new System.Drawing.Point(229, 128);
            this.mediumLevelPicked.Name = "mediumLevelPicked";
            this.mediumLevelPicked.Size = new System.Drawing.Size(90, 24);
            this.mediumLevelPicked.TabIndex = 13;
            this.mediumLevelPicked.TabStop = true;
            this.mediumLevelPicked.Text = "Medium";
            this.mediumLevelPicked.UseVisualStyleBackColor = true;
            this.mediumLevelPicked.CheckedChanged += new System.EventHandler(this.setLevelOfGame);
            // 
            // EasyLevelPicked
            // 
            this.EasyLevelPicked.AutoSize = true;
            this.EasyLevelPicked.Location = new System.Drawing.Point(329, 129);
            this.EasyLevelPicked.Name = "EasyLevelPicked";
            this.EasyLevelPicked.Size = new System.Drawing.Size(69, 24);
            this.EasyLevelPicked.TabIndex = 14;
            this.EasyLevelPicked.TabStop = true;
            this.EasyLevelPicked.Text = "Easy";
            this.EasyLevelPicked.UseVisualStyleBackColor = true;
            this.EasyLevelPicked.CheckedChanged += new System.EventHandler(this.setLevelOfGame);
            // 
            // FormGameSettingsD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 324);
            this.Controls.Add(this.EasyLevelPicked);
            this.Controls.Add(this.mediumLevelPicked);
            this.Controls.Add(this.hardLevelPicked);
            this.Controls.Add(this.difficultyLevelLable);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAgainstOpponent);
            this.Controls.Add(this.textBoxSeconedPlayerName);
            this.Controls.Add(this.textBoxFirstPlayerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettingsD";
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirstPlayerName;
        private System.Windows.Forms.TextBox textBoxSeconedPlayerName;
        private System.Windows.Forms.Button buttonAgainstOpponent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Label difficultyLevelLable;
        private System.Windows.Forms.RadioButton hardLevelPicked;
        private System.Windows.Forms.RadioButton mediumLevelPicked;
        private System.Windows.Forms.RadioButton EasyLevelPicked;
    }
}