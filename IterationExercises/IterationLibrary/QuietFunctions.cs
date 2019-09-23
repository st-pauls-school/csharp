using System.Collections.Generic;
using System.Linq;

namespace IterationLibrary
{
    public class QuietFunctions
    {
        public static List<string> CountDown(int n)
        {
            List<string> returnValue = new List<string>();
            for(int i = n; i > 0; i--)
            {
                returnValue.Add(string.Format("{0}!", i));
            }
            returnValue.Add("Blast-Off!");
            return returnValue;
        }
    }
}
