using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {

        private const double DefaultCarFuelConsumption = 3;
        public Car(int _horsePower, double _fuel)
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
