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
    public partial class HDX : Form
    {
        CommonFunction func = new CommonFunction();
        ConnectData dtb = new ConnectData();
        public HDX()
        {
            InitializeComponent();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            ChiTietHDB ctHDB = new ChiTietHDB();
            ctHDB.ShowDialog();
        }
        void LoadData()
        {
            string sql = " select * from tblHoaDonBan ";
            DataTable hdb = dtb.ReadData(sql);
            dgvHoaDonBan.DataSource = hdb;
            DataTable dtNV = dtb.ReadData("Select * from tblNV");
            DataTable dtKH = dtb.ReadData("Select * from tblKhachHang");
            func.FillCombobox(cbbMaNhanVien, dtNV, "MaNV", "MaNV");
            func.FillCombobox(cbbMaKH, dtKH, "MaKH", "MaKH");
        }
        private void ResetValues()
        {
            btnIn.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            btnChiTiet.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHoaDonBan.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtTenKH.Enabled = false;
            txtMaHoaDonBan.Text = "";
            cbbMaNhanVien.SelectedIndex = -1;
            cbbMaNhanVien.Text = "Mời Chọn Mã Nhân Viên";
            dtpNgayBan.Value = DateTime.Today;
            cbbMaKH.SelectedIndex = -1;
            cbbMaKH.Text = "Mời Chọn Mã Khách Hàng";
            txtMaHoaDonBan.Focus();
        }

        private void HDX_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvHoaDonBan.Columns[0].HeaderText = "Mã Hóa Đơn Bán";
            dgvHoaDonBan.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvHoaDonBan.Columns[2].HeaderText = "Mã Khách Hàng";
            dgvHoaDonBan.Columns[3].HeaderText = "Ngày Bán";
            ResetValues();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMaHoaDonBan.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnChiTiet.Enabled = false;

            if (MessageBox.Show("Bạn có muốn sửa?", "TB",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (txtMaHoaDonBan.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hóa đơn bán!");
                    txtMaHoaDonBan.Focus();
                    return;
                }
                try
                {
                    dtb.ChangeData("update tblHoaDonBan set MaHDB=N'" + txtMaHoaDonBan.Text +
                    "',MaNV=N'" + cbbMaNhanVien.SelectedValue + "',MaKH=N'" + cbbMaKH.SelectedValue + "',NgayBan='"
                    + dtpNgayBan.Value.ToShortDateString() + "' where MaHDB=N'" + txtMaHoaDonBan.Text + "'");
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
            if (txtMaHoaDonBan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn hóa đơn để xóa");
                return;

            }
            if (MessageBox.Show("Bạn có muốn xóa?", "TB",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dtb.ChangeData("Delete tblHoaDonBan where MaHDB='" + txtMaHoaDonBan.Text + "'");
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = dtb.ReadData("Select * from tblHoaDonBan where MaHDB ='" + txtMaHoaDonBan.Text + "'");

            //Kiem tra dieu kien
            if (dtCheck.Rows.Count > 0)
            {
                MessageBox.Show("Mã hóa đơn bán đã có, mời bạn nhập mã khác");
                txtMaHoaDonBan.Focus();
                return;
            }
            if (txtMaHoaDonBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn bán!");
                txtMaHoaDonBan.Focus();
                return;
            }
            if (cbbMaNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã nhân viên!");
                cbbMaNhanVien.Focus();
                return;
            }
            if (cbbMaKH.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã khách hàng!");
                cbbMaKH.Focus();
                return;
            }
            // them moi hdn vao database           
            string sqlinsert = "Insert into tblHoaDonBan values(N'" + txtMaHoaDonBan.Text + "',N'" + cbbMaNhanVien.SelectedValue
                + "',N'" + cbbMaKH.SelectedValue + "','" + dtpNgayBan.Value.ToShortDateString() + "')";
            dtb.ChangeData(sqlinsert);
            LoadData();
            MessageBox.Show("Thêm mới thành công!");
            btnBoqua_Click(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            LoadData();
            ResetValues();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            txtTK.Text = "";
            btnThem.Enabled = true;
            LoadData();
            ResetValues();
        }

        private void dgvHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
            btnChiTiet.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            staticdata.MaHDB = dgvHoaDonBan.CurrentRow.Cells[0].Value.ToString();
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                txtMaHoaDonBan.Text = dgvHoaDonBan.CurrentRow.Cells[0].Value.ToString();
                cbbMaNhanVien.SelectedValue = dgvHoaDonBan.CurrentRow.Cells[1].Value.ToString();
                cbbMaKH.SelectedValue = dgvHoaDonBan.CurrentRow.Cells[2].Value.ToString();
                dtpNgayBan.Text = dgvHoaDonBan.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void cbbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaNhanVien.SelectedIndex == -1)
                txtTenNhanVien.Text = "";
            try
            {
                DataTable dtNV = dtb.ReadData("Select * from tblNV where MaNV='" + cbbMaNhanVien.SelectedValue + "'");
                txtTenNhanVien.Text = dtNV.Rows[0]["TenNV"].ToString();
            }
            catch { }
        }

        private void cbbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaKH.SelectedIndex == -1)
                txtTenKH.Text = "";
            try
            {
                DataTable dtKH = dtb.ReadData("Select * from tblKhachHang where MaKH='" + cbbMaKH.SelectedValue + "'");
                txtTenKH.Text = dtKH.Rows[0]["TenKH"].ToString();
            }
            catch { }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            // viet cau lenh sql cho tim kiem
            string sql = "select * from tblHoaDonBan where MaHDB is not null";
            // kiem tra tenKH

            if (txtTK.Text.Trim() != "")
            {
                sql += " and MaHDB like N'%" + txtTK.Text + "%'";
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn cần tìm!!");
                txtTK.Focus();
            }
            // load du lieu tim duoc len dataGridView
            dgvHoaDonBan.DataSource = dtb.ReadData(sql);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonBan.Rows.Count > 0) //TH có dữ liệu để ghi
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
                header.Value = "HÓA ĐƠN BÁN";
                //Định dạng tiêu đề bảng

                exSheet.get_Range("A2:G2").Font.Bold = true;
                exSheet.get_Range("A2:G2").HorizontalAlignment =
                Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A2").Value = "STT";
                exSheet.get_Range("B2").Value = "Mã Hóa Đơn Bán";
                exSheet.get_Range("B2").ColumnWidth = 20;
                exSheet.get_Range("C2").Value = "Mã Nhân Viên";
                exSheet.get_Range("C2").ColumnWidth = 20;
                exSheet.get_Range("D2").Value = "Mã Khách Hàng";
                exSheet.get_Range("D2").ColumnWidth = 20;
                exSheet.get_Range("E2").Value = "Ngày Bán";
                exSheet.get_Range("E2").ColumnWidth = 20;
                //In dữ liệu
                DataTable dtHDN = dtb.ReadData("Select * from tblHoaDonBan");
                for (int i = 0; i < dtHDN.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 3).ToString() + ":G" + (i + 3).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 3).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 3).ToString()).Value = dtHDN.Rows[i]["MaHDB"].ToString();
                    exSheet.get_Range("C" + (i + 3).ToString()).Value = dtHDN.Rows[i]["MaNV"].ToString();
                    exSheet.get_Range("D" + (i + 3).ToString()).Value = dtHDN.Rows[i]["MaKH"].ToString();
                    exSheet.get_Range("E" + (i + 3).ToString()).Value = dtHDN.Rows[i]["NgayBan"].ToString();
                }
                exSheet.Name = "Hóa Đơn Bán";
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
                MessageBox.Show("Không có danh sách hóa để in");
        }
    }
}
