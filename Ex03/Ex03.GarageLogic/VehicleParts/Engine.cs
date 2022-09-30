
namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_CurrentEnergyLevel;
        private float m_MaximumEnergyLevel;
        private GarageEnums.eEngineType m_EngineType;

        //protected Engine(float i_currentEnergyLevel, float i_maximumEnergyLevel, GarageEnums.eEngineType i_EngineType)
        //{
        //    this.m_CurrentEnergyLevel = i_currentEnergyLevel;
        //    this.m_MaximumEnergyLevel = i_maximumEnergyLevel;
        //    this.r_EngineType = i_EngineType;
        //}

        public abstract void FillEnergy(float i_EnergyToFill);

        internal float CurrentEnergyLevel
        {
            get 
            { 
                return m_CurrentEnergyLevel; 
            }
            set
            {
                m_CurrentEnergyLevel = value;
            }
        }

        internal float MaximumEnergyLevel
        {
            get 
            { 
                return m_MaximumEnergyLevel; 
            }
            set
            {
                m_MaximumEnergyLevel = value;
            }
        }

        internal GarageEnums.eEngineType EngineType
        {
            get
            {
                return m_EngineType;
            }
            set
            {
                m_EngineType = value;
            }
        }
    }
}
