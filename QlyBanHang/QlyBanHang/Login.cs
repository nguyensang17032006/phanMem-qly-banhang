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
            if (txtTaiKhoan.Text == string.Empty)
            {
                MessageBox.Show("Hãy nhập tài khoản của bạn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtMatKhau.Text == string.Empty)
            {
                MessageBox.Show("Hãy nhập mật khẩu của bạn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string user = txtTaiKhoan.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            string connStr = "Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT HoTenLot + ' ' + Ten AS HoTenDayDu, Quyen FROM NhanVien WHERE TK = @user AND MK = @pass";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lưu vào class toàn cục
                            TaiKhoan.HoTen = reader["HoTenDayDu"].ToString();
                            TaiKhoan.Quyen = reader["Quyen"].ToString();

                            MessageBox.Show("Đăng nhập thành công với quyền: " + TaiKhoan.Quyen);

                            this.Hide();
                            home home = new home();
                            home.FormClosed += (s, args) => Application.Exit();
                            home.Show();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                        }
                    }
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblEyeClose_Click(object sender, EventArgs e)
        {
            lblEyeClose.Visible = false;
            lblEyeShow.Visible = true;
            txtMatKhau.PasswordChar = '\0';
        }

        private void lblEyeShow_Click(object sender, EventArgs e)
        {
            lblEyeClose.Visible = true; 
            lblEyeShow.Visible= false;
            txtMatKhau.PasswordChar = '*';
        }
    }
}
