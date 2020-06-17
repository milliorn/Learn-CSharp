namespace Introduction
{
    public class DivideTest
    {
        public static void Divide(int x, int y, out int result, out int remainder)
        {
            result = x / y;
            remainder = x % y;
        }
    }
}
