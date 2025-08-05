namespace QlyBanHang
{
    partial class home
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home));
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnKho = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnNCC = new System.Windows.Forms.Button();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.qLDangNhapDataSet = new QlyBanHang.QLDangNhapDataSet();
            this.qLDangNhapDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qLDangNhapDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDangNhapDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSanPham
            // 
            this.btnSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnSanPham, "btnSanPham");
            this.btnSanPham.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.UseVisualStyleBackColor = false;
            this.btnSanPham.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnDonHang
            // 
            this.btnDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnDonHang, "btnDonHang");
            this.btnDonHang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.UseVisualStyleBackColor = false;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnKhachHang, "btnKhachHang");
            this.btnKhachHang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnKho
            // 
            this.btnKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnKho, "btnKho");
            this.btnKho.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKho.Name = "btnKho";
            this.btnKho.UseVisualStyleBackColor = false;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnNhanVien, "btnNhanVien");
            this.btnNhanVien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.UseVisualStyleBackColor = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnNCC
            // 
            this.btnNCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.btnNCC, "btnNCC");
            this.btnNCC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.UseVisualStyleBackColor = false;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click);
            // 
            // lblChucVu
            // 
            resources.ApplyResources(this.lblChucVu, "lblChucVu");
            this.lblChucVu.Name = "lblChucVu";
            // 
            // lblTenNV
            // 
            resources.ApplyResources(this.lblTenNV, "lblTenNV");
            this.lblTenNV.Name = "lblTenNV";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnThoat, "btnThoat");
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panelContent
            // 
            resources.ApplyResources(this.panelContent, "panelContent");
            this.panelContent.Name = "panelContent";
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint_2);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.lblChucVu);
            this.panel1.Controls.Add(this.lblTenNV);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // qLDangNhapDataSet
            // 
            this.qLDangNhapDataSet.DataSetName = "QLDangNhapDataSet";
            this.qLDangNhapDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLDangNhapDataSetBindingSource
            // 
            this.qLDangNhapDataSetBindingSource.DataSource = this.qLDangNhapDataSet;
            this.qLDangNhapDataSetBindingSource.Position = 0;
            // 
            // home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.btnNCC);
            this.Controls.Add(this.btnKhachHang);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.btnSanPham);
            this.Controls.Add(this.btnKho);
            this.Controls.Add(this.btnDonHang);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "home";
            this.Load += new System.EventHandler(this.home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qLDangNhapDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDangNhapDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnDonHang;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource qLDangNhapDataSetBindingSource;
        private QLDangNhapDataSet qLDangNhapDataSet;
        private System.Windows.Forms.Label label1;
    }
}