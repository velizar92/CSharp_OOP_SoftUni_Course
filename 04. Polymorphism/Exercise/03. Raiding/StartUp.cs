using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            


            while (raidGroup.Count < n)
            {
           
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                BaseHero baseHero = null;

                if (heroType == nameof(Druid))
                {
                    baseHero = new Druid(heroName);
                }
                else if (heroType == nameof(Paladin))
                {
                    baseHero = new Paladin(heroName);
                }
                else if (heroType == nameof(Rogue))
                {
                    baseHero = new Rogue(heroName);
                }
                else if (heroType == nameof(Warrior))
                {
                    baseHero = new Warrior(heroName);
                }

                if (baseHero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                raidGroup.Add(baseHero);

            }


            int bossPower = int.Parse(Console.ReadLine());
           
            foreach (BaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                bossPower -= hero.Power;
            }

            if (bossPower <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }



        }
    }
}
