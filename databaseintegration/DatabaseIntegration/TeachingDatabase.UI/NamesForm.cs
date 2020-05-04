using DatabaseIntegration.Lib;
using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace TeachingDatabase.UI
{
    public partial class NamesForm : Form
    {
        readonly SchoolDatabase _schoolDatabase;

        public NamesForm()
        {
            InitializeComponent();

            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["sl"];
            _schoolDatabase = new SchoolDatabase(connectionStringSettings.ConnectionString);

        }

        private void NamesForm_Load(object sender, EventArgs e)
        {
            // the query 
            string qry = string.Format(SchoolDatabase.STUDENTS_BY_YEAR_GROUP, "Lower 8");
            // get the connection string from the app.config 
            // NB. the database file must be in a directory that the process can write to (there'll be a lockfile) 
            try
            {
                DataSet ds = _schoolDatabase.GetMeSomeData(qry);

                // bind the dataset to the combobox 
                namesComboBox.DataSource = ds.Tables[0];
                namesComboBox.ValueMember = "ID"; // these are the field names returned from the query. 
                namesComboBox.DisplayMember = "Student";

                lblSelected.Text = "No-one selected yet";
            }
            catch (Exception ex)
            {
                lblSelected.Text = ex.Message;
            }
        }

        private void namesComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            lblSelected.Text = string.Format("the student selected is {0}", namesComboBox.SelectedValue.ToString());
        }
    }
}
