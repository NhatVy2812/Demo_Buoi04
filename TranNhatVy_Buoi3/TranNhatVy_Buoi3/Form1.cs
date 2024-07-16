using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVien;
using System.Data.SqlClient;
namespace TranNhatVy_Buoi3
{
    public partial class Form1 : Form
    {
    
        private string connectionString = "Server=A109PC37;Database=KHACHHANG;Integrated Security=True";
        private XuLy dataAccess;

        public Form1()
        {
            InitializeComponent();
            dataAccess = new XuLy(connectionString);
            this.btnLogin.Click += btnLogin_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối khi form được load
            //if (dataAccess.TestConnection())
            //{
            //    MessageBox.Show("Connected to database successfully!");
            //}
            //else
            //{
            //    MessageBox.Show("Failed to connect to database.");
            //}
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Example query to check credentials (use parameters to prevent SQL injection)
            string query = "SELECT * FROM NGUOIDUNG WHERE TEN = 'vy' AND MATKHAU = 123";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            DataTable result = dataAccess.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                // Successful login
                MessageBox.Show("Login successful!");
                this.Hide();

                // Hiển thị Form2
                Form2 form2 = new Form2();
                form2.ShowDialog(); // Sử dụng ShowDialog để đợi Form2 đóng trước khi quay lại Form1

                // Sau khi Form2 đóng, hiển thị lại Form1 (nếu cần)
                this.Show();
            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
