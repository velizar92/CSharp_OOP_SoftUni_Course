using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
      

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity, double airModifier)
        {
            this.Fuel = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TankCapacity = tankCapacity;
            this.AirModifier = airModifier;        
        }

        public double AirModifier { get; set; }

        public double Fuel { get; protected set; }
        
        public double FuelConsumptionPerKm { get; set; }

        public double TankCapacity { get; set; }

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
                    this.Fuel += fuel;
                }
            }
        }



    }
}
