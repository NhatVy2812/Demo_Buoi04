using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVien;
namespace UC_DSDN
{
    public partial class UserControl1: UserControl
    {
        private XuLy dataAccess;
        private DataTable dataTableUsers;
        public UserControl1()
        {
            InitializeComponent();
            dataAccess = new XuLy("Server=A109PC37;Database=KHACHHANG;Integrated Security=True"); // Thay đổi chuỗi kết nối phù hợp
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {
            // Query để lấy danh sách người dùng
            string query = "SELECT * FROM NGUOIDUNG";

            // Thực thi query và nhận DataTable từ XuLy
            dataTableUsers = dataAccess.ExecuteQuery(query);

            // Hiển thị dữ liệu lên DataGridView
            dataGridView1.DataSource = dataTableUsers;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

        }
    }
}
