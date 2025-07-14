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
    public partial class ThemKH : Form
    {
        SqlConnection conn = SqlCon.GetConnection();
        public ThemKH()
        {
            InitializeComponent();
        }

        private void ThemKH_Load(object sender, EventArgs e)
        {
            
        }
        private string TaoMaKHTuDong()
        {
            try
            {
                conn.Open();
                string query = "SELECT TOP 1 MaKhachHang FROM KhachHang ORDER BY MaKhachHang DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null)
                {
                    string maCuoi = result.ToString().Replace("KH0", "");
                    int so = int.Parse(maCuoi);
                    return "KH0" + (so + 1).ToString("D2");
                }
                else
                {
                    return "KH001";
                }
            }
            catch
            {
                conn.Close();
                return "KH001";
            }
        }
        

        

        private void ThemNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaKH.Text = TaoMaKHTuDong();
            
        }

        private void btnThemKH_Click_1(object sender, EventArgs e)
        {
            string ma = txtMaKH.Text.Trim();
            string ten = txtTenKH.Text.Trim();
            string sdt = txtSDTKH.Text.Trim();
            string email = txtEmailKH.Text.Trim();

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

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn thêm khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                conn.Open();
                string insert = @"INSERT INTO KhachHang (MaKhachHang, TenKH, SDT, Email)
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
                    MessageBox.Show("Thêm khách hàng thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm khách hàng. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }
    }
}
    

