using System;
using System.Collections.Generic;


namespace GarageLogicVehicle
{
    public class Motorbike : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }
        private int m_EngineCapacity;
        private eLicenseType m_LicenseType;
        private GarageLogicEnergy.Energy m_MotorBike;

        internal Motorbike(Dictionary<string, string> i_BikeProperties)
            :base(i_BikeProperties)
        {
            m_EngineCapacity = int.Parse(i_BikeProperties["Engine Capacity"]);
            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_BikeProperties["License Type"]);

            if (base.m_EnergyType == eEnergyType.FuelBased)
            {
                m_MotorBike = new GarageLogicEnergy.FuelVehicle(i_BikeProperties);
            }
            else
            {
                m_MotorBike = new GarageLogicEnergy.ElectricVehicle(i_BikeProperties);
            }
        }

        internal int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        internal eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public override string ToString()
        {
            string bikeInfo = string.Format(
                @"{0}
Engine capacity = {1}
License type = {2}", base.ToString(), m_EngineCapacity.ToString(), m_LicenseType.ToString());

            return bikeInfo;
        } 
    }
}
