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
using System.Drawing.Drawing2D;
namespace QlyBanHang
{
    public partial class UC_SanPham: UserControl
    {
        SqlConnection kn =new SqlConnection("Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();


        public UC_SanPham()
        {
            InitializeComponent();
            
        }
        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void thucHienBindingSource()
        {
            adapter = new SqlDataAdapter("SELECT * from SanPham", kn);
            adapter.Fill(ds);
            bs.DataSource=ds.Tables[0];
            dgvSanPham.DataSource = bs;

            txtMaSP.DataBindings.Clear();
            txtMaSP.DataBindings.Add("Text", bs, "MaSP", true, DataSourceUpdateMode.Never);

            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", bs, "SoLuongTon", true, DataSourceUpdateMode.Never);

            txtTenSP.DataBindings.Clear();
            txtTenSP.DataBindings.Add("Text", bs, "TenSP", true, DataSourceUpdateMode.Never);

            txtHang.DataBindings.Clear();
            txtHang.DataBindings.Add("Text", bs, "Hang", true, DataSourceUpdateMode.Never);

            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", bs, "GiaBan", true, DataSourceUpdateMode.Never);

            txtTheLoai.DataBindings.Clear();
            txtTheLoai.DataBindings.Add("Text", bs, "TheLoai", true, DataSourceUpdateMode.Never);

            bindingNavigator1.BindingSource = bs;
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            thucHienBindingSource();
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text.Trim();
            if (bs.DataSource is DataTable dt)
            {
                if (string.IsNullOrEmpty(timkiem))
                {
                    bs.RemoveFilter();
                }
                else
                {
                    // Ví dụ: tìm trong cột TenSanPham
                    bs.Filter = $"TenSP LIKE '%{timkiem}%' OR MaSP LIKE '%{timkiem}%' OR Hang LIKE '%{timkiem}%' OR TheLoai LIKE '%{timkiem}%'";
                }
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            string hang = txtHang.Text.Trim();
            string theLoai = txtTheLoai.Text.Trim();
            decimal giaBan;
            int soLuong;

            if (!decimal.TryParse(txtGiaBan.Text, out giaBan) || !int.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Giá bán hoặc số lượng không hợp lệ!");
                return;
            }

            string query = @"UPDATE SanPham 
                     SET TenSP = @TenSP, Hang = @Hang, TheLoai = @TheLoai, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon
                     WHERE MaSP = @MaSP";

            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSP", tenSP);
                cmd.Parameters.AddWithValue("@Hang", hang);
                cmd.Parameters.AddWithValue("@TheLoai", theLoai);
                cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                cmd.Parameters.AddWithValue("@SoLuongTon", soLuong);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    RefreshSanPham();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần cập nhật.");
                }
            }

        }
        private void RefreshSanPham()
        {
            ds.Clear(); // Xoá dữ liệu cũ
            thucHienBindingSource(); // Load lại
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";

            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        RefreshSanPham(); // Load lại dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm cần xóa.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
                }
            }
        }

    }
}
