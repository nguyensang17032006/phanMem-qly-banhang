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
    public partial class ThemSanPham : Form
    {
        SqlConnection kn = SqlCon.GetConnection();
        public ThemSanPham()
        {
            InitializeComponent();
        }

        private void ThemSanPham_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
        }

        private void LoadNhaCungCap()
        {
            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                string query = "SELECT MaNCC, TenNCC FROM NhaCungCap";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNhaCungCap.DataSource = dt;
                cmbNhaCungCap.DisplayMember = "TenNCC";
                cmbNhaCungCap.ValueMember = "MaNCC";
                cmbNhaCungCap.SelectedIndex = -1;
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            
            string theLoai = txtTheLoai.Text.Trim();

            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!");
                return;
            }

            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Giá bán không hợp lệ hoặc nhỏ hơn 0!");
                return;
            }

            if (cmbNhaCungCap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            string maNCC = cmbNhaCungCap.SelectedValue.ToString();
            int soLuong = 0;

            try
            {
                kn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP", kn);
                checkCmd.Parameters.AddWithValue("@MaSP", maSP);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng nhập mã khác!");
                    kn.Close();
                    return;
                }

                string query = @"INSERT INTO SanPham (MaSP, TenSP, Hang, TheLoai, GiaBan, SoLuongTon)
                         VALUES (@MaSP, @TenSP, @Hang, @TheLoai, @GiaBan, @SoLuongTon)";

                SqlCommand cmd = new SqlCommand(query, kn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                cmd.Parameters.AddWithValue("@TenSP", tenSP);
                cmd.Parameters.AddWithValue("@Hang", maNCC);
                cmd.Parameters.AddWithValue("@TheLoai", theLoai);
                cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                cmd.Parameters.AddWithValue("@SoLuongTon", soLuong);
               

                int rows = cmd.ExecuteNonQuery();
                kn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                kn.Close();
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
   
