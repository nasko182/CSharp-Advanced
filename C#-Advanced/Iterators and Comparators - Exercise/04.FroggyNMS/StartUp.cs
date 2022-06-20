using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FroggyNMS
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> stones = new List<int>(nums);
            var lake = new Lake(stones);
            List<int> output = new List<int>();
            foreach (var stone in lake)
            {
               output.Add(stone); 
            }
            Console.WriteLine(String.Join(", ", output));
            
        }
    }
}
