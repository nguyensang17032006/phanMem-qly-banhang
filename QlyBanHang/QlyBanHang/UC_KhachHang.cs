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
    public partial class UC_KhachHang: UserControl
    {
        SqlConnection kn = new SqlConnection("Data Source=LAPTOP-TQK\\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        public UC_KhachHang()
        {
            InitializeComponent();
        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }

        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from KhachHang", kn);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            dgvKhachHang.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
            dgvKhachHang.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            txtChiTieu.DataBindings.Clear();
            txtChiTieu.DataBindings.Add("Text", bs, "TongChiTieu", true, DataSourceUpdateMode.Never);
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text",bs,"Email",true,DataSourceUpdateMode.Never);
            txtHang.DataBindings.Clear();
           txtHang.DataBindings.Add("Text",bs,"ThuHang",true,DataSourceUpdateMode.Never);
            txtKH.DataBindings.Clear();
            txtKH.DataBindings.Add("Text",bs,"MaKhachHang",true,DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text",bs,"SDT",true,DataSourceUpdateMode.Never);
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text",bs,"TenKH",true,DataSourceUpdateMode.Never);
        }
    }
}
