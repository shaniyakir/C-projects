
namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        //public ElectricEngine(float i_currentEnergyLevel, float i_maximumEnergyLevel, GarageEnums.eEngineType i_EngineType) : base(i_currentEnergyLevel, i_maximumEnergyLevel, i_EngineType) {}

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
    }
}
