using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {

        private const double DEFAULT_MILLILITERS = 50;
        private const decimal DEFAULT_PRICE = 3.50m;

        private double milliliters;
        private decimal price;

        public Coffee(string _name, double _caffeine)
           : base(_name, DEFAULT_PRICE, DEFAULT_MILLILITERS)    //set default such
        {
            this.Caffeine = _caffeine;
        }

     

        public double Caffeine { get; set; }

        public override double Milliliters { 
            get 
            { 
                return DEFAULT_MILLILITERS; 
            }

            set
            {
                this.milliliters = value;
            }
        
        
        }

        public override decimal Price { 
            get 
            { 
                return DEFAULT_PRICE; 
            }
            set
            {
                this.price = value;
            }

        }


    }

}
