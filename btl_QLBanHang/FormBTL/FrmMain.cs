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

namespace btl_QLBanHang
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        ConnectData dtb = new ConnectData();
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (staticdata.check==0)
                return;
            string sql = "select top 3 with ties tblNV.TenNV,Anh, sum(ThanhTien) as TongTien " +
                "from tblNV, tblHoaDonBan, tblChiTietHDB " +
                "where tblNV.MaNV=tblHoaDonBan.MaNV and tblChiTietHDB.MaHDB=tblHoaDonBan.MaHDB " +
                "group by tblNV.TenNV,Anh " +
                "order by TongTien desc";
            string sqlsp = "select top 3 with ties tblSanPham.TenSP,Anh , sum(ThanhTien) as TongTien " +
                "from tblSanPham, tblChiTietHDB " +
                "where  tblSanPham.MaSP=tblChiTietHDB.MaSP " +
                "group by tblSanPham.TenSP,Anh " +
                "order by TongTien desc";
            DataTable dtnv = dtb.ReadData(sql);
            DataTable dtsp = dtb.ReadData(sqlsp);
            string FileAnh1 = null;
            string FileAnh2 = null;
            string FileAnh3 = null;

            string FileAnhSP1 = null;
            string FileAnhSP2 = null;
            string FileAnhSP3 = null;
            
            if (dtnv.Rows.Count ==3)
            {
                lblNVTop1.Text = dtnv.Rows[0]["TenNV"].ToString();
                lblNVTop2.Text = dtnv.Rows[1]["TenNV"].ToString();
                lblNVTop3.Text = dtnv.Rows[2]["TenNV"].ToString();
                FileAnh1 = dtnv.Rows[0]["Anh"].ToString();
                FileAnh2 = dtnv.Rows[1]["Anh"].ToString();
                FileAnh3 = dtnv.Rows[2]["Anh"].ToString();
            }
            if (dtnv.Rows.Count == 2)
            {
                lblNVTop1.Text = dtnv.Rows[0]["TenNV"].ToString();
                lblNVTop2.Text = dtnv.Rows[1]["TenNV"].ToString();
                FileAnh1 = dtnv.Rows[0]["Anh"].ToString();
                FileAnh2 = dtnv.Rows[1]["Anh"].ToString();
            }
            if (dtnv.Rows.Count == 1)
            {
                lblNVTop1.Text = dtnv.Rows[0]["TenNV"].ToString();
                FileAnh1 = dtnv.Rows[0]["Anh"].ToString();
            }
            if (dtsp.Rows.Count == 3)
            {
                lblSpTop1.Text = dtsp.Rows[0]["TenSP"].ToString();
                lblSpTop2.Text = dtsp.Rows[1]["TenSP"].ToString();
                lblSpTop3.Text = dtsp.Rows[2]["TenSP"].ToString();
                FileAnhSP1 = dtsp.Rows[0]["Anh"].ToString();
                FileAnhSP2 = dtsp.Rows[1]["Anh"].ToString();
                FileAnhSP3 = dtsp.Rows[2]["Anh"].ToString();
            }
            if (dtsp.Rows.Count == 2)
            {
                lblSpTop1.Text = dtsp.Rows[0]["TenSP"].ToString();
                lblSpTop2.Text = dtsp.Rows[1]["TenSP"].ToString();
                FileAnhSP1 = dtsp.Rows[0]["Anh"].ToString();
                FileAnhSP2 = dtsp.Rows[1]["Anh"].ToString();
            }
            if (dtsp.Rows.Count == 1)
            {
                lblSpTop1.Text = dtsp.Rows[0]["TenSP"].ToString();
                FileAnhSP1 = dtsp.Rows[0]["Anh"].ToString();
            }
            try
            {
                picTop1.Image = Image.FromFile(Application.StartupPath + "\\Images\\AvatarNV\\" + FileAnh1);
                picTop2.Image = Image.FromFile(Application.StartupPath + "\\Images\\AvatarNV\\" + FileAnh2);
                picTop3.Image = Image.FromFile(Application.StartupPath + "\\Images\\AvatarNV\\" + FileAnh3);
                picSpTop1.Image = Image.FromFile(Application.StartupPath + "\\Images\\SanPham\\" + FileAnhSP1);
                picSpTop2.Image = Image.FromFile(Application.StartupPath + "\\Images\\SanPham\\" + FileAnhSP2);
                picSpTop3.Image = Image.FromFile(Application.StartupPath + "\\Images\\SanPham\\" + FileAnhSP3);
            }
            catch
            {
                picTop1.Image = null;
                picTop2.Image = null;
                picTop3.Image = null;
                picSpTop1.Image = null;
                picSpTop2.Image = null;
                picSpTop3.Image = null;
            }
        }
    
    }
}
