using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_HasCooledProducts;
        private float m_MaxLoad;

        //    public Truck(string i_Model, string i_LisenceNumber, float i_EnergyLevelPercentage, List<Wheel> i_Wheels, Engine i_Engine, bool i_HasCooledProducts, float i_MaxLoad)
        //      : base(i_Model, i_LisenceNumber, i_EnergyLevelPercentage, i_Wheels, i_Engine)
        //    {
        //        this.m_HasCooledProducts = i_HasCooledProducts;
        //        this.r_MaxLoad = i_MaxLoad;
        //    }

        public Truck()
        {
            this.Questions.Add("Is the truck moving cool foods (true/false): ");
            this.Questions.Add("What is the max Load (int): ");
        }

        internal bool HasCooledProducts
        {
            get
            {
                return m_HasCooledProducts;
            }
            set
            {
                m_HasCooledProducts = value;
            }
        }

        internal float MaxLoad
        {
            get
            {
                return m_MaxLoad;
            }
            set
            {
                m_MaxLoad = value;
            }
        }

        public override bool SetProperty(int i_PropertyIndex, string i_ProperyValue, Garage i_garage)
        {
            bool success = false;

            if (i_PropertyIndex <= 9)
            {
                success = base.SetProperty(i_PropertyIndex, i_ProperyValue, i_garage);
            }
            else if (i_PropertyIndex == 10) // is moving cool foods
            {
                bool propertyValueBool;

                if (!bool.TryParse(i_ProperyValue, out propertyValueBool))
                {
                    throw new FormatException();
                }

                m_HasCooledProducts = propertyValueBool;
                success = true;
            }
            else if (i_PropertyIndex == 11) // set max load
            {
                float propertyValueFloat;

                if (!float.TryParse(i_ProperyValue, out propertyValueFloat))
                {
                    throw new FormatException();
                }

                m_MaxLoad = propertyValueFloat;
                success = true;
            }

            return success;
        }

        public override string ToString()
        {
            return GarageStringMessages.TruckToString(this);
        }
    }
}

