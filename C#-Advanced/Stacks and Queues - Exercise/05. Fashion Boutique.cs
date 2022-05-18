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
            int[] clothes = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(clothes);
            int capacity = int.Parse(Console.ReadLine());
            int racksCounter = 0;
            int sum = 0;
            while (stack.Count > 0)
            {
                racksCounter++;
                sum = 0;
                while (sum < capacity)
                {
                    if (sum+stack.Peek()<=capacity)
                    {
                        sum += stack.Pop();
                        if (sum == capacity)
                        {
                            break;
                        }
                        if (stack.Count==0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
            Console.WriteLine(racksCounter);
        }
    }
}
