using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        const double TRUCK_AIR_MODIFIER = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
            :base(fuelQuantity, fuelConsumptionPerKm, TRUCK_AIR_MODIFIER)
        {

        }
   

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);         
        }


        public override string ToString()
        {
            return $"Truck: {this.Fuel:F2}";
        }

    }
}
