using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {

        public Dessert(string _name, decimal _price, 
            double _grams, double _calories)
          : base(_name, _price, _grams)
        {
            this.Calories = _calories;
        }

        public virtual double Calories { get; set; }

    }
}
