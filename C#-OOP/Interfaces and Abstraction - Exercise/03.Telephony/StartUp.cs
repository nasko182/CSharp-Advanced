using System;
using Telephony.Core;
using Telephony.IO;
using Telephony.IO.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new Engine(reader,writer);
            engine.Start();
        }
    }
}
