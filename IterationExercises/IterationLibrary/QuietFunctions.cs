using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IterationLibrary
{
    public class QuietFunctions
    {
        public static string CountDown(int n)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = n; i > 0; i--)
            {
                sb.AppendLine(string.Format("{0}!", i));
            }
            sb.AppendLine("Blast-Off!");
            return sb.ToString();
        }
    }
}
