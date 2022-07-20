using System;
using System.Collections.Generic;
using System.Text;
using Telephony.IO.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly Smartphone smartphone;
        private readonly StationaryPhone stationaryPhone;

        private Engine()
        {
            this.smartphone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] numbers = reader.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] urls = reader.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            foreach(string number in numbers)
            {
                if (IsValidNumber(number))
                {
                    if (number.Length==10)
                    {
                        writer.WriteLine(smartphone.Call(number));
                    }
                    else if (number.Length==7)
                    {
                        writer.WriteLine(stationaryPhone.Call(number));
                    }
                }
                else
                {
                    writer.WriteLine("Invalid number!");
                }
            }
            foreach (string url in urls)
            {
                if (IsValidUrl(url))
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                else
                {
                    writer.WriteLine("Invalid URL!");
                }
            }

        }
        private static bool IsValidNumber(string number)
        {
            foreach (var ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool IsValidUrl(string url)
        {
            foreach (var ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
