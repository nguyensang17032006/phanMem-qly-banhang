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
    public partial class UC_DonHang : UserControl
    {
        SqlConnection kn = SqlCon.GetConnection();
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public UC_DonHang()
        {
            InitializeComponent();
            

        }
        public void LoadDonHangData()
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM DonHang", kn);

                ds.Clear(); // xoá toàn bộ dữ liệu cũ để tránh lặp
                adapter.Fill(ds);

                bs.DataSource = ds.Tables[0];
                dgvDonHang.DataSource = bs;
                dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load đơn hàng: " + ex.Message);
            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            TaoDonHang taoDonHang = new TaoDonHang(this);
            taoDonHang.ShowDialog();

        }


        private void UC_DonHang_Load(object sender, EventArgs e)
        {
            LoadDonHangData();
            adapter = new SqlDataAdapter("select * from DonHang", kn);
         
            bs.DataSource = ds.Tables[0];
            dgvDonHang.DataSource = bs;
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bindingNavigator1.BindingSource = bs;
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bs, "DiaChi", true, DataSourceUpdateMode.Never);
            txtHinhThuc.DataBindings.Clear();
            txtHinhThuc.DataBindings.Add("Text", bs, "HinhThuc", true, DataSourceUpdateMode.Never);
            txtMaDon.DataBindings.Clear();
            txtMaDon.DataBindings.Add("Text", bs, "MaDon", true, DataSourceUpdateMode.Never);
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", bs, "MaKhachHang", true, DataSourceUpdateMode.Never);
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bs, "MaNV", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bs, "SDT", true, DataSourceUpdateMode.Never);
            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", bs, "TongTien", true, DataSourceUpdateMode.Never);
            dtpNgayMua.DataBindings.Clear();
            dtpNgayMua.DataBindings.Add("Value", bs, "NgayMua", true, DataSourceUpdateMode.Never);
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            string maDH = dgvDonHang.CurrentRow.Cells["MaDon"].Value.ToString();
            ChiTietDonHang chiTietDonHang = new ChiTietDonHang(maDH);
            chiTietDonHang.ShowDialog();
        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            // Kiểm tra dòng được chọn
            if (dgvDonHang.CurrentRow == null || dgvDonHang.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng hợp lệ để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã đơn hàng
            string maDon = dgvDonHang.CurrentRow.Cells["MaDon"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(maDon))
            {
                MessageBox.Show("Không thể xác định mã đơn hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn hàng {maDon} không?",
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

                    // Xóa chi tiết đơn hàng trước
                    string deleteChiTiet = "DELETE FROM ChiTietDonHang WHERE MaDon = @MaDon";
                    SqlCommand cmdCT = new SqlCommand(deleteChiTiet, conn);
                    cmdCT.Parameters.AddWithValue("@MaDon", maDon);
                    cmdCT.ExecuteNonQuery();

                    // Xóa đơn hàng
                    string deleteDon = "DELETE FROM DonHang WHERE MaDon = @MaDon";
                    SqlCommand cmdDon = new SqlCommand(deleteDon, conn);
                    cmdDon.Parameters.AddWithValue("@MaDon", maDon);
                    int rowsAffected = cmdDon.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đã xóa đơn hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDonHangData(); // Cập nhật lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               
                bs.Filter = $"MaDon = '{maCanTim}'";
            }
        }
    }
}

