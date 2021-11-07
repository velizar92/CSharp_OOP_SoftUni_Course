using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl
{
    public class Robot : Creature
    {
       

        public Robot(string _model, string _id)
            :base(_id)
        {
            this.Model = _model;
                  
        }

        public string Model { get; set; }      
    
    }
}
