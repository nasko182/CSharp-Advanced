using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(a=>a.AttributeType==typeof(AuthorAttribute)))
                {
                    foreach (AuthorAttribute attribute in method.GetCustomAttributes(false))
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
