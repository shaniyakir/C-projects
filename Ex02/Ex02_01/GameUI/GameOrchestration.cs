using System;
using Ex02_01.GameFramework;

namespace Ex02_01.GameUI
{
    internal class GameOrchestration
    {
        // Orchestrates (manages) the entire game
        internal static void GameOrchestrator(Player i_FirstPlayer, Player i_SecondPlayer, bool PlayAgain)
        {
            GameObject currentGame = GameInit.CreateNewGame(i_FirstPlayer, i_SecondPlayer, PlayAgain);
            play(currentGame);
        }

        // Plays one match of current game
        private static void play(GameObject i_currentgame)
        {
            while ( i_currentgame.PlayerOne.PlayerPoints + i_currentgame.PlayerTwo.PlayerPoints < i_currentgame.Board.GetNumberOfCards() / 2)
            {
                PlayTurn.PlayUserTurn(i_currentgame, i_currentgame.PlayerOne);
                if (i_currentgame.PlayerOne.PlayerPoints + i_currentgame.PlayerTwo.PlayerPoints < i_currentgame.Board.GetNumberOfCards() / 2)
                {
                    if ( i_currentgame.PlayerTwo.IsComputer)
                    {
                        PlayTurn.PlayComputerTurn(i_currentgame, i_currentgame.PlayerTwo);
                    }
                    else
                    {
                        PlayTurn.PlayUserTurn(i_currentgame, i_currentgame.PlayerTwo);

                    }
                }
            }

            Console.WriteLine("{0} Won!", GetLeadingPlayerName(i_currentgame.PlayerOne, i_currentgame.PlayerTwo));
            
            if ( ValidInput.CheckIfWantsRematch())
            {
                GameOrchestrator(i_currentgame.PlayerOne, i_currentgame.PlayerTwo, true);
            }

            Console.WriteLine(StringMessagesGame.k_SayingGoodBye);
            Environment.Exit(0);
        }

        // Check which player is leading the game in points
        private static string GetLeadingPlayerName(Player i_FirstPlayer, Player i_SecondPlayer)
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
    }
}
