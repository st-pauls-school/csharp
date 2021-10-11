namespace IterationLibrary
{
    public class IterationUtilities
    {
        public static int Triangular(int x)
        {
            int returnvalue = 0;
            for (int i = 1; i <= x; ++i)
                returnvalue += i;
            return returnvalue;
        }
        public static int Triangular2(int x)
        {
            return x * (x + 1) / 2;
        }
    }
}
