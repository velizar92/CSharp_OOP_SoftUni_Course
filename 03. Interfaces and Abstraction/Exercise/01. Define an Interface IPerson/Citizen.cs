using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson
    {

        public Citizen(string _name, int _age)
        {
            this.Name = _name;
            this.Age = _age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
