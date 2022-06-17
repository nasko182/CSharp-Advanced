using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic_Swap_Method_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(SwapIndexes(list,indexes));

        }
        static string SwapIndexes<T>(List<T> list, int[] indexes)
        {
            T value = list[indexes[0]];

            list[indexes[0]] = list[indexes[1]];
            list[indexes[1]] = value;
            var sb = new StringBuilder();
            foreach (T item in list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }

       
    }
}
