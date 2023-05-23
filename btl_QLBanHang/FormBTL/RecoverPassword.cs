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
using System.Data.SqlClient;
namespace btl_QLBanHang.FormBTL
{
    public partial class RecoverPassword : Form
    {
        public RecoverPassword()
        {
            InitializeComponent();
        }
        ConnectData dtb = new ConnectData();    
        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void btnReserPassword_Click(object sender, EventArgs e)
        {
            if(txtnewpass.Text =="" || txtconfirmpass.Text=="")
            {
                MessageBox.Show("Bạn Phải Nhập Mật Khẩu");
                return;
            }
            if(txtconfirmpass.Text != txtnewpass.Text)
            {
                MessageBox.Show("Mật Khẩu Không Trùng Khớp");
                return;
            }
            string sql = "update tblUser set Password = '"+txtnewpass.Text+ "'where Email = '"+staticdata.To+"'";
            dtb.ChangeData(sql);
            MessageBox.Show("Đổi Mật Khẩu Thành Công!");
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void txtnewpass_MouseClick(object sender, MouseEventArgs e)
        {
            txtnewpass.Text = "";
        }

        private void txtconfirmpass_MouseClick(object sender, MouseEventArgs e)
        {
            txtconfirmpass.Text = "";
        }

        private void lblBackToLogin_MouseHover(object sender, EventArgs e)
        {
            lblBackToLogin.ForeColor = Color.FromArgb(255, 128, 255); 
        }

        private void lblBackToLogin_MouseLeave(object sender, EventArgs e)
        {
            lblBackToLogin.ForeColor = Color.White;
        }
    }
}
