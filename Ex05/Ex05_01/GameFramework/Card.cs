
namespace Ex05_01.GameFramework
{
    internal class Card
    {
        private readonly char r_CardValue;
        private readonly int r_HeightIndex;
        private readonly int r_WidthIndex;
        private bool m_IsDiscovered;
        private bool m_IsCurrentlyOpen;
        internal Card(char i_CardValue, int i_HeightIndex, int i_WidthIndex)
        {
            this.r_CardValue = i_CardValue;
            this.r_HeightIndex = i_HeightIndex;
            this.r_WidthIndex = i_WidthIndex;
            this.m_IsDiscovered = false;
            this.m_IsCurrentlyOpen = false;
        }

        internal char CardValue
        {
            get 
            { 
                return r_CardValue; 
            }
        }

        internal int HeightIndex
        {
            get 
            { 
                return r_HeightIndex; 
            }
        }

        internal int WidthIndex
        {
            get 
            { 
                return r_WidthIndex; 
            }
        }

        public bool IsDiscovered
        {
            get
            {
                return m_IsDiscovered;
            }
            set
            {
                this.m_IsDiscovered = value;
            }
        }

        internal bool IsCurrentlyOpen
        {
            get
            {
                return m_IsCurrentlyOpen;
            }
            set
            {
                this.m_IsCurrentlyOpen = value;
            }
        }

        public override bool Equals(object obj)
        {
            bool returnVal = false;

            Card compareTo = obj as Card;
            if (compareTo != null)
            {
                returnVal = (r_HeightIndex.Equals(compareTo.HeightIndex) && r_WidthIndex.Equals(compareTo.WidthIndex));
            }

            return returnVal;
        }
    }
}
