
namespace Ex05_01.GameFramework
{
    public class Player
    {
        private readonly string r_PlayerName;
        private int m_PlayerPoints;
        private readonly bool r_IsComputer;

        internal Player(string i_PlayerName, bool i_IsComputer)
        {
            this.r_PlayerName = i_PlayerName;
            this.m_PlayerPoints = 0;
            this.r_IsComputer = i_IsComputer;
        }
        internal string PlayerName
        {
            get 
            { 
                return this.r_PlayerName; 
            }
        }

        internal int PlayerPoints
        {
            get 
            { 
                return m_PlayerPoints; 
            }
            set 
            { 
                m_PlayerPoints = value; 
            }
        }

        internal bool IsComputer 
        { 
            get 
            { 
                return r_IsComputer; 
            } 
        }

    }
}
