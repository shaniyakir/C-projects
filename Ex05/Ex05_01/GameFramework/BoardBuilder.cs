using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_01.GameFramework
{
    internal class BoardBuilder
    {
        private readonly int r_BoardHeight;
        private readonly int r_BoardWidth;
        private Card[,] m_CardsOnBoard;
        private List<Card> m_CardsOnBoardList;
        private static readonly Random r_Random = new Random();

        internal BoardBuilder(int i_BoardHeight, int i_BoardWidth)
        {
            this.r_BoardHeight = i_BoardHeight;
            this.r_BoardWidth = i_BoardWidth;
            this.m_CardsOnBoard = null;
            this.m_CardsOnBoardList = new List<Card>();
            InitBoard();
        }

        internal void InitBoard()
        {
            int numOfCards = this.r_BoardHeight * this.r_BoardWidth;
            List<char> possibleCardValues = new List<char>();
            char firstCardValue = 'A';
            for (int i = 0; i < numOfCards / 2; i++)
            {
                possibleCardValues.Add((char)((int)firstCardValue + i));
                possibleCardValues.Add((char)((int)firstCardValue + i));
            }

            this.m_CardsOnBoard = new Card[this.r_BoardHeight, this.r_BoardWidth];

            int randomValue;
            for (int height = 0; height < this.r_BoardHeight; height++)
            {
                for (int width = 0; width < this.r_BoardWidth; width++)
                {
                    randomValue = r_Random.Next(0, possibleCardValues.Count);
                    Card newCard = new Card(possibleCardValues[randomValue], height, width);
                    m_CardsOnBoard[height, width] = newCard;
                    m_CardsOnBoardList.Add(newCard);
                    possibleCardValues.RemoveAt(randomValue);
                }
            }
        }

        internal int BoardHeight
        {
            get 
            { 
                return this.r_BoardHeight; 
            }
        }

        internal int BoardWidth
        {
            get 
            { 
                return this.r_BoardWidth; 
            }
        }

        internal int GetNumberOfCards()
        {
            return this.BoardHeight * this.BoardWidth;
        }

        internal Card[,] Cards
        {
            get 
            { 
                return this.m_CardsOnBoard; 
            }
        }

        internal List<Card> CardList
        {
            get 
            { 
                return this.m_CardsOnBoardList; 
            }
        }

        internal Card GetCardOnIndex(int i_RowIndex, int i_ColIndex)
        {
            return this.Cards[i_RowIndex, i_ColIndex];
        }
    }
}
