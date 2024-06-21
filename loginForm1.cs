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
    public partial class loginForm1 : Form
    {
        SqlConnection sqlConnection;
        public loginForm1()
        {
            InitializeComponent();
        }

        private async void label1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ЛЕС;Initial Catalog=pharmacy;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [заказы]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.ForeColor = Color.White;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.ForeColor = Color.Red;
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            String login = loginField.Text;

            this.Hide();
            kursovaya.Form1 form1 = new Form1();
            form1.Show();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
