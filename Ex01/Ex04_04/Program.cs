using System;
namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            string userInput = getValidUserInput();
            printIsInputPalindrome(userInput);
            printIsNumAndDivisbleByThree(userInput);
            printIsStrAndNumberOfLowecase(userInput);

            Console.WriteLine("\nPlease press enter to exit");
            Console.ReadLine();
        }

        private static string getValidUserInput()
        {
            string userInput;

            while (true)
            {
                Console.WriteLine("Please input a string of size 9 consisting of only letters or only numbers:");
                userInput = Console.ReadLine();

                if (userInput.Length == 9 && (IsAllDigits(userInput) || isAllLetters(userInput)))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }

            return userInput;
        }
        public static bool IsAllDigits(string i_UserInput)
        {
            bool v_IsAllDigits = true;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (!Char.IsDigit(i_UserInput[i]))
                {
                    v_IsAllDigits = false;
                    break;
                }
            }

            return v_IsAllDigits;
        }
        private static bool isAllLetters(string i_UserInput)
        {
            bool v_IsAllLetters = true;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (!Char.IsLetter(i_UserInput[i]))
                {
                    v_IsAllLetters = false;
                    break;
                }
            }

            return v_IsAllLetters;
        }
        private static void printIsInputPalindrome(string i_UserInput)
        {
            bool v_IsPalindrome = true;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (i_UserInput[i] != i_UserInput[i_UserInput.Length - i - 1])
                {
                    v_IsPalindrome = false;
                    break;
                }
            }

            if (v_IsPalindrome)
            {
                Console.WriteLine("1. Input is a palindrom!");
            }
            else
            {
                Console.WriteLine("1. Input is not a palindrom...");
            }
        }
        private static void printIsNumAndDivisbleByThree(string i_UserInput)
        {
            if (!IsAllDigits(i_UserInput))
            {
                Console.WriteLine("2. Input is not a number...");
            }
            else
            {
                int userInputAsInt;
                int.TryParse(i_UserInput, out userInputAsInt);

                if (userInputAsInt % 3 == 0)
                {
                    Console.WriteLine("2. Input is a number and divisble by 3.");
                }
                else
                {
                    Console.WriteLine("2. Input is a number but not divisble by 3.");
                }
            }
        }
        private static void printIsStrAndNumberOfLowecase(string i_UserInput)
        {
            if (!isAllLetters(i_UserInput))
            {
                Console.WriteLine("3. Input is not all letters...");
            }
            else
            {
                int numOfLowercaseLetters = 0;

                for (int i = 0; i < i_UserInput.Length; i++)
                {
                    if (Char.IsLower(i_UserInput[i]))
                    {
                        numOfLowercaseLetters++;
                    }
                }

                Console.WriteLine("3. Number of lowercase letters in the string is: " + numOfLowercaseLetters.ToString());
            }
        }
    }
}
