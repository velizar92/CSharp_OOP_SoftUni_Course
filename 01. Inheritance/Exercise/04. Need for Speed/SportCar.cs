using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {


        private const double DefaultCarFuelConsumption = 10;
        public SportCar(int _horsePower, double _fuel)
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
