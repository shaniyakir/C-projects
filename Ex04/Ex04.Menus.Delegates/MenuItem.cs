using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private readonly string r_MenuTitle;
        private MenuItem m_ParentMenu;
        private List<MenuItem> m_SubMenus;

        public MenuItem(string i_MenuTitle)
        {
            this.r_MenuTitle = i_MenuTitle;
            this.m_ParentMenu = null;
            this.m_SubMenus = new List<MenuItem>();
        }

        public string MenuTitle
        {
            get { return this.r_MenuTitle; }
        }

        public MenuItem ParentMenu
        {
            get { return this.m_ParentMenu; }
            set { m_ParentMenu = value; }
        }

        public List<MenuItem> SubMenus
        {
            get { return this.m_SubMenus; }
        }

        public void AddSubMenus(List<MenuItem> i_MenuObject)
        {
            foreach (MenuItem menuObject in i_MenuObject)
            {
                menuObject.ParentMenu = this;
                m_SubMenus.Add(menuObject);
            }
        }
    }
}
