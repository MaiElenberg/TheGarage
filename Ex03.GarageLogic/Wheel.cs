using System;
using System.Text;

namespace GarageLogicWheel
{
    public class Wheel
    {
        private readonly string r_Manufacturer;
        private float m_CurrentPressure;
        private readonly float r_MaxPressure;

        public Wheel(string i_Manufacturer, float i_CurrentPressure, float i_MaxPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentPressure = i_CurrentPressure;
            r_MaxPressure = i_MaxPressure;
            if(m_CurrentPressure > r_MaxPressure)
            {
                throw new ArgumentException("Current air pressure is too big. The maximum number is : {0}", r_MaxPressure.ToString());
            }
        }

        public void Inflate(float i_AddAir)
        {
            if (m_CurrentPressure + i_AddAir > r_MaxPressure || i_AddAir < 0)
            {
                throw new GarageLogicException.ValueOutOfRangeException(0, r_MaxPressure - m_CurrentPressure);
            }
            else
            {
                m_CurrentPressure += i_AddAir;
            }
        }

        internal string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }
        }

        internal float CurrentPressure
        {
            get
            {
                return m_CurrentPressure;
            }
        }

        internal float MaxPressure
        {
            get
            {
                return r_MaxPressure;
            }
        }

        public override string ToString()
        {
            string wheelInfo = string.Format(
                @"Wheel's manufacturer = {0}
Current pressure of the wheel = {1}" , r_Manufacturer, m_CurrentPressure);

            wheelInfo.Remove(wheelInfo.Length - 1);

            return wheelInfo;
        }
    }
}
