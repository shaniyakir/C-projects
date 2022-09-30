using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05_01.GameFramework;

namespace Ex05_01.GameUI
{
    public partial class FormGameSettingsD : Form
    {
        private int m_CurrentBoardSizeIndex;
        private bool m_SeconedPlayerIsComputer;
        private int m_ComputerDifficulty;
        private readonly Tuple<int, int>[] r_BoardSizeOptions =
        {
            Tuple.Create(4, 4),
            Tuple.Create(4, 5),
            Tuple.Create(4, 6),
            Tuple.Create(5, 4),
            Tuple.Create(5, 6),
            Tuple.Create(6, 4),
            Tuple.Create(6, 5),
            Tuple.Create(6, 6)
        };
        private readonly int k_EasyLevelGame = 1;
        private readonly int k_MediumLevelGame = 3;
        private readonly int k_HardLevelGame = 5;

        public FormGameSettingsD()
        {
            InitializeComponent();
            this.m_CurrentBoardSizeIndex = 0;
            this.m_SeconedPlayerIsComputer = true;
            this.m_ComputerDifficulty = 0;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            m_CurrentBoardSizeIndex = (m_CurrentBoardSizeIndex + 1) % r_BoardSizeOptions.Length;
            string displayText = buildBoardSizeNewText(m_CurrentBoardSizeIndex);
            this.buttonBoardSize.Text = displayText;
        }

        private string buildBoardSizeNewText(int i_BoardSizeOptionIndex)
        {
            StringBuilder boardSizeBuilder = new StringBuilder();

            boardSizeBuilder.Append(r_BoardSizeOptions[i_BoardSizeOptionIndex].Item1);
            boardSizeBuilder.Append(" x ");
            boardSizeBuilder.Append(r_BoardSizeOptions[i_BoardSizeOptionIndex].Item2);
            return boardSizeBuilder.ToString();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            bool correctInput = false;

            if (this.textBoxFirstPlayerName.Text.Length != 0
                && this.textBoxSeconedPlayerName.Text.Length != 0 && !m_SeconedPlayerIsComputer)
            {
                correctInput = true;
            }
            else if (m_SeconedPlayerIsComputer && this.m_ComputerDifficulty != 0 && this.textBoxFirstPlayerName.Text.Length != 0)
            {
                correctInput = true;
            }
            else if (m_SeconedPlayerIsComputer && this.m_ComputerDifficulty == 0 && this.textBoxFirstPlayerName.Text.Length != 0)
            {
                MessageBox.Show("Invalid input! Make sure you pick the level game...");
            }
            else
            {
                MessageBox.Show("Invalid input! Make sure you fill in players name...");
            }
            if (correctInput)
            {
                this.Visible = false;
                Player firstPlayer = new Player(textBoxFirstPlayerName.Text, false);
                Player seconedPlayer = new Player(textBoxSeconedPlayerName.Text, m_SeconedPlayerIsComputer);
                Tuple<int, int> boardSize = r_BoardSizeOptions[m_CurrentBoardSizeIndex];
                setLevelOfGame(this, e);
                FormMainGameD formMainGame = new FormMainGameD(firstPlayer, seconedPlayer, boardSize, m_ComputerDifficulty);
                formMainGame.ShowDialog();
            }
        }

        private void buttonAgainstFriend_Click(object sender, EventArgs e)
        {
            this.m_SeconedPlayerIsComputer = false;
            this.textBoxSeconedPlayerName.Enabled = true;
            this.difficultyLevelLable.Visible = false;
            this.hardLevelPicked.Visible = false;
            this.mediumLevelPicked.Visible = false;
            this.EasyLevelPicked.Visible = false;
            this.textBoxSeconedPlayerName.Clear();
            this.buttonAgainstOpponent.Text = "Against Computer";
            this.buttonAgainstOpponent.Click -= buttonAgainstFriend_Click;
            this.buttonAgainstOpponent.Click += buttonAgainstComputer_Click;
        }

        private void buttonAgainstComputer_Click(object sender, EventArgs e)
        {
            this.m_SeconedPlayerIsComputer = true;
            this.difficultyLevelLable.Visible = true;
            this.hardLevelPicked.Visible = true;
            this.mediumLevelPicked.Visible = true;
            this.EasyLevelPicked.Visible = true;
            this.textBoxSeconedPlayerName.Clear();
            this.textBoxSeconedPlayerName.Text = "-computer-";
            this.textBoxSeconedPlayerName.Enabled = false;
            this.buttonAgainstOpponent.Text = "Against a Friend";
            
            this.buttonAgainstOpponent.Click -= buttonAgainstComputer_Click;
            this.buttonAgainstOpponent.Click += buttonAgainstFriend_Click;
        }

        private void setLevelOfGame(object sender, EventArgs e)
        {
            if (hardLevelPicked.Checked)
            {
                this.m_ComputerDifficulty = k_HardLevelGame;
            }
            else if (mediumLevelPicked.Checked)
            {
                this.m_ComputerDifficulty = k_MediumLevelGame;
            }
            else
            {
                this.m_ComputerDifficulty = k_EasyLevelGame;
            }
        }

    }
}
