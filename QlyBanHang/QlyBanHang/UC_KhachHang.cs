using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QlyBanHang
{
    public partial class UC_KhachHang: UserControl
    {
        SqlConnection kn = SqlCon.GetConnection();
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public UC_KhachHang()
        {
            InitializeComponent();
        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }

        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from KhachHang", kn);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            dgvKhachHang.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
            dgvKhachHang.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            txtChiTieu.DataBindings.Clear();
            txtChiTieu.DataBindings.Add("Text", bs, "TongChiTieu", true, DataSourceUpdateMode.Never);
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text",bs,"Email",true,DataSourceUpdateMode.Never);
            txtHang.DataBindings.Clear();
           txtHang.DataBindings.Add("Text",bs,"ThuHang",true,DataSourceUpdateMode.Never);
            txtKH.DataBindings.Clear();
            txtKH.DataBindings.Add("Text",bs,"MaKhachHang",true,DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text",bs,"SDT",true,DataSourceUpdateMode.Never);
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text",bs,"TenKH",true,DataSourceUpdateMode.Never);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            ThemKH themKH = new ThemKH();
            if (themKH.ShowDialog() == DialogResult.OK)
            {
                ds.Clear();
                adapter.Fill(ds);
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string maKH = txtKH.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string thuHang = txtHang.Text.Trim();

            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                kn.Open();
                string sql = @"UPDATE KhachHang 
                       SET TenKH = @TenKH, SDT = @SDT, Email = @Email
                       WHERE MaKhachHang = @MaKH";
                SqlCommand cmd = new SqlCommand(sql, kn);
                cmd.Parameters.AddWithValue("@TenKH", tenKH);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds.Clear();
                    adapter.Fill(ds); // Load lại dữ liệu sau khi sửa
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                kn.Close();
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.Quyen != "Admin")
            {
                FormXacNhanAdmin xacNhan = new FormXacNhanAdmin();
                xacNhan.ShowDialog();

                if (!xacNhan.LaAdminXacNhan)
                {
                    MessageBox.Show("Thao tác bị huỷ vì không có xác nhận admin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            string maKH = txtKH.Text.Trim();

            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cảnh báo đầu tiên: mất hạng thành viên
            DialogResult warning = MessageBox.Show(
                "⚠️ Việc xóa khách hàng sẽ làm mất toàn bộ thông tin, bao gồm cả hạng thành viên.\nBạn có chắc chắn muốn tiếp tục không?",
                "Cảnh báo quan trọng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (warning == DialogResult.No)
                return;

            // Xác nhận xóa lần 2
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa khách hàng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            try
            {
                kn.Open();

                string sql = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKH";
                SqlCommand cmd = new SqlCommand(sql, kn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds.Clear();
                    adapter.Fill(ds); // Load lại dữ liệu
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Lỗi ràng buộc FK
                {
                    MessageBox.Show("Không thể xóa khách hàng do có liên kết với dữ liệu khác.", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                kn.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string tuKhoa = toolStripTextBox1.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                ds.Clear();
                adapter.Fill(ds);
                bs.DataSource = ds.Tables[0]; 
                return;
            }

            string sql = @"SELECT * FROM KhachHang 
                   WHERE MaKhachHang LIKE @TuKhoa OR TenKH LIKE @TuKhoa";

            try
            {
                SqlDataAdapter timAdapter = new SqlDataAdapter(sql, kn);
                timAdapter.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                DataTable dtTim = new DataTable();
                timAdapter.Fill(dtTim);

                if (dtTim.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào phù hợp.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                bs.DataSource = dtTim;
                dgvKhachHang.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click(sender, e); // Gọi lại hàm tìm kiếm
                e.SuppressKeyPress = true; // Không cho tiếng 'beep' khi ấn Enter
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
