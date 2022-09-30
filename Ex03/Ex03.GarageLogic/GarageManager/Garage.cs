using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        internal Dictionary<string, VehicleInGarage> m_DictionaryOfVehicleInGarage = new Dictionary<string, VehicleInGarage>();
       
        public bool IsVehicleIsInTheGarage(string i_LicenseNumber)
        {
            return m_DictionaryOfVehicleInGarage.ContainsKey(i_LicenseNumber);
        }

        private void validateVehicleExists(string i_LisenceNumber)
        {
            if (!IsVehicleIsInTheGarage(i_LisenceNumber))
            {
                throw new ArgumentException(GarageStringMessages.k_TriedGetIlegalVehicle);
            }
        }
        
        public GarageEnums.eEngineType GetVehicleEngineTypeFromGarage(string i_LisenceNumber)
        {
            validateVehicleExists(i_LisenceNumber);
            return m_DictionaryOfVehicleInGarage[i_LisenceNumber].Vehicle.Engine.EngineType;
        } 

        public void InsertNewVehicleInGarage(string i_VehicleOwner, string i_OwnerPhoneNumber, GarageEnums.eVehicleGarageStatus i_VehicleGarageStatus, Vehicle i_Vehicle)
        {
            if (IsVehicleIsInTheGarage(i_Vehicle.LisenceNumber))
            {
                throw new ArgumentException(GarageStringMessages.k_TriedInsertIlegalVehicle);
            }

            VehicleInGarage newVehicle = new VehicleInGarage(i_VehicleOwner, i_OwnerPhoneNumber, i_VehicleGarageStatus, i_Vehicle);
            m_DictionaryOfVehicleInGarage.Add(i_Vehicle.LisenceNumber, newVehicle);
        }

        public List<string> ListLisencePlatesInGarage()
        {
            return new List<string>(m_DictionaryOfVehicleInGarage.Keys);
        }

        public  List<string> ListLisencePlatesInGarageByStatus(GarageEnums.eVehicleGarageStatus i_Status)
        {
            List<string> LisencePlatesWithStatus = new List<string>();

            foreach (VehicleInGarage vehicleInGarage in m_DictionaryOfVehicleInGarage.Values)
            {
                if (vehicleInGarage.VehicleGarageStatus.Equals(i_Status))
                {
                    LisencePlatesWithStatus.Add(vehicleInGarage.Vehicle.LisenceNumber);
                }
            }

            return LisencePlatesWithStatus;
        }

        public void ChangeVehicleStatus(string i_LisenceNumber, GarageEnums.eVehicleGarageStatus i_VehicleNewStatus)
        {
            validateVehicleExists(i_LisenceNumber);
            m_DictionaryOfVehicleInGarage[i_LisenceNumber].VehicleGarageStatus = i_VehicleNewStatus;
        }

        public void InflateWheelsToMax(string i_LisenceNumber)
        {
            validateVehicleExists(i_LisenceNumber);
            VehicleInGarage vehicleInGarage = m_DictionaryOfVehicleInGarage[i_LisenceNumber];

            for (int i = 0 ; i < vehicleInGarage.Vehicle.Wheels.Count; i++)
            {
                vehicleInGarage.Vehicle.Wheels[i].InflateToMax();
            }
        }

        public void FillVehiclePetrol(string i_LisenceNumber, GarageEnums.ePetrolType i_PetrolType, float i_LitersToFill)
        {          
            validateVehicleExists(i_LisenceNumber);
            VehicleInGarage vehicleInGarage = m_DictionaryOfVehicleInGarage[i_LisenceNumber];

            if (vehicleInGarage.Vehicle.Engine.EngineType != GarageEnums.eEngineType.Petrol)
            {
                throw new ArgumentException(GarageStringMessages.k_InvalidEngineType);
            }

            if (((PetrolEngine)vehicleInGarage.Vehicle.Engine).PetrolType != i_PetrolType)
            {
                throw new ArgumentException(GarageStringMessages.k_invalidPetrolType);
            }

            vehicleInGarage.Vehicle.Engine.FillEnergy(i_LitersToFill);
        }

        public void FillElectricVehicle(string i_LisenceNumber, float i_minutesToFill)
        {
            validateVehicleExists(i_LisenceNumber);
            VehicleInGarage vehicleInGarage = m_DictionaryOfVehicleInGarage[i_LisenceNumber];

            if (vehicleInGarage.Vehicle.Engine.EngineType != GarageEnums.eEngineType.Electric)
            {
                throw new ArgumentException(GarageStringMessages.k_InvalidEngineType);
            }

            vehicleInGarage.Vehicle.Engine.FillEnergy(i_minutesToFill / 60);
        }

        public void PrintVehicleData(string i_LisenceNumber)
        {
            validateVehicleExists(i_LisenceNumber);
            VehicleInGarage vehicleInGarage = m_DictionaryOfVehicleInGarage[i_LisenceNumber];

            Console.WriteLine(new string('#', 30));
            Console.WriteLine(vehicleInGarage.ToString());
            Console.WriteLine(new string('#', 30));
        }

    }
}
