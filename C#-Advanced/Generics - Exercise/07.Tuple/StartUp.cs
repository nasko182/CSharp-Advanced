using System;
using System.Collections.Generic;

namespace _07.Exercise

{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var list = new List<string>();
            list.Add(input[0]);
            list.Add(input[1]);
            string address = input[2];
            string[] input2 = Console.ReadLine().Split();
            string name = input2[0];
            int quantity = int.Parse(input2[1]);
            string[] input3 = Console.ReadLine().Split();
            int num = int.Parse(input3[0]);
            double numWithPoint = double.Parse(input3[1]);
            var tuple1 = new Tuple<string,string>();
            foreach (var item in list)
            {
                tuple1.AddToFirst(item);
            }
            tuple1.AddToSecond(address);
            var tuple2 = new Tuple<string,int>();
            tuple2.AddToFirst(name);
            tuple2.AddToSecond(quantity);
            var tuple3 = new Tuple<int,double>();
            tuple3.AddToFirst(num);
            tuple3.AddToSecond(numWithPoint);

            Console.WriteLine(tuple1.Print());
            Console.WriteLine(tuple2.Print());
            Console.WriteLine(tuple3.Print());


        }
    }
}
