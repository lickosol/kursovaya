using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ЛЕС;Initial Catalog=pharmacy;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [препараты]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["id_препарата"]) + "      " + Convert.ToString(sqlReader["название"]));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void close_MouseLeave_1(object sender, EventArgs e)
        {
            close.ForeColor = Color.Red;
        }

        private void close_MouseEnter_1(object sender, EventArgs e)
        {
            close.ForeColor = Color.White;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (lable_error.Visible)
                lable_error.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [препараты] (id_препарата, название)VALUES(@id_препарата, @название)", sqlConnection);

                command.Parameters.AddWithValue("id_препарата", textBox1.Text);
                command.Parameters.AddWithValue("название", textBox2.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                lable_error.Visible = true;
                lable_error.Text = "EMPTY, like my soul...";
            }
        }

        private async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [препараты]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["id_препарата"]) + "      " + Convert.ToString(sqlReader["название"]));
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
    }
}
