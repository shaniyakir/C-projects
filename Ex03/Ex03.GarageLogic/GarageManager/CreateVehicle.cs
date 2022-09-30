using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class CreateVehicle
    {
        public enum eVehicleTypes
        {
            Car = 1,
            Truck = 2,
            MotorCycle = 3
        }

        public static Vehicle CreateNewVehicle(int i_VehicleType)
        {
            // For adding new Vehicle types add the Enum corresponding int value as a call to return the new vehicle object
            if (i_VehicleType == 1)
            {
                return new Car();
            }
            else if (i_VehicleType == 2)
            {
                return new Truck();
            }
            else // i_VehicleType == 3
            {
                return new Motorcycle();
            }
        }

        //public Vehicle CreateNewCar(string i_Model, string i_LisenceNumber, float i_EnergyLevelPercentage, List<Wheel> i_Wheels, Engine i_Engine, GarageEnums.eCarColors i_CarColor, GarageEnums.eCarDoors i_CarDoors)
        //{
        //    return new Car(i_Model, i_LisenceNumber, i_EnergyLevelPercentage, i_Wheels, i_Engine, i_CarColor, i_CarDoors);
        //}

        //public Vehicle CreateNewMotorcycle(string i_Model, string i_LisenceNumber, float i_EnergyLevelPercentage, List<Wheel> i_Wheels, Engine i_Engine, GarageEnums.eLicenseType i_LisenceType, int i_EngineCC)
        //{
        //    return new Motorcycle(i_Model, i_LisenceNumber, i_EnergyLevelPercentage, i_Wheels, i_Engine, i_LisenceType, i_EngineCC);
        //}

        //public Vehicle CreateNewTruck(string i_Model, string i_LisenceNumber, float i_EnergyLevelPercentage, List<Wheel> i_Wheels, Engine i_Engine, bool i_HasCooledProducts, float i_MaxLoad)
        //{
        //    return new Truck(i_Model, i_LisenceNumber, i_EnergyLevelPercentage, i_Wheels, i_Engine, i_HasCooledProducts, i_MaxLoad);
        //}
    }
}
