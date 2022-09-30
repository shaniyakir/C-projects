using System;
using Ex02_01.GameFramework;
using Ex02_01.GameUI;
using Ex02.ConsoleUtils;

namespace Ex02_01
{
    internal class PlayTurn
    {
        private static readonly Random r_ComputerRandomTurn = new Random();

        //The method open the given cards in the given game according to the game rules.
        private static Card flipCard(GameObject i_ActiveGame)
        {
            Card chooseCard = ValidInput.GetValidCard(i_ActiveGame);
            chooseCard.IsCurrentlyOpen = true;
            Screen.Clear();
            i_ActiveGame.Board.PrintBoard();

            return chooseCard;
        }

        // This method plays a full turn (2 picks) of the user
        internal static void PlayUserTurn(GameObject i_ActiveGame, Player i_currentPlayer)
        {
            Screen.Clear();
            i_ActiveGame.Board.PrintBoard();

            Card firstCardFlip = flipCard(i_ActiveGame);
            Card secondCardFlip = flipCard(i_ActiveGame);

            firstCardFlip.IsCurrentlyOpen = false;
            secondCardFlip.IsCurrentlyOpen = false;

            if (firstCardFlip.CardValue == secondCardFlip.CardValue)
            {
                i_currentPlayer.PlayerPoints++;
                firstCardFlip.IsDiscovered = true;
                secondCardFlip.IsDiscovered = true;
                Console.WriteLine("Nice! {0} earned a point! his total is now: {1}", i_currentPlayer.PlayerName, i_currentPlayer.PlayerPoints);
            }
            else
            {
                GameObject.addOpenCard(firstCardFlip, i_ActiveGame);
                GameObject.addOpenCard(secondCardFlip, i_ActiveGame);
            }

            System.Threading.Thread.Sleep(2000);
        }

        // This method plays a full turn (2 picks) of the computer
        // This method utilizes AI !
        // First the computer chooses the first card at random (out of valid cards options)
        // Then (depending on the difficulity of the game) the computer "remembers" the previous X turns played and the card locations.
        // If at first he picks a random card with it's pair picked in the previous X hand the computer will choose the correct pair (otherwise random).
        // Easy:    X = 1
        // Medium:  X = 3
        // Hard:    X = 5
        internal static void PlayComputerTurn(GameObject i_ActiveGame, Player i_CurrentPlayer)
        {
            Screen.Clear();
            i_ActiveGame.Board.PrintBoard();
            Card firstCardFlip = getFirstComputerValidRandomCard(i_ActiveGame); // pick randomly
            Card secondCardFlip = getSecondComputerValidRandomCard(i_ActiveGame, firstCardFlip); // pick with AI
            firstCardFlip.IsCurrentlyOpen = false;
            secondCardFlip.IsCurrentlyOpen = false;

            if (firstCardFlip.CardValue == secondCardFlip.CardValue)
            {
                i_CurrentPlayer.PlayerPoints++;
                firstCardFlip.IsDiscovered = true;
                secondCardFlip.IsDiscovered = true;
                Console.WriteLine("Nice! {0} earned a point! his total is now: {1}", i_CurrentPlayer.PlayerName, i_CurrentPlayer.PlayerPoints);
            }

            GameObject.addOpenCard(firstCardFlip, i_ActiveGame);
            GameObject.addOpenCard(secondCardFlip, i_ActiveGame);
            System.Threading.Thread.Sleep(2000);
            Screen.Clear();
            i_ActiveGame.Board.PrintBoard();
        }

        // choose a random valid card for the computer 
        private static Card getFirstComputerValidRandomCard(GameObject i_ActiveGame)
        {
            int randomColIndex;
            int randomRowIndex;
            Card firstCard;
            do
            {
                randomColIndex = r_ComputerRandomTurn.Next(0, i_ActiveGame.Board.BoardWidth);
                randomRowIndex = r_ComputerRandomTurn.Next(0, i_ActiveGame.Board.BoardHeight);
                firstCard = i_ActiveGame.Board.GetCardOnIndex(randomRowIndex, randomColIndex);
            }
            while (firstCard.IsDiscovered || firstCard.IsCurrentlyOpen);

            firstCard.IsCurrentlyOpen = true;
            Screen.Clear();
            i_ActiveGame.Board.PrintBoard();

            return firstCard;
        }

        // get seconed valid card for the cimputer using AI
        private static Card getSecondComputerValidRandomCard(GameObject i_ActiveGame, Card i_FirstCard)
        {
            Card secondCard = null;
            bool locatedInOpenedCards = false;
            int difficultyGameLevel = i_ActiveGame.ComputerDifficulty;

            // search for the card in the previously X*2 opened cards
            for (int i = 0; i < difficultyGameLevel * 2; i++)
            {
                if (i_ActiveGame.OpenedCards.Count - i - 1 < 0)
                {
                    break;
                }
                else
                {
                    Card currentCard = i_ActiveGame.OpenedCards[i_ActiveGame.OpenedCards.Count - i - 1];
                    if (currentCard.CardValue == i_FirstCard.CardValue && !i_FirstCard.Equals(currentCard))
                    {
                        secondCard = currentCard;
                        locatedInOpenedCards = true;
                        secondCard.IsCurrentlyOpen = true;
                        break;
                    }
                }
            }

            if (!locatedInOpenedCards || secondCard == null)
            {
                // If card is not in recently played turns, pick one at random
                secondCard = PlayTurn.getFirstComputerValidRandomCard(i_ActiveGame);
            }

            Screen.Clear();
            i_ActiveGame.Board.PrintBoard();
            return secondCard;
        }
    }
}

