using System;
using System.Configuration;

namespace TeachingDatabase.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = Properties.Settings.Default.Interval;
            ConnectionStringSettings cxnstring = ConfigurationManager.ConnectionStrings["sl"];

            DatabaseIntegration.Lib.TeachingDatabase td = new DatabaseIntegration.Lib.TeachingDatabase(cxnstring.ConnectionString);

            foreach(string s in td.Students("L8"))
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
