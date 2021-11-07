using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {

        public Food(string _name, decimal _price, double _grams)
           : base(_name, _price)
        {
            this.Grams = _grams;
        }


        public virtual double Grams { get; set; }
    }
}
