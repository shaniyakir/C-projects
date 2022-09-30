using System;
using Ex02_01.GameFramework;

namespace Ex02_01.GameUI
{
    // Handels all requests for valid user input
    internal class ValidInput
    {
        private const string k_QuitAnswer = "Q";
        private const string k_ComputerSecondPlayer = "C";
        private const int k_SmallestSizeBoardInput = 4;
        private const int k_LargestSizeBoardInput = 6;

        // Get one dimension for game board
        private static int getValidBoardDimension(string i_HeightOrWidth)
        {
            string stringBoardInputSize;
            int intBoardInputSize;
            bool isValidSize;

            while (true)
            {
                if (i_HeightOrWidth == "height")
                {
                    Console.WriteLine(StringMessagesGame.k_InputBoardHeight);
                }
                else if (i_HeightOrWidth == "width")
                {
                    Console.WriteLine(StringMessagesGame.k_InputBoardWidth);
                }

                stringBoardInputSize = Console.ReadLine();
                isValidSize = int.TryParse(stringBoardInputSize, out intBoardInputSize);
                if (isValidSize && intBoardInputSize >= k_SmallestSizeBoardInput && intBoardInputSize <= k_LargestSizeBoardInput)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(StringMessagesGame.k_InvalidInput);
                }
            }

            return intBoardInputSize;
        }

        internal static BoardBuilder GetValidBoard()
        {
            int boardHeight = getValidBoardDimension("height");
            int boardWidth = getValidBoardDimension("width");

            while (((boardHeight * boardWidth) % 2) != 0)
            {
                Console.WriteLine(StringMessagesGame.k_InvalidInputSizeOfBoardMessage);
                boardHeight = getValidBoardDimension("height");
                boardWidth = getValidBoardDimension("width");
            }

            return new BoardBuilder(boardHeight, boardWidth);
        }

        // Get valid card format from user
        internal static Card GetValidCard(GameObject i_CurrentGame)
        {
            Console.WriteLine(StringMessagesGame.k_AskValidCardFormat);
            string currentCell = Console.ReadLine();
            int columnIndexOfCell;
            int rowIndexOfCell;

            while (currentCell != k_QuitAnswer)
            {
                if ((currentCell != null) && (currentCell.Length == 2) && (char.IsUpper(currentCell[0])) && (char.IsDigit(currentCell[1])))
                {
                    columnIndexOfCell = (int)(currentCell[0] - 'A');
                    rowIndexOfCell = currentCell[1] - '1';

                    if (rowIndexOfCell < i_CurrentGame.Board.BoardHeight && rowIndexOfCell >= 0 
                        && columnIndexOfCell < i_CurrentGame.Board.BoardWidth)
                    {
                        if (i_CurrentGame.Board.GetCardOnIndex(rowIndexOfCell, columnIndexOfCell).IsDiscovered
                            || i_CurrentGame.Board.GetCardOnIndex(rowIndexOfCell, columnIndexOfCell).IsCurrentlyOpen)
                        {
                            Console.WriteLine(StringMessagesGame.k_InvalidDiscoveredCell);
                            currentCell = Console.ReadLine();
                        }
                        else
                        {
                            return i_CurrentGame.Board.GetCardOnIndex(rowIndexOfCell, columnIndexOfCell);
                        }

                    }
                    else
                    {
                        Console.WriteLine(StringMessagesGame.k_InvalidCellInput);
                        currentCell = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(StringMessagesGame.k_InvalidCellInput);
                    currentCell = Console.ReadLine();
                }
            }

            Console.WriteLine(StringMessagesGame.k_SayingGoodBye);
            Environment.Exit(0);
            return null;
        }

        // Get valid player (user/computer)
        internal static Player GetValidPlayer(bool i_CanBeComputer)
        {
            String playerName;
            bool playerIsComputer = true;

            if (i_CanBeComputer == false)
            {
                Console.WriteLine(StringMessagesGame.k_FirstPlayerNameMessage);
                playerName = Console.ReadLine();
                return new Player(playerName, !playerIsComputer);
            }

            else
            {
                Console.WriteLine(StringMessagesGame.k_SecondPlayerNameMessage);
                playerName = Console.ReadLine();
                if (playerName == k_ComputerSecondPlayer)
                {

                    return new Player("Computer", playerIsComputer);
                }
                else
                {
                    return new Player(playerName, !playerIsComputer);
                }
            }
        }

        // Check if user wants a rematch after the game has ended
        internal static bool CheckIfWantsRematch()
        {
            bool playerResponse;

            Console.WriteLine(StringMessagesGame.k_AskForAnewGame);
            string answerForPlayAnotherGame = Console.ReadLine();

            while (answerForPlayAnotherGame != "Y" && answerForPlayAnotherGame != "N")
            {
                Console.WriteLine(StringMessagesGame.k_InvalidInput);
                answerForPlayAnotherGame = Console.ReadLine();
            }

            if (answerForPlayAnotherGame == "Y")
            {
                playerResponse = true;
            }
            else
            {
                playerResponse = false;
            }

            return playerResponse;
        }

        // Get difficulty level for computer second player.
        // Returns: X, where X is - 
        // Easy:    X = 1
        // Medium:  X = 3
        // Hard:    X = 5
        internal static int GetDifficultyLevel()
        {
            string difficultyLevelString;
            int difficultyLevel = 0;

            while (difficultyLevel == 0)
            {
                Console.WriteLine(StringMessagesGame.k_AskDifficltyLevel);
                difficultyLevelString = Console.ReadLine();

                if (difficultyLevelString == "H")
                {
                    //in hard level the computer will remember 5 turns back
                    difficultyLevel = 5;
                }
                else if (difficultyLevelString == "M")
                {
                    //in medium level the computer will remember 3 turns back
                    difficultyLevel = 3;
                }
                else if(difficultyLevelString == "E")
                {
                    //in easy level the computer will remember 1 turn back
                    difficultyLevel = 1;
                }
                else if (difficultyLevelString == "Q")
                {
                    Console.WriteLine(StringMessagesGame.k_SayingGoodBye);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(StringMessagesGame.k_InvalidInput);
                }
            }
            return difficultyLevel;
        }
    }
}

