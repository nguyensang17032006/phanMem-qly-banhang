namespace QlyBanHang
{
    partial class FormXacNhanAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormXacNhanAdmin));
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnXN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pbDongMat = new System.Windows.Forms.PictureBox();
            this.pbMoMat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDongMat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoMat)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(181, 21);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(234, 35);
            this.txtTaiKhoan.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tài khoản";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(181, 78);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(234, 35);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // btnXN
            // 
            this.btnXN.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXN.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXN.ForeColor = System.Drawing.Color.Black;
            this.btnXN.Location = new System.Drawing.Point(170, 140);
            this.btnXN.Name = "btnXN";
            this.btnXN.Size = new System.Drawing.Size(166, 51);
            this.btnXN.TabIndex = 3;
            this.btnXN.Text = "Xác nhận";
            this.btnXN.UseVisualStyleBackColor = false;
            this.btnXN.Click += new System.EventHandler(this.btnXN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mật khẩu";
            // 
            // pbDongMat
            // 
            this.pbDongMat.Image = ((System.Drawing.Image)(resources.GetObject("pbDongMat.Image")));
            this.pbDongMat.Location = new System.Drawing.Point(439, 85);
            this.pbDongMat.Name = "pbDongMat";
            this.pbDongMat.Size = new System.Drawing.Size(32, 28);
            this.pbDongMat.TabIndex = 5;
            this.pbDongMat.TabStop = false;
            this.pbDongMat.Visible = false;
            this.pbDongMat.Click += new System.EventHandler(this.pbDongMat_Click);
            // 
            // pbMoMat
            // 
            this.pbMoMat.Image = ((System.Drawing.Image)(resources.GetObject("pbMoMat.Image")));
            this.pbMoMat.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbMoMat.InitialImage")));
            this.pbMoMat.Location = new System.Drawing.Point(439, 85);
            this.pbMoMat.Name = "pbMoMat";
            this.pbMoMat.Size = new System.Drawing.Size(32, 29);
            this.pbMoMat.TabIndex = 6;
            this.pbMoMat.TabStop = false;
            this.pbMoMat.Click += new System.EventHandler(this.pbMoMat_Click);
            // 
            // FormXacNhanAdmin
            // 
            this.ClientSize = new System.Drawing.Size(506, 227);
            this.Controls.Add(this.pbMoMat);
            this.Controls.Add(this.pbDongMat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnXN);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTaiKhoan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormXacNhanAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hãy nhập tài khoản của quản lý";
            this.Load += new System.EventHandler(this.FormXacNhanAdmin_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbDongMat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoMat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnXN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbDongMat;
        private System.Windows.Forms.PictureBox pbMoMat;
    }
}