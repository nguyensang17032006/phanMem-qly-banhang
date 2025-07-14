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
    public partial class ChiTietNhapHang : Form
    {
        SqlConnection kn = SqlCon.GetConnection();
        SqlDataAdapter adapter;
        DataSet ds =new DataSet();
        BindingSource bs = new BindingSource();
        string maNhapHang;
        public ChiTietNhapHang(string maNhap)
        {
            InitializeComponent();
            maNhapHang = maNhap;
        }
        
        private void ChiTietNhapHang_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select MaSP,SoLuong,DonGia,ThanhTien from ChiTietNhap where MaNhap=@MaNhap", kn);
            adapter.SelectCommand.Parameters.AddWithValue("@MaNhap", maNhapHang);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            dgvTTSP.DataSource = bs;
            dgvTTSP.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM PhieuNhap WHERE MaNhap = @MaNhap", kn);
            ad.SelectCommand.Parameters.AddWithValue("@MaNhap", maNhapHang);

            DataSet ds2 = new DataSet();
            BindingSource bs2 =new BindingSource();
            ad.Fill(ds2);
            bs2.DataSource= ds2.Tables[0];

            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", bs2, "MaNCC", true);
            txtMaNhap.DataBindings.Clear();
            txtMaNhap.DataBindings.Add("Text", bs2, "MaNhap", true);
            txtTotal.DataBindings.Clear();
            txtTotal.DataBindings.Add("Text", bs2, "TongTien", true);
            dtpNgayNhap.DataBindings.Clear();
            dtpNgayNhap.DataBindings.Add("Value", bs2, "NgayNhap", true);
        }
    }
}
