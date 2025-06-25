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
using System.Data.SqlClient;

namespace QlyBanHang
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTaiKhoan.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            string connStr = "Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLDangNhap;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT Quyen FROM TaiKhoan WHERE TenDangNhap=@user AND MatKhau=@pass";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string quyen = result.ToString();
                        MessageBox.Show("Đăng nhập thành công với quyền: " + quyen);

                        // Mở form chính
                        
                        this.Hide();
                        home home = new home();
                        home.FormClosed += (s, args) => Application.Exit(); // Khi form Home đóng thì thoát app
                        home.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
