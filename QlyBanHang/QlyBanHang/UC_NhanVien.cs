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
    public partial class UC_NhanVien : UserControl
    {
        SqlConnection kn = new SqlConnection("Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs =new BindingSource();
        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select * from NhanVien", kn);
            adapter.Fill(ds);
            if (!ds.Tables[0].Columns.Contains("HoTen"))
                ds.Tables[0].Columns.Add("HoTen", typeof(string), "HoTenLot + ' ' + Ten");
            bs.DataSource = ds.Tables[0];
            dgvNhanVien.DataSource = bs;
            dgvNhanVien.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            bindingNavigator1.BindingSource = bs;

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text",bs,"Email",true,DataSourceUpdateMode.Never);
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bs, "MaNV", true, DataSourceUpdateMode.Never);
            txtMK.DataBindings.Clear();
            txtMK.DataBindings.Add("Text", bs, "MK", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bs, "SDT", true, DataSourceUpdateMode.Never);
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text",bs,"HoTen",true,DataSourceUpdateMode.Never);
            txtTK.DataBindings.Clear();
            txtTK.DataBindings.Add("Text",bs,"TK",true,DataSourceUpdateMode.Never);
        }
    }
}
