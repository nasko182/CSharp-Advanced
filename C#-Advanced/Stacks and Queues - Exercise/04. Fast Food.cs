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
            Queue<int> queue = new Queue<int>(quantityOfOrder);
            for (int i = 0; i < quantityOfOrder.Length; i++)
            {
                if (quantityOfFood>= queue.Peek())
                {
                    quantityOfFood -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(quantityOfOrder.Max());

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
            }
        }
    }
}
