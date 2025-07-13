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
    public partial class UC_NhanVien : UserControl
    {
        SqlConnection kn = new SqlConnection("Data Source=LAPTOP-TQK\\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs =new BindingSource();
        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            ds.Clear();
            adapter = new SqlDataAdapter("select * from NhanVien", kn);
            adapter.Fill(ds);
            if (!ds.Tables[0].Columns.Contains("HoTen"))
                ds.Tables[0].Columns.Add("HoTen", typeof(string), "HoTenLot + ' ' + Ten");
            bs.DataSource = ds.Tables[0];
            dgvNhanVien.DataSource = bs;
            dgvNhanVien.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            bindingNavigator1.BindingSource = bs;

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text",bs,"Email",true,DataSourceUpdateMode.Never);
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bs, "MaNV", true, DataSourceUpdateMode.Never);
            txtMK.DataBindings.Clear();
            txtMK.DataBindings.Add("Text", bs, "MK", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bs, "SDT", true, DataSourceUpdateMode.Never);
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text",bs,"HoTen",true,DataSourceUpdateMode.Never);
            txtTK.DataBindings.Clear();
            txtTK.DataBindings.Add("Text",bs,"TK",true,DataSourceUpdateMode.Never);
        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null || dgvNhanVien.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();

            
            if (maNV.Equals("AD001", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không thể xóa tài khoản quản trị viên chính chủ",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {maNV}?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNV = @MaNV", conn);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        adapter.Fill(ds); // Tải lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = txtMaNV.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string tk = txtTK.Text.Trim();
            string mk = txtMK.Text.Trim();

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Không xác định được mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dữ liệu gốc từ DataGridView (DataRow hiện tại)
            DataRowView currentRow = (DataRowView)bs.Current;
            string oldEmail = currentRow["Email"].ToString().Trim();
            string oldSDT = currentRow["SDT"].ToString().Trim();
            string oldTK = currentRow["TK"].ToString().Trim();
            string oldMK = currentRow["MK"].ToString().Trim();

            // So sánh
            if (email == oldEmail && sdt == oldSDT && tk == oldTK && mk == oldMK)
            {
                MessageBox.Show("Bạn chưa thay đổi thông tin nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"UPDATE NhanVien 
                                              SET Email = @Email,
                                                  SDT = @SDT,
                                                  TK = @TK,
                                                  MK = @MK
                                              WHERE MaNV = @MaNV", conn);

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@TK", tk);
                    cmd.Parameters.AddWithValue("@MK", mk);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ds.Clear();
                        adapter.Fill(ds); // load lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            ThemNV formThemNV = new ThemNV();
            formThemNV.ShowDialog(); 

            
            UC_NhanVien_Load(null, null); 
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string maCanTim = txttimkiem.Text.Trim();

            if (string.IsNullOrEmpty(maCanTim))
            {
                // Nếu không nhập gì, hiển thị lại toàn bộ dữ liệu
                bs.Filter = "";
            }
            else
            {

                bs.Filter = $"MaNV = '{maCanTim}'";
            }
        }
    }
}
