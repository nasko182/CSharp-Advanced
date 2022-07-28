using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string name = args.Split(' ')[0];
            object[] cmdArgs = args.Split(' ').Skip(1).ToArray();
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == name+"Command"&& t.GetInterfaces().Any(i=>i==typeof(ICommand)));
            MethodInfo method = type.GetMethod("Execute");
            object cmdInstance = Activator.CreateInstance(type);
            string result = (string)method.Invoke(cmdInstance, new object[] {cmdArgs});
            return result;
        } 
    }
}
