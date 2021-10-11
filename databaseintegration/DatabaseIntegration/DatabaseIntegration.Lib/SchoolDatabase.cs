using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DatabaseIntegration.Lib
{
    public class SchoolDatabase
    {
        readonly string _connectionString;
        public const string STUDENTS_BY_YEAR_GROUP = "select distinct s.id ID, s.name Student from years y join teaching_sets ts on y.id = ts.year join setlist sl on ts.id = sl.set_id join students s on sl.student_id = s.id where y.name = '{0}' order by s.name ";

        public SchoolDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<string> Students(string year)
        {
            string qry = string.Format(STUDENTS_BY_YEAR_GROUP, year);
            return GetMeAList(qry);
        }


        public IEnumerable<string> GetMeAList(string qry)
        {
            using (SQLiteConnection cxn = new SQLiteConnection(_connectionString))
            {
                cxn.Open();
                SQLiteCommand cmd;
                cmd = cxn.CreateCommand();
                cmd.CommandText = qry;

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // return the second column 
                    yield return reader.GetString(1);
                }
            }
        }

        public DataSet GetMeSomeData(string qry)
        {
            DataSet ds = null;
            // use 'using' the avoid explicitly closing the connection 
            using (SQLiteConnection cxn = new SQLiteConnection(_connectionString))
            {
                // create a command object based on a query and a connection 
                SQLiteCommand cmd = new SQLiteCommand(qry, cxn);
                cmd.CommandType = CommandType.Text;
                // pass the command to an adapter 
                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                // use the adapter to fill a dataset 
                ds = new DataSet();
                // if the location is unwritable, you'll get an error here 
                ad.Fill(ds);
            }

            return ds;
        }
    }
}
