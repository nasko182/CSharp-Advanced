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
            int[] parms = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = parms[0];
            int s = parms[1];
            int x = parms[2];
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> stack = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                int element = input[i];
                stack.Enqueue(element);
            }
            for (int i = 0; i < s; i++)
            {
                stack.Dequeue();
            }
            if (stack.Count > 0)
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine($"{stack.Min()}");
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
