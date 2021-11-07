using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double airModifier)
        {
            this.Fuel = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.AirModifier = airModifier;
        }

        public double AirModifier { get; set; }

        public double Fuel { get; set; }

        public double FuelConsumptionPerKm { get; set;}

        public void Drive(double distance)
        {
            double requiredFuel = distance * (FuelConsumptionPerKm + AirModifier);
            if (requiredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.Fuel -= requiredFuel;
            }
        }

        public virtual void Refuel(double fuel)
        {
            this.Fuel += fuel;
        }
    }
}
