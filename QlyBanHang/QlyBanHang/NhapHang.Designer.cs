namespace QlyBanHang
{
    partial class NhapHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapHang));
            this.button1 = new System.Windows.Forms.Button();
            this.dgvNhap = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbSanPham = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtTheLoai = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.grb = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.cmbNCC = new System.Windows.Forms.ComboBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaNhap = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(606, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 71);
            this.button1.TabIndex = 34;
            this.button1.Text = "Tạo phiếu nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvNhap
            // 
            this.dgvNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhap.Location = new System.Drawing.Point(9, 248);
            this.dgvNhap.Name = "dgvNhap";
            this.dgvNhap.RowHeadersWidth = 51;
            this.dgvNhap.RowTemplate.Height = 24;
            this.dgvNhap.Size = new System.Drawing.Size(1230, 234);
            this.dgvNhap.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.txtGiaBan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cbSanPham);
            this.groupBox1.Controls.Add(this.txtSoLuong);
            this.groupBox1.Controls.Add(this.txtGiaNhap);
            this.groupBox1.Controls.Add(this.txtTheLoai);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtTenSP);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(653, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 230);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sản phẩm";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(244, 174);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(186, 42);
            this.btnXoa.TabIndex = 38;
            this.btnXoa.Text = "Xóa sản phẩm";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Enabled = false;
            this.txtGiaBan.Location = new System.Drawing.Point(346, 132);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(223, 28);
            this.txtGiaBan.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 22);
            this.label5.TabIndex = 36;
            this.label5.Text = "Giá bán";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(15, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 42);
            this.button2.TabIndex = 35;
            this.button2.Text = "Thêm sản phẩm";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // cbSanPham
            // 
            this.cbSanPham.FormattingEnabled = true;
            this.cbSanPham.Location = new System.Drawing.Point(110, 33);
            this.cbSanPham.Name = "cbSanPham";
            this.cbSanPham.Size = new System.Drawing.Size(121, 30);
            this.cbSanPham.TabIndex = 32;
            this.cbSanPham.SelectedIndexChanged += new System.EventHandler(this.cbSanPham_SelectedIndexChanged_1);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(110, 80);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(121, 28);
            this.txtSoLuong.TabIndex = 17;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(110, 132);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(121, 28);
            this.txtGiaNhap.TabIndex = 16;
            // 
            // txtTheLoai
            // 
            this.txtTheLoai.Enabled = false;
            this.txtTheLoai.Location = new System.Drawing.Point(346, 83);
            this.txtTheLoai.Name = "txtTheLoai";
            this.txtTheLoai.Size = new System.Drawing.Size(223, 28);
            this.txtTheLoai.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "Giá nhập";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 22);
            this.label10.TabIndex = 12;
            this.label10.Text = "Số lượng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(237, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 22);
            this.label11.TabIndex = 9;
            this.label11.Text = "Thể loại";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Enabled = false;
            this.txtTenSP.Location = new System.Drawing.Point(346, 33);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(223, 28);
            this.txtTenSP.TabIndex = 6;
            this.txtTenSP.TextChanged += new System.EventHandler(this.txtTenSP_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(237, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 22);
            this.label13.TabIndex = 5;
            this.label13.Text = "Tên SP";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 22);
            this.label14.TabIndex = 4;
            this.label14.Text = "Mã SP";
            // 
            // grb
            // 
            this.grb.Controls.Add(this.label4);
            this.grb.Controls.Add(this.txtTenHang);
            this.grb.Controls.Add(this.cmbNCC);
            this.grb.Controls.Add(this.dtpNgayNhap);
            this.grb.Controls.Add(this.txtTongTien);
            this.grb.Controls.Add(this.label2);
            this.grb.Controls.Add(this.label3);
            this.grb.Controls.Add(this.label6);
            this.grb.Controls.Add(this.label1);
            this.grb.Controls.Add(this.txtMaNhap);
            this.grb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb.Location = new System.Drawing.Point(9, 0);
            this.grb.Name = "grb";
            this.grb.Size = new System.Drawing.Size(638, 242);
            this.grb.TabIndex = 31;
            this.grb.TabStop = false;
            this.grb.Text = "Thông tin nhập hàng";
            this.grb.Enter += new System.EventHandler(this.grb_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 22);
            this.label4.TabIndex = 30;
            this.label4.Text = "Nhãn hàng";
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(161, 146);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(139, 28);
            this.txtTenHang.TabIndex = 29;
            // 
            // cmbNCC
            // 
            this.cmbNCC.FormattingEnabled = true;
            this.cmbNCC.Location = new System.Drawing.Point(161, 89);
            this.cmbNCC.Name = "cmbNCC";
            this.cmbNCC.Size = new System.Drawing.Size(139, 30);
            this.cmbNCC.TabIndex = 28;
            this.cmbNCC.SelectedIndexChanged += new System.EventHandler(this.cmbNCC_SelectedIndexChanged);
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(431, 39);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(179, 28);
            this.dtpNgayNhap.TabIndex = 27;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(431, 91);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(179, 28);
            this.txtTongTien.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tổng tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Mã NCC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Ngày nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã nhập hàng";
            // 
            // txtMaNhap
            // 
            this.txtMaNhap.Location = new System.Drawing.Point(161, 36);
            this.txtMaNhap.Name = "txtMaNhap";
            this.txtMaNhap.Size = new System.Drawing.Size(139, 28);
            this.txtMaNhap.TabIndex = 3;
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 559);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvNhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.NhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grb.ResumeLayout(false);
            this.grb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtTheLoai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox grb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSanPham;
        private System.Windows.Forms.ComboBox cmbNCC;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXoa;
    }
}