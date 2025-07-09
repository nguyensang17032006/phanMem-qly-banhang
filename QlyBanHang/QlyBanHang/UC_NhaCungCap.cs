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
    public partial class UC_NhaCungCap : UserControl
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet ds=new DataSet();
        BindingSource bs=new BindingSource();
        
        public UC_NhaCungCap()
        {
            InitializeComponent();
        }

        private void UC_NhaCungCap_Load(object sender, EventArgs e)
        {
            adapter =new SqlDataAdapter("select * from NhaCungCap",conn);
            adapter.Fill(ds);
            bs.DataSource = ds.Tables[0];
            dgvNCC.DataSource = bs;
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bs, "Email", true);
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", bs, "MaNCC", true);
            txtSDT.DataBindings.Clear();
            txtTenNCC.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bs, "SDT", true);
            txtTenNCC.DataBindings.Add("Text", bs, "TenNCC", true);
            bindingNavigator1.BindingSource = bs;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
