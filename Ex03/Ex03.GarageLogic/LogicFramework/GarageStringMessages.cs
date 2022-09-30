using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class GarageStringMessages
    {
        internal const string k_TriedGetIlegalVehicle = "You've tried to access a vehicle that does not exist in the garage.";
        internal const string k_TriedInsertIlegalVehicle = "You've tried to insert a vehicle that already exists in the garage.";
        internal const string k_InvalidEngineType = "Yo've tried to fill the wrong type of energy in the vehicle";
        internal const string k_invalidPetrolType = "You've entered a wrong petrol type in the vehicle";

        private static string vehicleToString(Vehicle i_Vehicle)
        {
            StringBuilder vehicleStringBuilder = new StringBuilder();

            vehicleStringBuilder.Append("Model: " + i_Vehicle.Model + Environment.NewLine);
            vehicleStringBuilder.Append("Lisence Number: " + i_Vehicle.LisenceNumber + Environment.NewLine);
            vehicleStringBuilder.Append("Engine Type: " + i_Vehicle.Engine.EngineType.ToString() + Environment.NewLine);
            vehicleStringBuilder.Append("Current amount of Fuel/Electricity: " + i_Vehicle.Engine.CurrentEnergyLevel + Environment.NewLine);
            vehicleStringBuilder.Append("Maximum amount of Fuel/Electricity: " + i_Vehicle.Engine.MaximumEnergyLevel + Environment.NewLine);
            vehicleStringBuilder.Append("Wheels: " + wheelsToString(i_Vehicle.Wheels) + Environment.NewLine);

            return vehicleStringBuilder.ToString();
        }

        private static string wheelsToString(List<Wheel> i_Wheels)
        {
            StringBuilder wheelsStringBuilder = new StringBuilder();
            
            for (int i = 0; i < i_Wheels.Count; i++)
            {
                wheelsStringBuilder.Append("[" + wheelToString(i_Wheels[i]) + "] ");
            }

            return wheelsStringBuilder.ToString();
        }

        internal static string wheelToString(Wheel i_Wheel)
        {
            StringBuilder wheelStringBuilder = new StringBuilder();

            wheelStringBuilder.Append("Manufacturer: " + i_Wheel.Manufacturer + ", ");
            wheelStringBuilder.Append("TirePressure: " + i_Wheel.TirePressure + ", ");
            wheelStringBuilder.Append("MaxPressure: " + i_Wheel.MaxPressure);

            return wheelStringBuilder.ToString();
        }

        internal static string MotorcycleToString(Motorcycle i_Motorcycle)
        {
            StringBuilder motorcycleStringBuilder = new StringBuilder();

            motorcycleStringBuilder.Append(vehicleToString(i_Motorcycle));
            motorcycleStringBuilder.Append("License Type: " + i_Motorcycle.LicenseType + Environment.NewLine);
            motorcycleStringBuilder.Append("Engine CC: " + i_Motorcycle.EngineCC + Environment.NewLine);

            return motorcycleStringBuilder.ToString();
        }

        internal static string CarToString(Car i_Car)
        {
            StringBuilder carStringBuilder = new StringBuilder();

            carStringBuilder.Append(vehicleToString(i_Car));
            carStringBuilder.Append("Car Color: " + i_Car.CarColor + Environment.NewLine);
            carStringBuilder.Append("Car Doors: " + i_Car.CarDoors + Environment.NewLine);

            return carStringBuilder.ToString();
        }

        internal static string TruckToString(Truck i_Truck)
        {
            StringBuilder truckStringBuilder = new StringBuilder();

            truckStringBuilder.Append(vehicleToString(i_Truck));
            truckStringBuilder.Append("Has Cooled Products: " + i_Truck.HasCooledProducts.ToString() + Environment.NewLine);
            truckStringBuilder.Append("Max Load: " + i_Truck.MaxLoad + Environment.NewLine);

            return truckStringBuilder.ToString();
        }

        internal static string VehicleInGarageToString(VehicleInGarage i_Vehicle)
        {
            StringBuilder vehicleInGarageStringBuilder = new StringBuilder();

            vehicleInGarageStringBuilder.Append(i_Vehicle.Vehicle.ToString());
            vehicleInGarageStringBuilder.Append("Vehicle Owner: " + i_Vehicle.VehicleOwner + Environment.NewLine);
            vehicleInGarageStringBuilder.Append("Owner Phone Number: " + i_Vehicle.OwnerPhoneNumber + Environment.NewLine);
            vehicleInGarageStringBuilder.Append("Vehicle Status: " + i_Vehicle.VehicleGarageStatus.ToString() + Environment.NewLine);

            return vehicleInGarageStringBuilder.ToString();
        }
    }
}
