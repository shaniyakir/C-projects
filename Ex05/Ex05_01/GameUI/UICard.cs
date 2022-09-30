using Ex05_01.GameFramework;
using System.Windows.Forms;


namespace Ex05_01.GameUI
{
    internal class UICard : Button
    {
        private Card m_Card;

        internal UICard(Card i_Card) : base() 
        { 
            this.m_Card = i_Card; 
        }

        internal Card Card
        {
            get { return m_Card; }
            set { m_Card = value; }
        }
    }
}
