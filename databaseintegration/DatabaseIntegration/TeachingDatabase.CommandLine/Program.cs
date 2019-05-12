using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;

namespace TeachingDatabase.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionStringSettings cxnstring = ConfigurationManager.ConnectionStrings["sl"];
            SQLiteConnection cxn = new SQLiteConnection(cxnstring.ConnectionString);
            cxn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd = cxn.CreateCommand();
            cmd.CommandText = "select yg.name as 'Year', s.name as Student from YearGroups yg join StudentYearGroup syg left join Students s on syg.studentid = s.id where yg.name = 'L8' ";

            SQLiteDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine("{0} - {1}", reader.GetString(0), reader.GetString(1));
            }

            cxn.Close();
            Console.ReadKey();
        }
    }
}
