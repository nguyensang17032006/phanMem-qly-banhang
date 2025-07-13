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
            this.cmbMaSP = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.cmbMaSP);
            this.groupBox1.Controls.Add(this.button2);
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
            this.groupBox1.Location = new System.Drawing.Point(704, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 200);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sản phẩm";
            // 
            // cmbMaSP
            // 
            this.cmbMaSP.FormattingEnabled = true;
            this.cmbMaSP.Location = new System.Drawing.Point(110, 33);
            this.cmbMaSP.Name = "cmbMaSP";
            this.cmbMaSP.Size = new System.Drawing.Size(121, 30);
            this.cmbMaSP.TabIndex = 32;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(252, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 44);
            this.button2.TabIndex = 31;
            this.button2.Text = "Thêm SP";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.txtTheLoai.Location = new System.Drawing.Point(346, 83);
            this.txtTheLoai.Name = "txtTheLoai";
            this.txtTheLoai.Size = new System.Drawing.Size(189, 28);
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
            this.txtTenSP.Location = new System.Drawing.Point(346, 33);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(189, 28);
            this.txtTenSP.TabIndex = 6;
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
            this.grb.Size = new System.Drawing.Size(689, 214);
            this.grb.TabIndex = 31;
            this.grb.TabStop = false;
            this.grb.Text = "Thông tin nhập hàng";
            this.grb.Enter += new System.EventHandler(this.grb_Enter);
            // 
            // cmbNCC
            // 
            this.cmbNCC.FormattingEnabled = true;
            this.cmbNCC.Location = new System.Drawing.Point(166, 89);
            this.cmbNCC.Name = "cmbNCC";
            this.cmbNCC.Size = new System.Drawing.Size(177, 30);
            this.cmbNCC.TabIndex = 28;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Location = new System.Drawing.Point(461, 39);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(222, 28);
            this.dtpNgayNhap.TabIndex = 27;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(461, 91);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(222, 28);
            this.txtTongTien.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tổng tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Mã NCC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Ngày nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã nhập hàng";
            // 
            // txtMaNhap
            // 
            this.txtMaNhap.Location = new System.Drawing.Point(166, 36);
            this.txtMaNhap.Name = "txtMaNhap";
            this.txtMaNhap.Size = new System.Drawing.Size(177, 28);
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
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.ComboBox cmbMaSP;
        private System.Windows.Forms.ComboBox cmbNCC;
    }
}