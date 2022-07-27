using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.RevealAllGetters("Stealer.Hacker");
            Console.WriteLine(result);
            result = spy.RevealAllSetters("Stealer.Hacker");
            Console.WriteLine(result);

        }
    }
}
