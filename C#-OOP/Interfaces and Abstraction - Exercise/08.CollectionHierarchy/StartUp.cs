using CollectionHierarchy.Core;
using CollectionHierarchy.IO;
using CollectionHierarchy.IO.Interfaces;
using System;

namespace _08.CollectionHierarchy
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
