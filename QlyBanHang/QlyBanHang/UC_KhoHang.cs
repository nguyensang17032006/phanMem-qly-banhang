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
    public partial class UC_KhoHang : UserControl
    {
        SqlConnection kn = SqlCon.GetConnection();
        SqlDataAdapter adapter;
        DataSet ds=new DataSet();
        BindingSource bs= new BindingSource();

        public UC_KhoHang()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            string maNhap= dgvTTNhap.CurrentRow.Cells["MaNhap"].Value.ToString();
            ChiTietNhapHang chiTietNhapHang = new ChiTietNhapHang(maNhap);
            chiTietNhapHang.ShowDialog();
        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }

        private void UC_KhoHang_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from PhieuNhap", kn);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            dgvTTNhap.DataSource = bs;
            dgvTTNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", bs, "MaNCC", true,DataSourceUpdateMode.Never);
            txtMaNhap.DataBindings.Clear();
            txtMaNhap.DataBindings.Add("Text", bs, "MaNhap", true,DataSourceUpdateMode.Never);
            txtTotal.DataBindings.Clear();
            txtTotal.DataBindings.Add("Text", bs, "TongTien", true, DataSourceUpdateMode.Never);
            dtpNgayNhap.DataBindings.Clear();
            dtpNgayNhap.DataBindings.Add("Value", bs, "NgayNhap", true, DataSourceUpdateMode.Never);
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.Quyen != "admin")
            {
                FormXacNhanAdmin xacNhan = new FormXacNhanAdmin();
                xacNhan.ShowDialog();

                if (!xacNhan.LaAdminXacNhan)
                {
                    MessageBox.Show("Thao tác bị huỷ vì không có xác nhận admin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (dgvTTNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa!");
                return;
            }

            // Lấy mã phiếu nhập từ dòng đang chọn
            string maNhap = dgvTTNhap.CurrentRow.Cells["MaNhap"].Value.ToString();

            // Xác nhận người dùng có chắc chắn muốn xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu nhập {maNhap} không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        // Xóa chi tiết phiếu nhập trước
                        SqlCommand cmdCT = new SqlCommand("DELETE FROM ChiTietNhap WHERE MaNhap = @MaNhap", conn, tran);

                        cmdCT.Parameters.AddWithValue("@MaNhap", maNhap);
                        cmdCT.ExecuteNonQuery();

                        // Xóa phiếu nhập
                        SqlCommand cmdPN = new SqlCommand("DELETE FROM PhieuNhap WHERE MaNhap = @MaNhap", conn, tran);
                        cmdPN.Parameters.AddWithValue("@MaNhap", maNhap);
                        cmdPN.ExecuteNonQuery();

                        tran.Commit();
                        MessageBox.Show("Xóa phiếu nhập thành công!");

                        // Cập nhật lại giao diện
                        ds.Clear();
                        adapter.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            NhapHang formNhap = new NhapHang();
            formNhap.ShowDialog(); // Mở form dưới dạng dialog
                                   // Sau khi đóng có thể load lại danh sách nếu cần
            UC_KhoHang_Load(null, null); // Gọi lại để load dữ liệu
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            string maCanTim = txtTimKiem.Text.Trim(); // LẤY từ ToolStripTextBox (không phải button)

            if (string.IsNullOrEmpty(maCanTim))
            {
                bs.RemoveFilter(); // Hiển thị lại tất cả
            }
            else
            {
                bs.Filter = $"MaNhap = '{maCanTim}'"; ;
            }
        }

    }
}

