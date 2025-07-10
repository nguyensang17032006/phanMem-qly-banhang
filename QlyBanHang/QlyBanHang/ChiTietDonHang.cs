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
    public partial class ChiTietDonHang : Form
    {
        string MaDon;
        SqlConnection kn = new SqlConnection("Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public ChiTietDonHang(string maDH)
        {
            InitializeComponent();
            MaDon = maDH;
        }

        private void ChiTietDonHang_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT ct.MaSP, sp.TenSP, ct.SoLuong, ct.GiaBan, ct.ThanhTien FROM ChiTietDonHang ct INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP where ct.MaDon=@MaDonHang", kn);
            adapter.SelectCommand.Parameters.AddWithValue("@MaDonHang", MaDon);
            adapter.Fill(ds);
            bs.DataSource=ds.Tables[0];
            dgvTTSP.DataSource = bs;
            dgvTTSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlDataAdapter ad = new SqlDataAdapter("select * from DonHang", kn);
            DataSet ds2= new DataSet();
            BindingSource bs2=new BindingSource();
            ad.Fill(ds2);
            bs2.DataSource=ds2.Tables[0];
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bs2, "DiaChi", true, DataSourceUpdateMode.Never);
            txtHinhThuc.DataBindings.Clear();
            txtHinhThuc.DataBindings.Add("Text",bs2,"HinhThuc", true,DataSourceUpdateMode.Never);
            txtMaDon.DataBindings.Clear();
            txtMaDon.DataBindings.Add("Text", bs2, "MaDon", true, DataSourceUpdateMode.Never);
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text",bs2,"MaKhachHang",true,DataSourceUpdateMode.Never);
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bs2, "MaNV", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text",bs2,"SDT",true,DataSourceUpdateMode.Never);
            txtTotal.DataBindings.Clear();
            txtTotal.DataBindings.Add("Text", bs2, "TongTien", true, DataSourceUpdateMode.Never);
            dtpNgayMua.DataBindings.Clear();
            dtpNgayMua.DataBindings.Add("Value",bs2,"NgayMua",true,DataSourceUpdateMode.Never);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
