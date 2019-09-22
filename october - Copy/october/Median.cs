using System.Collections.Generic;

namespace october
{
    class Median
    {
        public static double GetTheMedianValue(List<int> incoming)
        {
            // this function takes an unsorted list of integers and will return the median value. 
            incoming.Sort();
            if (incoming.Count % 2 == 1)
                return incoming[(incoming.Count - 1) / 2];
            return (double)(incoming[incoming.Count/2] + incoming[(incoming.Count / 2)-1]) /2 ;
        }
    }
}
