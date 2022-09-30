
using System;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class DisplayableMenuItem : MenuItem, IDisplayable
    {
        public DisplayableMenuItem(string i_MenuTitle) : base(i_MenuTitle) { }

        public void Show()
        {
            bool userReturn = false;

            while (!userReturn)
            {
                Console.Clear();
                StringBuilder displayMenuBuilder = new StringBuilder();

                displayMenuBuilder.AppendLine("**" + this.MenuTitle + "**");
                displayMenuBuilder.AppendLine("------------------------");
                int i = 1;
                foreach (MenuItem subMenuObject in this.SubMenus)
                {
                    displayMenuBuilder.Append(i++ + ": ");
                    displayMenuBuilder.AppendLine(subMenuObject.MenuTitle);
                }
                displayMenuBuilder.AppendLine("0: " + exitOrBackString());
                displayMenuBuilder.AppendLine("------------------------");
                displayMenuBuilder.Append("Please enter your choice (1-" + this.SubMenus.Count + " or 0 to exit):");
                Console.WriteLine(displayMenuBuilder);
                int validUserInput = getValidUserChoice();
                userReturn = performUserOperation(validUserInput);
            }
        }

        private string exitOrBackString()
        {
            string exitOrBackString;

            if (this.ParentMenu == null)
            {
                exitOrBackString = "Exit";
            }
            else
            {
                exitOrBackString = "Back";
            }

            return exitOrBackString;
        }

        private int getValidUserChoice()
        {
            string userInput = Console.ReadLine();
            int validUserInputInt;

            while (!int.TryParse(userInput, out validUserInputInt) || validUserInputInt < 0 || validUserInputInt > this.SubMenus.Count)
            {
                Console.WriteLine("(!) Invalid input try again...");
                userInput = Console.ReadLine();
            }

            return validUserInputInt;
        }

        private bool performUserOperation(int i_UserChoice)
        {
            bool userReturn = false;

            if (i_UserChoice == 0)
            {
                userReturn = true;
            }
            else
            {
                RunnableMenuItem runnableMenu = this.SubMenus[i_UserChoice - 1] as RunnableMenuItem;

                if (runnableMenu != null)
                {
                    runnableMenu.Run();
                } 
                else
                {
                    DisplayableMenuItem displayableMenu = this.SubMenus[i_UserChoice - 1] as DisplayableMenuItem;
                    displayableMenu.Show();
                }
            }

            return userReturn;
        }
    }
}
