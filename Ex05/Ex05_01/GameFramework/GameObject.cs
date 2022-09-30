
using System.Collections.Generic;

namespace Ex05_01.GameFramework
{
    internal class GameObject
    {
        private readonly Player r_PlayerOne;
        private readonly Player r_PlayerTwo;
        private BoardBuilder m_Board;
        private List<Card> m_OpenedCards;
        private List<Card> m_UnOpenedCards;
        private readonly int r_ComputerDifficulty;

        internal GameObject(Player i_PlayerOne, Player i_PlayerTwo, BoardBuilder i_Board, List<Card> i_Cards, int i_DifficultyLevel)
        {
            this.r_PlayerOne = i_PlayerOne;
            this.r_PlayerTwo = i_PlayerTwo;
            this.m_Board = i_Board;
            this.m_OpenedCards = new List<Card>();
            this.m_UnOpenedCards = i_Cards;
            if (i_DifficultyLevel != 0)
            {
                this.r_ComputerDifficulty = i_DifficultyLevel;
            }
        }

        internal Player PlayerOne
        {
            get 
            { 
                return r_PlayerOne; 
            }
        }

        internal Player PlayerTwo
        {
            get 
            { 
                return r_PlayerTwo; 
            }
        }

        internal BoardBuilder Board
        {
            get 
            { 
                return m_Board; 
            }
        }

        internal List<Card> OpenedCards
        {
            get 
            { 
                return m_OpenedCards; 
            }
        }

        internal List<Card> UnOpenedCards
        {
            get 
            { 
                return m_UnOpenedCards; 
            }
        }

        internal static void addOpenCard(Card i_cardDiscoverd, GameObject i_currentGame)
        {
            i_currentGame.m_OpenedCards.Add(i_cardDiscoverd);
            i_currentGame.m_UnOpenedCards.Remove(i_cardDiscoverd);
        }

        internal int ComputerDifficulty
        {
            get 
            { 
                return r_ComputerDifficulty; 
            }
        }
    }
}
