using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Citizen : Creature
    {
       
        public Citizen(string _name, int _age, string _id)
            :base(_id)
        {
            this.Name = _name;
            this.Age = _age;
            this.Id = _id;         
        }

        public string Name { get; set; }
        public int Age { get; set; }
    

    }
}
