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
    public partial class FormMainGameD : Form
    {
        private readonly Player r_FirstPlayer;
        private static readonly Color k_FirstPlayerColor = Color.PaleGreen;
        private readonly Player r_SecondPlayer;
        private static readonly Color k_SeconedPlayerColor = Color.Plum;
        private Player m_CurrentPlayer;
        private Color m_CurrentColor;
        private readonly int r_DifficultyLevel;
        private readonly Tuple<int, int> r_BoardSize;
        private GameObject m_GameObject;
        private List<UICard> m_UICardList;
        private UICard m_FirstCardClicked;
        private UICard m_SecondCardClicked;
        private static readonly Random r_ComputerRandomTurn = new Random();
        private const int k_StartPosition = 15;
        private const int k_ButtonSize = 100;
        private const int k_Spacing = 15;
        private const int k_LableWidth = 200;
        private const int k_LableHeight = 30;

        public FormMainGameD(Player i_FirstPlayer, Player i_SecondPlayer, Tuple<int, int> i_BoardSize, int i_Difficulty)
        {
            this.r_FirstPlayer = i_FirstPlayer;
            this.r_SecondPlayer = i_SecondPlayer;
            this.m_CurrentPlayer = this.r_FirstPlayer;
            this.m_CurrentColor = k_FirstPlayerColor;
            this.m_UICardList = new List<UICard>();
            this.r_BoardSize = i_BoardSize;
            this.m_GameObject = buildGame(r_FirstPlayer, r_SecondPlayer, r_BoardSize);
            this.r_DifficultyLevel = (i_SecondPlayer.IsComputer ? i_Difficulty : 0);
            buildGameForm(m_GameObject);
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private GameObject buildGame(Player i_FirstPlayer, Player i_SecondPlayer, Tuple<int, int> i_BoardSize)
        {
            BoardBuilder board = new BoardBuilder(i_BoardSize.Item1, i_BoardSize.Item2);

            return new GameObject(i_FirstPlayer, i_SecondPlayer, board, board.CardList, this.r_DifficultyLevel);
        }

        private void buildGameForm(GameObject i_GameObject)
        {
            int xPosition = k_StartPosition;
            int yPosition = k_StartPosition;

            for (int i = 0; i < i_GameObject.Board.BoardHeight; i++)
            {
                for (int j = 0; j < i_GameObject.Board.BoardWidth; j++)
                {
                    UICard cardInUI = new UICard(m_GameObject.Board.GetCardOnIndex(i, j));
                    cardInUI.Name = string.Format("Btn{0}{1}", i, j);
                    cardInUI.Height = k_ButtonSize;
                    cardInUI.Width = k_ButtonSize;
                    cardInUI.Location = new Point(xPosition, yPosition);
                    cardInUI.Click += firstCard_Click;
                    m_UICardList.Add(cardInUI);
                    xPosition = xPosition + k_ButtonSize + k_Spacing;
                    this.Controls.Add(cardInUI);
                }

                xPosition = k_StartPosition;
                yPosition = yPosition + k_ButtonSize + k_Spacing;
            }

            Label currentPlayerNameLabel = buildCurrentPlayerLabel(m_CurrentPlayer, xPosition, yPosition, m_CurrentColor);
            Label firstPlayerLabel = buildPlayerNameLabel(r_FirstPlayer, xPosition, yPosition += k_LableHeight + k_Spacing, k_FirstPlayerColor);
            Label secondPlayerLabel = buildPlayerNameLabel(r_SecondPlayer, xPosition, yPosition += k_LableHeight + k_Spacing, k_SeconedPlayerColor);
            this.Controls.Add(currentPlayerNameLabel);
            this.Controls.Add(firstPlayerLabel);
            this.Controls.Add(secondPlayerLabel);
        }

        private void RematchGame()
        {
            r_FirstPlayer.PlayerPoints = 0;
            r_SecondPlayer.PlayerPoints = 0;
            GameObject rematchGameObject = buildGame(r_FirstPlayer, r_SecondPlayer, r_BoardSize);
            FormMainGameD rematchForm = new FormMainGameD(r_FirstPlayer, r_SecondPlayer, r_BoardSize, r_DifficultyLevel);
            rematchForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            this.m_GameObject = rematchGameObject;
            rematchForm.ShowDialog();
        }

        private Label buildCurrentPlayerLabel(Player i_CurrentPlayer, int i_XPosition, int i_YPosition, Color i_PlayerBackColor)
        {
            Label currentPlayerNameLable = new Label();
            currentPlayerNameLable.Name = "currentPlayerNameLabel";
            currentPlayerNameLable.Text = String.Format("Current Player: {0}", i_CurrentPlayer.PlayerName);
            currentPlayerNameLable.Height = k_LableHeight;
            currentPlayerNameLable.Width = k_LableWidth;
            currentPlayerNameLable.Location = new Point(i_XPosition, i_YPosition);
            currentPlayerNameLable.BackColor = i_PlayerBackColor;
            currentPlayerNameLable.AutoSize = true;
            currentPlayerNameLable.Margin = new Padding(0, 0, 0, 10);
            return currentPlayerNameLable;
        }

        private Label buildPlayerNameLabel(Player i_Player, int i_XPosition, int i_YPosition, Color i_PlayerBackColor)
        {
            Label currentPlayerNameLable = new Label();
            currentPlayerNameLable.Name = "PlayerLabel" + i_Player.PlayerName;
            currentPlayerNameLable.Text = String.Format("{0}: {1} Pair(s)", i_Player.PlayerName, i_Player.PlayerPoints);
            currentPlayerNameLable.Height = k_LableHeight;
            currentPlayerNameLable.Width = k_LableWidth;
            currentPlayerNameLable.Location = new Point(i_XPosition, i_YPosition);
            currentPlayerNameLable.BackColor = i_PlayerBackColor;
            currentPlayerNameLable.AutoSize = true;
            currentPlayerNameLable.Margin = new Padding(0,0,0,10);
            return currentPlayerNameLable;
        }

        private void firstCard_Click(object sender, EventArgs e)
        {
            UICard clickedUICard = sender as UICard;

            if (!clickedUICard.Card.IsDiscovered && !clickedUICard.Card.IsCurrentlyOpen)
            {
                openUserCard(clickedUICard);
                this.m_FirstCardClicked = clickedUICard;
                notifyAllFirstCardClicked();
            }
        }
        private void secondCard_Click(object sender, EventArgs e)
        {
            UICard clickedUICard = sender as UICard;

            if (!clickedUICard.Card.IsDiscovered && !clickedUICard.Card.IsCurrentlyOpen)
            {
                openUserCard(clickedUICard);
                this.m_SecondCardClicked = clickedUICard;
                validateUserTurn();
            }
        }

        private int getCardIndex(UICard i_UICard)
        {
            int cardIndex = 0;
            foreach (UICard card in m_UICardList)
            {
                if (card.Card == i_UICard.Card)
                {
                    break;
                }
                cardIndex++;
            }

            return cardIndex;
        }

        private void openUserCard(UICard i_UICard)
        {
            i_UICard.Card.IsCurrentlyOpen = true;
            i_UICard.Text = i_UICard.Card.CardValue.ToString();
            Application.DoEvents();
        }

        private void openComputerCard(UICard i_UICard)
        {
            int cardIndex = getCardIndex(i_UICard);
            m_UICardList[cardIndex].Card.IsCurrentlyOpen = true;
            m_UICardList[cardIndex].Text = m_UICardList[cardIndex].Card.CardValue.ToString();
            Application.DoEvents();
        }

        private void validateUserTurn()
        {
            checkMatchingCards(m_FirstCardClicked, m_SecondCardClicked);
            notifyAllSecondCardClicked();
            System.Threading.Thread.Sleep(2000);
            updatePoints();
            checkGameStatus();
            switchPlayers();
            Application.DoEvents();
            if (m_CurrentPlayer.IsComputer && r_SecondPlayer.IsComputer)
            {               
                playAIComputerTurn();              
            }
        }

        private void notifyAllFirstCardClicked()
        {
            foreach (UICard card in m_UICardList)
            {
                card.Click -= firstCard_Click;
                if (!card.Card.IsDiscovered)
                {
                    card.Click += secondCard_Click;
                }
            }
        }

        private void notifyAllSecondCardClicked()
        {
            foreach (UICard card in m_UICardList)
            {
                card.Card.IsCurrentlyOpen = false;

                if (!card.Card.IsDiscovered)
                {
                    card.Click -= secondCard_Click;
                    card.Click += firstCard_Click;
                    card.Text = "";
                }
            }
        }

        private void checkMatchingCards(UICard i_FirstCard, UICard i_SecondCard)
        {
            UICard firstCard = m_UICardList[getCardIndex(i_FirstCard)];
            UICard secondCard = m_UICardList[getCardIndex(i_SecondCard)];

            if (firstCard.Card.CardValue == secondCard.Card.CardValue)
            {
                m_CurrentPlayer.PlayerPoints++;
                firstCard.Card.IsDiscovered = true;
                firstCard.BackColor = m_CurrentColor;
                secondCard.Card.IsDiscovered = true;
                secondCard.BackColor = m_CurrentColor;
            }

            GameObject.addOpenCard(firstCard.Card, m_GameObject);
            GameObject.addOpenCard(secondCard.Card, m_GameObject);
        }

        private void updatePoints()
        {
            Label currentPlayerNameLabel = this.Controls.Find("PlayerLabel" + m_CurrentPlayer.PlayerName, true).First() as Label;
            currentPlayerNameLabel.Text = String.Format("{0}: {1} Pair(s)", m_CurrentPlayer.PlayerName, m_CurrentPlayer.PlayerPoints);
        }

        private void checkGameStatus()
        {
            if (m_GameObject.PlayerOne.PlayerPoints + m_GameObject.PlayerTwo.PlayerPoints >= m_GameObject.Board.GetNumberOfCards() / 2)
            {
                string message = String.Format("{0} Won!\nWould you like to have a rematch?", getLeadingPlayerName(r_FirstPlayer, r_SecondPlayer));
                string caption = this.Text;
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    Environment.Exit(0);
                }
                else
                {
                    RematchGame();
                }
            }
        }

        private string getLeadingPlayerName(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            if (i_FirstPlayer.PlayerPoints > i_SecondPlayer.PlayerPoints)
            {
                return i_FirstPlayer.PlayerName;
            }
            else if (i_SecondPlayer.PlayerPoints > i_FirstPlayer.PlayerPoints)
            {
                return i_SecondPlayer.PlayerName;
            }
            else
            {
                return "It's a tie! No one ";
            }
        }

        private void switchPlayers()
        {
            if (this.m_CurrentPlayer == this.r_FirstPlayer)
            {
                this.m_CurrentPlayer = this.r_SecondPlayer;
                this.m_CurrentColor = k_SeconedPlayerColor;
            }
            else
            {
                this.m_CurrentPlayer = this.r_FirstPlayer;
                this.m_CurrentColor = k_FirstPlayerColor;
            }

            Label currentPlayerNameLabel = this.Controls.Find("currentPlayerNameLabel", true).First() as Label;
            currentPlayerNameLabel.Text = String.Format("Current Player: {0}", m_CurrentPlayer.PlayerName);
            currentPlayerNameLabel.BackColor = m_CurrentColor;
        }

        // This method plays a full turn (2 picks) of the computer
        // This method utilizes AI !
        // First the computer chooses the first card at random (out of valid cards options)
        // Then (depending on the difficulity of the game) the computer "remembers" the previous X turns played and the card locations.
        // If at first he picks a random card with it's pair picked in the previous X hand the computer will choose the correct pair (otherwise random).
        // Easy:    X = 1
        // Medium:  X = 3
        // Hard:    X = 5
        private void playAIComputerTurn()
        {
            this.m_FirstCardClicked = getFirstComputerValidRandomCard();
            computerFirstClick(m_FirstCardClicked);
            this.m_SecondCardClicked = getSecondComputerValidRandomCard();
            computerSecondClick(m_SecondCardClicked);
        }

        private UICard getFirstComputerValidRandomCard()
        {
            UICard cardClicked;
            int randomColIndex;
            int randomRowIndex;

            do
            {
                randomColIndex = r_ComputerRandomTurn.Next(0, m_GameObject.Board.BoardWidth);
                randomRowIndex = r_ComputerRandomTurn.Next(0, m_GameObject.Board.BoardHeight);
                cardClicked = new UICard(m_GameObject.Board.GetCardOnIndex(randomRowIndex, randomColIndex));
            }
            while (cardClicked.Card.IsDiscovered || cardClicked.Card.IsCurrentlyOpen);

            return cardClicked;
        }

        private UICard getSecondComputerValidRandomCard()
        {
            UICard cardClicked = null;
            bool locatedInOpenedCards = false;

            // search for the card in the previously X*2 opened cards
            for (int i = 0; i < r_DifficultyLevel * 2; i++)
            {
                if (m_GameObject.OpenedCards.Count - i - 1 < 0)
                {
                    break;
                }
                else
                {
                    Card currentCard = m_GameObject.OpenedCards[m_GameObject.OpenedCards.Count - i - 1];
                    if (currentCard.CardValue == m_FirstCardClicked.Card.CardValue && !m_FirstCardClicked.Card.Equals(currentCard) && !currentCard.IsDiscovered && !currentCard.IsCurrentlyOpen)
                    {
                        cardClicked = new UICard(currentCard);
                        locatedInOpenedCards = true;
                        break;
                    }
                }
            }

            if (!locatedInOpenedCards || cardClicked == null)
            {
                // If card is not in recently played turns, pick one at random
                cardClicked = getFirstComputerValidRandomCard();
            }

            return cardClicked;
        }

        private void computerFirstClick(UICard i_UICard)
        {
            if (!i_UICard.Card.IsDiscovered && !i_UICard.Card.IsCurrentlyOpen)
            {
                openComputerCard(i_UICard);
                notifyAllFirstCardClicked();
            }
        }

        private void computerSecondClick(UICard i_UICard)
        {
            if (!i_UICard.Card.IsDiscovered && !i_UICard.Card.IsCurrentlyOpen)
            {
                openComputerCard(i_UICard);
                validateComputerTurn();
            }
        }

        private void validateComputerTurn()
        {
            checkMatchingCards(this.m_FirstCardClicked, this.m_SecondCardClicked);
            notifyAllSecondCardClicked();
            updatePoints();
            System.Threading.Thread.Sleep(2000);
            checkGameStatus();
            switchPlayers();
            Application.DoEvents();
        }
    }
}
