namespace Introduction
{
    public class Colors
    {
        public static readonly Colors Black = new Colors(0, 0, 0);
        public static readonly Colors White = new Colors(255, 255, 255);
        public static readonly Colors Red = new Colors(255, 0, 0);
        public static readonly Colors Green = new Colors(0, 255, 0);
        public static readonly Colors Blue = new Colors(0, 0, 255);
#pragma warning disable IDE0052 // Remove unread private members
        private readonly byte r;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private readonly byte g;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private readonly byte b;
#pragma warning restore IDE0052 // Remove unread private members

        public Colors(byte red, byte green, byte blue)
        {
            r = red;
            g = green;
            b = blue;
        }
    }
}
