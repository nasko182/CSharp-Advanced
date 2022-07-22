using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = new Circle(3.2);
            Console.WriteLine(shape.Draw());
            shape = new Rectangle(6, 5);
            Console.WriteLine(shape.Draw());
        }
    }
}
