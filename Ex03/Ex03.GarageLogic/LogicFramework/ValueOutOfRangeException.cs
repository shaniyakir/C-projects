using System;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;
        private const string k_ExceptionMessage = "Inserted value is not between min value: {0}, and max value: {1}";

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format(k_ExceptionMessage, i_MinValue, i_MaxValue))
        {
            this.r_MinValue = i_MinValue;
            this.r_MaxValue = i_MaxValue;
        }

        public float MaxValue
        {
            get 
            { 
                return r_MaxValue; 
            }
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }
    }
}
