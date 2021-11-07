using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {

        private const double DefaultCarFuelConsumption = 8;
        public RaceMotorcycle(int _horsePower, double _fuel)
           : base(_horsePower, _fuel)
        {

        }

        public override double FuelConsumption
        {
            get
            {
                return DefaultCarFuelConsumption;
            }

        }

    }
}
