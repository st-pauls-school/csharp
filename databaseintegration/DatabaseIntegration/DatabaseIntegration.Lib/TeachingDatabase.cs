using System.Collections.Generic;
using System.Data.SQLite;

namespace DatabaseIntegration.Lib
{
    public class TeachingDatabase
    {
        readonly string _connectionString; 

        public TeachingDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<string> Students(string yg)
        {
            IList<string> students = new List<string>();

            using (SQLiteConnection cxn = new SQLiteConnection(_connectionString))
            {
                cxn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd = cxn.CreateCommand();
                cmd.CommandText = string.Format("select yg.name as 'Year', s.name as Student from YearGroups yg join StudentYearGroup syg left join Students s on syg.studentid = s.id where yg.name = '{0}' ", yg);

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(reader.GetString(0));
                }
            }
            return students;

        }
    }
}
