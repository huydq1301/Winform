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
    public partial class ChangePassword : Form
    {
        public static string username;
        ConnectData connectData = new ConnectData();
        public ChangePassword()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            DataTable dtUser = connectData.ReadData("Select * from tblUser");
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ");
            }
            if (txtNewPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới");
            }
            if (txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa xác nhận mật khẩu");
            }
            DataTable dtPassword = connectData.ReadData("Select * from tblUser where Username= '" + lblUsername.Text + "'");
            if (txtOldPassword.Text != dtPassword.Rows[0].ItemArray[2].ToString())
            {
                MessageBox.Show("Sai mật khẩu");
            }
            else
            {
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp");
                }
                else
                {
                    connectData.ChangeData("update tblUser set Password=N'" + txtNewPassword.Text + "' where Username= N'" + username + "'");
                    MessageBox.Show("Cập nhật thành công");
                    LoadData();
                    this.Close();

                }
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            lblUsername.Text = "Xin chào " + username;
        }
    }
}
