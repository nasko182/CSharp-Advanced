using System;
using WildFarm.Core;
using WildFarm.IO;
using WildFarm.IO.Interfaces;

namespace Wild_Farm
{
    public class StatUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new Engine(writer,reader);

            engine.Start();
        }
    }
}
