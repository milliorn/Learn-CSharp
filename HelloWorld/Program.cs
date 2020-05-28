using System;

namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("What is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }

    }
}
