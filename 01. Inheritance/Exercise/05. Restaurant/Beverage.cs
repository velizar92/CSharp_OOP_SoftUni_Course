using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string _name, decimal _price, double _milliliters)
            :base(_name, _price)
        {
            this.Milliliters = _milliliters;
        }

        public virtual double Milliliters { get; set; }



    }
}
