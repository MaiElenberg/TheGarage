using System;
using System.Collections.Generic;


namespace GarageLogicEnergy
{
    public class Energy
    {

        protected float m_CurrentAmount;
        protected readonly float r_MaxAmount;
        protected float m_EnergyPercent;

        internal Energy(Dictionary<string, string> i_EnergyState, GarageLogicVehicle.Vehicle.eEnergyType i_EnergyType)
        {
            if (i_EnergyType == GarageLogicVehicle.Vehicle.eEnergyType.ElectricBased)
            {
                m_CurrentAmount = float.Parse(i_EnergyState["Current Battery Level"]);
                r_MaxAmount = float.Parse(i_EnergyState["Maximum Battery Capcity"]);
            }
            else
            {
                m_CurrentAmount = float.Parse(i_EnergyState["Current Fuel Level"]);
                r_MaxAmount = float.Parse(i_EnergyState["Maximum Fuel Capcity"]);
            }
            m_EnergyPercent = (m_CurrentAmount / r_MaxAmount) * 100;
        }

        internal void EnergyFilling(float i_AddEnergy)
        {
            if (m_CurrentAmount + i_AddEnergy > r_MaxAmount || i_AddEnergy < 0)
            {
                throw new GarageLogicException.ValueOutOfRangeException(0, r_MaxAmount - m_CurrentAmount);
            }
            else
            {
                m_CurrentAmount += i_AddEnergy;
            }
        }

        internal void EnergyFilling(float i_AddEnergy, FuelVehicle.eFuelType i_AccualType, FuelVehicle.eFuelType i_UserType)
        {
            if (i_UserType != i_AccualType)
            {
                throw new ArgumentException("Wrong fuel type. Please select {0}", i_UserType.ToString());
            }
            EnergyFilling(i_AddEnergy);
        }

        internal float CurrentAmount
        {
            get
            {
                return m_CurrentAmount;
            }
            set
            {
                m_CurrentAmount = value;
            }
        }

        internal float MaxAmount
        {
            get
            {
                return r_MaxAmount;
            }
        }

        public float EnergyPercent
        {
            get
            {
                return m_EnergyPercent;
            }
        }

        public override string ToString()
        {
            string energyInfo = string.Format(
                @"Energy Percent = {0}
Current amount of energy = {1}", m_EnergyPercent, m_CurrentAmount);

            return energyInfo;
        }
    }
}
