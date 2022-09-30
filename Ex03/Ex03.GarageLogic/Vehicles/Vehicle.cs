using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LisenceNumber;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;
        protected List<string> m_Questions = new List<string>
            {
                "What model is the vehicle (string): ",
                "What is the vehicle's lisence number (string, 7/8 chars): ",
                "How many wheels does the vehicle have (int): ",
                "What is the wheels manufacturer (string): ",
                "What is the wheels tire pressure (int): ",
                "What is the wheels max tire pressure (int, higher than current pressure): ",
                "What is the vehicle's engine type [Petrol/Electric]: ",
                "What type of fuel does the vehicle have (If the vehicle is electric just press ENTER)? [Soler/Octan95/Octan96/Octan98]: ",
                "What is the vehicle's *current* amount of liters/battery-hours (int): ",
                "What is the vehicle's *maximum* amount of liters/battery-hours (int): "
            };

        //protected Vehicle(string i_Model, string i_LisenceNumber, List<Wheel> i_Wheels, Engine i_Engine)
        //{
        //    this.m_Model = i_Model;
        //    this.m_LisenceNumber = i_LisenceNumber;
        //    this.m_Wheels = i_Wheels;
        //    this.m_Engine = i_Engine;
        //}

        protected Vehicle()
        {
            this.m_Wheels = new List<Wheel>();
            //this.m_Engine = new Engine();
        }

        internal string Model
        {
            get
            {
                return m_Model;
            }
            set
            {
                m_Model = value;
            }
        }

        public string LisenceNumber
        {
            get
            {
                return m_LisenceNumber;
            }
            internal set
            {
                m_LisenceNumber = value;
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
            }
        }

        internal Engine Engine
        {
            get
            {
                return this.m_Engine;
            }
            set
            {
                this.m_Engine = value;
            }
        }

        public List<string> Questions
        {
            get
            {
                return m_Questions;
            }
        }

        public virtual bool SetProperty(int i_PropertyIndex, string i_ProperyValue, Garage i_garage)
        {
            bool successful = false;

            if (i_PropertyIndex == 0) // model of vehicle
            {
                m_Model = i_ProperyValue;
                successful = true;
            }
            else if (i_PropertyIndex == 1)  // Lisence Number Of Vehicle
            {
                if (!((i_ProperyValue.Length == 8 || i_ProperyValue.Length == 7) && i_ProperyValue.All(char.IsDigit)))
                {
                    successful = false;
                }
                else
                {
                    if (i_garage.IsVehicleIsInTheGarage(i_ProperyValue))
                    {
                        successful = false;
                    }
                    else
                    {
                        m_LisenceNumber = i_ProperyValue;
                        successful = true;
                    }
                }
            }
            else if (i_PropertyIndex == 2) // number of wheels
            {
                int propertyValueInt;

                if (!int.TryParse(i_ProperyValue, out propertyValueInt))
                {
                    throw new FormatException();
                }

                if (propertyValueInt >= 0)
                {
                    for (int i = 0; i < propertyValueInt; i++)
                    {
                        m_Wheels.Add(new Wheel());
                    }

                    successful = true;
                }
            }
            else if (i_PropertyIndex == 3) // wheels manufacturer
            {
                for (int i = 0; i < m_Wheels.Count; i++)
                {
                    m_Wheels[i].Manufacturer = i_ProperyValue;
                }

                successful = true;
            }
            else if (i_PropertyIndex == 4) // set tire pressure
            {
                int propertyValueInt;

                if (!int.TryParse(i_ProperyValue, out propertyValueInt))
                {
                    throw new FormatException();
                }

                if (propertyValueInt < 0)
                {
                    throw new ValueOutOfRangeException(0, Int32.MaxValue);
                }

                for (int i = 0; i < m_Wheels.Count; i++)
                {
                    m_Wheels[i].TirePressure = propertyValueInt;
                }

                successful = true;
            }
            else if (i_PropertyIndex == 5) // Wheels max pressure
            {
                int propertyValueInt;

                if (!int.TryParse(i_ProperyValue, out propertyValueInt))
                {
                    successful = false;
                    throw new FormatException();
                }

                if (propertyValueInt < m_Wheels[0].TirePressure)
                {
                    successful = false;
                    throw new ValueOutOfRangeException(propertyValueInt, Int32.MaxValue);
                }

                for (int i = 0; i < m_Wheels.Count; i++)
                {
                    m_Wheels[i].MaxPressure = propertyValueInt;
                }

                successful = true;
            }
            else if (i_PropertyIndex == 6) // engine type
            {
                if (i_ProperyValue == "Petrol")
                {
                    this.m_Engine = new PetrolEngine();
                    this.Engine.EngineType = GarageEnums.eEngineType.Petrol;
                    successful = true;
                }
                else if (i_ProperyValue == "Electric")
                {
                    m_Engine = new ElectricEngine();
                    this.Engine.EngineType = GarageEnums.eEngineType.Electric;
                    successful = true;
                }
                else
                {
                    successful = false;
                }
            }
            else if (i_PropertyIndex == 7) // fuel type for petrol engines
            {
                try
                {
                    if (this.Engine.EngineType == GarageEnums.eEngineType.Petrol)
                    {
                        ((PetrolEngine)this.Engine).PetrolType = (GarageEnums.ePetrolType)Enum.Parse(typeof(GarageEnums.ePetrolType), i_ProperyValue);
                        successful = true;
                    }
                    else if (this.Engine.EngineType == GarageEnums.eEngineType.Electric && i_ProperyValue == "")
                    {
                        successful = true;
                    }
                    else
                    {
                        successful = false;
                    }
                }
                catch (Exception)
                {
                    successful = false;
                }

            }
            else if (i_PropertyIndex == 8) // energy percentage level
            {
                int propertyValueInt;

                if (!int.TryParse(i_ProperyValue, out propertyValueInt))
                {
                    throw new FormatException();
                }

                if (propertyValueInt < 0)
                {
                    throw new ValueOutOfRangeException(propertyValueInt, Int32.MaxValue);
                }

                m_Engine.CurrentEnergyLevel = propertyValueInt;
                successful = true;
            }
            else if (i_PropertyIndex == 9) // max energy level
            {
                int propertyValueInt;

                if (!int.TryParse(i_ProperyValue, out propertyValueInt))
                {
                    throw new FormatException();
                }

                if (propertyValueInt < m_Engine.CurrentEnergyLevel)
                {
                    throw new ValueOutOfRangeException(propertyValueInt, Int32.MaxValue);
                }

                m_Engine.MaximumEnergyLevel = propertyValueInt;


                successful = true;
            }

            return successful;
        }

        public abstract override string ToString();
    }
}
