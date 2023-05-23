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

namespace btl_QLBanHang.FormBTL
{
    public partial class ChiTietNV : Form
    {
        public string nv = "Nhân Viên", ql = "Quản Lý";


        ConnectData connectData = new ConnectData();
        public ChiTietNV()
        {
            InitializeComponent();
        }

        void LoadData()
        {

            DataTable dataTable = connectData.ReadData("Select * from tblChiTietNV");
            dgvChiTietNV.DataSource = dataTable;
            txtMaNV.Enabled = false;
        }

        private void ChiTietNV_Load(object sender, EventArgs e)
        {
            try
            {
                string sqlInsert1 = "Insert into tblChiTietNV values(N'" + NhanVien.maNV + "','Nhân viên',0,0,0)";
                connectData.ChangeData(sqlInsert1);

                dgvChiTietNV.Columns[0].HeaderText = "MaNV";
                dgvChiTietNV.Columns[1].HeaderText = "Chức vụ";
                dgvChiTietNV.Columns[2].HeaderText = "Lương cơ bản";
                dgvChiTietNV.Columns[3].HeaderText = "Hệ số";
                dgvChiTietNV.Columns[4].HeaderText = "Thưởng";
            }
            catch
            {

            }
            LoadData();
        }
        void Resetform()
        {
            txtMaNV.Text = "";
            txtChucvu.Text = "";
            txtLCB.Text = "";
            txtHSL.Text = "";
            txtThuong.Text = "";


        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            connectData.ChangeData("update tblChiTietNV  set ChucVu=N'" + txtChucvu.Text +
                           "',LuongCB= N'" + txtLCB.Text
                           + "',HeSo='" + (txtHSL.Text)
                           + "',Thuong=N'" + (txtThuong.Text)

                           + "' from tblChiTietNV inner join tblNV on tblChiTietNV.MaNV=tblNV.MaNV where tblChiTietNV.MaNV='" + txtMaNV.Text + "'");
            MessageBox.Show("Sửa thành công");
            Resetform();
            LoadData();
        }

        private void dgvChiTietNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvChiTietNV.CurrentRow.Cells[0].Value.ToString();
            txtChucvu.Text = dgvChiTietNV.CurrentRow.Cells[1].Value.ToString();
            txtLCB.Text = dgvChiTietNV.CurrentRow.Cells[2].Value.ToString();
            txtHSL.Text = dgvChiTietNV.CurrentRow.Cells[3].Value.ToString();
            txtThuong.Text = dgvChiTietNV.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int check = 0;
            string sql = "select * from tblChiTietNV where ";
            if (radNV.Checked == true || radQL.Checked == true)
            {
                check = 1;
                if (radNV.Checked == true)
                {
                    sql += "ChucVu=N'" + nv + "'";
                }
                else if (radQL.Checked == true)
                {
                    sql += "ChucVu=N'" + ql + "'";
                }
                if (txtMaxLuong.Text != "" && txtMinLuong.Text != "")
                {

                    sql += "and LuongCB between " + txtMinLuong.Text + " and " + txtMaxLuong.Text;
                }
                if (txtMinHSL.Text != "" && txtMaxHSL.Text != "")
                {
                    sql += "and HeSo between " + (txtMinHSL.Text) + " and " + (txtMaxHSL.Text);
                }
                if (txtMinThuong.Text != "" && txtMaxThuong.Text != "")
                {
                    sql += "and Thuong between " + txtMinThuong.Text + " and " + txtMaxThuong.Text;

                }
            }
            else
            {
                if (txtMaxLuong.Text != "" && txtMinLuong.Text != "")
                {

                    sql += "LuongCB between " + txtMinLuong.Text + " and " + txtMaxLuong.Text;
                    if (txtMinHSL.Text != "" && txtMaxHSL.Text != "")
                    {
                        sql += "and HeSo between " + (txtMinHSL.Text) + " and " + (txtMaxHSL.Text);
                    }
                    if (txtMinThuong.Text != "" && txtMaxThuong.Text != "")
                    {
                        sql += "and Thuong between " + txtMinThuong.Text + " and " + txtMaxThuong.Text;

                    }
                }
                else
                {
                    if (txtMinHSL.Text != "" && txtMaxHSL.Text != "")
                    {
                        sql += "HeSo between " + (txtMinHSL.Text) + " and " + (txtMaxHSL.Text);
                        if (txtMinThuong.Text != "" && txtMaxThuong.Text != "")
                        {
                            sql += "and Thuong between " + txtMinThuong.Text + " and " + txtMaxThuong.Text;

                        }
                    }
                    else
                    {
                        if (txtMinThuong.Text != "" && txtMaxThuong.Text != "")
                        {
                            sql += "Thuong between " + txtMinThuong.Text + " and " + txtMaxThuong.Text;

                        }
                    }
                }

            }

            dgvChiTietNV.DataSource = connectData.ReadData(sql);

        }

        private void txtMinHSL_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa thông tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                connectData.ChangeData("Delete tblChiTietNV where MaNV='" + txtMaNV.Text + "'");
                LoadData();
            }
            else
            {
                this.Close();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            radNV.Checked = false;
            radQL.Checked = false;
            txtMinThuong.Text = "";
            txtMaxThuong.Text = "";
            txtMinHSL.Text = "";
            txtMaxHSL.Text = "";
            txtMinLuong.Text = "";
            txtMaxLuong.Text = "";
            LoadData();
        }
    }
}
