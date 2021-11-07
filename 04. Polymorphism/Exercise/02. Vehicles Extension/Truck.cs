using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        const double TRUCK_AIR_MODIFIER = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            :base(fuelQuantity, fuelConsumptionPerKm, tankCapacity, TRUCK_AIR_MODIFIER)
        {

        }
   

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else
            {
                if (this.Fuel + fuel > this.TankCapacity)
                {
                    throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
                }
                else
                {
                    this.Fuel += fuel * 0.95;
                }
            }
        }


        public override string ToString()
        {
            return $"Truck: {this.Fuel:F2}";
        }

    }
}
