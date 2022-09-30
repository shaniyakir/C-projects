using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            printBegginerDiamond(5);
        }

        public static void printBegginerDiamond(int i_DiamondHeight)
        {
            StringBuilder diamondStringBuilder = new StringBuilder();
            string diamod = buildDiamond(i_DiamondHeight, diamondStringBuilder, 1).ToString();
            Console.WriteLine(diamod);
            Console.ReadLine();
        }

        private static StringBuilder buildDiamond(int i_DiamondHeight, StringBuilder i_DiamondStringBuilder, int i_CurrentRow)
        {
            if (i_DiamondHeight > 0)
            {
                i_DiamondStringBuilder.Append(' ', i_DiamondHeight - 1);
                i_DiamondStringBuilder.Append('*', (i_CurrentRow * 2) - 1);
                i_DiamondStringBuilder.Append('\n');

                if (i_DiamondHeight > 1)
                {
                    buildDiamond(i_DiamondHeight - 1, i_DiamondStringBuilder, i_CurrentRow + 1);
                }

                if (i_DiamondHeight != 1)
                {
                    i_DiamondStringBuilder.Append(' ', i_DiamondHeight - 1);
                    i_DiamondStringBuilder.Append('*', (i_CurrentRow * 2) - 1);
                    i_DiamondStringBuilder.Append('\n');
                }
            }

            return i_DiamondStringBuilder;
        }
    }
}