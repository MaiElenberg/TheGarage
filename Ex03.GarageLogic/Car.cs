using System;
using System.Collections.Generic;

namespace GarageLogicVehicle
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Red = 1,
            Blue = 2,
            Black = 3,
            Grey = 4
        }

        public enum eNumDoors
        {
            Two = 2,
            Three = 3,
            Four = 4, 
            Five = 5
        } 
        private eColor m_Color;
        private int m_NumDoors;
        private GarageLogicEnergy.Energy m_Car;

        internal Car(Dictionary<string, string> i_CarProperties)
            :base(i_CarProperties)
        {
            m_Color = (eColor)Enum.Parse(typeof(eColor), i_CarProperties["Car Color"]);
            m_NumDoors = (int)(eNumDoors)Enum.Parse(typeof(eNumDoors), i_CarProperties["Number of Doors"]);

            if(base.m_EnergyType == eEnergyType.FuelBased)
            {
                m_Car = new GarageLogicEnergy.FuelVehicle(i_CarProperties);
            }
            else
            {
                m_Car = new GarageLogicEnergy.ElectricVehicle(i_CarProperties);
            }
        }

        internal eColor Color
        {
            get
            {
                return m_Color;
            }
        }

        internal int NumDoors
        {
            get
            {
                return m_NumDoors;
            }
        }

        public override string ToString()
        {
            string carInfo = string.Format(
                @"{0}
Color of the car = {1}
Number of doors = {2}", base.ToString(), m_Color.ToString(), m_NumDoors);

            return carInfo;
        }
    }
}
