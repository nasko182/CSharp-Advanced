using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var heroes = new List<BaseHero>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type is "Druid")
                {
                    heroes.Add(new Druid(name));
                }
                else if (type is "Paladin") 
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type is "Rogue") 
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type is "Warrior")
                {
                    heroes.Add(new Warrior(name));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }


            }
            int bossPower = int.Parse(Console.ReadLine());
            int totalHeroPower = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalHeroPower+=hero.Power;
            }
            if (totalHeroPower>=bossPower)
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
