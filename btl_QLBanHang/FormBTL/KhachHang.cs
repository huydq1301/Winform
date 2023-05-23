using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using QLBH.Classes;
using System.Data.Common;
using System.Net.NetworkInformation;
using Microsoft.Office.Core;
using System.Windows.Diagnostics;
using System.Globalization;
using System.IO;

namespace btl_QLBanHang
{
    public partial class KhachHang : Form
    {
        ConnectData datb = new ConnectData();
        CommonFunction function = new CommonFunction();
        string fileAnh;
        string TenFile = "";
        public KhachHang()
        {
            InitializeComponent();
        }
    
      
        private void KhachHang_Load(object sender, EventArgs e)
        {
            txtMaKhach.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            LoadData();

            dgvKhachHang.Columns[0].HeaderText = "Mã KH";
            dgvKhachHang.Columns[1].HeaderText = "Họ tên KH";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns[4].HeaderText = "Ngày sinh";
            dgvKhachHang.Columns[5].HeaderText = "Ảnh KH";
            dgvKhachHang.Columns[6].HeaderText = "Giới tính";

            ResetValues();
        }
        void LoadData()
        {
            DataTable dtKhachHang = datb.ReadData("Select * from tblKhachHang");
            dgvKhachHang.DataSource = dtKhachHang;
        }
    


        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnLuu.Enabled=true;
            btnThem.Enabled = false;
            btnBoQua.Enabled = true;
            txtMaKhach.Enabled = true;
            txtMaKhach.Focus();

        }
        private void ResetValues()
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            TenFile = "";
            picAnh.Image = null;
            dtpNgaySinh.Value = DateTime.Today;
            txtDiaChi.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            bt_Anh.Enabled = false;
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = datb.ReadData("Select * from tblKhachHang where MaKH ='" + txtMaKhach.Text + "'");

            //Kiem tra dieu kien
            if (dtCheck.Rows.Count > 0)
            {
                MessageBox.Show("Mã Khách Hàng đã có, mời bạn nhập mã khác");
                txtMaKhach.Focus();
                return;
            }
            if (txtMaKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã KH!");
                txtMaKhach.Focus();
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhach.Focus();
                return;
            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            if (rdoNam.Checked == false && rdoNu.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            // them moi khach hang vao database           
            string sqlInsert = "Insert into tblKhachHang values(N'" + txtMaKhach.Text + "',N'" + txtTenKhach.Text + "',N'" + txtDiaChi.Text
                + "',N'" + txtDienThoai.Text + "','" + dtpNgaySinh.Value.ToShortDateString() + "','" + TenFile + "',N'" + staticdata.gt + "')";
            datb.ChangeData(sqlInsert);
            LoadData();
            MessageBox.Show("Thêm mới thành công!");
            ResetValues();
            btnThem.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKhach.Focus();
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKhach.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;
            }
            DataTable dataTable = datb.ReadData("Select * from tblKhachHang");   
                datb.ChangeData("update tblKhachHang set TenKH=N'" + txtTenKhach.Text +
                            "',DiaChi= N'" + txtDiaChi.Text
                            + "',DienThoai='" + txtDienThoai.Text
                            + "',GioiTinh= N'" + staticdata.gt
                            + "',NgaySinh='" + dtpNgaySinh.Value.ToShortDateString()
                            + "',Anh='" + TenFile
                            + "'where MaKH='" + txtMaKhach.Text + "'");
                MessageBox.Show("Sửa thành công");
                LoadData();
                ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable dataTable = datb.ReadData("Select * from tblKhachHang");
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string  sqlcheck = "select * from tblHoaDonBan where N'"+txtMaKhach.Text+"' = MaKH";
                DataTable check = datb.ReadData(sqlcheck);
                if(check.Rows.Count >0)
                {
                    MessageBox.Show("Bạn không thể xóa khách hàng này vì họ đã mua hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBoQua_Click(sender, e);
                    return;
                }
                sql = "DELETE tblKhachHang WHERE MaKH=N'" + txtMaKhach.Text + "'";              
                datb.ChangeData(sql);
                LoadData();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            LoadData();
            ResetValues();
           
        }

        private void txtMaKhach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnBoQua.Enabled = true;
            txtMaKhach.Enabled = false;
            bt_Anh.Enabled = true;
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                txtMaKhach.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKhach.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
                dtpNgaySinh.Text = dgvKhachHang.CurrentRow.Cells[4].Value.ToString();
                TenFile = dgvKhachHang.CurrentRow.Cells[5].Value.ToString();
                if (TenFile == "")
                {
                    string ten = "macdinh.png";
                    picAnh.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Images\\KhachHang\\" + ten);
                }
                    
                else
                {
                    try
                    {
                        picAnh.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Images\\KhachHang\\" + TenFile);
                    }
                    catch
                    {
                        picAnh.Image = null;
                    }
                }
                if (dgvKhachHang.CurrentRow.Cells[6].Value.ToString().Trim() == "Nam")
                {
                    rdoNam.Checked = true;              
                }
                else
                {
                    rdoNu.Checked = true;
                }
               
            }
            catch
            {
            }
            
        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            staticdata.gt = radioButton.Text;

        }

        private void rdoNu_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            staticdata.gt = radioButton.Text;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
            btnBoQua.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            // viet cau lenh sql cho tim kiem
            string sql = "select * from tblKhachHang where MaKH is not null";
            
           
            // kiem tra tenKH
            
            if (txtTimKh.Text.Trim() != "")
            {
                sql += " and TenKH like N'%" + txtTimKh.Text + "%'";
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng cần tìm!!");
                txtTimKh.Focus();
            }
            // load du lieu tim duoc len dataGridView
            dgvKhachHang.DataSource = datb.ReadData(sql);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnBoQua.Enabled = true;
            txtMaKhach.Enabled = false;
            //Bắt lỗi khi người sử dụng kích linh tinh lên datagrid
            try
            {
                txtMaKhach.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKhach.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
                dtpNgaySinh.Text = dgvKhachHang.CurrentRow.Cells[4].Value.ToString();

                if (dgvKhachHang.CurrentRow.Cells[6].Value.ToString().Trim() == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }

            }
            catch
            {
            }
        }

        private void bt_Anh_Click(object sender, EventArgs e)
        {
            string[] image;
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "JPEG Images|*.jpg|PNG Images|*.png|All Files|*.*";
            OpenFile.FilterIndex = 1;
            OpenFile.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\Images\\KhachHang\\";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(OpenFile.FileName);
                image = OpenFile.FileName.ToString().Split('\\');
                fileAnh = image[image.Length - 1];
                TenFile = Path.GetFileName(fileAnh);
            }
        }
    }
}
