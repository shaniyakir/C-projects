
namespace Ex03.GarageLogic
{
    internal class VehicleInGarage
    {
        private string m_VehicleOwner;
        private string m_OwnerPhoneNumber;
        private GarageEnums.eVehicleGarageStatus m_VehicleGarageStatus;
        private Vehicle m_Vehicle;

        internal VehicleInGarage(string i_VehicleOwner, string i_OwnerPhoneNumber, GarageEnums.eVehicleGarageStatus i_VehicleGarageStatus, Vehicle i_Vehicle)
        {
            this.m_VehicleOwner = i_VehicleOwner;
            this.m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.m_VehicleGarageStatus = i_VehicleGarageStatus;
            this.m_Vehicle = i_Vehicle;
        }

        internal string VehicleOwner
        {
            get
            {
                return m_VehicleOwner;
            }
            set
            {
                m_VehicleOwner = value;
            }
        }

        internal string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set 
            { 
                m_OwnerPhoneNumber = value; 
            }
        }

        internal GarageEnums.eVehicleGarageStatus VehicleGarageStatus
        {
            get
            {
                return m_VehicleGarageStatus;
            }
            set
            {
                m_VehicleGarageStatus = value;
            }
        }

        internal Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            return GarageStringMessages.VehicleInGarageToString(this);
        }
    }
}
