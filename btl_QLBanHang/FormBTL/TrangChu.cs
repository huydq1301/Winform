using btl_QLBanHang.FormBTL;
using QLBH.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace btl_QLBanHang
{
    public partial class TrangChu : Form
    {

        public TrangChu()
        {
            InitializeComponent();
            pnlNav.Height = btnTrangChu.Height;
            pnlNav.Top = btnTrangChu.Top;
            pnlNav.Left = btnTrangChu.Left;
            btnTrangChu.BackColor = Color.FromArgb(46, 51, 73);
        }
        //hàm này để lấy giá trị username ghi lên tên nhân viên ở phần đầu trang chủ

        //public TrangChu(string giatri) : this()
        //{
        //    strNhan = giatri;
        //    lblTenNhanVien.Text ="UserName: "+ strNhan;
        //}

        private void TrangChu_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            lblTenNhanVien.Text = staticdata.TenNV;
            if(staticdata.LinkAvt=="")
            {
                staticdata.LinkAvt = "macdinh.png";
            }
            if(lblTenNhanVien.Text=="")
            {
                Application.Exit();
            }
            AvatarUser.Image = Image.FromFile(Application.StartupPath + "\\Images\\AvatarNV\\" + staticdata.LinkAvt);
            FrmMain form = new FrmMain();
            AddForm(form);
        }


        private void AddForm(Form form)
        {
            this.panel.Controls.Clear();
            form.TopLevel = false;
            form.AutoScroll = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Text = form.Text;
            this.panel.Controls.Add(form);
            form.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnHoaDon.Height;
            pnlNav.Top = btnHoaDon.Top;
            btnHoaDon.BackColor = Color.FromArgb(46, 51, 73);
            contextMenuStrip1.Show(btnHoaDon, new Point(0, btnHoaDon.Height));
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            lblTenNhanVien.Text = staticdata.TenNV;
            AvatarUser.Image = Image.FromFile(Application.StartupPath + "\\Images\\AvatarNV\\" + staticdata.LinkAvt);
            pnlNav.Height = btnTrangChu.Height;
            pnlNav.Top = btnTrangChu.Top;
            pnlNav.Left = btnTrangChu.Left;
            btnTrangChu.BackColor = Color.FromArgb(46, 51, 73);
            FrmMain form = new FrmMain();
            AddForm(form);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnNhanVien.Height;
            pnlNav.Top = btnNhanVien.Top;
            btnNhanVien.BackColor = Color.FromArgb(46, 51, 73);
            NhanVien form = new NhanVien();
            AddForm(form);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnKhachHang.Height;
            pnlNav.Top = btnKhachHang.Top;
            btnKhachHang.BackColor = Color.FromArgb(46, 51, 73);
            KhachHang form = new KhachHang();
            AddForm(form);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSanPham.Height;
            pnlNav.Top = btnSanPham.Top;
            btnSanPham.BackColor = Color.FromArgb(46, 51, 73);
            SanPham form = new SanPham();
            AddForm(form);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnKhuyenMai.Height;
            pnlNav.Top = btnKhuyenMai.Top;
            btnKhuyenMai.BackColor = Color.FromArgb(46, 51, 73);
            KhuyenMai form = new KhuyenMai();
            AddForm(form);
        }

        private void hoaDonNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDN form = new HDN();
            AddForm(form);
        }

        private void hoaDonBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDX form = new HDX();
            AddForm(form);
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDoanhThu.Height;
            pnlNav.Top = btnDoanhThu.Top;
            btnDoanhThu.BackColor = Color.FromArgb(46, 51, 73);
            DoanhThu form1 = new DoanhThu();
            AddForm(form1);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //if(MessageBox.Show("Bạn Có Muốn Thoát", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
            Application.Exit();
        }

        private void btnTrangChu_Leave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void AvatarUser_Click(object sender, EventArgs e)
        {

        }
    }
}
