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
    public partial class KhuyenMai : Form
    {
        ConnectData connectData = new ConnectData();
        public KhuyenMai()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKM.Enabled = false;
            btnBoQua.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            txtMaKM.Text = dgvKhuyenMai.CurrentRow.Cells[0].Value.ToString();
            nbrGiamGia.Text = dgvKhuyenMai.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = dgvKhuyenMai.CurrentRow.Cells[2].Value.ToString();


        }

        private void KhuyenMai_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKM.Enabled = true;
            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKM.Text = "";
            nbrGiamGia.Value = 0;
            txtGhiChu.Text = "";
            LoadForm();
            dgvKhuyenMai.Columns[0].HeaderText = "Mã KM";
            dgvKhuyenMai.Columns[1].HeaderText = "Giảm giá";
            dgvKhuyenMai.Columns[2].HeaderText = "Ghi Chú";
        }
        public void LoadForm()
        {
            DataTable dataTable = connectData.ReadData("select * from tblKhuyenMai");
            dgvKhuyenMai.DataSource = dataTable;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            DataTable dataTable = connectData.ReadData("Select * from tblKhuyenMai where MaKM='" + txtMaKM.Text + "'");
            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Đã tồn tại mã khuyến mại này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if(txtMaKM.Text=="")
            {
                MessageBox.Show("Bạn phải nhập mã khuyến mại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(nbrGiamGia.Value==0)
            {
                MessageBox.Show("Bạn phải chọn phần trăm khuyến mại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sqlInsert = "insert into tblKhuyenMai values('" + txtMaKM.Text + "','" + nbrGiamGia.Value + "',N'" + txtGhiChu.Text + "')";
            connectData.ChangeData(sqlInsert);
            LoadForm();
            MessageBox.Show("Thêm mới thành công");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dataTable = connectData.ReadData("Select * from tblKhuyenMai");
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKM.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn mã khuyến mại nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (MessageBox.Show("Bạn có muốn sửa mã khuyến mại này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtMaKM.Text == "km00")
                {
                    MessageBox.Show("Bạn không thể sửa mã khuyến mại mặc định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sqlcheck = "select * from tblChiTietHDB where MaKM=N'" + txtMaKM.Text + "'";
                DataTable check = connectData.ReadData(sqlcheck);
                if (check.Rows.Count > 0)
                {
                    double thanhtien = 0, sl = 0, gia = 0;
                    int km=0;

                    string select = "select DonGiaBan , SLBan from tblSanPham , tblChiTietHDB "
                        + "where tblSanPham.MaSP= tblChiTietHDB.MaSP";
                    DataTable dtselect = connectData.ReadData(select);
                    gia = Convert.ToDouble(dtselect.Rows[0]["DonGiaBan"].ToString());
                    sl = Convert.ToDouble(dtselect.Rows[0]["SLBan"].ToString());
                    km = Convert.ToInt16(nbrGiamGia.Value);
                    thanhtien = (sl * gia) * (100 -km ) / 100;
                    string updatett = "update tblChiTietHDB set ThanhTien=" + thanhtien 
                        + " where MaKM=N'" + txtMaKM.Text + "'";
                    connectData.ChangeData(updatett);
                    string updatekm = "update tblKhuyenMai set MaKM=N'" + txtMaKM.Text + "',"
                        + "GiamGia='" + nbrGiamGia.Value + "',GhiChu=N'" + txtGhiChu.Text + "'"
                        + " where MaKM=N'" + txtMaKM.Text + "'";
                    connectData.ChangeData(updatekm);
                    KhuyenMai_Load(sender, e);
                    return;
                }
                string updatekm1 = "update tblKhuyenMai set MaKM=N'" + txtMaKM.Text + "',"
                        + "GiamGia='" + nbrGiamGia.Value + "',GhiChu=N'" + txtGhiChu.Text + "'"
                        + " where MaKM=N'" + txtMaKM.Text + "'";
                connectData.ChangeData(updatekm1);
                KhuyenMai_Load(sender, e);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKM.Enabled = true;
            btnThem.Enabled = true;
            txtMaKM.Text = "";
            nbrGiamGia.Value = 0;
            txtGhiChu.Text = "";
            LoadForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataTable dataTable = connectData.ReadData("Select * from tblKhuyenMai");
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKM.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn mã khuyến mại nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (MessageBox.Show("Bạn có muốn xóa mã khuyến mại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtMaKM.Text == "km00")
                {
                    MessageBox.Show("Bạn không thể xóa mã khuyến mại mặc định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sqlcheck = "select * from tblChiTietHDB where MaKM=N'" + txtMaKM.Text + "'";
                DataTable check = connectData.ReadData(sqlcheck);
                if (check.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn không thể xóa mã khuyến mại này vì nó liên quan bảng chi tiết hóa đơn bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sql = "DELETE tblKhuyenMai WHERE MaKM=N'" + txtMaKM.Text + "'";
                connectData.ChangeData(sql);
                KhuyenMai_Load(sender, e);
            }
        }
    }
}
