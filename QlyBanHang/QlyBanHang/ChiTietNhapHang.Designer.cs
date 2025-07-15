namespace QlyBanHang
{
    partial class ChiTietNhapHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiTietNhapHang));
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaNhap = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvTTSP = new System.Windows.Forms.DataGridView();
            this.grb = new System.Windows.Forms.GroupBox();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTSP)).BeginInit();
            this.grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(519, 93);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(189, 28);
            this.txtTotal.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Tổng tiền";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Enabled = false;
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(174, 93);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(184, 28);
            this.dtpNgayNhap.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 22);
            this.label9.TabIndex = 13;
            this.label9.Text = "Ngày nhập";
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
            this.txtMaNhap.Enabled = false;
            this.txtMaNhap.Location = new System.Drawing.Point(174, 36);
            this.txtMaNhap.Name = "txtMaNhap";
            this.txtMaNhap.Size = new System.Drawing.Size(184, 28);
            this.txtMaNhap.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTTSP);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 309);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sản phẩm";
            // 
            // dgvTTSP
            // 
            this.dgvTTSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTSP.Location = new System.Drawing.Point(6, 46);
            this.dgvTTSP.Name = "dgvTTSP";
            this.dgvTTSP.RowHeadersWidth = 51;
            this.dgvTTSP.RowTemplate.Height = 24;
            this.dgvTTSP.Size = new System.Drawing.Size(731, 257);
            this.dgvTTSP.TabIndex = 33;
            // 
            // grb
            // 
            this.grb.Controls.Add(this.txtMaNCC);
            this.grb.Controls.Add(this.label2);
            this.grb.Controls.Add(this.txtTotal);
            this.grb.Controls.Add(this.label6);
            this.grb.Controls.Add(this.dtpNgayNhap);
            this.grb.Controls.Add(this.label9);
            this.grb.Controls.Add(this.label1);
            this.grb.Controls.Add(this.txtMaNhap);
            this.grb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb.Location = new System.Drawing.Point(18, 6);
            this.grb.Name = "grb";
            this.grb.Size = new System.Drawing.Size(746, 214);
            this.grb.TabIndex = 33;
            this.grb.TabStop = false;
            this.grb.Text = "Chi tiết phiếu nhập";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Enabled = false;
            this.txtMaNCC.Location = new System.Drawing.Point(519, 36);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(189, 28);
            this.txtMaNCC.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 23;
            this.label2.Text = "Mã NCC";
            // 
            // ChiTietNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChiTietNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết nhập hàng";
            this.Load += new System.EventHandler(this.ChiTietNhapHang_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTSP)).EndInit();
            this.grb.ResumeLayout(false);
            this.grb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTTSP;
        private System.Windows.Forms.GroupBox grb;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Label label2;
    }
}