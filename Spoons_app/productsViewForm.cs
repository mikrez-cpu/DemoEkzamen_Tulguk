using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Spoons_app
{
    public partial class productsViewForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAB206_4\SQLEXPRESS;Initial Catalog=SpoonsDB;Integrated Security=True");
        public productsViewForm()
        {
            InitializeComponent();
        }

        private void productsViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void productsViewForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1142, 656);
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Products", con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            authForm authForm = new authForm();
            this.Hide();
            authForm.Show();
        }
    }
}
