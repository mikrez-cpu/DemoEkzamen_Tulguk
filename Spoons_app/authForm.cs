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
    public partial class authForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAB206_4\SQLEXPRESS;Initial Catalog=SpoonsDB;Integrated Security=True");
        public authForm()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productsWorkForm productsWorkForm = new productsWorkForm();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select * From Users Where Login='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    SqlCommand command = new SqlCommand("Select Role from Users where Login='"+textBox1.Text+"'", con);
                    string Role = command.ExecuteScalar().ToString();
                    switch (Role)
                    {
                        case "Клиент":
                            MessageBox.Show("Вы вошли как клиент!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            productsWorkForm.Show();
                            break;
                        case "Менеджер":
                            MessageBox.Show("Вы вошли как менеджер!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            productsWorkForm.Show();
                            break;
                        case "Администратор":
                            MessageBox.Show("Вы вошли как администратор!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            productsWorkForm.Show();
                            break;
                    }
                }
                else
                    {
                        MessageBox.Show("Пользователь с введёнными данными не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void authForm_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productsViewForm productsViewForm = new productsViewForm();
            this.Hide();
            productsViewForm.Show();
        }
    }
}
