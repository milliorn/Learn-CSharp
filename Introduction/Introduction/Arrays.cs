using System;

namespace Introduction
{
    public class Arrays
    {
        public static void DemoSingleDimensionalArray()
        {
            int[] a = new int[10];

            Console.WriteLine("SampleSingleDimensionalArray called start.");

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i * i;
            }
            
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("a[{0}] = {1}", i, a[i]);
            }
            
            Console.WriteLine("SampleSingleDimensionalArray call ended.");
        }

        public static void Demo2DArray()
        {
            int[,] numbers = new int[,]
            {
                {0, 2, 4, 6, 8},
                {1, 3, 5, 7, 9}
            };

            Console.WriteLine("Demo2DArray has started");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i, j] + "\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Demo2DArray has ended");
        }
    }
}
