using btl_QLBanHang.FormBTL;
using QLBH.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btl_QLBanHang
{
    public partial class LoginForm : Form
    {
        ConnectData dtb = new ConnectData();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username" && txtPassword.Text == "Password")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtUsername.Text == "Username" || txtUsername.Text == "")
            {
                MessageBox.Show("Chưa nhập Username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassword.Text == "Password" || txtPassword.Text == "")
            {
                MessageBox.Show("Chưa nhập Password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = "select Username, Password, TenNV,  Anh  from tblUser, tblNV where Username = N'"
                + txtUsername.Text + "' and Password = N'" + txtPassword.Text + "'"
                + " and tblUser.MaNV = tblNV.MaNV";
            SqlDataReader dt = dtb.ReaderLogin(sql);
            if (!dt.HasRows)
            {
                MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Chính Xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!dt.Read())
            {
                MessageBox.Show("Có Lỗi Xảy Ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string user = dt[0].ToString();
            string pass = dt[1].ToString();
            string tennv = dt[2].ToString();
            string linkanh= dt[3].ToString();
            if (txtUsername.Text != user)
            {
                MessageBox.Show("Không Tồn Tại Tài Khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassword.Text != pass)
            {
                MessageBox.Show("Mật Khẩu Sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            staticdata.userName = txtUsername.Text;
            staticdata.LinkAvt = linkanh;
            staticdata.TenNV= tennv;
            MessageBox.Show("Đăng Nhập Thành Công! ", "Thông báo", MessageBoxButtons.OK);
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            staticdata.check = 0;
            Application.Exit();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsername.Text = "";
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = "";
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.ShowDialog();
        }

        private void hidepass_Click(object sender, EventArgs e)
        {
            showpass.Show();
            hidepass.Hide();
            txtPassword.PasswordChar = '\0';
        }

        private void showpass_Click(object sender, EventArgs e)
        {
            hidepass.Show();
            showpass.Hide();
            txtPassword.PasswordChar = '*';
        }

        private void lblForgotPassword_MouseHover(object sender, EventArgs e)
        {
            lblForgotPassword.ForeColor = Color.FromArgb(255, 128, 255);
        }

        private void lblForgotPassword_MouseMove(object sender, MouseEventArgs e)
        {
            lblForgotPassword.ForeColor = Color.White;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
