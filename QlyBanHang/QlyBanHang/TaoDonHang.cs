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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QlyBanHang
{
    public partial class TaoDonHang : Form
    {
        SqlConnection kn = new SqlConnection("Data Source=LAPTOP-TQK\\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
        private UC_DonHang ucParent;
        public TaoDonHang(UC_DonHang parent)
        {
            InitializeComponent();
            ucParent = parent;
            this.FormClosed += TaoDonHang_FormClosed;
        }
        private void TaoDonHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            ucParent.LoadDonHangData(); // GỌI hàm load dữ liệu
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TaoDonHang_Load(object sender, EventArgs e)
        {
            // Load mã sản phẩm
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT MaSP FROM SanPham", kn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cmbMaSP.DataSource = dt;
            cmbMaSP.DisplayMember = "MaSP";
            cmbMaSP.ValueMember = "MaSP";
            

            TaoBangTamSanPham();
            LoadMaSP();
            cmbMaSP.SelectedIndexChanged += cmbMaSP_SelectedIndexChanged;
            cmbMaKH.SelectedIndexChanged += cmbMaKH_SelectedIndexChanged;

            LoadMaKH();
            LoadMaNV();
            cmbHinhThuc.Items.Add("Online");
            cmbHinhThuc.Items.Add("Offline");
            cmbHinhThuc.SelectedIndex = 0;

            txtMaDon.Text = TaoMaDonHangTuDong();
        }
        private void LoadMaSP()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-TQK\\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True"))
            {
                string query = "SELECT MaSP, TenSP FROM SanPham";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMaSP.DataSource = dt;
                cmbMaSP.DisplayMember = "MaSP";    // Hiện mã trong dropdown
                cmbMaSP.ValueMember = "MaSP";      // Giá trị là mã sản phẩm

                cmbMaSP.SelectedIndex = -1; // Không chọn gì lúc đầu
            }
        }
        private void cmbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaSP.SelectedIndex == -1 || cmbMaSP.SelectedValue == null)
                return;

            string maSP = cmbMaSP.SelectedValue.ToString();

            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-TQK\\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True"))
            {
                string query = "SELECT TenSP, GiaBan FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTenSP.Text = reader["TenSP"].ToString(); 

                    txtGiaBan.Text = reader["GiaBan"].ToString();
                }
                conn.Close();
            }
        }
        DataTable dtSanPhamTam = new DataTable();

        

        private void TaoBangTamSanPham()
        {
            dtSanPhamTam.Columns.Add("MaSP");
            dtSanPhamTam.Columns.Add("TenSP");
            dtSanPhamTam.Columns.Add("SoLuong", typeof(int));
            dtSanPhamTam.Columns.Add("GiaBan", typeof(decimal));
            dtSanPhamTam.Columns.Add("ThanhTien", typeof(decimal));

            dgvSanPham.DataSource = dtSanPhamTam;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbMaSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm.");
                return;
            }

            string maSP = cmbMaSP.SelectedValue.ToString();
            string tenSP = txtTenSP.Text.Trim();

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out decimal giaBan))
            {
                MessageBox.Show("Giá bán không hợp lệ!");
                return;
            }

            //  Kiểm tra số lượng tồn
            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                string query = "SELECT SoLuongTon FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm!");
                    return;
                }

                int tonKho = Convert.ToInt32(result);

                if (soLuong > tonKho)
                {
                    MessageBox.Show("Không đủ số lượng trong kho!");
                    return;
                }
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm này vào đơn hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            decimal thanhTien = soLuong * giaBan;

            // Thêm vào bảng tạm
            dtSanPhamTam.Rows.Add(maSP, tenSP, soLuong, giaBan, thanhTien);

            // Cập nhật tổng tiền
            decimal tong = dtSanPhamTam.AsEnumerable().Sum(row => row.Field<decimal>("ThanhTien"));
            txtTongTien.Text = tong.ToString("N0"); // Ví dụ: 120,000

        }





        // xử lý thông tin đơn hàng
        private void LoadMaKH()
        {
            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaKhachHang FROM KhachHang", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMaKH.DataSource = dt;
                cmbMaKH.DisplayMember = "MaKhachHang";
                cmbMaKH.ValueMember = "MaKhachHang";
                cmbMaKH.SelectedIndex = -1;
            }
        }

        private void LoadMaNV()
        {
            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaNV FROM NhanVien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMaNV.DataSource = dt;
                cmbMaNV.DisplayMember = "MaNV";
                cmbMaNV.ValueMember = "MaNV";
                cmbMaNV.SelectedIndex = -1;
            }
        }
        private void cmbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaKH.SelectedIndex == -1 || cmbMaKH.SelectedValue == null)
                return;

            string maKH = cmbMaKH.SelectedValue.ToString();

            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                string query = "SELECT SDT FROM KhachHang WHERE MaKhachHang = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtSDT.Text = reader["SDT"].ToString();
                    
                }
                conn.Close();
            }
        }

        private void btnTaoDonHang_Click(object sender, EventArgs e)
        {
            
        }



        private void ResetFormDonHang()
        {
            cmbMaKH.SelectedIndex = -1;
            cmbMaNV.SelectedIndex = -1;
            cmbMaSP.SelectedIndex = -1;
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtTongTien.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            cmbHinhThuc.SelectedIndex = -1;
            dtSanPhamTam.Clear();
        }


        private string TaoMaDonHangTuDong()
        {
            string maDonMoi = "DH001"; // Mặc định nếu chưa có đơn hàng nào

            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                conn.Open();
                string query = "SELECT MAX(MaDon) FROM DonHang WHERE MaDon LIKE 'DH%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    string lastMaDon = result.ToString(); // ví dụ: "DH007"
                    string numberPart = lastMaDon.Substring(2); // "007"
                    if (int.TryParse(numberPart, out int number))
                    {
                        number++;
                        maDonMoi = "DH" + number.ToString("D3");
                    }
                }
            }

            return maDonMoi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra có sản phẩm hay chưa
            if (dtSanPhamTam.Rows.Count == 0)
            {
                MessageBox.Show("Đơn hàng chưa có sản phẩm nào.", "Thiếu sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra chọn mã KH, NV và hình thức
            if (cmbMaKH.SelectedIndex == -1 || cmbMaNV.SelectedIndex == -1 || cmbHinhThuc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ khách hàng, nhân viên và hình thức mua.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            string hinhThuc = cmbHinhThuc.SelectedItem.ToString();

            // Nếu là Online thì bắt buộc nhập địa chỉ
            if (hinhThuc == "Online" && string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ giao hàng khi mua Online.", "Thiếu địa chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo mã đơn hàng tự động
            string maDon = TaoMaDonHangTuDong();
            txtMaDon.Text = maDon; // Gán vào textbox cho hiển thị

            string maKH = cmbMaKH.SelectedValue.ToString();
            string maNV = cmbMaNV.SelectedValue.ToString();
            string sdt = txtSDT.Text.Trim();
            string diaChi = (hinhThuc == "Online") ? txtDiaChi.Text.Trim() : ""; // Nếu offline thì bỏ địa chỉ
            DateTime ngayMua = DateTime.Now;

            decimal tongTien = dtSanPhamTam.AsEnumerable().Sum(row => row.Field<decimal>("ThanhTien"));

            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Thêm đơn hàng
                    string queryDon = @"
                INSERT INTO DonHang (MaDon, MaKhachHang, MaNV, NgayMua, TongTien, DiaChi, SDT, HinhThuc)
                VALUES (@MaDon, @MaKH, @MaNV, @NgayMua, @TongTien, @DiaChi, @SDT, @HinhThuc)";

                    SqlCommand cmdDon = new SqlCommand(queryDon, conn, tran);
                    cmdDon.Parameters.AddWithValue("@MaDon", maDon);
                    cmdDon.Parameters.AddWithValue("@MaKH", maKH);
                    cmdDon.Parameters.AddWithValue("@MaNV", maNV);
                    cmdDon.Parameters.AddWithValue("@NgayMua", ngayMua);
                    cmdDon.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdDon.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmdDon.Parameters.AddWithValue("@SDT", sdt);
                    cmdDon.Parameters.AddWithValue("@HinhThuc", hinhThuc);
                    cmdDon.ExecuteNonQuery();

                    // Thêm chi tiết đơn hàng
                    foreach (DataRow row in dtSanPhamTam.Rows)
                    {
                        string queryChiTiet = @"
        INSERT INTO ChiTietDonHang (MaDon, MaSP, SoLuong, GiaBan)
        VALUES (@MaDon, @MaSP, @SoLuong, @GiaBan)";

                        SqlCommand cmdCT = new SqlCommand(queryChiTiet, conn, tran);
                        cmdCT.Parameters.AddWithValue("@MaDon", maDon);
                        cmdCT.Parameters.AddWithValue("@MaSP", row["MaSP"]);
                        cmdCT.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
                        cmdCT.Parameters.AddWithValue("@GiaBan", row["GiaBan"]);
                        cmdCT.ExecuteNonQuery();

                        // Cập nhật số lượng tồn
                        string updateSLQuery = @"
        UPDATE SanPham
        SET SoLuongTon = SoLuongTon - @SoLuong
        WHERE MaSP = @MaSP";

                        SqlCommand cmdUpdateSL = new SqlCommand(updateSLQuery, conn, tran);
                        cmdUpdateSL.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
                        cmdUpdateSL.Parameters.AddWithValue("@MaSP", row["MaSP"]);
                        cmdUpdateSL.ExecuteNonQuery();
                    }



                    tran.Commit();
                    MessageBox.Show("Tạo đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormDonHang();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi tạo đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

    }
}
