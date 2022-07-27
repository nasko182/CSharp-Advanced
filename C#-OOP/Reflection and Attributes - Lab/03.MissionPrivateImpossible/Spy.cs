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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType($"Stealer.{className}");
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static);

            foreach (var method in methods.Where(g => g.Name.Contains("get")).Where(m=>m.IsPrivate))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in methods.Where(g => g.Name.Contains("set")).Where(m => m.IsPublic))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }



            return sb.ToString();

        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static);
            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }


            return sb.ToString();
        }



    }
}
