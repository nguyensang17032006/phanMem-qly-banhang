namespace QlyBanHang
{
    partial class ChiTietDonHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiTietDonHang));
            this.dgvTTSP = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grb = new System.Windows.Forms.GroupBox();
            this.txtHinhThuc = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayMua = new System.Windows.Forms.DateTimePicker();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTTSP
            // 
            this.dgvTTSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTSP.Location = new System.Drawing.Point(6, 46);
            this.dgvTTSP.Name = "dgvTTSP";
            this.dgvTTSP.RowHeadersWidth = 51;
            this.dgvTTSP.RowTemplate.Height = 24;
            this.dgvTTSP.Size = new System.Drawing.Size(1133, 257);
            this.dgvTTSP.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTTSP);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1145, 261);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sản phẩm";
            // 
            // grb
            // 
            this.grb.Controls.Add(this.txtHinhThuc);
            this.grb.Controls.Add(this.txtDiaChi);
            this.grb.Controls.Add(this.label6);
            this.grb.Controls.Add(this.label3);
            this.grb.Controls.Add(this.dtpNgayMua);
            this.grb.Controls.Add(this.txtTotal);
            this.grb.Controls.Add(this.txtMaKH);
            this.grb.Controls.Add(this.txtSDT);
            this.grb.Controls.Add(this.label9);
            this.grb.Controls.Add(this.label8);
            this.grb.Controls.Add(this.label5);
            this.grb.Controls.Add(this.label4);
            this.grb.Controls.Add(this.txtMaNV);
            this.grb.Controls.Add(this.label2);
            this.grb.Controls.Add(this.label1);
            this.grb.Controls.Add(this.txtMaDon);
            this.grb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb.Location = new System.Drawing.Point(0, 0);
            this.grb.Name = "grb";
            this.grb.Size = new System.Drawing.Size(1167, 214);
            this.grb.TabIndex = 31;
            this.grb.TabStop = false;
            this.grb.Text = "Chi tiết đơn hàng ";
            // 
            // txtHinhThuc
            // 
            this.txtHinhThuc.Location = new System.Drawing.Point(554, 100);
            this.txtHinhThuc.Name = "txtHinhThuc";
            this.txtHinhThuc.Size = new System.Drawing.Size(189, 28);
            this.txtHinhThuc.TabIndex = 23;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(186, 167);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(557, 28);
            this.txtDiaChi.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(789, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Tổng tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 19;
            this.label3.Text = "Hình thức";
            // 
            // dtpNgayMua
            // 
            this.dtpNgayMua.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayMua.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayMua.Location = new System.Drawing.Point(186, 101);
            this.dtpNgayMua.Name = "dtpNgayMua";
            this.dtpNgayMua.Size = new System.Drawing.Size(208, 28);
            this.dtpNgayMua.TabIndex = 18;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(900, 167);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(208, 28);
            this.txtTotal.TabIndex = 17;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(900, 36);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(208, 28);
            this.txtMaKH.TabIndex = 15;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(900, 103);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(208, 28);
            this.txtSDT.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(68, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 22);
            this.label9.TabIndex = 13;
            this.label9.Text = "Ngày mua";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(789, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "SĐT";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(789, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mã KH\r\n";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(554, 33);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(189, 28);
            this.txtMaNV.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã NV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã đơn";
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(186, 36);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(208, 28);
            this.txtMaDon.TabIndex = 3;
            // 
            // ChiTietDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 498);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChiTietDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết đơn hàng";
            this.Load += new System.EventHandler(this.ChiTietDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grb.ResumeLayout(false);
            this.grb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTTSP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grb;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayMua;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHinhThuc;
    }
}