using System;
using Acme.Collections;

namespace Introduction
{
    class Program
    {
        static void Main()
        {
            Hello.HelloWorld();

            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(10);
            stack.Push(100);
            
            Console.WriteLine($"{stack.Pop()} was popped from the stack.");
            Console.WriteLine($"{stack.Pop()} was popped from the stack.");
            Console.WriteLine($"{stack.Pop()} was popped from the stack.");

            Point point = new Point(1, 2);
            Console.WriteLine($"Point x is {point.x}.");
            Console.WriteLine($"Point y is {point.y}.");

            Pair<int, string> pair = new Pair<int, string>
            {
                First = 1,
                Second = "two"
            };

            Console.WriteLine($"First equals {pair.First}.");
            Console.WriteLine($"Second equals {pair.Second}.");

            Point3D point3D = new Point3D(1, 2, 3);

            Console.WriteLine($"Point3D.x equals {point3D.x}.");
            Console.WriteLine($"Point3D.y equals {point3D.y}.");
            Console.WriteLine($"Point3D.z equals {point3D.z}.");

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Colors black = Colors.Black;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Colors blue = Colors.Black;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Colors green = Colors.Green;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Colors red = Colors.Red;
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            Colors white = Colors.White;
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            int swap1 = 1;
            int swap2 = 2;
            SwapTest.Swap(ref swap1, ref swap2);
            Console.WriteLine("swap1 is now {0}. swap2 is now {1}.", swap1, swap2);


            DivideTest.Divide(10, 3, out int result, out int remainder);
            Console.WriteLine($"Result equals {result}. Remainder equals {remainder}.");

            Entity.SetNextSerialNo(1000);
            Entity e1 = new Entity();
            Entity e2 = new Entity();

            e1.GetSerialNo();

            Console.WriteLine("Serial number: {0}.", e1);
            Console.WriteLine("Serial number: {0}.", e2.GetSerialNo());
            Console.WriteLine(Entity.GetNextSerialNo());

            Arrays.DemoSingleDimensionalArray();
            Arrays.Demo2DArray();

            EnumColor enumRed = EnumColor.Red;
            EnumTest.PrintColor(enumRed);

            EnumColor enumGreen = EnumColor.Green;
            EnumTest.PrintColor(enumGreen);

            EnumColor enumBlue = EnumColor.Blue;
            EnumTest.PrintColor(enumBlue);


            EnumTest.PrintAllEnumColor();

            Multiplier.MultiplierTest();

            HelpTest.HelpAttributeTest();

            Console.ReadKey();
        }
    }
}
