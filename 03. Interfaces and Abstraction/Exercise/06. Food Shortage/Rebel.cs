using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {

        public Rebel(string _name, int _age, string _group)
        {
            this.Name = _name;
            this.Age = _age;
            this.Group = _group;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Group { get; set; }

        public int Food { get; set; } = 0;

        public DateTime BirthDate { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
