using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System;
using System.Linq;
using System.IO;

namespace DynamicIronPythonSample
{
    class Program
    {
        static void Main()
        {
            // Set the current directory to the IronPython libraries.
            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string path2 = @"C:\Program Files\IronPython 2.7";
            string path = Path.Combine(path1, path2);
            System.IO.Directory.SetCurrentDirectory(path);

            // Create an instance of the random.py IronPython library.
            Console.WriteLine("Loading random.py");
            ScriptRuntime py = Python.CreateRuntime();
            dynamic random = py.UseFile("random.py");
            Console.WriteLine("random.py loaded.");

            //  Initialize an enumerable set of integers
            int[] items = Enumerable.Range(1, 7).ToArray();

            //  Randomly shuffle the array of integers by using IronPython.
            for (int i = 0; i < 5; i++)
            {
                //  Random doesn't work, used C# instead.
                //random.shuffle(items);
                int[] shuffled = items.OrderBy(n => Guid.NewGuid()).ToArray();


                foreach (int item in shuffled)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------");
            }
        }
    }
}
