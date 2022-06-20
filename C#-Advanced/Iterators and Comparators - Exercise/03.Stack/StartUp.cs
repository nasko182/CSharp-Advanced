using System;
using System.Linq;

namespace _03Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            var stack = new MyStack<string>();
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                if (action=="Push")
                {
                    var elements = command.Replace("Push ", "").Split(", ");
                    foreach (var element in elements)
                    {
                        stack.Push(element);
                    }
                }
                else
                {
                    stack.Pop();
                }
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var element in stack)
                {
                    Console.WriteLine(element.ToString());
                }
            }

        }
    }
}
