using btl_QLBanHang.FormBTL;
using QLBH.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Execl = Microsoft.Office.Interop.Excel;

namespace btl_QLBanHang
{
    public partial class NhanVien : Form
    {
        public static string maNV;
        ConnectData datb = new ConnectData();
        CommonFunction function = new CommonFunction();
        string fileAnh;
        int checkuser = 0;
        public NhanVien(string userName)
        {
            InitializeComponent();
            DataTable dtNhanVien = datb.ReadData("Select * from tblNhanVien");
            function.FillCombobox(cmbSapxep, dtNhanVien, "MaNV", "TenNV");

            //txtUsername.Text = userName;
        }
        public NhanVien()
        {
            InitializeComponent();
        }
        //đổi mk
        private void btnChangePW_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword();
            form.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            /*            DataTable dataTable = datb.ReadData("select chucvu from tblChiTietNV inner join tblUser on tblChiTietNV.MaNV=tblUser.MaNV where Username=N'" + staticdata.userName + "'");
            */
            DataTable dtCheck = datb.ReadData("Select * from tblNV where MaNV ='N" + txtMaNV.Text + "'");
            if (dtCheck.Rows.Count > 0)
            {
                MessageBox.Show("Mã nhân viên đã có, mời bạn nhập mã khác");
                txtMaNV.Focus();
                return;
            }
            if(txtMaNV.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên");
                txtMaNV.Focus();
                return;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên");
                txtMaNV.Focus();
                return;
            }
            if (txtPhone.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại");
                txtMaNV.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ");
                txtMaNV.Focus();
                return;
            }
            if (txtGioitinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính");
                txtMaNV.Focus();
                return;
            }
            if(picNV.Image==null)
            {
                MessageBox.Show("Bạn chưa chọn ảnh");
                txtMaNV.Focus();
                return;
            }
            // them moi hang vao database
            string sqlInsert = "Insert into tblNV values(N'" + txtMaNV.Text + "',N'" + txtHoTen.Text + "',N'" + txtDiaChi.Text
               + "',N'" + txtPhone.Text + "','" + fileAnh + "',N'" + txtGioitinh.Text + "','" + dtpNgaysinh.Value.ToShortDateString() + "')";
            if (txtMaNV.Text != null)
            {
                maNV = txtMaNV.Text;
            }


            /*datb.ChangeData("update tblChiTietNV set ChucVu=N'Nhân Viên',LuongCB=0,HeSo=0,Thuong=0" 
                                + "where MaNV='" + txtMaNV.Text + "'");*/
            try
            {

                datb.ChangeData(sqlInsert);

                LoadData();
                MessageBox.Show("Thêm mới thành công!");
                ResetValue();
            }
            catch
            {

                MessageBox.Show("Lỗi");
            }
            //}

        }
        void LoadData()
        {
            DataTable dtNhanvien = datb.ReadData("Select * from tblNV");
            dgvNhanVien.DataSource = dtNhanvien;


        }
        void ResetValue()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            dtpNgaysinh.Value = DateTime.Today;
            txtPhone.Text = "";
            txtDiaChi.Text = "";
            txtGioitinh.Text = "";
            fileAnh = "";
            txtMaNV.Focus();
            txtMaNV.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            picNV.Image = null;
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            cmbSapxep.Items.Add("Họ tên");
            cmbSapxep.Items.Add("Ngày sinh");
            LoadData();

            dgvNhanVien.Columns[0].HeaderText = "Mã NV";
            dgvNhanVien.Columns[1].HeaderText = "Họ tên";
            dgvNhanVien.Columns[2].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[3].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[4].HeaderText = "Ảnh";
            dgvNhanVien.Columns[5].HeaderText = "Giới tính";
            dgvNhanVien.Columns[6].HeaderText = "Ngày sinh";

            ResetValue();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Enabled = false;

            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
                txtPhone.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
                fileAnh = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();

                try
                {
                    picNV.Image = Image.FromFile(Application.StartupPath + "\\Images\\AvatarNV\\" + fileAnh);

                }
                catch
                {
                    picNV.Image = null;

                }
                txtGioitinh.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
                dtpNgaysinh.Value = (DateTime)dgvNhanVien.CurrentRow.Cells[6].Value;
            }
            catch
            {
            }
            if(staticdata.TenNV==txtHoTen.Text)
            {
                checkuser= 1;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {


            DataTable dataTable = datb.ReadData("select chucvu from tblChiTietNV inner join tblUser on tblChiTietNV.MaNV=tblUser.MaNV where Username=N'" + staticdata.userName + "'");
            if (dataTable.Rows[0].ItemArray[0].ToString() != "Quản Lý")
            {
                MessageBox.Show("Ban khong co quyen sua nhan vien");
            }
            else
            {

                datb.ChangeData("update tblNV set TenNV=N'" + txtHoTen.Text +
                            "',DiaChi= N'" + txtDiaChi.Text
                            + "',SoDienThoai='" + txtPhone.Text
                            + "',GioiTinh=N'" + txtGioitinh.Text
                            + "',NgaySinh='" + dtpNgaysinh.Value.ToShortDateString()
                            + "',Anh='" + fileAnh
                            + "'where MaNV='" + txtMaNV.Text + "'");

                MessageBox.Show("Sửa thành công");
                if(checkuser==1)
                {
                    staticdata.TenNV = txtHoTen.Text;
                    staticdata.LinkAvt = fileAnh;
                }
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn phần tử để xóa");
                return;
            }
            DataTable dataTable = datb.ReadData("select chucvu from tblChiTietNV inner join tblUser on tblChiTietNV.MaNV=tblUser.MaNV where Username=N'" + staticdata.userName + "'");
            if (dataTable.Rows[0].ItemArray[0].ToString() != "Quản Lý")
            {
                MessageBox.Show("Bạn không có quyền xóa nhân viên");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xoá nhân viên này không?", "Có hay không", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string checkquanly = "select  ChucVu from tblChiTietNV where MaNV=N'" + txtMaNV.Text + "'";
                    DataTable checkql = datb.ReadData(checkquanly);
                    if (checkql.Rows[0].ItemArray[0].ToString() == "Quản Lý")
                    {
                        MessageBox.Show("Bạn không thể xóa quản lý");
                        return;
                    }
                    string sqlcheckban = "select * from tblHoaDonBan where N'" + txtMaNV.Text + "' = MaNV";
                    DataTable checkban = datb.ReadData(sqlcheckban);
                    string sqlchecknhap = "select * from tblHoaDonNhap where N'" + txtMaNV.Text + "' = MaNV";
                    DataTable checknhap = datb.ReadData(sqlchecknhap);
                    if (checkban.Rows.Count > 0 || checknhap.Rows.Count > 0)
                    {
                        MessageBox.Show("Bạn không thể xóa nhân viên này vì họ liên quan đến các hóa đơn khác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ResetValue();
                        return;
                    }
                    else
                    {
                        string manv = txtMaNV.Text;
                        datb.ChangeData("Delete tblChiTietNV where MaNV='" + manv + "'");
                        datb.ChangeData("Delete tblNV where MaNV='" + manv + "'");
                        MessageBox.Show("Xóa thành công");
                        LoadData();
                        ResetValue();
                    }
                    

                }

            }
        }
        private void btnChiTietNV_Click(object sender, EventArgs e)
        {
            DataTable dataTable = datb.ReadData("select chucvu from tblChiTietNV inner join tblUser on tblChiTietNV.MaNV=tblUser.MaNV where Username=N'" + staticdata.userName + "'");
            if (dataTable.Rows[0].ItemArray[0].ToString() != "Quản Lý")
            {
                MessageBox.Show("Ban khong co quyen xem muc nay");
            }
            else
            {
                ChiTietNV chiTietNV = new ChiTietNV();
                chiTietNV.ShowDialog();
            }
        }




        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // cam nut Sua va Xoa
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // viet cau lenh sql cho tim kiem
            string sql = "select * from tblNV where MaNV is not null";
            // tim theo MaSP khac rong

            // kiem tra TenSP
            if (txtTimKiem.Text.Trim() != "")
            {
                sql += " and TenNV like N'%" + txtTimKiem.Text + "%'";
            }

            // load du lieu tim duoc len dataGridView
            dgvNhanVien.DataSource = datb.ReadData(sql);


        }





        private void btnThoat_Click(object sender, EventArgs e)
        {
            LoadData();
            txtTimKiem.Text = "";
            ResetValue();
        }

        private void cmbSapxep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSapxep.SelectedIndex == 0)
            {
                this.dgvNhanVien.Sort(this.dgvNhanVien.Columns["TenNV"], ListSortDirection.Ascending);
            }
            else
            {
                this.dgvNhanVien.Sort(this.dgvNhanVien.Columns["NgaySinh"], ListSortDirection.Ascending);
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            string[] image;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPEG Images|*.jpg|PNG Images|*.png|All files|*.*";
            openFile.FilterIndex = 1;
            openFile.InitialDirectory = Application.StartupPath;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picNV.Image = Image.FromFile(openFile.FileName);
                image = openFile.FileName.ToString().Split('\\');
                fileAnh = image[image.Length - 1];
                //MessageBox.Show(fileAnh);
            }
        }

    }
}
