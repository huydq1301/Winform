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
    public partial class HDN : Form
    {
        CommonFunction func = new CommonFunction();
        ConnectData dtb = new ConnectData();
        public HDN()
        {
            InitializeComponent();
        }
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            ChiTietHDN ctHDN = new ChiTietHDN();
            ctHDN.ShowDialog();
        }
        void LoadData()
        {
            string sql = " select * from tblHoaDonNhap ";
            DataTable hdn = dtb.ReadData(sql);
            dgvHoaDonNhap.DataSource = hdn;
            DataTable dtNV = dtb.ReadData("Select * from tblNV");
            DataTable dtNCC = dtb.ReadData("Select * from tblNhaCungCap");
            func.FillCombobox(cbbMaNhanVien, dtNV, "MaNV", "MaNV");
            func.FillCombobox(cbbMaNCC, dtNCC, "MaNCC", "MaNCC");
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
            txtMaHoaDonNhap.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtNCC.Enabled = false;
            txtMaHoaDonNhap.Text = "";
            cbbMaNhanVien.SelectedIndex = -1;
            cbbMaNhanVien.Text = "Mời Chọn Mã Nhân Viên";
            dtpNgayNhap.Value = DateTime.Today;
            cbbMaNCC.SelectedIndex = -1;
            cbbMaNCC.Text = "Mời Chọn Mã Nhà Cung Cấp";
            txtMaHoaDonNhap.Focus();
        }
        private void HDN_Load(object sender, EventArgs e)
        {

            LoadData();
            dgvHoaDonNhap.Columns[0].HeaderText = "Mã Hóa Đơn Nhập";
            dgvHoaDonNhap.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvHoaDonNhap.Columns[2].HeaderText = "Ngày Nhập";
            dgvHoaDonNhap.Columns[3].HeaderText = "Mã Nhà Cung Cấp";
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
            txtMaHoaDonNhap.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = dtb.ReadData("Select * from tblHoaDonNhap where MaHDN ='" + txtMaHoaDonNhap.Text + "'");

            //Kiem tra dieu kien
            if (dtCheck.Rows.Count > 0)
            {
                MessageBox.Show("Mã hóa đơn nhập đã có, mời bạn nhập mã khác");
                txtMaHoaDonNhap.Focus();
                return;
            }
            if (txtMaHoaDonNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn nhập!");
                txtMaHoaDonNhap.Focus();
                return;
            }
            if (cbbMaNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã nhân viên!");
                cbbMaNhanVien.Focus();
                return;
            }
            if (cbbMaNCC.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã nhà cung cấp!");
                cbbMaNCC.Focus();
                return;
            }
            // them moi hdn vao database           
            string sqlinsert = "Insert into tblHoaDonNhap values(N'" + txtMaHoaDonNhap.Text + "',N'" + cbbMaNhanVien.SelectedValue + "','"
                + dtpNgayNhap.Value.ToShortDateString() + "',N'" + cbbMaNCC.SelectedValue + "')";
            dtb.ChangeData(sqlinsert);
            LoadData();
            MessageBox.Show("Thêm mới thành công!");
            btnBoqua_Click(sender, e);

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

        private void cbbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaNCC.SelectedIndex == -1)
                txtNCC.Text = "";
            try
            {
                DataTable dtNCC = dtb.ReadData("Select * from tblNhaCungCap where MaNCC='" + cbbMaNCC.SelectedValue + "'");
                txtNCC.Text = dtNCC.Rows[0]["TenNCC"].ToString();
            }
            catch { }
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
            btnChiTiet.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            staticdata.MaHDN = dgvHoaDonNhap.CurrentRow.Cells[0].Value.ToString();
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                txtMaHoaDonNhap.Text = dgvHoaDonNhap.CurrentRow.Cells[0].Value.ToString();
                cbbMaNhanVien.SelectedValue = dgvHoaDonNhap.CurrentRow.Cells[1].Value.ToString();
                dtpNgayNhap.Text = dgvHoaDonNhap.CurrentRow.Cells[2].Value.ToString();
                cbbMaNCC.SelectedValue = dgvHoaDonNhap.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnChiTiet.Enabled = false;

            if (MessageBox.Show("Bạn có muốn sửa?", "TB",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (txtMaHoaDonNhap.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã hóa đơn nhập!");
                    txtMaHoaDonNhap.Focus();
                    return;
                }
                try
                {
                    dtb.ChangeData("update tblHoaDonNhap set MaHDN=N'" + txtMaHoaDonNhap.Text +
                    "',MaNV=N'" + cbbMaNhanVien.SelectedValue + "',NgayNhap='" + dtpNgayNhap.Value.ToShortDateString() +
                    "',MaNCC=N'" + cbbMaNCC.SelectedValue + "' where MaHDN=N'" + txtMaHoaDonNhap.Text + "'");
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

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            txtTK.Text = "";
            btnThem.Enabled = true;
            LoadData();
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDonNhap.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn hóa đơn để xóa");
                return;

            }
            if (MessageBox.Show("Bạn có muốn xóa?", "TB",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dtb.ChangeData("Delete tblHoaDonNhap where MaHDN='" + txtMaHoaDonNhap.Text + "'");
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            LoadData();
            ResetValues();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonNhap.Rows.Count > 0) //TH có dữ liệu để ghi
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
                header.Value = "HÓA ĐƠN NHẬP";
                //Định dạng tiêu đề bảng

                exSheet.get_Range("A2:G2").Font.Bold = true;
                exSheet.get_Range("A2:G2").HorizontalAlignment =
                Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A2").Value = "STT";
                exSheet.get_Range("B2").Value = "Mã Hóa Đơn Nhập";
                exSheet.get_Range("B2").ColumnWidth = 20;
                exSheet.get_Range("C2").Value = "Mã Nhân Viên";
                exSheet.get_Range("C2").ColumnWidth = 20;
                exSheet.get_Range("D2").Value = "Ngày Nhập";
                exSheet.get_Range("D2").ColumnWidth = 20;
                exSheet.get_Range("E2").Value = "Mã Nhà Cung Cấp";
                exSheet.get_Range("E2").ColumnWidth = 20;
                //In dữ liệu
                DataTable dtHDN = dtb.ReadData("Select * from tblHoaDonNhap");
                for (int i = 0; i < dtHDN.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 3).ToString() + ":G" + (i + 3).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 3).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 3).ToString()).Value = dtHDN.Rows[i]["MaHDN"].ToString();
                    exSheet.get_Range("C" + (i + 3).ToString()).Value = dtHDN.Rows[i]["MaNV"].ToString();
                    exSheet.get_Range("D" + (i + 3).ToString()).Value = dtHDN.Rows[i]["NgayNhap"].ToString();
                    exSheet.get_Range("E" + (i + 3).ToString()).Value = dtHDN.Rows[i]["MaNCC"].ToString();
                }
                exSheet.Name = "Hóa Đơn Nhập";
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

        private void btnTK_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            // viet cau lenh sql cho tim kiem
            string sql = "select * from tblHoaDonNhap where MaHDN is not null";
            // kiem tra tenKH

            if (txtTK.Text.Trim() != "")
            {
                sql += " and MaHDN like N'%" + txtTK.Text + "%'";
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn cần tìm!!");
                txtTK.Focus();
            }
            // load du lieu tim duoc len dataGridView
            dgvHoaDonNhap.DataSource = dtb.ReadData(sql);
        }
    }
}
