using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {

        const double CAR_AIR_MODIFIER = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionPerKm)
           : base(fuelQuantity, fuelConsumptionPerKm, CAR_AIR_MODIFIER)
        {

        }

      
        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
        }

        public override string ToString()
        {
            return $"Car: {this.Fuel:F2}";
        }
    }
}
