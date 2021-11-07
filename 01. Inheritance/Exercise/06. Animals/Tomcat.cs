using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
     
        private const string DEFAULT_GENDER = "Male";

        public Tomcat(string _name, int _age)
           : base(_name, _age, DEFAULT_GENDER)
        {

        }

    
        public override string ProduceSound()
        {
           return "MEOW";
        }


    }
}
