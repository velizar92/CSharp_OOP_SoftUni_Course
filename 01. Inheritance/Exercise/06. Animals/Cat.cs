using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {

        public Cat(string _name, int _age, string _gender)
         : base(_name, _age, _gender)
        {

        }

        public override string ProduceSound()
        {
           return "Meow meow";
        }

     

    }
}
