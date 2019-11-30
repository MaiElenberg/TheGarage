using System;
using System.Collections.Generic;

namespace GarageLogicEnergy
{
    public class FuelVehicle : Energy
    {
        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }
        protected readonly eFuelType r_FuelType;

        public FuelVehicle(Dictionary<string, string> i_FuelProperties)
            : base(i_FuelProperties, GarageLogicVehicle.Vehicle.eEnergyType.FuelBased)
        {
            r_FuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_FuelProperties["Fuel Type"]);
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public override string ToString()
        {
            string fuelInfo = string.Format(
                @"Fuel type = {0}
{1}", r_FuelType, base.ToString());

            return fuelInfo;
        }

    }
}
