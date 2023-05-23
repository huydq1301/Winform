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
using Excel = Microsoft.Office.Interop.Excel;
namespace btl_QLBanHang.FormBTL
{
    public partial class ChiTietHDN : Form
    {
        public ChiTietHDN()
        {
            InitializeComponent();
        }
        string mahdn = staticdata.MaHDN;
        CommonFunction func = new CommonFunction();
        ConnectData dtb = new ConnectData();
        double tongtien = 0;
        void LoadData()
        {
            txtMaHDN.Text = mahdn;
            string sql = " select MaSP, SLNhap, ThanhTien from tblChiTietHDN where MaHDN=N'" + txtMaHDN.Text + "'";
            DataTable CThdn = dtb.ReadData(sql);
            dgvChiTietHDN.DataSource = CThdn;
            DataTable dtSP = dtb.ReadData("Select * from tblSanPham ");
            func.FillCombobox(cbbMaSP, dtSP, "MaSP", "MaSP");

            for (int i = 0; i < CThdn.Rows.Count; i++)
            {
                tongtien = tongtien + float.Parse(CThdn.Rows[i]["ThanhTien"].ToString());
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
            txtMaHDN.Enabled = false;
            txtTenSanPham.Enabled = false;
            txtGiaNhap.Enabled = false;
            txtThanhTien.Enabled = false;
            nbrSLNhap.Value = 0;
            nbrSLNhap.Enabled = false;
            cbbMaSP.SelectedIndex = -1;
            cbbMaSP.Focus();
        }
        private void ChiTietHDN_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvChiTietHDN.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvChiTietHDN.Columns[1].HeaderText = "Số Lượng Nhập";
            dgvChiTietHDN.Columns[2].HeaderText = "Thành Tiền";
            ResetValues();
        }

        private void dgvChiTietHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            nbrSLNhap.Enabled = true;
            cbbMaSP.Enabled = false;
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                cbbMaSP.SelectedValue = dgvChiTietHDN.CurrentRow.Cells[0].Value.ToString();
                nbrSLNhap.Text = dgvChiTietHDN.CurrentRow.Cells[1].Value.ToString();
                txtThanhTien.Text = dgvChiTietHDN.CurrentRow.Cells[2].Value.ToString();
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
                txtGiaNhap.Text = "";
                return;
            }
            try
            {
                DataTable dtSP = dtb.ReadData("Select TenSP, DonGiaNhap from tblSanPham " +
                " where tblSanPham.MaSP=N'" + cbbMaSP.SelectedValue + "'");
                txtTenSanPham.Text = dtSP.Rows[0]["TenSP"].ToString();
                DataTable SP = dtb.ReadData("Select  DonGiaNhap from tblSanPham " +
                " where tblSanPham.MaSP=N'" + cbbMaSP.SelectedValue + "'");
                txtGiaNhap.Text = SP.Rows[0]["DonGiaNhap"].ToString();
                txtThanhTien.Text = (Convert.ToDouble(txtGiaNhap.Text) * Convert.ToDouble(nbrSLNhap.Value)).ToString();
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
            nbrSLNhap.Enabled = true;
            cbbMaSP.Focus();
        }

        private void nbrSLNhap_ValueChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = (Convert.ToDouble(txtGiaNhap.Text) * Convert.ToDouble(nbrSLNhap.Value)).ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = dtb.ReadData("Select * from tblChiTietHDN where MaHDN ='" + txtMaHDN.Text +
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
            if (nbrSLNhap.Value == 0)
            {
                MessageBox.Show("Bạn phải chọn số lượng sản phẩm!");
                nbrSLNhap.Focus();
                return;
            }
            int slcon = 0, slnhap = 0;
            DataTable dtSP = dtb.ReadData("Select SoLuong from tblSanPham where MaSP='" + cbbMaSP.SelectedValue + "'");
            slcon = int.Parse(dtSP.Rows[0]["SoLuong"].ToString());
            slnhap = int.Parse(nbrSLNhap.Value.ToString());
            // them moi CTHDN vao database           
            string sqlinsert = "Insert into tblChiTietHDN values(N'" + txtMaHDN.Text + "',N'" + cbbMaSP.SelectedValue + "','"
              + nbrSLNhap.Value + "',N'" + txtThanhTien.Text + "')";
            dtb.ChangeData(sqlinsert);
            string sqlupdate = "UpDate tblSanPham set SoLuong='" + (slcon + slnhap).ToString() + "' where MaSP='" + cbbMaSP.SelectedValue + "'";
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
                if (nbrSLNhap.Value == 0)
                {
                    MessageBox.Show("Bạn phải chọn số lượng sản phẩm!");
                    nbrSLNhap.Focus();
                    return;
                }
                try
                {
                    int slcon = 0, slnhaptruoc = 0, slnhapsau = 0;
                    DataTable dtSP = dtb.ReadData("Select SoLuong from tblSanPham where MaSP='" + cbbMaSP.SelectedValue + "'");
                    DataTable dtCThdn = dtb.ReadData("Select SLNhap from tblChiTietHDN where MaSP='" + cbbMaSP.SelectedValue + "'");
                    slcon = int.Parse(dtSP.Rows[0]["SoLuong"].ToString());
                    slnhaptruoc = int.Parse(dtCThdn.Rows[0]["SLNhap"].ToString());
                    slnhapsau = int.Parse(nbrSLNhap.Value.ToString());
                    if (slnhaptruoc < slnhapsau)
                    {
                        slcon = slcon + slnhapsau - slnhaptruoc;
                    }
                    else
                    {
                        slcon = slcon - slnhaptruoc + slnhapsau;
                    }
                    dtb.ChangeData("update tblChiTietHDN set SLNhap='" + nbrSLNhap.Value +
                    "',ThanhTien='" + txtThanhTien.Text + "' where MaHDN=N'" + txtMaHDN.Text + "' and MaSP=N'" + cbbMaSP.SelectedValue + "'");
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
                    int slcon = 0, slnhap = 0;
                    DataTable dtSP = dtb.ReadData("Select SoLuong from tblSanPham where MaSP='" + cbbMaSP.SelectedValue + "'");
                    slcon = int.Parse(dtSP.Rows[0]["SoLuong"].ToString());
                    slnhap = int.Parse(nbrSLNhap.Value.ToString());
                    dtb.ChangeData("Delete tblChiTietHDN where MaHDN='" + txtMaHDN.Text + "' and MaSP=N'" + cbbMaSP.SelectedValue + "'");
                    string sqlupdate = "UpDate tblSanPham set SoLuong='" + (slcon - slnhap).ToString() + "' where MaSP='" + cbbMaSP.SelectedValue + "'";
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
            if (dgvChiTietHDN.Rows.Count > 0) //TH có dữ liệu để ghi
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
                header.Value = "CHI TIẾT HÓA ĐƠN NHẬP";
                exSheet.get_Range("A2").Value = "Chi Tiết Hóa Đơn Nhập Số: " + txtMaHDN.Text;
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
                exSheet.get_Range("C4").Value = "Số Lượng Nhập";
                exSheet.get_Range("C4").ColumnWidth = 20;
                exSheet.get_Range("D4").Value = "Thành Tiền";
                exSheet.get_Range("D4").ColumnWidth = 20;
                //In dữ liệu
                DataTable dtCTHDN = dtb.ReadData("Select * from tblChiTietHDN");
                for (int i = 0; i < dtCTHDN.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 5).ToString() + ":G" + (i + 5).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 5).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 5).ToString()).Value = dtCTHDN.Rows[i]["MaSP"].ToString();
                    exSheet.get_Range("C" + (i + 5).ToString()).Value = dtCTHDN.Rows[i]["SLNhap"].ToString();
                    exSheet.get_Range("D" + (i + 5).ToString()).Value = dtCTHDN.Rows[i]["ThanhTien"].ToString();
                }
                exSheet.Name = "Chi Tiết Hóa Đơn Nhập";
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
