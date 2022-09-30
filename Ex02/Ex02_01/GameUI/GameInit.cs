
using Ex02_01.GameFramework;

namespace Ex02_01.GameUI
{
    internal class GameInit
    {
        // Creates a new game object and board
        internal static GameObject CreateNewGame(Player i_FirstPlayer, Player i_SecondPlayer, bool i_PlayAgain)
        {
            Player playerOne;
            Player playerTwo;
            int DifficultyLevel = 0;

            // If new game is not a rematch - get new player names
            if (!i_PlayAgain)
            {
                bool canBeComputer = true;
                playerOne = ValidInput.GetValidPlayer(!canBeComputer);
                playerTwo = ValidInput.GetValidPlayer(canBeComputer);
                // If second player is a computer get game difficulty 
                if(playerTwo.IsComputer)
                {
                    DifficultyLevel = ValidInput.GetDifficultyLevel();
                }
            }
            else
            {
                playerOne = i_FirstPlayer;
                playerTwo = i_SecondPlayer;
            }

            BoardBuilder newGameBoard = ValidInput.GetValidBoard();
            return new GameObject(playerOne, playerTwo, newGameBoard, newGameBoard.CardList, DifficultyLevel);
        }
    }
}
