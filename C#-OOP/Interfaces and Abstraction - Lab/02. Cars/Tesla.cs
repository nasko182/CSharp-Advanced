using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                model = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set { this.color = value; }
        }

        public int Battery
        {
            get
            {
                return this.battery;
            }
            private set { battery = value; }
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
            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine(Start());
            sb.Append(Stop());
            return sb.ToString();
        }
    }
}
