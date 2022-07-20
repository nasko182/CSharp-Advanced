using BorderControl.Core;
using System;
using Telephony.IO;
using Telephony.IO.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(writer, reader);
            engine.Start();
        }
    }
}
