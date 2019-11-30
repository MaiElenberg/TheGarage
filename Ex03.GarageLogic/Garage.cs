using System.Collections.Generic;
using System.Text;

namespace GarageLogicClient
{
    public class Garage
    {
        private List<GarageLogicVehicle.Vehicle> m_GarageVehicels;

        public Garage()
        {
            m_GarageVehicels = new List<GarageLogicVehicle.Vehicle>();
        }

        public void AddVehicle(GarageLogicVehicle.Vehicle i_Vehicle)
        {
            m_GarageVehicels.Add(i_Vehicle);
        }

        public bool Exists(string i_LicenseNumber)
        {
            foreach (GarageLogicVehicle.Vehicle vehicle in m_GarageVehicels)
            {
                if ((vehicle.LicenseNumber).Equals(i_LicenseNumber)) {
                    return true;
                }
            }
            return false;
        }

        public GarageLogicVehicle.Vehicle GetVehicle(string i_LicenseNumber)
        {
            foreach (GarageLogicVehicle.Vehicle vehicle in m_GarageVehicels)
            {
                if ((vehicle.LicenseNumber).Equals(i_LicenseNumber)) {
                    return vehicle;
                }
            }
            return null;
        }

        public void ChangeStatus(string i_LicenseNumber, int i_Status)
        {
            GarageLogicVehicle.Vehicle vehicle = GetVehicle(i_LicenseNumber);
            vehicle.Condition = (GarageLogicVehicle.Vehicle.eCondition)i_Status;
        }

        public void InflateAir(string i_LicenseNumber, float i_Air)
        {
            GarageLogicVehicle.Vehicle vehicle = GetVehicle(i_LicenseNumber);
            foreach (GarageLogicWheel.Wheel wheel in vehicle.Wheels)
            {
                wheel.Inflate(i_Air);
            }
        }

        public void FillFuel(string i_LicenseNumber, float i_AddFuel, GarageLogicEnergy.FuelVehicle.eFuelType i_FuelType)
        {
            GarageLogicVehicle.Vehicle vehicle = GetVehicle(i_LicenseNumber);
            GarageLogicEnergy.FuelVehicle.eFuelType accualType = (vehicle.EnergyPercent as GarageLogicEnergy.FuelVehicle).FuelType;
            (vehicle.EnergyPercent as GarageLogicEnergy.FuelVehicle).EnergyFilling(i_AddFuel, i_FuelType, accualType);
        }

        public void FillBattery(string i_LicenseNumber, float i_Battery)
        {
            GetVehicle(i_LicenseNumber).EnergyFilling(i_Battery);
        }

        public string GetAllVehicles()
        {
            StringBuilder listOfLicense = new StringBuilder();
            
            foreach (GarageLogicVehicle.Vehicle vehicle in m_GarageVehicels)
            {
                listOfLicense.Append(vehicle.LicenseNumber + "\n");
            }
            return listOfLicense.ToString();
        }

        public string GetVehiclesByCondition(int i_Condition)
        {
            StringBuilder listOfLicense = new StringBuilder();

            foreach (GarageLogicVehicle.Vehicle vehicle in m_GarageVehicels)
            {
                if(vehicle.Condition == (GarageLogicVehicle.Vehicle.eCondition)i_Condition)
                {
                    listOfLicense.Append(vehicle.LicenseNumber + "\n");
                }
            }
            return listOfLicense.ToString();
        }

        public string GetVehicleFullInformation(string i_LicenseNumber)
        {

            GarageLogicVehicle.Vehicle vehicle = GetVehicle(i_LicenseNumber);
            string vehicleInfo = vehicle.ToString();
            
            return vehicleInfo;
        }

        public List<GarageLogicVehicle.Vehicle> GarageVehicels
        {
            get
            {
                return m_GarageVehicels;
            }
        }
    }
}
