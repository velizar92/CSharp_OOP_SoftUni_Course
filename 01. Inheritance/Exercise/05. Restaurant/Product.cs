using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {

        public Product(string _name, decimal _price)
        {
            this.Name = _name;
            this.Price = _price;
        }

        public string Name { get; set; }
        public virtual decimal Price { get; set; }





    }

}
