using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogicVehicle
{
    public class Vehicle
    {
        public enum eEnergyType
        {
            ElectricBased = 1,
            FuelBased = 2
        }

        public enum eCondition
        {
            Fixed = 1,
            Processing = 2,
            Paid = 3
        }

        protected readonly GarageLogicClient.NewClient.eVehicleType r_VehicleType;
        protected readonly string r_Model;
        protected readonly string r_LicenseNum;
        protected GarageLogicEnergy.Energy m_EnergyPercent;
        protected List<GarageLogicWheel.Wheel> m_Wheels;
        protected eEnergyType m_EnergyType;
        protected VehicleInfo m_OwnerInfo;
        protected eCondition m_Status;

        public Vehicle(Dictionary<string, string> i_VehicleProperties)
        {
            r_VehicleType = (GarageLogicClient.NewClient.eVehicleType)Enum.Parse
                (typeof(GarageLogicClient.NewClient.eVehicleType), i_VehicleProperties["Vehicle Type"]);
            r_Model = i_VehicleProperties["Model Type"];
            r_LicenseNum = i_VehicleProperties["License Number"];
            m_EnergyType = (eEnergyType)Enum.Parse(typeof(eEnergyType), i_VehicleProperties["Energy Type"]);
            if(m_EnergyType == eEnergyType.FuelBased)
            {
                m_EnergyPercent = new GarageLogicEnergy.FuelVehicle(i_VehicleProperties);
            }
            else
            {
                m_EnergyPercent = new GarageLogicEnergy.ElectricVehicle(i_VehicleProperties);
            }

            int numberOfWheels = int.Parse(i_VehicleProperties["Number Of Wheels"]);
            m_Wheels = new List<GarageLogicWheel.Wheel>();
            string manufacturer = i_VehicleProperties["Manufacturer Wheel"];
            float airPressure = float.Parse(i_VehicleProperties["Air Pressure Wheel"]);
            float airMax = float.Parse(i_VehicleProperties["Maximum Air Pressure Wheel"]);

            for (int i = 0; i < numberOfWheels; i++)
            {
                m_Wheels.Add(new GarageLogicWheel.Wheel(manufacturer, airPressure, airMax));
            }

            m_OwnerInfo = new VehicleInfo(i_VehicleProperties["Owner Name"], i_VehicleProperties["Owner Number"]);
            m_Status = eCondition.Processing;
        }

        public void EnergyFilling(float i_AddEnergy)
        {
            if(m_EnergyType == eEnergyType.ElectricBased)
            {
                m_EnergyPercent.EnergyFilling(i_AddEnergy);
            }
            else
            {
                throw new ArgumentException("Please select fuel type");
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNum;
            }
        }

        public eCondition Condition
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }

        public GarageLogicClient.NewClient.eVehicleType VehicleType
        {
            get
            {
                return r_VehicleType;
            }
        }

        public GarageLogicEnergy.Energy EnergyPercent
        {
            get
            {
                return m_EnergyPercent;
            }
        }

        public List<GarageLogicWheel.Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public eEnergyType EnergyType
        {
            get
            {
                return m_EnergyType;
            }
        }

        public VehicleInfo OwnerInfo
        {
            get
            {
                return m_OwnerInfo;
            }
        }

        public override string ToString()
        {
            StringBuilder wheelsIInformation = new StringBuilder();
            foreach(GarageLogicWheel.Wheel wheel in m_Wheels)
            {
                wheelsIInformation.Append(wheel.ToString() + "\n");
            }
            wheelsIInformation.Length -= 1;
            string vehicle = string.Format(
                @"{0}
Vechicle type = {1}
Model = {2}
License number = {3}
Vegicle's status = {4}
{5}
{6}"
, m_OwnerInfo.ToString(), r_VehicleType.ToString(), r_Model, r_LicenseNum, m_Status,
                m_EnergyPercent.ToString(), wheelsIInformation.ToString());

            return vehicle.ToString();
        }
    }
}
