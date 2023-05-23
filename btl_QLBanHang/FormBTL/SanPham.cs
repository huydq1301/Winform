using btl_QLBanHang.FormBTL.SanPham;
using QLBH.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Windows.Diagnostics;
using System.Globalization;

namespace btl_QLBanHang
{
    public partial class SanPham : Form
    {
        //
        CommonFunction function = new CommonFunction();
        ConnectData data = new ConnectData();
        string sql;
        int Action = 0;
        int Search = 0;
        string FileAnh;
        string TenFile = "";
        //
        private void cb_Add()
        {
            System.Data.DataTable dtcb = data.ReadData("SELECT * FROM tblChatLieu");
            function.FillCombobox(cb_ChatLieu, dtcb, "TenChatLieu", "MaChatLieu");
            dtcb = data.ReadData("SELECT * FROM tblKhuyenMai");
            function.FillCombobox(cb_KM, dtcb, "GiamGia", "MaKM");
            dtcb = data.ReadData("SELECT * FROM tblNhaCungCap");
            function.FillCombobox(cb_NCC, dtcb, "TenNCC", "MaNCC");
            dtcb = data.ReadData("SELECT * FROM tblMauSac");
            function.FillCombobox(cb_MauSac, dtcb, "TenMau", "MaMauSac");
            dtcb = data.ReadData("SELECT * FROM tblSize");
            function.FillCombobox(cb_Size, dtcb, "TenSize", "MaSize");
        }
        //
        private void dgv_load()
        {
            sql = "SELECT * FROM tblSanPham";
            dgvSanpham.DataSource = data.ReadData(sql);
            NhapThongTin(false);
            // Tên cột
            dgvSanpham.Columns[0].HeaderText = "Mã SP";
            dgvSanpham.Columns[1].HeaderText = "Tên SP";
            dgvSanpham.Columns[2].HeaderText = "Mã chất liệu";
            dgvSanpham.Columns[3].HeaderText = "Màu sắc";
            dgvSanpham.Columns[4].HeaderText = "Size";
            dgvSanpham.Columns[5].HeaderText = "Số lượng";
            dgvSanpham.Columns[6].HeaderText = "Mã Khuyến mãi";
            dgvSanpham.Columns[7].HeaderText = "Đơn giá nhập";
            dgvSanpham.Columns[8].HeaderText = "Đơn giá bán";
            dgvSanpham.Columns[9].HeaderText = "File Ảnh";
            dgvSanpham.Columns[10].HeaderText = "Ghi chú";
            dgvSanpham.Columns[11].HeaderText = "Mã Nhà cung cấp";
        }
        private void Reset()
        {
            tb_MaSP.Text = "";
            tb_SLuong.Text = "";
            cb_NCC.Text = "";
            tb_TenSP.Text = "";
            tb_DGN.Text = "";
            tb_DGB.Text = "";
            cb_KM.Text = "";
            cb_NCC.Text = "";
            cb_MauSac.Text = "";
            tb_MoTa.Text = "";
            cb_Size.Text = "";
            picSanpham.Image = null;
        }
        //
        public SanPham()
        {
            InitializeComponent();
            dgv_load();
            cb_Add();
        }
        // Enable các TextBox ComboBox RadioButton
        private void NhapThongTin(bool En)
        {
            tb_MaSP.Enabled = En;
            tb_TenSP.Enabled = En;
            cb_NCC.Enabled = En;
            tb_SLuong.Enabled = En;
            tb_DGN.Enabled = En;
            tb_DGB.Enabled = En;
            cb_KM.Enabled = En;
            cb_ChatLieu.Enabled = En;
            bt_Anh.Enabled = En;
            cb_MauSac.Enabled = En;
            cb_Size.Enabled = En;
            tb_MoTa.Enabled = En;
        }
        // Hủy thêm, sửa, xóa, tìm kiếm
        private void bt_Huy_Click(object sender, EventArgs e)
        {
            error_ThongTin.Clear();
            // Đang ở trạng thái tìm kiếm nhưng không bấm nút sửa hoặc xóa
            if ((Search == 1 && Action == 0) || (Search == 0 && Action != 0))
            {
                Search = 0;
                bt_Them.Enabled = true;
                bt_excel.Enabled = true;
                sql = "SELECT * FROM tblSanPham";
                dgvSanpham.DataSource = data.ReadData(sql);
            }
            Action = 0;
            bt_TimKiem.Enabled = true;
            bt_Sua.Enabled = true;
            bt_Xoa.Enabled = true;
            bt_Them.Text = "Thêm";
            bt_Sua.Text = "Sửa";
            bt_Xoa.Text = "Xóa";
            NhapThongTin(false);
            Reset();
        }
        // Kiểm tra lỗi nhập thông tin
        private bool LoiNhap()
        {
            error_ThongTin.Clear();
            bool loi = false;
            int SL = 0;
            decimal DonGia = 0;
            // Mã sản phẩm
            if (tb_MaSP.Text == "")
            {
                error_ThongTin.SetError(tb_MaSP, "Chưa nhập mã sản phẩm");
                loi = true;
            }
            // Tên sản phẩm
            if (tb_TenSP.Text == "")
            {
                error_ThongTin.SetError(tb_TenSP, "Chưa nhập tên sản phẩm");
                loi = true;
            }
            // Nhà cung cấp
            if (cb_NCC.Text == "")
            {
                error_ThongTin.SetError(cb_NCC, "Chưa chọn nhà cung cấp");
                loi = true;
            }
            // Số lượng SP
            if (tb_SLuong.Text == "")
            {
                error_ThongTin.SetError(tb_SLuong, "Chưa ghi số lượng sản phẩm");
                loi = true;
            }
            else if (!int.TryParse(tb_SLuong.Text, out SL))
            {
                error_ThongTin.SetError(tb_SLuong, "Số lượng sản phẩm chỉ được điền số");
                loi = true;
            }
            // Đơn giá nhập
            if (tb_DGN.Text == "")
            {
                error_ThongTin.SetError(tb_DGN, "Chưa ghi đơn giá nhập");
                loi = true;
            }
            else if (!decimal.TryParse(tb_DGN.Text, out DonGia))
            {
                error_ThongTin.SetError(tb_DGN, "Đơn giá nhập chỉ được điền số");
                loi = true;
            }
            // Đơn giá bán
            if (tb_DGB.Text == "")
            {
                error_ThongTin.SetError(tb_DGB, "Chưa ghi đơn giá bán");
                loi = true;
            }
            else if (!decimal.TryParse(tb_DGB.Text, out DonGia))
            {
                error_ThongTin.SetError(tb_DGB, "Đơn giá bán chỉ được điền số");
                loi = true;
            }
            // Khuyến mãi
            if (cb_KM.Text == "")
            {
                error_ThongTin.SetError(cb_KM, "Chưa ghi mã khuyến mãi");
                loi = true;
            }
            // Trả về bool
            return loi;
        }
        // Nhập dữ liệu hàng hóa
        private void bt_Them_Click(object sender, EventArgs e)
        {
            // Bấm nút thêm
            if (Action == 0)
            {
                bt_TimKiem.Enabled = false;
                bt_Sua.Enabled = false;
                bt_Xoa.Enabled = false;
                bt_excel.Enabled = false;
                bt_Them.Text = "Lưu";
                Action = 1;
                NhapThongTin(true);
            }
            // Thực hiện thêm dữ liệu
            else if (Action == 1)
            {
                // Kiểm tra nhập
                if (LoiNhap())
                    return;
                sql = "SELECT * FROM tblSanPham WHERE MaSP = N'" + tb_MaSP.Text + "'";
                if (data.ReadData(sql).Rows.Count != 0)
                {
                    error_ThongTin.SetError(tb_MaSP, "Mã sản phẩm đã có trong hệ thống");
                    return;
                }
                // sql
                sql = "INSERT INTO tblSanPham VALUES (" +
                    "'" + tb_MaSP.Text + "', " +
                    "N'" + tb_TenSP.Text + "', " +
                    "'" + cb_ChatLieu.SelectedValue + "', " +
                    "N'" + cb_MauSac.SelectedValue + "', " +
                    "'" + cb_Size.SelectedValue + "'," +
                    "" + tb_SLuong.Text + ", " +
                    "'" + cb_KM.SelectedValue + "', " +
                    "" + tb_DGN.Text + ", " +
                    "" + tb_DGB.Text + ", " +
                    "'" + TenFile + "', " +
                    "N'" + tb_MoTa.Text + "', " +
                    "'" + cb_NCC.SelectedValue + "')";
                data.ChangeData(sql);
                dgv_load();
                // Kết thúc nhập
                bt_TimKiem.Enabled = true;
                bt_Sua.Enabled = true;
                bt_Xoa.Enabled = true;
                bt_excel.Enabled = true;
                bt_Them.Text = "Thêm";
                Action = 0;
                NhapThongTin(false);
            }
        }
        // Tìm Kiếm hàng hóa
        private void bt_TimKiem_Click(object sender, EventArgs e)
        {
            TimKiemSP TKSP = new TimKiemSP();
            TKSP.ShowDialog();
            if (CommonFunction.Search == 1)
            {
                bt_Them.Enabled = false;
                bt_excel.Enabled = false;
                Search = 1;
                dgvSanpham.DataSource = data.ReadData(CommonFunction.sql);
                //tb_MoTa.Text = CommonFunction.sql;
            }
            else
                return;
        }
        // Sửa dữ liệu hàng hóa
        private void bt_Sua_Click(object sender, EventArgs e)
        {
            // Bấm nút sửa
            if (Action == 0)
            {
                if (tb_MaSP.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm để sửa");
                    return;
                }
                else
                {
                    bt_Them.Enabled = false;
                    bt_TimKiem.Enabled = false;
                    bt_Xoa.Enabled = false;
                    bt_excel.Enabled = false;
                    bt_Sua.Text = "Lưu";
                    Action = 2;
                    NhapThongTin(true);
                    tb_MaSP.Enabled = false;
                }
            }
            // Thực hiện sửa dữ liệu
            else if (Action == 2)
            {
                // Kiểm tra lỗi
                if (tb_MaSP.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm để sửa");
                    return;
                }
                if (LoiNhap())
                    return;
                // sql

                sql = "UPDATE tblSanPham SET " +
                    "TenSP = N'" + tb_TenSP.Text + "', " +
                    "MaChatLieu = '" + cb_ChatLieu.SelectedValue + "', " +
                    "MaMauSac = N'" + cb_MauSac.SelectedValue + "', " +
                    "MaSize = N'" + cb_Size.SelectedValue + "'," +
                    "SoLuong = '" + tb_SLuong.Text + "', " +
                    "MaKM = '" + cb_KM.SelectedValue + "', " +
                    "DonGiaNhap = '" + tb_DGN.Text + "', " +
                    "DonGiaBan = '" + tb_DGB.Text + "', " +
                    "Anh = '" + TenFile + "', " +
                    "GhiChu = N'" + tb_MoTa.Text + "', " +
                    "MaNCC = '" + cb_NCC.SelectedValue + "'" +
                    "WHERE MaSP = '" + tb_MaSP.Text + "'";
                data.ChangeData(sql);
                dgv_load();
                string sqlcheckban = "select * from tblChiTietHDB where MaSP=N'" + tb_MaSP.Text + "'";
                System.Data.DataTable checkban = data.ReadData(sqlcheckban);
                if (checkban.Rows.Count > 0)
                {
                    double thanhtien = 0, sl = 0, gia = 0;
                    int km = 0;
                    string select = "select SLBan from tblSanPham , tblChiTietHDB "
                        + "where tblSanPham.MaSP= tblChiTietHDB.MaSP";
                    System.Data.DataTable dtselect = data.ReadData(select);
                    gia = Convert.ToDouble(tb_DGB.Text);
                    sl = Convert.ToDouble(dtselect.Rows[0]["SLBan"].ToString());
                    km = Convert.ToInt16(cb_KM.Text);
                    thanhtien = (sl * gia) * (100 - km) / 100;
                    string updatett = "update tblChiTietHDB set ThanhTien=" + thanhtien
                        + " where MaSP=N'" + tb_MaSP.Text + "'";
                    data.ChangeData(updatett);
                }
                string sqlchecknhap = "select * from tblChiTietHDN where MaSP=N'" + tb_MaSP.Text + "'";
                System.Data.DataTable checknhap = data.ReadData(sqlchecknhap);
                if (checknhap.Rows.Count > 0)
                {
                    double thanhtien = 0, sl = 0, gia = 0;
                    string select = "select SLNhap from tblSanPham , tblChiTietHDN "
                        + "where tblSanPham.MaSP= tblChiTietHDN.MaSP";
                    System.Data.DataTable dtselect = data.ReadData(select);
                    gia = Convert.ToDouble(tb_DGN.Text);
                    sl = Convert.ToDouble(dtselect.Rows[0]["SLNhap"].ToString());
                    thanhtien = (sl * gia);
                    string updatett = "update tblChiTietHDN set ThanhTien=" + thanhtien
                        + " where MaSP=N'" + tb_MaSP.Text + "'";
                    data.ChangeData(updatett);
                }
                // Kết thúc sửa
                if (Search == 0)
                    bt_Them.Enabled = true;
                bt_TimKiem.Enabled = true;
                bt_Xoa.Enabled = true;
                bt_excel.Enabled = true;
                bt_Sua.Text = "Sửa";
                Action = 0;
                NhapThongTin(false);
                Reset();
            }

        }
        // Xóa dữ liệu hàng hóa
        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            // Bấm nút xóa
            if (Action == 0)
            {
                // Kiểm tra điều kiện
                if (tb_MaSP.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn sảm phẩm để xóa");
                    return;
                }
                bt_Them.Enabled = false;
                bt_TimKiem.Enabled = false;
                bt_Sua.Enabled = false;
                bt_excel.Enabled = false;
                bt_Xoa.Text = "Lưu";
                Action = 3;
            }
            // thực hiện xóa dữ liệu
            else if (Action == 3)
            {
                // sql
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm có mã " + dgvSanpham.CurrentRow.Cells[0].Value.ToString(),
                "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlban = "select * from tblChiTietHDB where MaSP=N'" + tb_MaSP.Text + "'";
                    System.Data.DataTable checkban = data.ReadData(sqlban);
                    string sqlnhap = "select * from tblChiTietHDN where MaSP=N'" + tb_MaSP.Text + "'";
                    System.Data.DataTable checknhap = data.ReadData(sqlnhap);
                    if (checknhap.Rows.Count > 0 || checkban.Rows.Count > 0)
                    {
                        MessageBox.Show("Bạn không thể xóa mã sản phẩm này vì nó liên quan bảng chi tiết hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    sql = "DELETE FROM tblSanPham WHERE MaSP = '" + tb_MaSP.Text + "'";
                    data.ChangeData(sql);
                    dgv_load();
                }
                else
                    return;
                // Kết thúc xóa
                if (Search == 0)
                    bt_Them.Enabled = true;
                bt_TimKiem.Enabled = true;
                bt_Sua.Enabled = true;
                bt_excel.Enabled = true;
                bt_Xoa.Text = "Xóa";
                Action = 0;
                Reset();
            }

        }
        // Làm mới textbox, combobox

        // Chọn ảnh
        private void bt_Anh_Click(object sender, EventArgs e)
        {
            string[] image;
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "JPEG Images|*.jpg|PNG Images|*.png|All Files|*.*";
            OpenFile.FilterIndex = 1;
            OpenFile.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\Images\\SanPham\\";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                picSanpham.Image = Image.FromFile(OpenFile.FileName);
                image = OpenFile.FileName.ToString().Split('\\');
                FileAnh = image[image.Length - 1];
                TenFile = Path.GetFileName(FileAnh);
            }
        }
        // Chọn dòng trong DataGridView
        private void dgvSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_MaSP.Text = dgvSanpham.CurrentRow.Cells[0].Value.ToString();
            tb_TenSP.Text = dgvSanpham.CurrentRow.Cells[1].Value.ToString();
            cb_ChatLieu.SelectedValue = dgvSanpham.CurrentRow.Cells[2].Value.ToString();
            cb_MauSac.SelectedValue = dgvSanpham.CurrentRow.Cells[3].Value.ToString();
            cb_Size.SelectedValue = dgvSanpham.CurrentRow.Cells[4].Value.ToString();
            tb_SLuong.Text = dgvSanpham.CurrentRow.Cells[5].Value.ToString();
            cb_KM.SelectedValue = dgvSanpham.CurrentRow.Cells[6].Value.ToString();
            tb_DGN.Text = dgvSanpham.CurrentRow.Cells[7].Value.ToString();
            tb_DGB.Text = dgvSanpham.CurrentRow.Cells[8].Value.ToString();
            TenFile = dgvSanpham.CurrentRow.Cells[9].Value.ToString();
            tb_MoTa.Text = dgvSanpham.CurrentRow.Cells[10].Value.ToString();
            cb_NCC.SelectedValue = dgvSanpham.CurrentRow.Cells[11].Value.ToString();
            try
            {
                picSanpham.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Images\\SanPham\\" + TenFile);
            }
            catch
            {
                picSanpham.Image = null;
            }
        }
        // In dữ liệu ra excel
        private void bt_excel_Click(object sender, EventArgs e)
        {
            try
            {
                string ExcelFile = System.Windows.Forms.Application.StartupPath;
                Object misvalue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                //
                if (ExcelApp == null)
                    MessageBox.Show("Không thể sử dụng được thư viện EXCEL");
                //
                ExcelApp.Visible = false;
                Microsoft.Office.Interop.Excel.Workbook wb =
                    ExcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws =
                    (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range range =
                    (Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 1];
                //
                if (ws == null)
                {
                    MessageBox.Show("Không thể tạo được WorkSheet");
                    return;
                }
                // Viết ra excel
                ws.Cells[1, 1].Value = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                for (int i = 0; i < dgvSanpham.ColumnCount; i++)
                {
                    ws.Cells[2, i + 1].Value = dgvSanpham.Columns[i].HeaderText;
                }
                for (int i = 0; i < dgvSanpham.RowCount; i++)
                {
                    for (int j = 0; j < dgvSanpham.ColumnCount; j++)
                    {
                        if (dgvSanpham.Rows[i].Cells[j].Value != null)
                            ws.Cells[i + 3, j + 1].Value = dgvSanpham.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // Lưu File excel
                wb.SaveAs(ExcelFile);
                MessageBox.Show("In tệp Excel thành công");
                // Thoát và thu hồi bộ nhớ
                ExcelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
