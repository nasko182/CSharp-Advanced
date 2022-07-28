using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilyties
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValidationAttribute:Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
