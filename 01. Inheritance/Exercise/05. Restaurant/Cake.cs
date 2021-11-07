using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {

        const double DEFAULT_GRAMS = 250;
        const double DEFAULT_CALORIES = 1000;
        const decimal DEFAULT_PRICE = 5m;

        private double grams;
        private double calories;
        private decimal price;

        public Cake(string _name)
          : base(_name, DEFAULT_PRICE, DEFAULT_GRAMS, DEFAULT_CALORIES)
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


        public override double Calories { 
            get 
            {
                return DEFAULT_CALORIES; 
            }

            set
            {
                this.calories = value;
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
