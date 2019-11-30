using System;

namespace GarageLogicException
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("Invalid values. The range is between {0} to {1}", i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }
        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }
    }


}
