using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.IO.Interfaces
{
    public interface IWriter
    {
        public void Write(string text);
        public void WriteLine(string text);
    }
}
