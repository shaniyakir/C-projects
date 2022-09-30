using System;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        internal static void Init()
        {
            Garage m_Garage = new Garage();

            UIManager(m_Garage);
        }
        
        internal static void UIManager(Garage i_Garage) { 
            Console.WriteLine(UIMessages.k_LicenseNumber);   
            
            string LicenseNumber = ValidInput.IsValidLicenseNumber(Console.ReadLine());
            
            if (i_Garage.IsVehicleIsInTheGarage(LicenseNumber))
            {
                i_Garage.ChangeVehicleStatus(LicenseNumber, GarageEnums.eVehicleGarageStatus.BeingFixed);
                Console.WriteLine(UIMessages.k_CarAllreadyInTheGarage);
                TakeCareOfVehicleInGarage(LicenseNumber, i_Garage);
            }
            else
            {
                Console.WriteLine("We havent met yet!Lets add your vehicle. please choose the right number that represents you vehicle: ");
                foreach (int i in Enum.GetValues(typeof(CreateVehicle.eVehicleTypes)))
                {
                    Console.Write(string.Format("{0} = ", Enum.GetName(typeof(CreateVehicle.eVehicleTypes), i)));
                    Console.WriteLine("{0}", i);
                }

                string stringVehicleTypeInput = ValidInput.GetValidNumber(Console.ReadLine());
                Vehicle vehicle = CreateVehicle.CreateNewVehicle(int.Parse(stringVehicleTypeInput));

                for (int i = 0; i < vehicle.Questions.Count; i++)
                {
                    bool propertySuccess = false;
                    string inputMessage;

                    try
                    {
                        Console.Write(vehicle.Questions[i]);
                        inputMessage = Console.ReadLine();
                        propertySuccess = vehicle.SetProperty(i, inputMessage, i_Garage);
                    }

                    catch (Exception)
                    {
                    }
                    finally
                    {
                        while (!propertySuccess)
                        {
                            try
                            {
                                Console.WriteLine(UIMessages.k_InvalidInput);
                                inputMessage = Console.ReadLine();
                                propertySuccess = vehicle.SetProperty(i, inputMessage, i_Garage);
                            }
                            catch (Exception)
                            { 
                            }
                        }
                    }
                }

                Console.Write(Environment.NewLine);
                string lisence = vehicle.LisenceNumber;
                Console.Write(UIMessages.k_OwnerName);
                string ownerName = Console.ReadLine();
                Console.Write(UIMessages.k_OwnerPhoneNumber);
                string ownerPhoneNumber = ValidInput.GetValidPhoneNumber(Console.ReadLine());
                i_Garage.InsertNewVehicleInGarage(ownerName, ownerPhoneNumber, GarageEnums.eVehicleGarageStatus.BeingFixed, vehicle);
                Console.Write(Environment.NewLine);
                while (!TakeCareOfVehicleInGarage(lisence, i_Garage)) ;
            }
        }
        internal static bool TakeCareOfVehicleInGarage(string i_LicenseNumber, Garage i_Garage)
        {
            bool quit = false;

            Console.WriteLine(UIMessages.k_ActionOnVehicleInTheGarage);
            string StringCareOfVehicleInGarage = Console.ReadLine();

            if (StringCareOfVehicleInGarage == "0") // List all vehicles in garage (with optional filter)
            {
                List<string> lisenceList = new List<string>();
                Console.WriteLine(UIMessages.k_ListOfAllLisencesInTheGarage);
                string wantedList = Console.ReadLine();
                if (wantedList == "")
                {
                    lisenceList = i_Garage.ListLisencePlatesInGarage();
                    foreach (string lisence in lisenceList)
                    {
                        Console.WriteLine(lisence);
                    }    
                }
                else
                {
                    GarageEnums.eVehicleGarageStatus wantedListByStatus = ValidInput.GetValidStatus(wantedList);
                    lisenceList = i_Garage.ListLisencePlatesInGarageByStatus(wantedListByStatus);
                    foreach (string lisence in lisenceList)
                    {
                        Console.WriteLine(lisence);
                    }
                }
            }
            else if (StringCareOfVehicleInGarage == "1") // Change vehicle status
            {
                Console.Write(UIMessages.k_ChangeVehicleStatus);
                string statusChange = Console.ReadLine();
                GarageEnums.eVehicleGarageStatus wantedStatus = ValidInput.GetValidStatus(statusChange);

                i_Garage.ChangeVehicleStatus(i_LicenseNumber, wantedStatus);
                Console.WriteLine(UIMessages.k_EndTask);
            }
            else if (StringCareOfVehicleInGarage == "2") // Inflate all wheels to max
            {
                i_Garage.InflateWheelsToMax(i_LicenseNumber);

                Console.WriteLine(UIMessages.k_InflatedWheels);
                Console.WriteLine(UIMessages.k_EndTask);
            }
            else if (StringCareOfVehicleInGarage == "3") // Fill Petrol
            {
                if (i_Garage.GetVehicleEngineTypeFromGarage(i_LicenseNumber) != GarageEnums.eEngineType.Petrol)
                {
                    Console.Write(UIMessages.k_InvalidEngineType);
                }
                else
                {
                    bool filledPetrolSuccessfully = false;

                    while (!filledPetrolSuccessfully)
                    {
                        Console.Write(UIMessages.k_AddFuelCount);
                        float fuelAmountLiters = ValidInput.GetValidLitersAmount(Console.ReadLine());
                        Console.Write(UIMessages.k_AddFuelType);
                        GarageEnums.ePetrolType fuelType = ValidInput.GetValidFuelType(Console.ReadLine());
                        try
                        {
                            i_Garage.FillVehiclePetrol(i_LicenseNumber, fuelType, fuelAmountLiters);
                            filledPetrolSuccessfully = true;
                            Console.WriteLine(UIMessages.k_EndTask);
                        }
                        catch
                        {
                            Console.WriteLine(UIMessages.k_FailedRefuel);
                        }
                    }
                }
            }
            else if (StringCareOfVehicleInGarage == "4") // Fill Electricity
            {
                if (i_Garage.GetVehicleEngineTypeFromGarage(i_LicenseNumber) != GarageEnums.eEngineType.Electric)
                {
                    Console.Write(UIMessages.k_InvalidEngineType);
                }
                else
                {
                    try
                    {
                        Console.Write(UIMessages.k_ChargeBattery);
                        float electricByMinutes = ValidInput.GetValidElectricMinutes(Console.ReadLine());
                        i_Garage.FillElectricVehicle(i_LicenseNumber, electricByMinutes);
                        Console.WriteLine(UIMessages.k_EndTask);
                    }
                    catch
                    {
                        Console.WriteLine(UIMessages.k_WrongTypeOfEnergy);

                    }
                }
            }
            else if (StringCareOfVehicleInGarage == "5") // Print vehicle data.
            {
                i_Garage.PrintVehicleData(i_LicenseNumber);
                Console.WriteLine(UIMessages.k_EndTask);
            }
            else if (StringCareOfVehicleInGarage == "6") // start over with new vehicle
            {
                UI.UIManager(i_Garage);
                quit = true;
            }
            else if (StringCareOfVehicleInGarage == "7") // Quit
            {
                quit = true;
            }
            else
            {
                Console.WriteLine(UIMessages.k_InvalidInput);
            }
            return quit;
        }
    }
}
