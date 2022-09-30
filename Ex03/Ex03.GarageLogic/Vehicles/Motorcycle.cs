
using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private GarageEnums.eLicenseType m_LicenseType;
        private int m_EngineCC;

        //public Motorcycle(string i_Model, string i_LisenceNumber, float i_EnergyLevelPercentage, List<Wheel> i_Wheels, Engine i_Engine, GarageEnums.eLicenseType i_LisenceType, int i_EngineCC)
        //    : base(i_Model, i_LisenceNumber, i_EnergyLevelPercentage, i_Wheels, i_Engine)
        //{
        //    this.r_LicenseType = i_LisenceType;
        //    this.r_EngineCC = i_EngineCC;
        //}

        public Motorcycle()
        {
            this.Questions.Add("What is the Lisence Type [A/A1/B1/BB]: ");
            this.Questions.Add("What is the size of the engine in CC (int): ");
        }

        internal GarageEnums.eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        internal int EngineCC
        {
            get
            {
                return this.m_EngineCC;
            }
            set 
            {
                m_EngineCC = value; 
            }
        }

        public override bool SetProperty(int i_PropertyIndex, string i_ProperyValue, Garage i_garage)
        {
            bool success = false;

            if (i_PropertyIndex <= 9)
            {
                success = base.SetProperty(i_PropertyIndex, i_ProperyValue, i_garage);
            }
            else if (i_PropertyIndex == 10) // set license type
            {
                try
                {
                    m_LicenseType = (GarageEnums.eLicenseType)Enum.Parse(typeof(GarageEnums.eLicenseType), i_ProperyValue);
                    success = true;
                }
                catch
                {
                    success = false;
                }
            }
            else if (i_PropertyIndex == 11) // Engine CC
            {
                int propertyValueInt;

                if (!int.TryParse(i_ProperyValue, out propertyValueInt))
                {
                    throw new FormatException();
                }

                m_EngineCC = propertyValueInt;
                success = true;
            }

            return success;
        }

        public override string ToString()
        {
            return GarageStringMessages.MotorcycleToString(this);
        }
    }
}
