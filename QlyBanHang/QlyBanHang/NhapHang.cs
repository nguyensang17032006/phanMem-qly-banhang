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
    public partial class NhapHang : Form
    {
        SqlConnection kn = SqlCon.GetConnection();
        public NhapHang()
        {
            InitializeComponent();
        }
        private void NhapHang_Load(object sender, EventArgs e)
        {
            txtMaNhap.Text = TaoMaPhieuNhapTuDong();
            dtpNgayNhap.Value = DateTime.Now;
            dgvNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadMaNCC();
            TaoBangTamNhap();
            cbSanPham.SelectedIndexChanged += cbSanPham_SelectedIndexChanged;

        }

        private string TaoMaPhieuNhapTuDong()
        {
            string maMoi = "PN001";

            using (SqlConnection conn = SqlCon.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MAX(MaNhap) FROM PhieuNhap WHERE MaNhap LIKE 'PN%'", conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    string maCu = result.ToString(); // PN003
                    int so = int.Parse(maCu.Substring(2)); // 3
                    maMoi = "PN" + (so + 1).ToString("D3");
                }
            }

            return maMoi;
        }
        private void LoadMaNCC()
        {
            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaNCC,TenNCC FROM NhaCungCap", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNCC.DataSource = dt;
                cmbNCC.DisplayMember = "MaNCC";
                cmbNCC.ValueMember = "TenNCC";
            }
        }

        

        private void cbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedIndex == -1 || cbSanPham.SelectedValue == null) return;

            DataRowView drv = (DataRowView)cbSanPham.SelectedItem;
            txtTenSP.Text = drv["TenSP"].ToString();
            txtTheLoai.Text = drv["TheLoai"].ToString();
            txtGiaBan.Text = drv["GiaBan"].ToString();
        }

        DataTable dtChiTietNhap = new DataTable();

        private void TaoBangTamNhap()
        {
            dtChiTietNhap.Columns.Add("MaSP");
            dtChiTietNhap.Columns.Add("TenSP");
            dtChiTietNhap.Columns.Add("TheLoai");
            dtChiTietNhap.Columns.Add("SoLuong", typeof(int));
            dtChiTietNhap.Columns.Add("DonGia", typeof(decimal));
            dtChiTietNhap.Columns.Add("ThanhTien", typeof(decimal));

            dgvNhap.DataSource = dtChiTietNhap;
        }


        private void grb_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtChiTietNhap.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm!");
                return;
            }
            if (cmbNCC.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                return;
            }

            string maNhap = txtMaNhap.Text;
            string tenNCC = cmbNCC.SelectedValue.ToString();
            string maNCC = "";

            using (SqlConnection conn = SqlCon.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaNCC FROM NhaCungCap WHERE TenNCC = @TenNCC", conn);
                cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    maNCC = result.ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã NCC!");
                    return;
                }
            }
            DateTime ngayNhap = dtpNgayNhap.Value;
            decimal tongTien = dtChiTietNhap.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));

            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Phiếu nhập
                    SqlCommand cmdPN = new SqlCommand(@"INSERT INTO PhieuNhap(MaNhap, MaNCC, NgayNhap, TongTien)
                                                VALUES(@MaNhap, @MaNCC, @NgayNhap, @TongTien)", conn, tran);
                    cmdPN.Parameters.AddWithValue("@MaNhap", maNhap);
                    cmdPN.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmdPN.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                    cmdPN.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdPN.ExecuteNonQuery();

                    // Chi tiết nhập & cập nhật kho
                    foreach (DataRow row in dtChiTietNhap.Rows)
                    {
                        string maSP = row["MaSP"].ToString();
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        decimal DonGia = Convert.ToDecimal(row["DonGia"]);

                        
                        SqlCommand cmdCT = new SqlCommand(@"INSERT INTO ChiTietNhap(MaNhap, MaSP, SoLuong, DonGia)
                            VALUES(@MaNhap, @MaSP, @SoLuong, @DonGia)", conn, tran);

                        cmdCT.Parameters.AddWithValue("@MaNhap", maNhap);
                        cmdCT.Parameters.AddWithValue("@MaSP", maSP);
                        cmdCT.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", DonGia);
                        cmdCT.ExecuteNonQuery();

                        // Tăng số lượng tồn
                        //SqlCommand cmdUpdate = new SqlCommand(@"UPDATE SanPham
                        //                                SET SoLuongTon = SoLuongTon + @SoLuong
                        //                                WHERE MaSP = @MaSP", conn, tran);
                        //cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
                        //cmdUpdate.Parameters.AddWithValue("@MaSP", maSP);
                        //cmdUpdate.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("Tạo phiếu nhập thành công!");

                    // Reset
                    dtChiTietNhap.Clear();
                    txtTongTien.Clear();
                    txtMaNhap.Text = TaoMaPhieuNhapTuDong();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void cmbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNCC.SelectedIndex == -1 || cmbNCC.SelectedItem == null)
                return;

            // Clear cbSanPham trước khi load mới
            cbSanPham.DataSource = null;
            cbSanPham.Items.Clear();  // Cho chắc

            // Lấy TenNCC từ dòng được chọn
            DataRowView drv = (DataRowView)cmbNCC.SelectedItem;
            string tenNCC = drv["TenNCC"].ToString();
            txtTenHang.Text = tenNCC;

            // Lọc sản phẩm theo tên nhà cung cấp (Hang)
            SqlConnection conn = SqlCon.GetConnection();
            string query = "SELECT MaSP, TenSP, TheLoai, GiaBan FROM SanPham WHERE Hang = @TenNCC";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Gán dữ liệu mới
            cbSanPham.DataSource = dt;
            cbSanPham.DisplayMember = "MaSP";
            cbSanPham.ValueMember = "MaSP";
            txtTenSP.Clear();
            txtTheLoai.Clear();

            if (cbSanPham.Items.Count > 0)
            {
                cbSanPham.SelectedIndex = 0; // Chọn sản phẩm đầu tiên
                cbSanPham_SelectedIndexChanged(null, null); // Gọi sự kiện thủ công để hiển thị thông tin
            }
        }


        private void cbSanPham_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedIndex == -1) return;

            string maSP = cbSanPham.SelectedValue.ToString();
            string tenSP = txtTenSP.Text;
            string theLoai = txtTheLoai.Text;

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            if (!decimal.TryParse(txtGiaNhap.Text, out decimal DonGia) || DonGia <= 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ!");
                return;
            }

            // Kiểm tra giá nhập không được cao hơn giá bán
            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT GiaBan FROM SanPham WHERE MaSP = @MaSP", conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                object giaBanObj = cmd.ExecuteScalar();
                if (giaBanObj != null && decimal.TryParse(giaBanObj.ToString(), out decimal giaBan))
                {
                    if (DonGia > giaBan)
                    {
                        MessageBox.Show($"Giá nhập ({DonGia:N0}) không được lớn hơn giá bán ({giaBan:N0})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            //  Kiểm tra nếu sản phẩm đã có trong bảng => cập nhật
            bool daTonTai = false;
            foreach (DataRow row in dtChiTietNhap.Rows)
            {
                if (row["MaSP"].ToString() == maSP)
                {
                    int slCu = Convert.ToInt32(row["SoLuong"]);
                    row["SoLuong"] = slCu + soLuong;
                    row["DonGia"] = DonGia; // Nếu muốn cập nhật giá mới
                    row["ThanhTien"] = (slCu + soLuong) * DonGia;
                    daTonTai = true;
                    break;
                }
            }

            // Nếu chưa có thì thêm mới
            if (!daTonTai)
            {
                decimal thanhTien = soLuong * DonGia;
                dtChiTietNhap.Rows.Add(maSP, tenSP, theLoai, soLuong, DonGia, thanhTien);
                txtSoLuong.Clear();
                txtGiaNhap.Clear();
            }

            // Tính tổng tiền
            decimal tong = dtChiTietNhap.AsEnumerable().Sum(row => row.Field<decimal>("ThanhTien"));
            txtTongTien.Text = tong.ToString("N0");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhap.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Xóa dòng được chọn
                    dgvNhap.Rows.RemoveAt(dgvNhap.CurrentRow.Index);

                    // Cập nhật lại tổng tiền
                    decimal tong = dtChiTietNhap.AsEnumerable().Sum(row => row.Field<decimal>("ThanhTien"));
                    txtTongTien.Text = tong.ToString("N0");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.");
            }
        }

    }
}
