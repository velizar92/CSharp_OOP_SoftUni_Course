using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public abstract class Creature
    {
        public string Id { get; set; }

        public Creature(string _id)
        {
            this.Id = _id;
        }

        
    }
}
