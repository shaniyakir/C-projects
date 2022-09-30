using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowVersion : IRunnable
    {
        private const string k_Version = "22.3.4.8650";

        public void Run()
        {
            Console.WriteLine(String.Format("Version: {0}", k_Version) + Environment.NewLine);
            Console.WriteLine("Click ENTER to continue...");
            Console.ReadLine();
        }
    }
}
