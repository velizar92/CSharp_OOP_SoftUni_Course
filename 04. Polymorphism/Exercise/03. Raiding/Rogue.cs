﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {

        private const int ROGUE_POWER = 80;

        public Rogue(string name)
           : base(name, ROGUE_POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {Name} hit for {Power} damage";
        }


    }
}
