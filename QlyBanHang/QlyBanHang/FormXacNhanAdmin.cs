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

namespace QlyBanHang
{
    public partial class FormXacNhanAdmin : Form
    {
        public bool LaAdminXacNhan { get; private set; } = false;

        public FormXacNhanAdmin()
        {
            InitializeComponent();
        }

        private void FormXacNhanAdmin_Load(object sender, EventArgs e)
        {

        }

        private void FormXacNhanAdmin_Load_1(object sender, EventArgs e)
        {

        }

        private void btnXN_Click(object sender, EventArgs e)
        {
            string ten = txtTaiKhoan.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();

            using (SqlConnection conn = SqlCon.GetConnection())
            {
                conn.Open();
                string query = "SELECT Quyen FROM NhanVien WHERE TK = @ten AND MK = @matkhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@matkhau", matkhau);

                object result = cmd.ExecuteScalar();

                if (result != null && result.ToString() == "Admin")
                {
                    LaAdminXacNhan = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản không hợp lệ hoặc không có quyền admin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pbDongMat_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu
            pbMoMat.Visible = true;
            pbDongMat.Visible = false;
        }

        private void pbMoMat_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false; // Hiện mật khẩu
            pbDongMat.Visible = true;
            pbMoMat.Visible = false;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
