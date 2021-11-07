using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {

        private const double DEFAULT_GRAMS = 22;

        private double grams;

        public Fish(string _name, decimal _price)
        : base(_name, _price, DEFAULT_GRAMS)
        {

        }

        public override double Grams { 
            get 
            { 
                return DEFAULT_GRAMS; 
            }

            set
            {
                this.grams = value;
            }
        
        }


    }
}
