using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
   
        public Dog(string _name, int _age, string _gender)
            :base(_name, _age, _gender)
        {

        }


        public override string ProduceSound()
        {
           return "Woof!";
        }


    }
}
