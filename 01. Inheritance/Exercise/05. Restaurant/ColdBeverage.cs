using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class ColdBeverage : Beverage
    {

        public ColdBeverage(string _name, decimal _price, double _milliliters)
           : base(_name, _price, _milliliters)
        {

        }
    }
}
