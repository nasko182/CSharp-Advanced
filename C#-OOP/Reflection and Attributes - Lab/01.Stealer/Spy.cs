using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            StringBuilder sb = new StringBuilder();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(className);
            var classInstance = Activator.CreateInstance(type);
            sb.AppendLine($"Class under investigation: {type.FullName}");
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (string fieldName in fieldsNames)
            {
                var currentFileld = fields.FirstOrDefault(f => f.Name == fieldName);
                sb.AppendLine($"{currentFileld.Name} = {currentFileld.GetValue(classInstance)}");
            }


            return sb.ToString();
        }
    }
}
