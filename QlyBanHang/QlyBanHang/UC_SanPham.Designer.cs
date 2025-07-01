namespace QlyBanHang
{
    partial class UC_SanPham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grb = new System.Windows.Forms.GroupBox();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.qlDangNhapDataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.qlDangNhapDataSet1 = new QlyBanHang.QLDangNhapDataSet();
            this.qlDangNhapDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSanPham = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.grb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlDangNhapDataSet1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlDangNhapDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlDangNhapDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grb
            // 
            this.grb.Controls.Add(this.textBox5);
            this.grb.Controls.Add(this.textBox4);
            this.grb.Controls.Add(this.btnXoaSP);
            this.grb.Controls.Add(this.btnSuaSP);
            this.grb.Controls.Add(this.btnThemSP);
            this.grb.Controls.Add(this.textBox3);
            this.grb.Controls.Add(this.textBox2);
            this.grb.Controls.Add(this.label9);
            this.grb.Controls.Add(this.label8);
            this.grb.Controls.Add(this.label5);
            this.grb.Controls.Add(this.label4);
            this.grb.Controls.Add(this.textBox1);
            this.grb.Controls.Add(this.label2);
            this.grb.Controls.Add(this.label1);
            this.grb.Controls.Add(this.txtSanPham);
            this.grb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb.Location = new System.Drawing.Point(18, 28);
            this.grb.Name = "grb";
            this.grb.Size = new System.Drawing.Size(765, 187);
            this.grb.TabIndex = 0;
            this.grb.TabStop = false;
            this.grb.Text = "Thông tin sản phẩm";
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnXoaSP.FlatAppearance.BorderSize = 0;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSP.Location = new System.Drawing.Point(607, 132);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(125, 47);
            this.btnXoaSP.TabIndex = 2;
            this.btnXoaSP.Text = "Xóa SP";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSuaSP.FlatAppearance.BorderSize = 0;
            this.btnSuaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSP.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaSP.Location = new System.Drawing.Point(607, 77);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(125, 47);
            this.btnSuaSP.TabIndex = 1;
            this.btnSuaSP.Text = "Sửa SP";
            this.btnSuaSP.UseVisualStyleBackColor = false;
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnThemSP.FlatAppearance.BorderSize = 0;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSP.Location = new System.Drawing.Point(607, 17);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(125, 47);
            this.btnThemSP.TabIndex = 0;
            this.btnThemSP.Text = "Thêm SP";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Resize += new System.EventHandler(this.btnThemSP_Resize);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoGenerateColumns = false;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.DataSource = this.qlDangNhapDataSet1BindingSource1;
            this.dgvSanPham.Location = new System.Drawing.Point(18, 258);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.Size = new System.Drawing.Size(1224, 294);
            this.dgvSanPham.TabIndex = 1;
            // 
            // qlDangNhapDataSet1BindingSource1
            // 
            this.qlDangNhapDataSet1BindingSource1.DataSource = this.qlDangNhapDataSet1;
            this.qlDangNhapDataSet1BindingSource1.Position = 0;
            // 
            // qlDangNhapDataSet1
            // 
            this.qlDangNhapDataSet1.DataSetName = "QLDangNhapDataSet";
            this.qlDangNhapDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qlDangNhapDataSet1BindingSource
            // 
            this.qlDangNhapDataSet1BindingSource.DataSource = this.qlDangNhapDataSet1;
            this.qlDangNhapDataSet1BindingSource.Position = 0;
            // 
            // txtSanPham
            // 
            this.txtSanPham.Location = new System.Drawing.Point(110, 36);
            this.txtSanPham.Name = "txtSanPham";
            this.txtSanPham.Size = new System.Drawing.Size(121, 28);
            this.txtSanPham.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã SP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên SP";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(346, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 28);
            this.textBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hãng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thể loại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "Số lượng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 22);
            this.label9.TabIndex = 13;
            this.label9.Text = "Giá bán";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(346, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(189, 28);
            this.textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(110, 83);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(121, 28);
            this.textBox3.TabIndex = 15;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(110, 132);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(121, 28);
            this.textBox4.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(346, 126);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(189, 28);
            this.textBox5.TabIndex = 17;
            // 
            // UC_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.grb);
            this.Name = "UC_SanPham";
            this.Size = new System.Drawing.Size(1270, 560);
            this.Load += new System.EventHandler(this.UC_SanPham_Load);
            this.grb.ResumeLayout(false);
            this.grb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlDangNhapDataSet1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlDangNhapDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlDangNhapDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox grb;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.BindingSource qlDangNhapDataSet1BindingSource1;
        private QLDangNhapDataSet qlDangNhapDataSet1;
        private System.Windows.Forms.BindingSource qlDangNhapDataSet1BindingSource;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSanPham;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
    }
}
