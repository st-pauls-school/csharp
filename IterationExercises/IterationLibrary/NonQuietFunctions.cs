using System;

namespace IterationLibrary
{
    public class NonQuietFunctions
    {
        public static void Countdown(int n)
        {
            for(int i = n; i > 0; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Blast-off!");
        }
    }
}
