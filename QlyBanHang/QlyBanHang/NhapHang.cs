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
            LoadMaSP();
            TaoBangTamNhap();
            cmbMaSP.SelectedIndexChanged += cmbMaSP_SelectedIndexChanged;
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaNCC FROM NhaCungCap", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNCC.DataSource = dt;
                cmbNCC.DisplayMember = "MaNCC";
                cmbNCC.ValueMember = "MaNCC";
                cmbNCC.SelectedIndex = -1;
            }
        }

        private void LoadMaSP()
        {
            using (SqlConnection conn = new SqlConnection(kn.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaSP, TenSP, TheLoai FROM SanPham", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMaSP.DataSource = dt;
                cmbMaSP.DisplayMember = "MaSP";
                cmbMaSP.ValueMember = "MaSP";
                cmbMaSP.SelectedIndex = -1;
            }
        }

        private void cmbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaSP.SelectedIndex == -1 || cmbMaSP.SelectedValue == null) return;

            DataRowView drv = (DataRowView)cmbMaSP.SelectedItem;
            txtTenSP.Text = drv["TenSP"].ToString();
            txtTheLoai.Text = drv["TheLoai"].ToString();
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
            if (cmbMaSP.SelectedIndex == -1) return;

            string maSP = cmbMaSP.SelectedValue.ToString();
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


            decimal thanhTien = soLuong * DonGia;
            dtChiTietNhap.Rows.Add(maSP, tenSP, theLoai, soLuong, DonGia, thanhTien);

            // Tính tổng tiền
            decimal tong = dtChiTietNhap.AsEnumerable().Sum(row => row.Field<decimal>("ThanhTien"));
            txtTongTien.Text = tong.ToString("N0");
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
            string maNCC = cmbNCC.SelectedValue.ToString();
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
                        SqlCommand cmdUpdate = new SqlCommand(@"UPDATE SanPham
                                                        SET SoLuongTon = SoLuongTon + @SoLuong
                                                        WHERE MaSP = @MaSP", conn, tran);
                        cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdUpdate.Parameters.AddWithValue("@MaSP", maSP);
                        cmdUpdate.ExecuteNonQuery();
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
    }
}
