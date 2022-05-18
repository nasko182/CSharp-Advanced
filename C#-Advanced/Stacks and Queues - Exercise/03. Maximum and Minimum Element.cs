using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._Basic_Stack_Operations
{
    internal class Program

    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                string[] element = Console.ReadLine()
                .Split()
                .ToArray(); ;
                if(element[0]== "1")
                {
                    int x = int.Parse(element[1]);
                    stack.Push(x);
                }
                else if (element[0] == "2")
                {
                    stack.Pop();
                }
                else if (stack.Count != 0 && element[0] == "3")
                {
                    Console.WriteLine(stack.Max());
                }
                else if (stack.Count != 0 && element[0] == "4")
                {
                    Console.WriteLine(stack.Min());
                }
            }
            Console.WriteLine(String.Join(", ",stack));
        }
    }
}
