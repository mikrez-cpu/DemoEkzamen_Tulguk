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
    public partial class productsWorkForm : Form
    {
        int id = 0;
        public void loadData()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From  Products", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            label2.Text = "Количество позиций: " + dt.Rows.Count;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) > 15) 
                {
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Green; 
                }
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAB206_4\SQLEXPRESS;Initial Catalog=SpoonsDB;Integrated Security=True");
        public productsWorkForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            authForm authForm = new authForm();
            this.Hide();
            authForm.Show();
        }

        private void productsWorkForm_Load(object sender, EventArgs e)
        {
            con.Open();
            this.MinimumSize = new Size(1454, 708);
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id !=0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с ID " + id + "?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlCommand deleteQuery = new SqlCommand("Delete from Products where Product_ID = '"+id+"'", con);
                    deleteQuery.ExecuteScalar();
                    loadData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
                
                    
        }

        private void productsWorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                SqlCommand imageQuery = new SqlCommand("Select Image from Products where Product_ID = '" + id + "'", con);
                string image = imageQuery.ExecuteScalar().ToString();

                switch (image)
                {
                    case "B736H6.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.B736H6;
                        break;
                    case "D735T5.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.D735T5;
                        break;
                    case "E732R7.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.E732R7;
                        break;
                    case "F573T5.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.F573T5;
                        break;
                    case "G387Y6.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.G387Y6;
                        break;
                    case "H384H3.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.H384H3;
                        break;
                    case "K437E6.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.K437E6;
                        break;
                    case "R836H6.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.R836H6;
                        break;
                    case "T793T4.jpg":
                        label3.Text = "";
                        pictureBox1.Image = Properties.Resources.T793T4;
                        break;
                    case "":
                        label3.Text = "Изображение отсутствует";
                        pictureBox1.Image = Properties.Resources.picture;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для просмотра изображения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From  Products order by Price asc", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) > 15)
                {
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Green;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From  Products order by Price desc", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) > 15)
                {
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Green;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string discountOption = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (discountOption != "")
            {
                switch (discountOption)
                {
                    case "0-9,99%":
                        SqlDataAdapter adapter = new SqlDataAdapter("Select * From  Products where Max_Discount < 10", con);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        label2.Text = "Количество позиций: " + dt.Rows.Count + "из 28";
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Записи в диапазоне не найдены!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            loadData();
                        }
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) > 15)
                            {
                                dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Green;
                            }
                        }
                        break;
                    case "10-14,99%":
                        SqlDataAdapter adapter1 = new SqlDataAdapter("Select * From  Products where Max_Discount > 9 and Max_Discount < 16", con);
                        DataTable dt1 = new DataTable();
                        adapter1.Fill(dt1);
                        dataGridView1.DataSource = dt1;
                        label2.Text = "Количество позиций: " + dt1.Rows.Count + "из 28";
                        if (dt1.Rows.Count == 0)
                        {
                            MessageBox.Show("Записи в диапазоне не найдены!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            loadData();
                        }
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) > 15)
                            {
                                dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Green;
                            }
                        }
                        break;
                    case "15% и более":
                        SqlDataAdapter adapter2 = new SqlDataAdapter("Select * From  Products where Max_Discount > 15", con);
                        DataTable dt2 = new DataTable();
                        adapter2.Fill(dt2);
                        dataGridView1.DataSource = dt2;
                        label2.Text = "Количество позиций: " + dt2.Rows.Count + "из 28";
                        if (dt2.Rows.Count == 0)
                        {
                            MessageBox.Show("Записи в диапазоне не найдены!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            loadData();
                        }
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) > 15)
                            {
                                dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Green;
                            }
                        }
                        break;
            }



            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите искомый диапазон скидок!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlDataAdapter adapter2 = new SqlDataAdapter("Select * From  Products where Manufacturer='"+textBox1.Text+"'", con);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                dataGridView1.DataSource = dt2;
                label2.Text = "Количество позиций: " + dt2.Rows.Count + "из 28";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) > 15)
                    {
                        dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Green;
                    }
                }
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("Записи по критерию не найдены!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, напишите критерий поиска!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
