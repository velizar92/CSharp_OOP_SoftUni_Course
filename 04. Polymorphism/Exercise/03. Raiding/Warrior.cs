using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {

        private const int WARRIOR_POWER = 100;

        public Warrior(string name)
            : base(name, WARRIOR_POWER)
        {

        }
        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {Name} hit for {Power} damage";
        }
    }
}
