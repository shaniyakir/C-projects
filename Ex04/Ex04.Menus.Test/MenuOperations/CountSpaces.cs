using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class CountSpaces : IRunnable
    {
        public void Run()
        {
            int numberOfSpaces = 0;
            string sentenceInput;

            Console.WriteLine("Write a sentence you want to count the amount of spaces in:");
            sentenceInput = Console.ReadLine();
            for (int i = 0; i < sentenceInput.Length; i++)
            {
                if (sentenceInput[i] == ' ')
                {
                    numberOfSpaces++;
                }
            }

            Console.WriteLine(String.Format("There were: {0} spaces in your sentence!", numberOfSpaces) + Environment.NewLine);
            Console.WriteLine("Click ENTER to continue...");
            Console.ReadLine();
        }
    }
}
