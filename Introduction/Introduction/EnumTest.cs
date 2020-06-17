namespace Introduction
{
    using System;

    public enum EnumColor
    {
        Red,
        Green,
        Blue
    }

    public class EnumTest
    {
        public static void PrintColor(EnumColor color)
        {
            Console.WriteLine("EnumTest PrintColor has begun.");
            
            switch (color)
            {
                case EnumColor.Red:
                    Console.WriteLine("Red");
                    break;
                case EnumColor.Green:
                    Console.WriteLine("Green");
                    break;
                case EnumColor.Blue:
                    Console.WriteLine("Blue");
                    break;
                default:
                    Console.WriteLine("Unknown color");
                    break;
            }

            Console.WriteLine("EnumTest PrintColor has ended.");
        }

        public static void PrintAllEnumColor()
        {
            Console.WriteLine("PrintAllEnumColor has started.");

            System.Collections.IList list = Enum.GetValues(typeof(EnumColor));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Color is {0}", Enum.GetName(typeof(EnumColor), list[i]));
                Console.WriteLine("Value is {0}", (int)list[i]);
            }

            Console.WriteLine("PrintAllEnumColor has ended.");
        }
    }
}
