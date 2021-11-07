using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string DEFAULT_GENDER = "Female";


        public Kitten(string _name, int _age)
          : base(_name, _age, DEFAULT_GENDER)
        {

        }

        public override string ProduceSound()
        {
           return "Meow";
        }


    }
}
