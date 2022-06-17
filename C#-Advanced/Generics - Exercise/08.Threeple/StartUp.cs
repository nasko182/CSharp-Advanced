using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Exercise

{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string name1 = $"{input[0]} {input[1]}";
            string street = input[2];
            string town = string.Join(" ", input.Skip(3));
            var threeple1 = new Threeple<string,string,string>(name1, street, town);
            string[] input2 = Console.ReadLine().Split();
            string name = input2[0];
            int quantity = int.Parse(input2[1]);
            string isTrue =input2[2];
            if (isTrue=="drunk")
            {
                isTrue = "True";
            }
            else
            {
                isTrue="False";
            }
            var threeple2 = new Threeple<string, int, string>(name, quantity, isTrue);
            string[] input3 = Console.ReadLine().Split();
            string name2 = input3[0];
            double numWithPoint = double.Parse(input3[1]);
            string bank = input3[2];
            var threeple3 = new Threeple<string, double, string>(name2, numWithPoint, bank);


            Console.WriteLine(threeple1.Print());
            Console.WriteLine(threeple2.Print());
            Console.WriteLine(threeple3.Print());


        }
    }
}
