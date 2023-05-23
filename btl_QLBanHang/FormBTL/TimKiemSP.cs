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
using System.Windows.Markup;

namespace btl_QLBanHang.FormBTL.SanPham
{
    public partial class TimKiemSP : Form
    {
        ConnectData data = new ConnectData();
        CommonFunction function = new CommonFunction();
        //
        public TimKiemSP()
        {
            InitializeComponent();
        }
        //
        private void cb_Add()
        {
            DataRow dr;
            DataTable dtcb = data.ReadData("SELECT * FROM tblChatLieu");
            //
            dr = dtcb.NewRow();
            dr["TenChatLieu"] = "Tất cả";
            dr["MaChatLieu"] = null;
            dtcb.Rows.InsertAt(dr, 0);
            function.FillCombobox(cb_ChatLieu, dtcb, "TenChatLieu", "MaChatLieu");
            //
            dtcb = data.ReadData("SELECT * FROM tblNhaCungCap");
            dr = dtcb.NewRow();
            dr["TenNCC"] = "Tất cả";
            dr["MaNCC"] = null;
            dtcb.Rows.InsertAt(dr, 0);
            function.FillCombobox(cb_NCC, dtcb, "TenNCC", "MaNCC");
            //
            dtcb = data.ReadData("SELECT * FROM tblMauSac");
            dr = dtcb.NewRow();
            dr["TenMau"] = "Tất cả";
            dr["MaMauSac"] = null;
            dtcb.Rows.InsertAt(dr, 0);
            function.FillCombobox(cb_MauSac, dtcb, "TenMau", "MaMauSac");
            //
            dtcb = data.ReadData("SELECT * FROM tblSize");
            dr = dtcb.NewRow();
            dr["TenSize"] = "Tất cả";
            dr["MaSize"] = null;
            dtcb.Rows.InsertAt(dr, 0);
            function.FillCombobox(cb_Size, dtcb, "TenSize", "MaSize");

        }
        private void TimKiemSP_Load(object sender, EventArgs e)
        {
            cb_Add();
            CommonFunction.Search = 0;
        }
        private void bt_Thoat_Click(object sender, EventArgs e)
        {
            CommonFunction.sql = "";
            this.Close();
        }

        private string WHEREorAND(int filter)
        {
            if (filter == 0)
                return " WHERE ";
            else
                return " AND ";
        }
        private void IntOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bt_TimKiem_Click(object sender, EventArgs e)
        {
            int filter = 0;
            CommonFunction.sql = "";
            string sql = "SELECT * FROM tblSanPham";
            // Tìm theo mã SP
            if (tb_MaSP.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "MaSP = '" + tb_MaSP.Text + "'";
                filter++;
            }
            // Tìm theo tên SP
            if (tb_TenSP.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "TenSP LIKE N'" + tb_TenSP.Text + "'";
                filter++;
            }
            // Tìm theo màu sắc
            if (cb_MauSac.Text != "Tất cả")
            {
                sql += WHEREorAND(filter);
                sql += "MaMauSac LIKE N'" + cb_MauSac.SelectedValue + "'";
                filter++;
            }
            // Tìm theo size
            if (cb_Size.Text != "Tất cả")
            {
                sql += WHEREorAND(filter);
                sql += "MaSize LIKE N'" + cb_Size.SelectedValue + "'";
                filter++;
            }
            // Tìm theo số lượng SP
            if (tb_SL_Min.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "SoLuong >= " + tb_SL_Min.Text;
                filter++;
            }
            if (tb_SL_Min.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "SoLuong <= " + tb_SL_Max.Text;
                filter++;
            }
            // Tìm theo khuyến mãi
            /*if (tb_KM_Min.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "GiamGia > " + tb_KM_Min.Text;
                filter++;
            }
            if (tb_KM_Max.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "GiamGia < " + tb_KM_Max.Text;
                filter++;
            }*/
            // Tìm theo đơn giá nhập
            if (tb_DGN_Min.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "DonGiaNhap >= " + tb_DGN_Min.Text;
                filter++;
            }
            if (tb_DGN_Max.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "DonGiaNhap <= " + tb_DGN_Max.Text;
                filter++;
            }
            // Tìm theo đơn giá bán
            if (tb_DGB_Min.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "DonGiaBan >= " + tb_DGB_Min.Text;
                filter++;
            }
            if (tb_DGB_Max.Text != "")
            {
                sql += WHEREorAND(filter);
                sql += "DonGiaBan <= " + tb_DGB_Max.Text;
                filter++;
            }
            // Tìm theo chất liệu
            if (cb_ChatLieu.Text != "Tất cả")
            {
                sql += WHEREorAND(filter);
                sql += "MaChatLieu LIKE '" + cb_ChatLieu.SelectedValue + "'";
                filter++;
            }
            // Tìm theo nhà phân phối
            if (cb_NCC.Text != "Tất cả")
            {
                sql += WHEREorAND(filter);
                sql += "MaNCC LIKE '" + cb_ChatLieu.SelectedValue + "'";
                filter++;
            }
            // Thực hiện tìm kiếm
            if (filter == 0)
            {
                MessageBox.Show("Bạn chưa nhập thông tin của sản phẩm cần tìm");
                return;
            }
            else
            {
                CommonFunction.sql = sql;
                CommonFunction.Search = 1;
                this.Close();
            }
        }
    }
}
