using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
namespace QlyBanHang
{
    public partial class UC_SanPham: UserControl
    {
        SqlConnection kn =new SqlConnection("Data Source=DESKTOP-1417HQ2\\SQLEXPRESS02;Initial Catalog=QLBanHang;Integrated Security=True");
        SqlDataAdapter adapter;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();


        public UC_SanPham()
        {
            InitializeComponent();
            btnThemSP.Resize += (s, e) => {
                BoGocButton(btnThemSP, 20);
            };
            btnXoaSP.Resize += (s, e) =>
            {
                BoGocButton(btnThemSP, 20);
            };
            btnSuaSP.Resize += (s, e) =>
            {
                BoGocButton(btnSuaSP, 20);
            };
        }
        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        

private void BoGocButton(Button btn, int doBo)
    {
            GraphicsPath path = new GraphicsPath();
            int r = doBo;

            // Tạo vùng bo góc
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(btn.Width - r, 0, r, r, 270, 90);
            path.AddArc(btn.Width - r, btn.Height - r, r, r, 0, 90);
            path.AddArc(0, btn.Height - r, r, r, 90, 90);
            path.CloseAllFigures();

            // Gán vùng hiển thị
            btn.Region = new Region(path);
        }

        private void thucHienBindingSource()
        {
            adapter = new SqlDataAdapter("SElECT * FROM SANPHAM",kn);
            adapter.Fill(ds);
            bs.DataSource=ds.Tables[0];
            dgvSanPham.DataSource = bs;
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            thucHienBindingSource();
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void btnThemSP_Resize(object sender, EventArgs e)
        {
            BoGocButton(btnThemSP, 20); // hoặc bo nhiều hơn nếu muốn tròn
            BoGocButton(btnSuaSP, 20);
            BoGocButton(btnXoaSP, 20);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string filter = txtTimKiem.Text.Trim();
            if (bs.DataSource is DataTable dt)
            {
                if (string.IsNullOrEmpty(filter))
                {
                    bs.RemoveFilter();
                }
                else
                {
                    // Ví dụ: tìm trong cột TenSanPham
                    bs.Filter = $"TenSP LIKE '%{filter}%' OR MaSP LIKE '%{filter}%' OR Hang LIKE '%{filter}%' OR TheLoai LIKE '%{filter}%'";
                }
            }
        }
    }
}
