using System;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class ValidInput
    {
        public static string IsValidLicenseNumber(string i_LicenseNumber)
        {
            while (!(i_LicenseNumber.Length == 8 || i_LicenseNumber.Length == 7 && i_LicenseNumber.All(char.IsDigit)))
            {
                Console.WriteLine(UIMessages.k_InvalidInput);
                i_LicenseNumber = Console.ReadLine();
            }
            return i_LicenseNumber;
        }

        internal static string GetValidPhoneNumber(string i_PhoneNumber)
        {
            while (!(i_PhoneNumber.Length == 10 && i_PhoneNumber.All(char.IsDigit)))
            {
                Console.WriteLine(UIMessages.k_InvalidInput);
                i_PhoneNumber = Console.ReadLine();
            }
            return i_PhoneNumber;
        }

        internal static GarageEnums.eVehicleGarageStatus GetValidStatus(string i_Status)
        {
            GarageEnums.eVehicleGarageStatus status;
            string tryAgainInputStatus;
            bool success;
            bool TryParseStatus;

            try
            {
                TryParseStatus = Enum.TryParse(i_Status, out status);
                success = CheckStatusEnumType(i_Status);
                while (!success)
                {
                    Console.WriteLine(UIMessages.k_InvalidInput);
                    tryAgainInputStatus = Console.ReadLine();
                    i_Status = tryAgainInputStatus;
                    success = CheckStatusEnumType(i_Status);
                    TryParseStatus = Enum.TryParse(i_Status, out status);
                }

                return status;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        internal static float GetValidLitersAmount(string i_Liters)
        {
            while (!i_Liters.All(char.IsDigit))
            {
                Console.WriteLine(UIMessages.k_InvalidInput);
                i_Liters = Console.ReadLine();
            }
            return float.Parse(i_Liters);
        }

        internal static GarageEnums.ePetrolType GetValidFuelType(string i_FuelType)
        {
            GarageEnums.ePetrolType result;
            string tryAgainInputFuel;
            bool success;
            bool TryParseFuel;

            try
            {
                TryParseFuel = Enum.TryParse(i_FuelType, out result);
                success = CheckPetrolEnumType(i_FuelType);
                while (!success)
                {
                    Console.WriteLine(UIMessages.k_InvalidInput);
                    tryAgainInputFuel = Console.ReadLine();
                    i_FuelType = tryAgainInputFuel;
                    success = CheckPetrolEnumType(i_FuelType);
                    TryParseFuel = Enum.TryParse(i_FuelType, out result);
                }

                return result;
            }
            catch
            {
                throw;
            }
        }
        internal static float GetValidElectricMinutes(string i_Minutes)
        {
            while (!i_Minutes.All(char.IsDigit))
            {
                Console.WriteLine(UIMessages.k_InvalidInput);
                i_Minutes = Console.ReadLine();
            }

            return float.Parse(i_Minutes);
        }

        internal static string GetValidNumber(string i_TypeNumber)
        {
            try
            {
                bool successParse = int.TryParse(i_TypeNumber, out int result);
                while (result > Enum.GetNames(typeof(CreateVehicle.eVehicleTypes)).Length || result < 1)
                {
                    Console.WriteLine(UIMessages.k_InvalidInput);
                    i_TypeNumber = Console.ReadLine();
                    successParse = int.TryParse(i_TypeNumber, out result);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(UIMessages.k_InvalidInput);
            }

            return i_TypeNumber;
        }

        internal static bool CheckPetrolEnumType(string i_PetrolType)
        {
            bool success = false;
            foreach (string enumFuelName in Enum.GetNames(typeof(GarageEnums.ePetrolType)))
            {
                if (enumFuelName == i_PetrolType)
                {
                    success = true;
                    break;
                }
            }
            return success;
        }

        internal static bool CheckStatusEnumType(string i_StatusType)
        {
            bool success = false;
            foreach (string enumFuelName in Enum.GetNames(typeof(GarageEnums.eVehicleGarageStatus)))
            {
                if (enumFuelName == i_StatusType)
                {
                    success = true;
                    break;
                }
            }
            return success;
        }
    }
}

