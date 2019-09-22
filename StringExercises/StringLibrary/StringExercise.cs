using System.Text;

namespace StringLibrary
{
    public class StringExercise
    {
        public static string Increase(string s, int offset)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in s)
            {
                sb.Append(c + offset);
            }
            return sb.ToString();
        }
    }
}
