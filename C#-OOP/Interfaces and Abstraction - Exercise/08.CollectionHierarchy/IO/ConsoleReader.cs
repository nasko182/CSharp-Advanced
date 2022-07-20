using CollectionHierarchy.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.IO
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
