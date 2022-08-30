using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly BunnyRepository bunnies;
        private readonly EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);
            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            var bunny = bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            bunny.AddDye(dye);
            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var egg = eggs.FindByName(eggName);
            var workshop = new Workshop();
            bool iSWork = true;
            while (iSWork)
            {
                var bunniesList = bunnies.Models.Where(b => b.Energy >= 50);
                if (bunniesList.Any())
                {
                    foreach (var bunny in bunniesList.OrderByDescending(b => b.Energy))
                    {
                        workshop.Color(egg, bunny);
                        if (bunny.Energy == 0)
                        {
                            bunnies.Remove(bunny);
                        }
                        if (egg.IsDone())
                        {
                            iSWork = false;
                            break;
                        }
                    }
                }
                else
                {
                    iSWork = false;
                    throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
                }
            }
            if (egg.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return String.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Where(e => e.IsDone()).Count()} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count()} not finished");
            }
            return sb.ToString().Trim();
        }
    }
}
