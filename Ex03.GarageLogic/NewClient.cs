using System;
using System.Collections.Generic;

namespace GarageLogicClient
{
    public class NewClient
    {
        public enum eVehicleType
        {
            Car = 1,
            Motorbike = 2,
            Truck = 3
        }

        public static Dictionary<string, string> InitialVehicle()
        {
            return getVehicleFields();
        }

        public static Dictionary<string, string> SetProperties(Dictionary<string, string> i_NewVehicle)
        {
            switch (i_NewVehicle["Energy Type"])
            {
                case ("ElectricBased"):
                    i_NewVehicle = getElectricFields(i_NewVehicle);
                    break;
                case ("FuelBased"):
                    i_NewVehicle = getFuelFields(i_NewVehicle);
                    break;
            }

            switch (i_NewVehicle["Vehicle Type"])
            {
                case ("Motorbike"):
                    i_NewVehicle = addMotorbikeFields(i_NewVehicle);
                    break;
                case ("Car"):
                    i_NewVehicle = addCarFields(i_NewVehicle);
                    break;
                case ("Truck"):
                    i_NewVehicle = addTruckFields(i_NewVehicle);
                    break;
            }
            return i_NewVehicle;
        }

        public static GarageLogicVehicle.Vehicle CreateVehicle(Dictionary<string, string> i_VehicleDict)
        {
            GarageLogicVehicle.Vehicle vehicle = null;

            switch (i_VehicleDict["Vehicle Type"])
            {
                case ("Motorbike"):
                    i_VehicleDict.Add("Number Of Wheels", "2");
                    i_VehicleDict.Add("Maximum Air Pressure Wheel", "33");

                    if(i_VehicleDict["Energy Type"] == "ElectricBased")
                    {
                        i_VehicleDict.Add("Maximum Battery Capcity", "1.4");
                    }
                    else
                    {
                        i_VehicleDict.Add("Maximum Fuel Capcity", "8");
                        i_VehicleDict.Add("Fuel Type", "Octan95");
                    }
                    vehicle = new GarageLogicVehicle.Motorbike(i_VehicleDict);
                    break;
                case ("Car"):
                    i_VehicleDict.Add("Number Of Wheels", "4");
                    i_VehicleDict.Add("Maximum Air Pressure Wheel", "31");
                    if (i_VehicleDict["Energy Type"] == "ElectricBased")
                    {
                        i_VehicleDict.Add("Maximum Battery Capcity", "1.8");
                    }
                    else
                    {
                        i_VehicleDict.Add("Maximum Fuel Capcity", "55");
                        i_VehicleDict.Add("Fuel Type", "Octan96");
                    }
                    vehicle = new GarageLogicVehicle.Car(i_VehicleDict);
                    break;
                case ("Truck"):
                    i_VehicleDict.Add("Number Of Wheels", "12");
                    i_VehicleDict.Add("Maximum Air Pressure Wheel", "26");
                    i_VehicleDict.Add("Maximum Fuel Capcity", "110");
                    i_VehicleDict.Add("Fuel Type", "Soler");
                    vehicle = new GarageLogicVehicle.Truck(i_VehicleDict);
                    break;
            }

            return vehicle;
        }

        private static Dictionary<string, string> getVehicleFields()
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("Owner Name", null);
            fields.Add("Owner Number", null);
            fields.Add("Vehicle Type", null);
            fields.Add("Energy Type", null);
            fields.Add("Model Type", null);
            fields.Add("License Number", null);
            fields.Add("Manufacturer Wheel", null);
            fields.Add("Air Pressure Wheel", null);

            return fields;
        }

        private static Dictionary<string, string> getElectricFields(Dictionary<string, string> i_VehicleDict) 
        {
            i_VehicleDict.Add("Current Battery Level", null);

            return i_VehicleDict;
        }

        private static Dictionary<string, string> getFuelFields(Dictionary<string, string> i_VehicleDict)
        {
            i_VehicleDict.Add("Current Fuel Level", null);

            return i_VehicleDict;
        }

        private static Dictionary<string, string> addMotorbikeFields(Dictionary<string, string> i_VehicleDict)
        {
            i_VehicleDict.Add("License Type", null);
            i_VehicleDict.Add("Engine Capacity", null);

            return i_VehicleDict;
        }

        private static Dictionary<string, string> addCarFields(Dictionary<string, string> i_VehicleDict)
        {
            i_VehicleDict.Add("Car Color", null);
            i_VehicleDict.Add("Number Of Doors", null);

            return i_VehicleDict;
        }

        private static Dictionary<string, string> addTruckFields(Dictionary<string, string> i_VehicleDict)
        {
            i_VehicleDict.Add("Dangerous", null);
            i_VehicleDict.Add("Cargo Capacity", null);

            return i_VehicleDict;
        }

        public static float MaxAirPressure(string i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case "Motorbike":
                    return 33;

                case "Car":
                    return 31;

                case "Truck":
                    return 26;
            }
            return 0;
        }

        public static float MaxBatteryPressure(string i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case "Motorbike":
                    return 1.4f;

                case "Car":
                    return 1.8f;
            }
            return 0;
        }

        public static float MaxFuelLevel(string i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case "Motorbike":
                    return 8;

                case "Car":
                    return 55;

                case "Truck":
                    return 110;
            }
            return 0;
        }

    }
}
