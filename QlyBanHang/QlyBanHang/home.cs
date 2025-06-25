using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBanHang
{
    public partial class home: Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_SanPham());
        }

        private void home_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            LoadPage(new UC_SanPham());
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void LoadPage(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_DonHang());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_KhachHang());

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().Show();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}
