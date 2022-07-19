using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string model,string color)
        {
            this.Model=model;
            this.Color=color;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set { this.model = value; }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set { this.color = value; }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Color} Seat {Model}");
            sb.AppendLine(Start());
            sb.Append(Stop());

            return sb.ToString();
        }
    }
}
