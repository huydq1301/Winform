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
using Excel = Microsoft.Office.Interop.Excel;
namespace btl_QLBanHang.FormBTL
{
    public partial class ChiTietHDB : Form
    {
        string mahdb = staticdata.MaHDB;
        CommonFunction func = new CommonFunction();
        ConnectData dtb = new ConnectData();
        public ChiTietHDB()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            txtMaHDB.Text = mahdb;
            string sql = " select MaSP, SLBan, MaKM, ThanhTien from tblChiTietHDB where MaHDB=N'" + txtMaHDB.Text + "'";
            DataTable CThdb = dtb.ReadData(sql);
            dgvChiTietHDB.DataSource = CThdb;
            DataTable dtSP = dtb.ReadData("Select * from tblSanPham ");
            func.FillCombobox(cbbMaSP, dtSP, "MaSP", "MaSP");
            double tongtien = 0;
            for (int i = 0; i < CThdb.Rows.Count; i++)
            {
                tongtien = tongtien + float.Parse(CThdb.Rows[i]["ThanhTien"].ToString());
            }
            lblTongTien.Text = "Tổng Tiền: " + tongtien.ToString();
        }
        private void ResetValues()
        {
            cbbMaSP.Enabled = true;
            btnIn.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHDB.Enabled = false;
            txtTenSanPham.Enabled = false;
            txtGiaBan.Enabled = false;
            txtThanhTien.Enabled = false;
            txtMaKM.Enabled = false;
            nbrSLBan.Enabled = false;
            nbrSLBan.Value = 0;
            cbbMaSP.SelectedIndex = -1;
            cbbMaSP.Focus();
        }

        private void ChiTietHDB_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvChiTietHDB.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvChiTietHDB.Columns[1].HeaderText = "Số Lượng Bán";
            dgvChiTietHDB.Columns[2].HeaderText = "Mã Khuyến Mại";
            dgvChiTietHDB.Columns[3].HeaderText = "Thành Tiền";
            ResetValues();
        }

        private void dgvChiTietHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            cbbMaSP.Enabled = false;
            nbrSLBan.Enabled = true;
            txtMaKM.Enabled = false;
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                cbbMaSP.SelectedValue = dgvChiTietHDB.CurrentRow.Cells[0].Value.ToString();
                nbrSLBan.Text = dgvChiTietHDB.CurrentRow.Cells[1].Value.ToString();
                txtMaKM.Text = dgvChiTietHDB.CurrentRow.Cells[2].Value.ToString();
                txtThanhTien.Text = dgvChiTietHDB.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void cbbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaSP.SelectedIndex == -1)
            {
                txtTenSanPham.Text = "";
                txtGiaBan.Text = "";
                txtMaKM.Text = "";
                return;
            }
            try
            {
                DataTable dtSP = dtb.ReadData("Select TenSP, DonGiaNhap from tblSanPham " +
                " where tblSanPham.MaSP=N'" + cbbMaSP.SelectedValue + "'");
                txtTenSanPham.Text = dtSP.Rows[0]["TenSP"].ToString();
                DataTable SP = dtb.ReadData("Select  DonGiaBan, MaKM from tblSanPham " +
                " where tblSanPham.MaSP=N'" + cbbMaSP.SelectedValue + "'");
                txtGiaBan.Text = SP.Rows[0]["DonGiaBan"].ToString();
                txtMaKM.Text = SP.Rows[0]["MaKM"].ToString();
                DataTable dtKM = dtb.ReadData("Select GiamGia from tblSanPham, tblKhuyenMai" +
               " where tblSanPham.MaKM = tblKhuyenMai.MaKM and tblSanPham.MaSP='" + cbbMaSP.SelectedValue + "'");
                int phantramkm = int.Parse(dtKM.Rows[0]["GiamGia"].ToString());
                txtThanhTien.Text = (Convert.ToDouble(txtGiaBan.Text) * Convert.ToDouble(nbrSLBan.Value) * (100 - phantramkm) / 100).ToString();
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable dtSP = dtb.ReadData("Select MaSP from tblSanPham");
            func.FillCombobox(cbbMaSP, dtSP, "MaSP", "MaSP");
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            nbrSLBan.Enabled = true;
            cbbMaSP.Focus();
        }

        private void nbrSLBan_ValueChanged(object sender, EventArgs e)
        {
            DataTable dtKM = dtb.ReadData("Select GiamGia from tblSanPham, tblKhuyenMai" +
               " where tblSanPham.MaKM = tblKhuyenMai.MaKM and tblSanPham.MaSP='" + cbbMaSP.SelectedValue + "'");
            int phantramkm = int.Parse(dtKM.Rows[0]["GiamGia"].ToString());
            txtThanhTien.Text = (Convert.ToDouble(txtGiaBan.Text) * Convert.ToDouble(nbrSLBan.Value) * (100 - phantramkm) / 100).ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = dtb.ReadData("Select * from tblChiTietHDB where MaHDB ='" + txtMaHDB.Text +
                "' and MaSP=N'" + cbbMaSP.SelectedValue + "'");

            //Kiem tra dieu kien
            if (dtCheck.Rows.Count > 0)
            {
                MessageBox.Show("Hóa đơn này đã tồn tại mời bạn nhập mã khác");
                cbbMaSP.Focus();
                return;
            }
            if (cbbMaSP.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã sản phẩm!");
                cbbMaSP.Focus();
                return;
            }
            if (nbrSLBan.Value == 0)
            {
                MessageBox.Show("Bạn phải chọn số lượng sản phẩm!");
                nbrSLBan.Focus();
                return;
            }
            int slcon = 0, slban = 0;
            DataTable dtSP = dtb.ReadData("Select SoLuong from tblSanPham where MaSP='" + cbbMaSP.SelectedValue + "'");
            slcon = int.Parse(dtSP.Rows[0]["SoLuong"].ToString());
            slban = int.Parse(nbrSLBan.Value.ToString());
            if (slcon < slban)
            {
                MessageBox.Show("Không còn đủ số lượng. Sản phẩm " + txtTenSanPham.Text + " chỉ còn " + slcon);
                nbrSLBan.Focus();
                return;
            }
            slcon = slcon - slban;
            // them moi CTHDB vao database           
            string sqlinsert = "Insert into tblChiTietHDB values(N'" + txtMaHDB.Text + "',N'" + cbbMaSP.SelectedValue + "','"
              + nbrSLBan.Value + "',N'" + txtMaKM.Text + "',N'" + txtThanhTien.Text + "')";
            dtb.ChangeData(sqlinsert);
            string sqlupdate = "UpDate tblSanPham set SoLuong='" + (slcon).ToString() + "' where MaSP='" + cbbMaSP.SelectedValue + "'";
            dtb.ChangeData(sqlupdate);
            LoadData();
            MessageBox.Show("Thêm mới thành công!");
            btnBoqua_Click(sender, e);
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            LoadData();
            ResetValues();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            LoadData();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;

            if (MessageBox.Show("Bạn có muốn sửa?", "TB",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (cbbMaSP.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn phải chọn mã sản phẩm!");
                    cbbMaSP.Focus();
                    return;
                }
                if (nbrSLBan.Value == 0)
                {
                    MessageBox.Show("Bạn phải chọn số lượng sản phẩm!");
                    nbrSLBan.Focus();
                    return;
                }
                try
                {
                    int slcon = 0, slbantruoc = 0, slbansau = 0;
                    DataTable dtSP = dtb.ReadData("Select SoLuong from tblSanPham where MaSP='" + cbbMaSP.SelectedValue + "'");
                    DataTable dtCThdb = dtb.ReadData("Select SLBan from tblChiTietHDB where MaSP='" + cbbMaSP.SelectedValue + "'");
                    slcon = int.Parse(dtSP.Rows[0]["SoLuong"].ToString());
                    slbantruoc = int.Parse(dtCThdb.Rows[0]["SLBan"].ToString());
                    slbansau = int.Parse(nbrSLBan.Value.ToString());
                    if (slbantruoc < slbansau)
                    {
                        slcon = slcon - slbansau + slbantruoc;
                    }
                    else
                    {
                        slcon = slcon + slbantruoc - slbansau;
                    }
                    if (slcon < 0)
                    {
                        MessageBox.Show("Không còn đủ số lượng. Sản phẩm " + txtTenSanPham.Text + " chỉ còn " + slcon);
                        nbrSLBan.Focus();
                        return;
                    }
                    dtb.ChangeData("update tblChiTietHDB set SLBan=N'" + nbrSLBan.Value +
                    "',ThanhTien='" + txtThanhTien.Text +
                    "' where MaHDB=N'" + txtMaHDB.Text + "' and MaSP=N'" + cbbMaSP.SelectedValue + "'");
                    string sqlupdate = "UpDate tblSanPham set SoLuong='" + (slcon).ToString() + "' where MaSP='" + cbbMaSP.SelectedValue + "'";
                    dtb.ChangeData(sqlupdate);
                    LoadData();
                    MessageBox.Show("Sửa thành công!");
                    btnBoqua_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("Sửa không thành công, do dữ liệu có liên quan đến sản phẩm khác!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbbMaSP.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn hóa đơn để xóa");
                return;

            }
            if (MessageBox.Show("Bạn có muốn xóa?", "TB",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int slcon = 0, slban = 0;
                    DataTable dtSP = dtb.ReadData("Select SoLuong from tblSanPham where MaSP='" + cbbMaSP.SelectedValue + "'");
                    slcon = int.Parse(dtSP.Rows[0]["SoLuong"].ToString());
                    slban = int.Parse(nbrSLBan.Value.ToString());
                    dtb.ChangeData("Delete tblChiTietHDB where MaHDB='" + txtMaHDB.Text + "' and MaSP=N'" + cbbMaSP.SelectedValue + "'");
                    string sqlupdate = "UpDate tblSanPham set SoLuong='" + (slcon + slban).ToString() + "' where MaSP='" + cbbMaSP.SelectedValue + "'";
                    dtb.ChangeData(sqlupdate);
                    LoadData();
                    btnBoqua_Click(sender, e);
                    MessageBox.Show("Xóa thành công!");
                }
                catch
                {
                    MessageBox.Show("Xóa không thành công, do dữ liệu có liên quan đến sản phẩm khác!");
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHDB.Rows.Count > 0) //TH có dữ liệu để ghi
            {
                //Khai báo và khởi tạo các đối tượng
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
                //Định dạng chung
                Excel.Range header = (Excel.Range)exSheet.Cells[1, 3];
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "CHI TIẾT HÓA ĐƠN BÁN";
                exSheet.get_Range("A2").Value = "Chi Tiết Hóa Đơn Bán Số: " + txtMaHDB.Text;
                exSheet.get_Range("A2").Font.Bold = true;
                exSheet.get_Range("A2").Font.Color = Color.Red;
                exSheet.get_Range("A3").Value = lblTongTien.Text;
                exSheet.get_Range("A3").Font.Bold = true;
                exSheet.get_Range("A3").Font.Color = Color.Green;
                //Định dạng tiêu đề bảng

                exSheet.get_Range("A4:G4").Font.Bold = true;
                exSheet.get_Range("A4:G4").HorizontalAlignment =
                Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A4").Value = "STT";
                exSheet.get_Range("B4").Value = "Mã Sản Phẩm";
                exSheet.get_Range("B4").ColumnWidth = 20;
                exSheet.get_Range("C4").Value = "Số Lượng Bán";
                exSheet.get_Range("C4").ColumnWidth = 20;
                exSheet.get_Range("D4").Value = "Mã Khuyến Mại";
                exSheet.get_Range("D4").ColumnWidth = 20;
                exSheet.get_Range("E4").Value = "Thành Tiền";
                exSheet.get_Range("E4").ColumnWidth = 20;
                //In dữ liệu
                DataTable dtCTHDB = dtb.ReadData("Select * from tblChiTietHDB");
                for (int i = 0; i < dtCTHDB.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 5).ToString() + ":G" + (i + 5).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 5).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 5).ToString()).Value = dtCTHDB.Rows[i]["MaSP"].ToString();
                    exSheet.get_Range("C" + (i + 5).ToString()).Value = dtCTHDB.Rows[i]["SLBan"].ToString();
                    exSheet.get_Range("D" + (i + 5).ToString()).Value = dtCTHDB.Rows[i]["MaKM"].ToString();
                    exSheet.get_Range("E" + (i + 5).ToString()).Value = dtCTHDB.Rows[i]["ThanhTien"].ToString();
                }
                exSheet.Name = "Chi Tiết Hóa Đơn Bán";
                exBook.Activate();
                //Kích hoạt file Excel
                //Thiết lập các thuộc tính của SaveFileDialog
                dlgSave.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc)| *.doc | All files(*.*) | *.* ";
                dlgSave.FilterIndex = 1;
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".xls";
                string filePath = "";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = dlgSave.FileName;
                    exBook.SaveAs(dlgSave.FileName.ToString());//Lưu file Excel
                }
                exApp.Quit();//Thoát khỏi ứng dụng
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return;
                }
                MessageBox.Show("In thành công!");
            }
            else
                MessageBox.Show("Không có danh sách hóa đơn để in");
        }
    }
}
