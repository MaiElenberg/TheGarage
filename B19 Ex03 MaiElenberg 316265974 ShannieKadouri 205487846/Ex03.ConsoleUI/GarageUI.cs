using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class GarageUI
    {
        public GarageLogicClient.Garage m_Garage = new GarageLogicClient.Garage();

        public void GarageManager()
        {

            bool openGarage = true;
            while (openGarage)
            {
                Console.Clear();
                
String welcomingMag = String.Format(
                    @"Hello! Welcome to the Amazing Garage

To Add a new vehicle to the garage please press 1
To get information about the vehicles in the garage please press 2
To make changes to an existing vehicle please press 3
If you want to exit the system please press 4");

                System.Console.WriteLine(welcomingMag);
                string welcomeInput = System.Console.ReadLine();

                int welcomingInt = ValidateUI.ValidateInt(welcomeInput, 1, 4);

                switch (welcomingInt)
                {
                    case 1:
                        createVehicle();
                        break;
                    case 2:
                        information();
                        break;
                    case 3:
                        makeChange();
                        break;
                    case 4:
                        openGarage = false;
                        Console.Clear();
                        System.Console.WriteLine("Thank you! Have a nice day (press enter to exit)");
                        System.Console.ReadLine();
                        break;
                }
            }
        }

        private void createVehicle()
        {
            Console.Clear();
            Dictionary<string, string> vehicleDict = GarageLogicClient.NewClient.InitialVehicle();
            List<string> vehicleFields = new List<string>(vehicleDict.Keys);

            for(int i = 0; i < vehicleFields.Count; i++) 
            {
                Console.Clear();
                string currentOutput = vehicleFields[i];
                System.Console.WriteLine("Please select " + currentOutput);

                switch (currentOutput)
                {
                    case "Owner Number":
                        vehicleDict["Owner Number"] = ValidateUI.ValidatePhoneNumber(System.Console.ReadLine());
                        break;

                    case "Vehicle Type":
                        StringBuilder vehicleType = new StringBuilder();
                        int j = 1;
                        foreach (string type in Enum.GetNames(typeof(GarageLogicClient.NewClient.eVehicleType)))
                        {
                            vehicleType.AppendFormat("For {0} please press {1}\n", type.ToString(), j);
                            j++;
                        }
                        vehicleType.Length -= 1;
                        System.Console.WriteLine(vehicleType.ToString());
                        GarageLogicClient.NewClient.eVehicleType tempVehicle = (GarageLogicClient.NewClient.eVehicleType)
                            ValidateUI.ValidateInt(System.Console.ReadLine(), 1, Enum.GetNames(typeof(GarageLogicClient.NewClient.eVehicleType)).Length);
                        vehicleDict["Vehicle Type"] = tempVehicle.ToString();
                        if (vehicleDict["Vehicle Type"].Equals("Truck"))
                        {
                            vehicleDict["Energy Type"] = "FuelBased";
                            vehicleFields.Remove("Energy Type");
                        }
                        break;

                    case "License Number":
                        string licenseNumber = System.Console.ReadLine();
                        if (m_Garage.Exists(licenseNumber))
                        {
                            System.Console.WriteLine("Vehicle already in system. Changing condition to process");
                            m_Garage.GetVehicle(licenseNumber).Condition = GarageLogicVehicle.Vehicle.eCondition.Processing;
                            System.Console.WriteLine("Press any key to continue");
                            System.Console.ReadLine();
                            return;
                        }
                        vehicleDict["License Number"] = licenseNumber;
                        break;

                    case "Energy Type":
                        StringBuilder energyType = new StringBuilder();
                        i = 1;
                        foreach (string type in Enum.GetNames(typeof(GarageLogicVehicle.Vehicle.eEnergyType)))
                        {
                            energyType.AppendFormat("For {0} please press {1}\n", type.ToString(), i);
                            i++;
                        }
                        energyType.Length -= 1;
                        System.Console.WriteLine(energyType.ToString());
                        GarageLogicVehicle.Vehicle.eEnergyType tempEnergy = (GarageLogicVehicle.Vehicle.eEnergyType)
                            ValidateUI.ValidateInt(System.Console.ReadLine(), 1, Enum.GetNames(typeof(GarageLogicVehicle.Vehicle.eEnergyType)).Length);
                        vehicleDict["Energy Type"] = tempEnergy.ToString();
                        break;

                    case "Air Pressure Wheel":
                        vehicleDict["Air Pressure Wheel"] = (ValidateUI.ValidateFloat(System.Console.ReadLine(),
                            0, GarageLogicClient.NewClient.MaxAirPressure(vehicleDict["Vehicle Type"]))).ToString();
                        break;

                    default:
                        vehicleDict[currentOutput] = ValidateUI.ValidateString(System.Console.ReadLine());
                        break;
                }
            }

            int indexForNewDict = vehicleDict.Count;
            Dictionary<string, string> vehicleProperties = GarageLogicClient.NewClient.SetProperties(vehicleDict);
            List<string> fields = new List<string>(vehicleProperties.Keys);
           
            for (int i = 0; i < indexForNewDict; i++)
            {
                fields.RemoveAt(0);
            }
            foreach (string currentOutput in fields)
            {
                Console.Clear();
                System.Console.WriteLine(currentOutput);

                switch (currentOutput)
                {
                    case "Current Battery Level":
                        vehicleDict["Current Battery Level"] = (ValidateUI.ValidateFloat(System.Console.ReadLine(),
                            0, GarageLogicClient.NewClient.MaxBatteryPressure(vehicleProperties["Vehicle Type"]))).ToString();
                        break;

                    case "Current Fuel Level":
                        vehicleDict["Current Fuel Level"] = (ValidateUI.ValidateFloat(System.Console.ReadLine(),
                            0, GarageLogicClient.NewClient.MaxFuelLevel(vehicleProperties["Vehicle Type"]))).ToString();
                        break;

                    case "Cargo Capacity":
                        vehicleDict["Cargo Capacity"] = ValidateUI.ValidateFloat(System.Console.ReadLine());
                        break;

                    case "License Type":
                        StringBuilder licenseType = new StringBuilder();
                        int i = 1;
                        foreach (string type in Enum.GetNames(typeof(GarageLogicVehicle.Motorbike.eLicenseType)))
                        {
                            licenseType.AppendFormat("For {0} please press {1}\n", type.ToString(), i);
                            i++;
                        }
                        licenseType.Length -= 1;
                        System.Console.WriteLine(licenseType.ToString());
                        vehicleDict["License Type"] = ValidateUI.ValidateInt(System.Console.ReadLine(),
                            1, Enum.GetNames(typeof(GarageLogicVehicle.Motorbike.eLicenseType)).Length).ToString();
                        break;

                    case "Engine Capacity":
                        vehicleDict["Engine Capacity"] = ValidateUI.ValidateInt(System.Console.ReadLine());
                        break;

                    case "Car Color":
                        StringBuilder color = new StringBuilder();
                        i = 1;
                        foreach (string type in Enum.GetNames(typeof(GarageLogicVehicle.Car.eColor)))
                        {
                            color.AppendFormat("For {0} please press {1}\n", type.ToString(), i);
                            i++;
                        }
                        color.Length -= 1;
                        System.Console.WriteLine(color.ToString());
                        vehicleDict["Car Color"] = ValidateUI.ValidateInt(System.Console.ReadLine(),
                            1, Enum.GetNames(typeof(GarageLogicVehicle.Car.eColor)).Length).ToString();
                        break;

                    case "Number Of Doors":
                        StringBuilder numDoors = new StringBuilder();
                        i = 2;
                        foreach (string type in Enum.GetNames(typeof(GarageLogicVehicle.Car.eNumDoors)))
                        {
                            numDoors.AppendFormat("For {0} please press {1}\n", type.ToString(), i);
                            i++;
                        }
                        numDoors.Length -= 1;
                        System.Console.WriteLine(numDoors.ToString());
                        vehicleDict["Number of Doors"] = ValidateUI.ValidateInt(System.Console.ReadLine(),
                            2, Enum.GetNames(typeof(GarageLogicVehicle.Car.eNumDoors)).Length + 1).ToString();
                        break;

                    case "Dangerous":
                        System.Console.WriteLine("If the truck has dangerous metarials please press 1\n" +
                        "else press 2");

                        int true_false = ValidateUI.ValidateInt(System.Console.ReadLine(), 1, 2);
                        switch(true_false)
                        {
                            case 1:
                                vehicleDict["Dangerous"] = "true";
                                break;
                            case 2:
                                vehicleDict["Dangerous"] = "false";
                                break;
                        }
                        break;
                }
            }
            GarageLogicVehicle.Vehicle vehicle = GarageLogicClient.NewClient.CreateVehicle(vehicleDict);
            m_Garage.AddVehicle(vehicle);

            Console.Clear();
            System.Console.WriteLine("The vehicle has been added to the garage!\n" +
                "Press ant key to continue");
            System.Console.ReadLine();
        }

        private void information()
        {
            Console.Clear();
            if (m_Garage.GarageVehicels.Count == 0)
            {
                System.Console.WriteLine("There are no vehicles in the garage. Go back to main menu \n Press any key to continue");
                System.Console.ReadLine();
                return;
            }

            System.Console.WriteLine("If you would like to get information about the entire garate please press 1\n" +
                "If you would like to get information about a specific vehicle please press 2");

            int typeInformation = ValidateUI.ValidateInt(System.Console.ReadLine(), 1, 2); ;
            switch (typeInformation)
            {
                case 1:
                    garagelInformation();
                    break;

                case 2:
                    vehicleInformation();
                    break;
            }
            System.Console.WriteLine("Press any key to continue");
            System.Console.ReadLine();
        }

        private void vehicleInformation()
        {
            System.Console.WriteLine("Please insert the license number of the vehicle you would like to see\n" +
                "Or press 'Q' to return to main menu");
            string licenseNumber = System.Console.ReadLine();
            while (!licenseNumber.Equals("Q") && !m_Garage.Exists(licenseNumber))
            {
                System.Console.WriteLine("Vehicle not found! please try again");
                licenseNumber = System.Console.ReadLine();
            }
            Console.Clear();
            GarageLogicVehicle.Vehicle vehicle = m_Garage.GetVehicle(licenseNumber);
            string currentVehicles = m_Garage.GetVehicleFullInformation(licenseNumber);
            if(currentVehicles.Length == 0)
            {
                System.Console.WriteLine("There are no such vehicles in the garage. Go back to main menu");
                return;
            }
            System.Console.WriteLine(currentVehicles);
        }


        private void garagelInformation()
        {
            Console.Clear();
            string informationMag = string.Format(
               @"Which vehicles would you like to see?
All - press 1
Proccesing - press 2
Paid - press 3
Fixed - press 4");

            System.Console.WriteLine(informationMag);
            int usersWish = ValidateUI.ValidateInt(System.Console.ReadLine(), 1, 4);

            Console.Clear();
            string currentVehicles = "";
            switch (usersWish)
            {
                case 1:
                    currentVehicles = m_Garage.GetAllVehicles();
                    break;

                case 2:
                    currentVehicles = m_Garage.GetVehiclesByCondition(2);
                    break;

                case 3:
                    currentVehicles = m_Garage.GetVehiclesByCondition(3);
                    break;

                case 4:
                    currentVehicles = m_Garage.GetVehiclesByCondition(4);
                    break;
            }
            if (currentVehicles.Length == 0)
            {
                System.Console.WriteLine("There are no such vehicles in the garage. Go back to main menu");
                return;
            }
            System.Console.WriteLine(currentVehicles);
        }

        private void makeChange()
        {
            Console.Clear();
            if (m_Garage.GarageVehicels.Count == 0)
            {
                System.Console.WriteLine("There are no vehicles in the garage. Go back to main menu \n Press any key to continue");
                System.Console.ReadLine();
                return;
            }

            System.Console.WriteLine("Please enter license number");

            string licenseNumber = System.Console.ReadLine();
            while (!m_Garage.Exists(licenseNumber))
            {
                System.Console.WriteLine("License number not found. Please try again");
                licenseNumber = System.Console.ReadLine();
            }

            Console.Clear();
            string functionMag = string.Format(
                @"To change vehicle's status please press 1
To inflate air in the wheels please press 2
To fill the vehicle's fuel tank please press 3 (fuel type)
To charge the battery of the vehicles please press 4 (electric type)");

            System.Console.WriteLine(functionMag);
            int functionNumber = ValidateUI.ValidateInt(System.Console.ReadLine(), 1, 4);

            switch (functionNumber)
            {
                case 1:
                    changeStatus(licenseNumber);
                    break;

                case 2:
                    inflateAir(licenseNumber);
                    break;

                case 3:
                    fillFuelTank(licenseNumber);
                    break;

                case 4:
                    chargeBattery(licenseNumber);
                    break;
            }
        }

        private void changeStatus(string i_LicenseNumber)
        {
            Console.Clear();
            StringBuilder status = new StringBuilder();
            int i = 1;
            foreach (string condition in Enum.GetNames(typeof(GarageLogicVehicle.Vehicle.eCondition)))
            {
                status.Append("Change to " + condition + " please press " + i + "\n");
                i++;
            }
            status.Length -= 1;

            System.Console.WriteLine(status);
            int statusNumber = ValidateUI.ValidateInt(System.Console.ReadLine(),
                1, Enum.GetNames(typeof(GarageLogicVehicle.Vehicle.eCondition)).Length);

            Console.Clear();
            m_Garage.ChangeStatus(i_LicenseNumber, statusNumber);
            System.Console.WriteLine("Status changed succesfully \nPlease type any key to cotinue");
            System.Console.ReadLine();
        }

        private void inflateAir(string i_LicenseNumber)
        {
            Console.Clear();

            System.Console.WriteLine("Please write the amount of air you would like to fill");

            string air = System.Console.ReadLine();
            float airNumber;
            bool success = false;
            while(!success)
            {
                try
                {
                    airNumber = float.Parse(ValidateUI.ValidateFloat(air));
                    m_Garage.InflateAir(i_LicenseNumber, airNumber);
                    System.Console.WriteLine("Air inflated successfully \nPress any key to continue");
                    System.Console.ReadLine();
                    success = true;
                }
                catch(GarageLogicException.ValueOutOfRangeException error)
                {
                    if (error.MaxValue == error.MinValue)
                    {
                        System.Console.WriteLine("The wheel is full. No need to add \nPress any key to go back to main menu");
                        System.Console.ReadLine();
                        return;
                    }
                    System.Console.WriteLine(error.Message + ". Please try again");
                    air = System.Console.ReadLine();
                    continue;
                }
            }
        }

        private void fillFuelTank(string i_LicenseNumber)
        {
            Console.Clear();
            if(m_Garage.GetVehicle(i_LicenseNumber).EnergyType != GarageLogicVehicle.Vehicle.eEnergyType.FuelBased)
            {
                System.Console.WriteLine("The vehicle is electric. Go back to main menu");
                return;
            }

            System.Console.WriteLine("Please select fuel type");
            StringBuilder fuelTypes = new StringBuilder();
            int i = 1;
            foreach (string type in Enum.GetNames(typeof(GarageLogicEnergy.FuelVehicle.eFuelType)))
            {
                fuelTypes.AppendFormat("For {0} please press {1}\n", type.ToString(), i);
                i++;
            }

            System.Console.WriteLine(fuelTypes.ToString());

            int acctualFuelNumber = (int)((m_Garage.GetVehicle(i_LicenseNumber).EnergyPercent as GarageLogicEnergy.FuelVehicle).FuelType);
            int fuelType = ValidateUI.ValidateFuelType(System.Console.ReadLine(), acctualFuelNumber);

            string userInput;
            bool success = false;
            System.Console.WriteLine("Please write the amount of fuel you would like to fill");

            while (!success)
            {
                try
                {
                    userInput = System.Console.ReadLine();
                    float addFuel = float.Parse(ValidateUI.ValidateFloat(userInput));
                    m_Garage.FillFuel(i_LicenseNumber, addFuel,
                        (GarageLogicEnergy.FuelVehicle.eFuelType)fuelType);
                    System.Console.WriteLine("Fuel tank filled successfully \nPress any key to continue");
                    System.Console.ReadLine();
                    success = true;
                }
                catch (GarageLogicException.ValueOutOfRangeException error)
                {
                    if(error.MaxValue == error.MinValue)
                    {
                        System.Console.WriteLine("The tank is full. No need to add \nPress any key to go back to main menu");
                        System.Console.ReadLine();
                        return;
                    }
                    System.Console.WriteLine(error.Message + ". Please try again");
                    continue;
                }
                catch(FormatException error)
                {
                    System.Console.WriteLine("Invalid input. Please try again");
                }
            }
        }

        private void chargeBattery(string i_LicenseNumber)
        {
            Console.Clear();
            if (m_Garage.GetVehicle(i_LicenseNumber).EnergyType != GarageLogicVehicle.Vehicle.eEnergyType.ElectricBased)
            {
                System.Console.WriteLine("The vehicle is fuel based. Go back to main menu");
                return;
            }

            System.Console.WriteLine("Please write the amount of battery you would like to charge");

            string battery = System.Console.ReadLine();
            float batteryNumber;
            bool success = false;
            while (!success)
            {
                try
                {
                    batteryNumber = float.Parse(ValidateUI.ValidateFloat(battery));
                    m_Garage.FillBattery(i_LicenseNumber, batteryNumber);
                    System.Console.WriteLine("Battery charged successfully \nPress any key to continue");
                    System.Console.ReadLine();
                    success = true;
                }
                catch (GarageLogicException.ValueOutOfRangeException error)
                {
                    if (error.MaxValue == error.MinValue)
                    {
                        System.Console.WriteLine("The battery is full. No need to add \nPress any key to go back to main menu");
                        System.Console.ReadLine();
                        return;
                    }
                    System.Console.WriteLine(error.Message + ". Please try again");
                    battery = System.Console.ReadLine();
                    continue;
                }
            }
        }
    }
}
