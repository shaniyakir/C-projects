
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_TirePressure;
        private float m_MaxPressure;

        //public Wheel(string i_Manufacturer, float i_TirePressure, float i_MaxPressure)
        //{
        //    this.r_Manufacturer = i_Manufacturer;
        //    this.m_TirePressure = i_TirePressure;
        //    this.r_MaxPressure = i_MaxPressure;
        //}

        internal void Inflate(float i_AirToInflate)
        {
            if (m_TirePressure + i_AirToInflate < m_MaxPressure)
            {
                m_TirePressure += i_AirToInflate;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxPressure);
            }
        }

        internal void InflateToMax()
        {
            m_TirePressure = m_MaxPressure;
        }

        internal string Manufacturer
        {
            get 
            { 
                return m_Manufacturer; 
            }
            set
            {
                m_Manufacturer = value;
            }
        }

        internal float TirePressure
        {
            get
            {
                return m_TirePressure;
            }
            set
            {
                m_TirePressure = value;
            }
        }

        internal float MaxPressure
        {
            get
            {
                return m_MaxPressure;
            }
            set 
            { 
                m_MaxPressure = value; 
            }
        }

        public override string ToString()
        {
            return GarageStringMessages.wheelToString(this);
        }
    }
}
