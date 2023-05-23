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
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
        }
        CommonFunction func = new CommonFunction();
        ConnectData dtb = new ConnectData();
        private void cbbChonDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbChonDoanhThu.SelectedIndex == -1)
            {
                return;
            }
            if (cbbChonDoanhThu.SelectedIndex == 0)
            {
                lblNam.Show();
                nbrNam.Show();
                btnHienThi.Show();
                lblSP.Hide();
                lblChonNam.Hide();
                cbbSP.Hide();
                lblBan.Hide();
                lblNhap.Hide();
                return;
            }
            if (cbbChonDoanhThu.SelectedIndex == 1)
            {
                lblSP.Show();
                cbbSP.Show();
                btnHienThi.Show();
                lblChonNam.Show();
                nbrNam.Show();
                lblBan.Hide();
                lblNhap.Hide();
                return;
            }
            if (cbbChonDoanhThu.SelectedIndex == 2)
            {
                lblChonNam.Hide();
                cbbSP.Hide();
                lblSP.Hide();
                btnHienThi.Show();
                lblNam.Show();
                nbrNam.Show();

                return;
            }
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            cbbChonDoanhThu.Items.Clear();
            cbbChonDoanhThu.Items.Add("Theo Tháng");
            cbbChonDoanhThu.Items.Add("Theo Sản Phẩm");
            cbbChonDoanhThu.Items.Add("Cơ Cấu Sản Phẩm ");
            cbbChonDoanhThu.SelectedIndex = 0;
            lblNam.Hide();
            lblSP.Hide();
            cbbSP.Hide();
            nbrNam.Hide();
            lblChonNam.Hide();
            btnHienThi.Hide();
            lblBan.Hide();
            lblNhap.Hide();
            chaSPNhapBDTron.Hide();
            chaSPBanBDTron.Hide();
            DataTable dtSP = dtb.ReadData("Select * from tblSanPham");
            func.FillCombobox(cbbSP, dtSP, "TenSP", "TenSP");
            nbrNam.Maximum = 9999;
            nbrNam.Value = 2022;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            
            if (cbbChonDoanhThu.SelectedIndex == 0)
            {
                lblTieuDe.Text = "Doanh Thu Theo Theo Tháng";
                chaDoanhThu.Show();
                chaSPBanBDTron.Hide();
                chaSPNhapBDTron.Hide();
                chaDoanhThu.Series["Tiền Bán"].Points.Clear();
                chaDoanhThu.Series["Tiền Nhập"].Points.Clear();
                chaDoanhThu.ChartAreas["ChartArea1"].AxisX.Title = "Tháng";
                chaDoanhThu.ChartAreas["ChartArea1"].AxisY.Title = "VND";
                chaDoanhThu.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                DataTable dtban = dtb.ReadData("select * from tienbannam(" + nbrNam.Value + ")");
                DataTable dtnhap = dtb.ReadData("select * from tiennhapnam(" + nbrNam.Value + ")");
                for (int i = 0; i < dtban.Columns.Count; i++)
                {
                    chaDoanhThu.Series["Tiền Bán"].Points.AddXY(i + 1, dtban.Rows[0]["Thang" + (i + 1).ToString()]);
                    chaDoanhThu.Series["Tiền Bán"].Points[i].Label = dtban.Rows[0]["Thang" + (i + 1).ToString()].ToString();
                    chaDoanhThu.Series["Tiền Bán"].Points[i].LabelForeColor = Color.Green;
                    chaDoanhThu.Series["Tiền Nhập"].Points.AddXY(i + 1, dtnhap.Rows[0]["Thang" + (i + 1).ToString()]);
                    chaDoanhThu.Series["Tiền Nhập"].Points[i].Label = dtnhap.Rows[0]["Thang" + (i + 1).ToString()].ToString();
                    chaDoanhThu.Series["Tiền Nhập"].Points[i].LabelForeColor = Color.Red;
                }
                return;
            }

            if (cbbChonDoanhThu.SelectedIndex == 1)
            {
                lblTieuDe.Text = "Doanh Thu Theo Sản Phẩm";
                chaDoanhThu.Show();
                chaSPBanBDTron.Hide();
                chaSPNhapBDTron.Hide();
                chaDoanhThu.Series["Tiền Bán"].Points.Clear();
                chaDoanhThu.Series["Tiền Nhập"].Points.Clear();
                chaDoanhThu.ChartAreas["ChartArea1"].AxisX.Title = "Sản Phẩm";
                chaDoanhThu.ChartAreas["ChartArea1"].AxisY.Title = "VND";
                DataTable dtban = dtb.ReadData("select * from SPBan(" + nbrNam.Value +",N'"+cbbSP.SelectedValue+ "')");
                DataTable dtnhap = dtb.ReadData("select * from SPNhap(" + nbrNam.Value + ",N'"+cbbSP.SelectedValue+ "')");
                if(dtban.Rows.Count>0)
                {
                    chaDoanhThu.Series["Tiền Bán"].Points.AddXY(dtban.Rows[0]["TenSP"], dtban.Rows[0]["DTBan"]);
                    chaDoanhThu.Series["Tiền Bán"].Points[0].Label = dtban.Rows[0]["DTBan"].ToString();
                    chaDoanhThu.Series["Tiền Bán"].Points[0].LabelForeColor = Color.Green;
                }
                if (dtnhap.Rows.Count >0)
                {
                    chaDoanhThu.Series["Tiền Nhập"].Points.AddXY(dtnhap.Rows[0]["TenSP"], dtnhap.Rows[0]["DTNhap"]);
                    chaDoanhThu.Series["Tiền Nhập"].Points[0].Label = dtnhap.Rows[0]["DTNhap"].ToString();
                    chaDoanhThu.Series["Tiền Nhập"].Points[0].LabelForeColor = Color.Red;
                }
                if(dtnhap.Rows.Count <=0 && dtban.Rows.Count<=0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm " + cbbSP.SelectedValue + " ở năm " + nbrNam.Value);
                }
                return;
            }

            if (cbbChonDoanhThu.SelectedIndex == 2)
            {
                lblBan.Show();
                lblNhap.Show();
                lblTieuDe.Text = "Doanh Thu Theo Cơ Cấu Sản Phẩm";
                chaDoanhThu.Hide();
                cbbSP.Hide();
                chaSPBanBDTron.Show();
                chaSPNhapBDTron.Show();
                chaSPBanBDTron.Series["Tiền Bán"].Points.Clear();
                chaSPNhapBDTron.Series["Tiền Nhập"].Points.Clear();
                DataTable dtban = dtb.ReadData("select * from SPBanBDTron(" + nbrNam.Value + ")");
                DataTable dtnhap = dtb.ReadData("select * from SPNhapBDTron(" + nbrNam.Value + ")");
                if (dtban.Rows.Count > 0)
                {
                    for (int i = 0; i < dtban.Rows.Count; i++)
                    {
                        chaSPBanBDTron.Series["Tiền Bán"].Points.AddXY(dtban.Rows[i]["TenSP"], dtban.Rows[i]["DTBan"]);
                    }
                }
                if (dtnhap.Rows.Count > 0)
                {
                    for(int i = 0; i < dtnhap.Rows.Count; i++)
                    {
                        chaSPNhapBDTron.Series["Tiền Nhập"].Points.AddXY(dtnhap.Rows[i]["TenSP"], dtnhap.Rows[i]["DTNhap"]);
                    }    
                    
                }
                if (dtnhap.Rows.Count <= 0 && dtban.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm ở năm " + nbrNam.Value);
                }
                return;
            }
        }

       
    }
}
