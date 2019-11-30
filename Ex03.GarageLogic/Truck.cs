using System;
using System.Collections.Generic;

namespace GarageLogicVehicle
{
    internal class Truck : Vehicle
    {
        private bool m_Dangerous;
        private float m_CargoCapacity;

        internal Truck(Dictionary<string, string> i_TruckProperties)
            :base(i_TruckProperties)
        {
            m_Dangerous = bool.Parse(i_TruckProperties["Dangerous"]);
            m_CargoCapacity = float.Parse(i_TruckProperties["Cargo Capacity"]);
        }

        internal bool Dangerous
        {
            get
            {
                return m_Dangerous;
            }
        }

        internal float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }
        }

        public override string ToString()
        {
            string truckInfo = string.Format(
                @"{0}
Dangerous Materials = {1}
Cargo capacity = {2}", base.ToString(), m_Dangerous, m_CargoCapacity);

            return truckInfo;
        }

    }
}
