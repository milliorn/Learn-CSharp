using System;

namespace trial
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = string.Empty;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                //x = Program.StrTest();
                //x = Program.StrTest2();
                x = Program.StrTest3();
            }
            watch.Stop();
            Console.WriteLine($"{x}");
            Console.WriteLine($"Time: {watch.Elapsed}");
        }

        public static string StrTest()
        {
            int i = -1;
            return string.Create(5, new Random(), (Span<char> chars, Random r) =>
            {
                foreach (var _ in chars)
                {
                    i++;

                    if (i < 2)
                        chars[i] = (char)(r.Next(65, 90));
                    else
                        chars[i] = (char)(r.Next(48, 57));
                }
            });
        }

        public static string StrTest2()
        {
            Random r = new Random();
            return $"{(char)(r.Next(0, 10) + '0')}{(char)(r.Next(0, 10) + '0')}{(char)(r.Next(0, 10) + '0')}{(char)(r.Next(0, 10) + '0')}{(char)(r.Next(0, 10) + '0')}";
        }

        public static string StrTest3()
        {
            Random r = new Random();
            var builder = new System.Text.StringBuilder();
            builder.Append((char)(r.Next(0, 10) + '0'))
               .Append((char)(r.Next(0, 10) + '0'))
               .Append((char)(r.Next(0, 10) + '0'))
               .Append((char)(r.Next(0, 10) + '0'))
               .Append((char)(r.Next(0, 10) + '0'));

            return builder.ToString();
        }
    }
}