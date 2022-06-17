using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Generic_Count_Method_Doble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine())); 
            }
            var element = double.Parse(Console.ReadLine());
            Console.WriteLine(Comparer(list,element));
        }

        static int Comparer<T>(List<T> list, T element)
            where T : IComparable
        {
            int counter=0;
            foreach (var item in list)
            {
                if (item.CompareTo(element)>0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
