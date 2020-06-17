using System;

namespace Introduction
{
    public delegate double Function(double x);

    public class Multiplier
    {
        private readonly double factor;

        public Multiplier(double factor) => this.factor = factor;
        public double Multiply(double x) => x * factor;
        public static double Square(double x) => x * x;

        public static double[] Apply(double[] a, Function f)
        {
            double[] result = new double[a.Length];

            for (int i = 0; i < a.Length; ++i)
            {
                result[i] = f(a[i]);
            }

            return result;
        }

        public static void MultiplierTest()
        {
            double[] a = { 0.0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };
            double[] squares = Apply(a, Square);
            double[] sines = Apply(a, Math.Sin);

            Multiplier m = new Multiplier(2.0);
            double[] doubles = Apply(a, m.Multiply);

            Console.WriteLine("MultiplierTest has started.");
            Console.WriteLine("Printing \"a\" array [{0}]", string.Join(", ", a));
            Console.WriteLine("Printing squares array [{0}]", string.Join(", ", squares));
            Console.WriteLine("Printing sines array [{0}]", string.Join(", ", sines));
            Console.WriteLine("Printing doubles array [{0}]", string.Join(", ", doubles));
            Console.WriteLine("MultiplierTest has ended.");
        }
    }
}
