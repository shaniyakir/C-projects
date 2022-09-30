using System;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            printNumberStatistics();
        }

        private static void printNumberStatistics()
        {
            string validNumber = getValidNumber();

            printAmountOfDigitsSmallerThanUnity(validNumber);
            printLargestDigit(validNumber);
            printAmountOfDigitsDivisbleByThree(validNumber);
            printDigitsAverage(validNumber);

            Console.WriteLine("\nPlease press enter to exit");
            Console.ReadLine();
        }

        private static string getValidNumber()
        {
            string userInput;

            while (true)
            {
                Console.WriteLine("Please input a 9 digit integer:");
                userInput = Console.ReadLine();

                if (userInput.Length == 9 && Ex01_04.Program.IsAllDigits(userInput))
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

        private static void printAmountOfDigitsSmallerThanUnity(string i_ValidNumber)
        {
            int amountOfDigitsSmallerThanUnity = 0;
            int unityDigit;
            int.TryParse(i_ValidNumber[8].ToString(), out unityDigit);

            for (int i = 0; i < i_ValidNumber.Length - 1; i++)
            {
                int digitToCompare;
                int.TryParse(i_ValidNumber[i].ToString(), out digitToCompare);

                if (digitToCompare < unityDigit)
                {
                    amountOfDigitsSmallerThanUnity++;
                }
            }

            Console.WriteLine("1. The amout of digits smaller than the unity digit is: " + amountOfDigitsSmallerThanUnity);
        }

        private static void printLargestDigit(string i_ValidNumber)
        {
            int largestDigit;
            int.TryParse(i_ValidNumber[0].ToString(), out largestDigit);

            for (int i = 1; i < i_ValidNumber.Length; i++)
            {
                int digitToCompare;
                int.TryParse(i_ValidNumber[i].ToString(), out digitToCompare);

                if (largestDigit < digitToCompare)
                {
                    largestDigit = digitToCompare;
                }
            }

            Console.WriteLine("2. The largest digit is: " + largestDigit);
        }

        private static void printAmountOfDigitsDivisbleByThree(string i_ValidNumber)
        {
            int amountOfDigitsDivisbleByThree = 0;

            for (int i = 0; i < i_ValidNumber.Length; i++)
            {
                int digitToCheckIfDivisble;
                int.TryParse(i_ValidNumber[i].ToString(), out digitToCheckIfDivisble);

                if (digitToCheckIfDivisble % 3 == 0)
                {
                    amountOfDigitsDivisbleByThree++;
                }
            }

            Console.WriteLine("3. The amout of digits divisble by 3 is : " + amountOfDigitsDivisbleByThree);
        }

        private static void printDigitsAverage(string i_ValidNumber)
        {
            int sumOfDigits = 0;

            for (int i = 0; i < i_ValidNumber.Length; i++)
            {
                int digitToSum;
                int.TryParse(i_ValidNumber[i].ToString(), out digitToSum);
                sumOfDigits += digitToSum;
            }

            float digitsAverage = ((float)sumOfDigits) / i_ValidNumber.Length;

            Console.WriteLine("4. The digits average is: " + digitsAverage);
        }
    }
}
