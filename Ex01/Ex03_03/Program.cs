using System;
namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            printAdvancedDiamond();
        }
        private static void printAdvancedDiamond()
        {
            int diamondHeight = getValidHeightFromUser();
            Ex01_02.Program.printBegginerDiamond(diamondHeight);

            Console.WriteLine("Please press enter to exit");
            Console.ReadLine();
        }

        private static int getValidHeightFromUser()
        {
            string diamondHeightString;
            int diamondHeight;
            bool v_GoodInput;

            while (true)
            {
                diamondHeightString = Console.ReadLine();
                v_GoodInput = int.TryParse(diamondHeightString, out diamondHeight);
                if (!v_GoodInput || diamondHeight <= 0)
                {
                    Console.WriteLine("Invalid input, try again...");
                    continue;
                }

                if (diamondHeight % 2 == 0)
                {
                    diamondHeight--;
                }

                break;
            }

            return diamondHeight;
        }
    }
}
