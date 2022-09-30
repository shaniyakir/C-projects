using System;

namespace Ex04.Menus.Delegates
{
    public delegate void MenuSelected();

    public class RunnableMenuItem : MenuItem
    {
        public event MenuSelected RunnableMenuItemSelected;       
        public RunnableMenuItem(string i_MenuTitle) : base(i_MenuTitle)
        {          
        }

        internal void doWhenMenuSelected()
        {
            OnMenuSelect();
        }

        protected virtual void OnMenuSelect()
        {
            RunnableMenuItemSelected?.Invoke();
        }
    }
}
