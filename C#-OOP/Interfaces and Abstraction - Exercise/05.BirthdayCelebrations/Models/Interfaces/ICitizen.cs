using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models.Interfaces
{
    public interface ICitizen : IBirthable
    {
        public string Name { get;  }

        public int Age { get; }

        public string ID { get; }

        
    }
}
