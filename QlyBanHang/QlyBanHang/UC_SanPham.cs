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
        


        private void UC_SanPham_Load(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Resize(object sender, EventArgs e)
        {
            BoGocButton(btnThemSP, 20); // hoặc bo nhiều hơn nếu muốn tròn
            BoGocButton(btnSuaSP, 20);
            BoGocButton(btnXoaSP, 20);
        }
}
}
