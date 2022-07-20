using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Robot : Inhabiters, IRobot
    {
        private string model;
        private string id;

        public Robot(string model,string id)
        {
            this.Model = model;
            this.ID = id;
        }

        public string Model
        {
            get
            {
                return model;
            }

            private set
            {
                this.model = value;
            }

        }

        public override string ID
        {
            get
            {
                return this.id;
            }
            protected set { this.id = value; }
        }

    }
}
