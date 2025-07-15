using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBanHang
{
    public partial class ThemNhaCungCap : Form
    {
        SqlConnection conn = SqlCon.GetConnection();
        public ThemNhaCungCap()
        {
            InitializeComponent();
        }

        private void ThemNCC_Load(object sender, EventArgs e)
        {
            txtMaNCC.Text = TaoMaNCCTuDong();
        }
        private string TaoMaNCCTuDong()
        {
            try
            {
                conn.Open();
                string query = "SELECT TOP 1 MaNCC FROM NhaCungCap ORDER BY MaNCC DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null)
                {
                    string maCuoi = result.ToString().Replace("NCC", "");
                    int so = int.Parse(maCuoi);
                    return "NCC" + (so + 1).ToString("D2");
                }
                else
                {
                    return "NCC01";
                }
            }
            catch
            {
                conn.Close();
                return "NCC01";
            }
        }
        

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string ma = txtMaNCC.Text.Trim();
            string ten = txtTenNCC.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra định dạng email
            if (!Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w{2,}$"))
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn thêm nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                conn.Open();
                string insert = @"INSERT INTO NhaCungCap (MaNCC, TenNCC, SDT, Email)
                                  VALUES (@Ma, @Ten, @SDT, @Email)";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@Ma", ma);
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@Email", email);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!");
                    this.DialogResult = DialogResult.OK; // để UC_NhaCungCap biết cần load lại
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm nhà cung cấp. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

