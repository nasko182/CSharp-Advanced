using ExplicitInterfaces.Core;
using ExplicitInterfaces.IO;
using ExplicitInterfaces.IO.Interfaces;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
