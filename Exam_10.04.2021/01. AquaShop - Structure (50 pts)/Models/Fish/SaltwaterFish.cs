using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        //Can only live in SaltwaterAquarium!
        private int initSize = 5;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
        }

        public override void Eat()
        {
            Size += initSize + 2;
        }

    }
}
