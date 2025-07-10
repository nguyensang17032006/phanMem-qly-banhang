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
    public partial class UC_DonHang: UserControl
    {
        SqlConnection kn = new SqlConnection("Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public UC_DonHang()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        { 
           TaoDonHang taoDonHang = new TaoDonHang();
            taoDonHang.ShowDialog();
                
        }
        

        private void UC_DonHang_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from DonHang",kn);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            dgvDonHang.DataSource = bs;
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bindingNavigator1.BindingSource = bs;
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text",bs,"DiaChi",true,DataSourceUpdateMode.Never);
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
            dtpNgayMua.DataBindings.Add("Value",bs,"NgayMua",true,DataSourceUpdateMode.Never);
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            string maDH = dgvDonHang.CurrentRow.Cells["MaDon"].Value.ToString();
            ChiTietDonHang chiTietDonHang=new ChiTietDonHang(maDH);
            chiTietDonHang.ShowDialog();
        }
    }
}
