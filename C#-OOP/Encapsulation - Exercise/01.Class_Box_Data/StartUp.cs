using System;

namespace Class_Box_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double widht = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                var box = new Box(length, widht, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"{ae.Message} cannot be zero or negative.");
            }
        }
    }
}
