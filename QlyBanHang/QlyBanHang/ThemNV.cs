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
    public partial class ThemNV : Form
    {
        SqlConnection kn = SqlCon.GetConnection();
        public ThemNV()
        {
            InitializeComponent();
        }

        private void ThemNV_Load(object sender, EventArgs e)
        {
           
            cmbLoai.Items.Clear();
            cmbLoai.Items.Add("Admin");
            cmbLoai.Items.Add("Nhân viên");
            cmbLoai.SelectedIndex = 0; // Mặc định chọn Admin

            // Gắn sự kiện
            cmbLoai.SelectedIndexChanged += cmbLoai_SelectedIndexChanged;

            TaoMaNhanVienTuDong(); // Tạo mã đầu tiên theo lựa chọn mặc định
        }
        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaoMaNhanVienTuDong();
        }
        private void TaoMaNhanVienTuDong()
{
    string prefix = cmbLoai.SelectedItem.ToString() == "Admin" ? "AD" : "NV";
    string maMoi = prefix + "001";

    using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT MAX(MaNV) FROM NhanVien WHERE MaNV LIKE @Prefix + '%'", conn);
        cmd.Parameters.AddWithValue("@Prefix", prefix);

        object result = cmd.ExecuteScalar();
        if (result != DBNull.Value && result != null)
        {
            string maCu = result.ToString(); // VD: AD005
            int so = int.Parse(maCu.Substring(2));
            maMoi = prefix + (so + 1).ToString("D3");
        }

        txtMaNV.Text = maMoi;
    }
}


        private bool KiemTraEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }


        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim(); 
            string hoTenLot = txtHoLot.Text.Trim(); 
            string ten = txtTen.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string tk = txtTK.Text.Trim();
            string mk = txtMK.Text.Trim();
            string loai = cmbLoai.SelectedItem.ToString(); 

            if (!KiemTraEmail(email))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng dùng địa chỉ @gmail.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                conn.Open();
                // Kiểm tra trùng tài khoản
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE TK = @TK", conn);
                checkCmd.Parameters.AddWithValue("@TK", tk);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE Email = @Email", conn);
                checkEmail.Parameters.AddWithValue("@Email", email);
                if ((int)checkEmail.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Email đã tồn tại. Vui lòng nhập email khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

             
                SqlCommand checkSDT = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE SDT = @SDT", conn);
                checkSDT.Parameters.AddWithValue("@SDT", sdt);
                if ((int)checkSDT.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập số khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SqlCommand cmd = new SqlCommand(@"INSERT INTO NhanVien(MaNV, HoTenLot, Ten, Email, SDT, TK, MK, Quyen)
                                          VALUES(@MaNV, @HoTenLot, @Ten, @Email, @SDT, @TK, @MK, @Quyen)", conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@HoTenLot", hoTenLot);
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@TK", tk);
                cmd.Parameters.AddWithValue("@MK", mk);
                cmd.Parameters.AddWithValue("@Quyen", loai);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
