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
        SqlConnection kn = new SqlConnection("Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True");
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
    }
}
