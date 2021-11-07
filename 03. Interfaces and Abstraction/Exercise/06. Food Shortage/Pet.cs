using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IInformable
    {

        public Pet(string _name, DateTime _birtDate)
        {
            this.Name = _name;
            this.BirthDate = _birtDate;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
