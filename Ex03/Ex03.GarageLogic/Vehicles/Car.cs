using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private GarageEnums.eCarColors m_CarColor;
        private GarageEnums.eCarDoors m_CarDoors;

        public Car()
        {
            this.Questions.Add("What color is the car [Grey/White/Black/Blue]: ");
            this.Questions.Add("How many doors in the car [2/3/4/5] : ");
        }

        //    public Car(string i_Model, string i_LisenceNumber, float i_EnergyLevelPercentage, List<Wheel> i_Wheels, Engine i_Engine, GarageEnums.eCarColors i_CarColor, GarageEnums.eCarDoors i_CarDoors)
        //: base(i_Model, i_LisenceNumber, i_EnergyLevelPercentage, i_Wheels, i_Engine)
        //    {
        //        this.r_CarColor = i_CarColor;
        //        this.r_CarDoors = i_CarDoors;
        //    }

        internal GarageEnums.eCarColors CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        internal GarageEnums.eCarDoors CarDoors
        {
            get
            {
                return m_CarDoors;
            }
            set
            {
                m_CarDoors = value;
            }
        }

        public override bool SetProperty(int i_PropertyIndex, string i_ProperyValue, Garage i_garage)
        {
            bool success = false;

            if (i_PropertyIndex <= 9)
            {
                success = base.SetProperty(i_PropertyIndex, i_ProperyValue, i_garage);
            }

            else if (i_PropertyIndex == 10) // set color of car
            {
                try
                {
                    m_CarColor = (GarageEnums.eCarColors)Enum.Parse(typeof(GarageEnums.eCarColors), i_ProperyValue);
                    success = true;
                }
                catch
                {
                }
            }

            else if (i_PropertyIndex == 11) // set number of doors
            {
                bool IsNumberOfCarDoors = int.TryParse(i_ProperyValue, out int numberOfCarDoors);

                if (IsNumberOfCarDoors)
                {
                    foreach (int carDoors in Enum.GetValues(typeof(GarageEnums.eCarDoors)))
                    {
                        if(carDoors == numberOfCarDoors)
                        {
                            try
                            {
                                m_CarDoors = (GarageEnums.eCarDoors)Enum.Parse(typeof(GarageEnums.eCarDoors), i_ProperyValue);
                                success = true;
                            }

                            catch (Exception e)
                            {
                                throw e;
                            }
                        }
                    }
                }
            }
            return success;
        }

        public override string ToString()
        {
            return GarageStringMessages.CarToString(this);
        }
    }
}
