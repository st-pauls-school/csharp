using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachingDatabase.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string qry = "select s.id as 'ID', yg.name as 'Year', s.name as Student from YearGroups yg join StudentYearGroup syg left join Students s on syg.studentid = s.id where yg.name = 'L8' ";
            ConnectionStringSettings cxnstring = ConfigurationManager.ConnectionStrings["sl"];
            DataSet ds;
            using (SQLiteConnection cxn = new SQLiteConnection(cxnstring.ConnectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(qry, cxn);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
                ds = new DataSet();
                ad.Fill(ds);
            }

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Student";

            lblSelected.Text = "No-one selected yet";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            lblSelected.Text = string.Format("the student selected is {0}", comboBox1.SelectedValue.ToString());
        }
    }
}
