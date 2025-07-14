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
    public partial class UC_NhaCungCap : UserControl
    {
        SqlConnection conn = SqlCon.GetConnection();
        SqlDataAdapter adapter;
        DataSet ds=new DataSet();
        BindingSource bs=new BindingSource();
        
        public UC_NhaCungCap()
        {
            InitializeComponent();
        }

        private void UC_NhaCungCap_Load(object sender, EventArgs e)
        {
            adapter =new SqlDataAdapter("select * from NhaCungCap",conn);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            dgvNCC.DataSource = bs;
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bs, "Email", true,DataSourceUpdateMode.Never);
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", bs, "MaNCC", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Clear();
            txtTenNCC.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bs, "SDT", true, DataSourceUpdateMode.Never);
            txtTenNCC.DataBindings.Add("Text", bs, "TenNCC", true, DataSourceUpdateMode.Never);
            bindingNavigator1.BindingSource = bs;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            ThemNhaCungCap themNCC = new ThemNhaCungCap();
            if (themNCC.ShowDialog() == DialogResult.OK)
            {
                ds.Clear(); // Xoá dữ liệu cũ
                adapter.Fill(ds); // Load lại dữ liệu
            }
        }
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text.Trim();
            string tenNCC = txtTenNCC.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(maNCC) || string.IsNullOrEmpty(tenNCC) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra định dạng email
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w\.-]+@[\w\.-]+\.\w{2,}$"))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }

            // Lấy dữ liệu cũ từ BindingSource
            DataRowView currentRow = (DataRowView)bs.Current;
            if (currentRow == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu để sửa.");
                return;
            }

            string oldTenNCC = currentRow["TenNCC"].ToString();
            string oldEmail = currentRow["Email"].ToString();
            string oldSDT = currentRow["SDT"].ToString();

            // 🔍 Kiểm tra thay đổi
            if (tenNCC == oldTenNCC && email == oldEmail && sdt == oldSDT)
            {
                MessageBox.Show("Bạn chưa thay đổi thông tin nào để cập nhật.");
                return;
            }

            // ✅ Hỏi xác nhận
            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn cập nhật thông tin nhà cung cấp này?",
                                                   "Xác nhận sửa",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Thực hiện cập nhật
            string query = @"UPDATE NhaCungCap 
                     SET TenNCC = @TenNCC, Email = @Email, SDT = @SDT 
                     WHERE MaNCC = @MaNCC";

            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        ds.Clear(); // Load lại dữ liệu
                        adapter.Fill(ds);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhà cung cấp để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }





        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text.Trim();

            if (string.IsNullOrEmpty(maNCC))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhà cung cấp {maNCC}?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                connection.Open();

                // (Tuỳ chọn) Kiểm tra nếu NCC liên kết dữ liệu khác (ví dụ trong bảng Nhập hàng...) ở đây

                string deleteQuery = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        ds.Clear();
                        adapter.Fill(ds);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhà cung cấp để xóa.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maCanTim = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(maCanTim))
            {
                // Nếu không nhập gì, hiển thị lại toàn bộ dữ liệu
                bs.Filter = "";
            }
            else
            {

                bs.Filter = $"MaNCC = '{maCanTim}'";
            }
        }
    }
}
