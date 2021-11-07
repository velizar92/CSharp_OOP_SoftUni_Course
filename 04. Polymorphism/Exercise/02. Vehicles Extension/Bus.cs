using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        const double BUS_AIR_MODIFIER = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            :base(fuelQuantity, fuelConsumptionPerKm, tankCapacity, BUS_AIR_MODIFIER)
        {

        }

        public override string ToString()
        {
            return $"Bus: {this.Fuel:F2}";
        }

        public void TurnOffAirModifier()
        {
            this.AirModifier = 0;
        }


        public void TurnOnAirModifier()
        {
            this.AirModifier = 1.4;
        }

    }
}
