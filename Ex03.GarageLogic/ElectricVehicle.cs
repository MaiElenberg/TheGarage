using System.Collections.Generic;

namespace GarageLogicEnergy 
{
    internal class ElectricVehicle : Energy
    {

        internal ElectricVehicle(Dictionary<string, string> i_ElectricProperties)
            : base(i_ElectricProperties, GarageLogicVehicle.Vehicle.eEnergyType.ElectricBased)
        {
        }
    }
}
