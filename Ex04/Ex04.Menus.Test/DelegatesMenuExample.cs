using Ex04.Menus.Delegates;
using System.Collections.Generic;
using System;

namespace Ex04.Menus.Test
{
    internal class DelegatesMenuExample
    {
        private const string k_Version = "22.3.4.8650";
        internal static void RunExample()
        {
            MainMenu mainMenu = buildMainMenu();
            mainMenu.Show();
        }

        private static void showVersion_Selected()
        {
            Console.WriteLine(String.Format("Version: {0}", k_Version) + Environment.NewLine);
            Console.WriteLine("Click ENTER to continue...");
            Console.ReadLine();
        }

        private static void showTime_Selected()
        {
            Console.WriteLine(DateTime.Now.ToString().Split(' ')[1] + Environment.NewLine);
            Console.WriteLine("Click ENTER to continue...");
            Console.ReadLine();
        }

        private static void showDate_Selected()
        {
            Console.WriteLine(DateTime.Now.ToString().Split(' ')[0] + Environment.NewLine);
            Console.WriteLine("Click ENTER to continue...");
            Console.ReadLine();
        }

        private static void showCountSpace_Selected()
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

        public static MainMenu buildMainMenu()
        {
            MainMenu mainMenu = new MainMenu("Delegate Main Menu");
            DisplayableMenuItem versionAndSpaces = new DisplayableMenuItem("Version and Spaces");
            RunnableMenuItem versionItem = new RunnableMenuItem("Show Version");            
            RunnableMenuItem countSpaces = new RunnableMenuItem("Count Spaces");
            versionItem.RunnableMenuItemSelected += showVersion_Selected;
            countSpaces.RunnableMenuItemSelected += showCountSpace_Selected;
            versionAndSpaces.AddSubMenus(new List<MenuItem> { versionItem, countSpaces });
            DisplayableMenuItem showDateTime = new DisplayableMenuItem("Show Date/Time");
            RunnableMenuItem showDate = new RunnableMenuItem("Show Date");
            RunnableMenuItem showTime = new RunnableMenuItem("Show Time");
            showDate.RunnableMenuItemSelected += showDate_Selected;
            showTime.RunnableMenuItemSelected += showTime_Selected;
            showDateTime.AddSubMenus(new List<MenuItem> { showDate, showTime });
            mainMenu.AddSubMenus(new List<MenuItem> { versionAndSpaces, showDateTime });
            return mainMenu;
        }
    }
}
