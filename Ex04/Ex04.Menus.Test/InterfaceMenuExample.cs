using Ex04.Menus.Interfaces;
using System.Collections.Generic;

namespace Ex04.Menus.Test
{
    internal class InterfaceMenuExample
    {
        internal static void RunExample()
        {
            MainMenu mainMenu = buildMainMenu();
            mainMenu.Show();
        }

        private static MainMenu buildMainMenu()
        {
            MainMenu mainMenu = new MainMenu("Interface Main Menu");
            DisplayableMenuItem VersionAndSpaces = new DisplayableMenuItem("Version and Spaces");
            RunnableMenuItem showVersion = new RunnableMenuItem("Show Version", new ShowVersion());
            RunnableMenuItem countSpaces = new RunnableMenuItem("Count Spaces", new CountSpaces());
            VersionAndSpaces.AddSubMenus(new List<MenuItem> { showVersion, countSpaces });
            DisplayableMenuItem showDateTime = new DisplayableMenuItem("Show Date/Time");
            RunnableMenuItem showDate = new RunnableMenuItem("Show Date", new ShowDate());
            RunnableMenuItem showTime = new RunnableMenuItem("Show Time", new ShowTime());
            showDateTime.AddSubMenus(new List<MenuItem> { showDate, showTime });
            mainMenu.AddSubMenus(new List<MenuItem> { VersionAndSpaces, showDateTime });
            return mainMenu;
        }
    }
}
