
namespace Ex03.GarageLogic
{
    public class PetrolEngine : Engine
    {
        private GarageEnums.ePetrolType m_PetrolType;

        //public PetrolEngine(float i_currentEnergyLevel, float i_maximumEnergyLevel, GarageEnums.ePetrolType i_PetrolType, GarageEnums.eEngineType i_EngineType)
        //    : base(i_currentEnergyLevel, i_maximumEnergyLevel, i_EngineType)
        //{
        //    this.r_PetrolType = i_PetrolType;
        //}

        public override void FillEnergy(float i_EnergyToFill)
        {
            if (this.CurrentEnergyLevel + i_EnergyToFill <= this.MaximumEnergyLevel)
            {
                this.CurrentEnergyLevel += i_EnergyToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.MaximumEnergyLevel);
            }
        }

        public GarageEnums.ePetrolType PetrolType
        {
            get 
            { 
                return m_PetrolType; 
            }
            set
            {
                m_PetrolType = value;
            }
        }
    }
}
