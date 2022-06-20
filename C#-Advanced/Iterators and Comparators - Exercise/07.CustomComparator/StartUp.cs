using System;
using System.Linq;

namespace _07.CustomComparator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SortEvenAndOdd sortMethod = new SortEvenAndOdd();

            Array.Sort(input, sortMethod);

            Console.WriteLine(String.Join(" ",input));
        }
    }
}
