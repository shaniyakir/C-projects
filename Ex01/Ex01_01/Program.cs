namespace Ex01_01
{
    using System;

    public class Program
    {
        public static void Main()
        {
            binarySeries();
        }

        private static void binarySeries()
        {
            string[] binaryInputArray = new string[3];
            Console.WriteLine("Please enter 3 numbers in binary format of length 7 each:");
            for (int i = 0; i < 3; i++)
            {
                binaryInputArray[i] = getValidInput();
            }

            printStatistic(binaryInputArray);
            Console.WriteLine("Please press enter to exit");
            Console.ReadLine();
        }

        private static string getValidInput()
        {
            while (true)
            {
                string binaryInput = Console.ReadLine();

                if (binaryInput != null && binaryInput.Length == 7)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (binaryInput[i] != '0' && binaryInput[i] != '1')
                        {
                            break;
                        }

                        if (i == 6)
                        {
                            return binaryInput;
                        }
                    }
                }

                Console.WriteLine("You enterd an invalid binary number. Please try again:");
            }
        }

        private static void printStatistic(string[] i_BinaryInputArray)
        {
            string[] inputArrayAsDecimalStr = new string[3];
            for (int i = 0; i < i_BinaryInputArray.Length; i++)
            {
                inputArrayAsDecimalStr[i] = convertBinaryStringToIntNumber(i_BinaryInputArray[i]).ToString();
            }

            printDecimalNumbersOrderdAsc(i_BinaryInputArray);
            float amountOfAvgZero = AverageNumOfDigit(i_BinaryInputArray, '0');
            float amountOfAvgOne = AverageNumOfDigit(i_BinaryInputArray, '1');
            int amountDivideByThree = AmountOfNumbersDivisibleByThree(i_BinaryInputArray);
            int numOfPalindrom = AmountOfDecimalPalindrom(inputArrayAsDecimalStr);
            string statisticsMessage = string.Format(
@"The average number of zeros in input is: {0}
The average of ones in input is: {1}
The number of inputs that are divisible by 3 is: {2}
The number of inputs that are a palindrom is: {3}",
amountOfAvgZero, amountOfAvgOne, amountDivideByThree, numOfPalindrom);

            Console.WriteLine(statisticsMessage);
        }

        private static void printDecimalNumbersOrderdAsc(string[] i_BinaryInputArray)
        {
            int[] numInputArray = new int[3];
            int i_CurrentBiggerInt;
            Console.WriteLine("Printing your binary numbers as demical in ascanding order:");
            for (int k = 0; k < i_BinaryInputArray.Length; k++)
            {
                numInputArray[k] = convertBinaryStringToIntNumber(i_BinaryInputArray[k]);
            }

            for (int i = 0; i < i_BinaryInputArray.Length; i++)
            {
                for (int j = i + 1; j < i_BinaryInputArray.Length; j++)
                {
                    if (numInputArray[i] > numInputArray[j])
                    {
                        i_CurrentBiggerInt = numInputArray[i];
                        numInputArray[i] = numInputArray[j];
                        numInputArray[j] = i_CurrentBiggerInt;
                    }
                }
            }

            for (int i = 0; i < numInputArray.Length; i++)
            {
                Console.WriteLine(numInputArray[i]);
            }
        }

        private static int convertBinaryStringToIntNumber(string i_BinaryInputArray)
        {
            int i_InputAsInt = 0;

            for (int i = i_BinaryInputArray.Length - 1; i >= 0; i--)
            {
                i_InputAsInt += (i_BinaryInputArray[i] - '0') * (int)Math.Pow(2, i_BinaryInputArray.Length - 1 - i);
            }

            return i_InputAsInt;
        }

        private static float AverageNumOfDigit(string[] i_BinaryInputArray, char i_digitToCount)
        {
            int m_CountTheWantedDigit = 0;

            for (int i = 0; i < i_BinaryInputArray.Length; i++)
            {
                for (int j = 0; j < i_BinaryInputArray[i].Length; j++)
                {
                    if (i_BinaryInputArray[i][j] == i_digitToCount)
                    {
                        m_CountTheWantedDigit++;
                    }
                }
            }

            return (float)m_CountTheWantedDigit / i_BinaryInputArray.Length;
        }

        private static int AmountOfNumbersDivisibleByThree(string[] i_BinaryInputArray)
        {
            int m_AmountOfNumbers = 0;

            for (int i = 0; i < i_BinaryInputArray.Length; i++)
            {
                if (convertBinaryStringToIntNumber(i_BinaryInputArray[i]) % 3 == 0)
                {
                    m_AmountOfNumbers++;
                }
            }

            return m_AmountOfNumbers;
        }

        private static int AmountOfDecimalPalindrom(string[] i_BinaryInputArray)
        {
            int m_AmountOfPalindroms = 0;
            bool v_CheackIfPalindrom;
            int middleInputStringLength = (int)(i_BinaryInputArray[1].Length / 2);

            for (int i = 0; i < i_BinaryInputArray.Length; i++)
            {
                v_CheackIfPalindrom = true;
                for (int j = i_BinaryInputArray[i].Length - 1; j >= middleInputStringLength; j--)
                {
                    if (i_BinaryInputArray[i][j] != i_BinaryInputArray[i][i_BinaryInputArray[i].Length - 1 - j])
                    {
                        v_CheackIfPalindrom = false;
                        break;
                    }
                }

                if (v_CheackIfPalindrom)
                {
                    m_AmountOfPalindroms++;
                }
            }

            return m_AmountOfPalindroms;
        }
    }
}
