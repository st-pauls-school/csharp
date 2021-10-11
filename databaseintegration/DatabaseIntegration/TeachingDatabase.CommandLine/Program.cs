using DatabaseIntegration.Lib;
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

            SchoolDatabase td = new SchoolDatabase(cxnstring.ConnectionString);

            foreach(string s in td.Students("Lower 8"))
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
