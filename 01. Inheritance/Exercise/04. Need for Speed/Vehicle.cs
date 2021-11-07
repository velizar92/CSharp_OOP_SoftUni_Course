using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {

        public Vehicle(int _horsePower, double _fuel)
        {
            this.HorsePower = _horsePower;
            this.Fuel = _fuel;
        }

        public double DefaultFuelConsumption { get { return 1.25; } set { } }
        public virtual double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }          
        }
        public double Fuel { get; set; }

        public int HorsePower { get; set; }



        public virtual void Drive(double _kilometers)
        {
            this.Fuel -= FuelConsumption * _kilometers;
        }



    }
}
