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
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] quantityOfOrder = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(quantityOfOrder.Reverse());
            Console.WriteLine(quantityOfOrder.Max());
            if (queue.Sum() <= quantityOfFood)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                    Console.Write($"Orders left:");
                for (int i = 0; i < quantityOfOrder.Length; i++)
                {
                        if (queue.Sum() > quantityOfFood)
                        {
                            Console.Write($" {queue.Dequeue()}");
                            
                        }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
