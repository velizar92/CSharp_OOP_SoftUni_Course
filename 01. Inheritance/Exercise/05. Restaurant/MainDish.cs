using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class MainDish : Food
    {

        public MainDish(string _name, decimal _price, double _grams)
           : base(_name, _price, _grams)
        {
            
        }
    }
}
