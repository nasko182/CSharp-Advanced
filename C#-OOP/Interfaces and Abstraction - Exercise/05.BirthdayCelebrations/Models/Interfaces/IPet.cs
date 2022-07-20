using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models.Interfaces
{
    public interface IPet:IBirthable
    {
        public string Name { get; }
    }
}
