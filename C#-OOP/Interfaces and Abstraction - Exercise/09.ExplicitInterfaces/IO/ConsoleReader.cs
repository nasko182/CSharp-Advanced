using ExplicitInterfaces.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
