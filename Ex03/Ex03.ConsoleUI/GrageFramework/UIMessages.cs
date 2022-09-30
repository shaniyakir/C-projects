using System;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal class UIMessages
    {
        public const string k_LicenseNumber = "Welcome to Amit and Shani garage! Please enter your car license number: ";
        public const string k_CarAllreadyInTheGarage = "Thank you. We remember your car details from your prior treatment here.";
        public const string k_InvalidInput = "(!) You enterd a wrong input. Please try again: ";
        public const string k_ActionOnVehicleInTheGarage = "Your vehicle is in our garage. What would you like to do? \nPlease enter the right number: \n" +
            "0 - for getting a list of all this license numbers of vehicles in the garage. \n" +
            "1 - for changing your vehicle status. \n" +
            "2 - to inflate all wheels to max. \n" +
            "3 - to fuel the vehicle. \n" +
            "4 - to charge the vehicle. \n" +
            "5 - to show your vehicle data. \n" +
            "6 - to start over with new vehicle\n" +
            "7 - exit";
        public const string k_ListOfAllLisencesInTheGarage = "Would you like to filter the list by vehicles status?\n if yes enter the wanted status: BeingFixed, Fixed or Paid.\n else press ENTER to continune";
        public const string k_ChangeVehicleStatus = "Please enter the new status [BeingFixed/Fixed/Paid]: ";
        public const string k_AddFuelCount = "Please enter the amount of fuel you want to add (int): ";
        public const string k_AddFuelType = "Please enter the type of fuel you want to add : [Soler/Octan95/Octan96/Octan98]: ";
        public const string k_ChargeBattery = "Please enter the number of minutes to charge (int): ";
        public const string k_OwnerName = "Please enter the vehicle owner's name (string): ";
        public const string k_OwnerPhoneNumber = "Please enter owner's phone number (10 numbers): ";
        public const string k_FailedRefuel = "(!) Invalid refuel request (either wrong type or over-fueled)! please try again: ";
        public const string k_WrongTypeOfEnergy = "(!) You coose the wrong type of fuel for your vehicle. please enter what yo want to do next: ";
        public const string k_EndTask = "\nWe did it! what's next? \n";
        public const string k_InflatedWheels = "All wheels were inflated to their max successfully. ";
        public const string k_InvalidEngineType = "(!) Can't perform this operation on this type of engine.";
    }
}
