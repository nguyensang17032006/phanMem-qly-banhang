﻿using System;
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
            LoadPage(new UC_SanPham());
            lblTenNV.Text = $"Họ và tên: {TaiKhoan.HoTen}";
            lblChucVu.Text = "Chức vụ: " + TaiKhoan.Quyen;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
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
            DialogResult result= MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng ko?", "Xác nhận thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result != DialogResult.No)
            {
                this.Close();
            }
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

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.Quyen != "Admin")
            {
                FormXacNhanAdmin xacNhan = new FormXacNhanAdmin();
                xacNhan.ShowDialog();

                if (!xacNhan.LaAdminXacNhan)
                {
                    MessageBox.Show("Thao tác bị huỷ vì không có xác nhận admin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            LoadPage(new UC_NhanVien());
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.Quyen != "Admin")
            {
                FormXacNhanAdmin xacNhan = new FormXacNhanAdmin();
                xacNhan.ShowDialog();

                if (!xacNhan.LaAdminXacNhan)
                {
                    MessageBox.Show("Thao tác bị huỷ vì không có xác nhận admin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            LoadPage(new UC_NhaCungCap());
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            if (TaiKhoan.Quyen != "Admin")
            {
                FormXacNhanAdmin xacNhan = new FormXacNhanAdmin();
                xacNhan.ShowDialog();

                if (!xacNhan.LaAdminXacNhan)
                {
                    MessageBox.Show("Thao tác bị huỷ vì không có xác nhận admin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            LoadPage(new UC_KhoHang());
        }
    }
}
