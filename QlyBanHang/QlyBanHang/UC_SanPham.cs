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
            
            DataRowView row = (DataRowView)bs.Current;
            if (row != null)
            {
                string oldTenSP = row["TenSP"].ToString();
                string oldHang = row["Hang"].ToString();
                string oldTheLoai = row["TheLoai"].ToString();
                decimal oldGiaBan = Convert.ToDecimal(row["GiaBan"]);
                int oldSoLuong = Convert.ToInt32(row["SoLuongTon"]);

                // 🔄 So sánh dữ liệu
                if (tenSP == oldTenSP &&
                    hang == oldHang &&
                    theLoai == oldTheLoai &&
                    giaBan == oldGiaBan &&
                    soLuong == oldSoLuong)
                {
                    MessageBox.Show("Bạn chưa thay đổi thông tin nào để cập nhật.");
                    return;
                }
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
        private void XoaSanPham(string maSP)
        {
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                conn.Open();

                // Kiểm tra sản phẩm có trong ChiTietDonHang hoặc ChiTietNhap không
                string checkQuery = @"
            SELECT COUNT(*) FROM ChiTietDonHang WHERE MaSP = @MaSP;
            SELECT COUNT(*) FROM ChiTietNhap WHERE MaSP = @MaSP;";

                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MaSP", maSP);

                int countDonHang = 0;
                int countNhap = 0;

                using (SqlDataReader reader = checkCmd.ExecuteReader())
                {
                    if (reader.Read())
                        countDonHang = reader.GetInt32(0);

                    if (reader.NextResult() && reader.Read())
                        countNhap = reader.GetInt32(0);
                }

                // Nếu có dữ liệu liên quan thì cảnh báo
                if (countDonHang > 0 || countNhap > 0)
                {
                    DialogResult warning = MessageBox.Show(
                        "Sản phẩm này đã được dùng trong đơn hàng hoặc nhập hàng.\n" +
                        "Nếu tiếp tục, tất cả dữ liệu liên quan sẽ bị xóa.\nBạn có chắc chắn muốn xóa không?",
                        "Cảnh báo xóa dữ liệu",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (warning != DialogResult.Yes)
                    {
                        conn.Close();
                        return;
                    }

                    // Xóa dữ liệu liên quan trước
                    SqlCommand deleteDetails = new SqlCommand(@"
                DELETE FROM ChiTietDonHang WHERE MaSP = @MaSP;
                DELETE FROM ChiTietNhap WHERE MaSP = @MaSP;", conn);
                    deleteDetails.Parameters.AddWithValue("@MaSP", maSP);
                    deleteDetails.ExecuteNonQuery();
                }

                // Xóa sản phẩm
                SqlCommand deleteSP = new SqlCommand("DELETE FROM SanPham WHERE MaSP = @MaSP", conn);
                deleteSP.Parameters.AddWithValue("@MaSP", maSP);
                int rows = deleteSP.ExecuteNonQuery();

                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    RefreshSanPham(); // Load lại dữ liệu nếu có
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để xóa.");
                }
            }
        }


        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            XoaSanPham(maSP);
        }

    }
}
