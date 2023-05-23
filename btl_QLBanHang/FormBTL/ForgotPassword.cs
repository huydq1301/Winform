using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Security.RightsManagement;
using System.Data.SqlClient;
using QLBH.Classes;
using System.Net.Http;

namespace btl_QLBanHang.FormBTL
{
    public partial class ForgotPassword : Form
    {
        string RandomCode;
        ConnectData dtb = new ConnectData();
        public ForgotPassword()
        {
            InitializeComponent();
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(!IsValid(txtEmail.Text))
            {
                MessageBox.Show("Email Không Đúng Định Dạng!");
                return;
            }
            string sql = "select Email from tblUser where Email = '"+txtEmail.Text+"'";
            SqlDataReader dt = dtb.ReaderLogin(sql);
            if (!dt.HasRows)
            {
                MessageBox.Show("Email Bạn Đã Nhập Không Tồn Tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!dt.Read())
            {
                MessageBox.Show("Có Lỗi Xảy Ra!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string from, pass, messageBody;
            Random ran = new Random();
            RandomCode = (ran.Next(999999)).ToString();
            MailMessage mailMessage = new MailMessage();
            staticdata.To = txtEmail.Text;
            from = "huydq130108@gmail.com";
            pass = "t i z f u b c s k x f x g y m f";//mat khau ung dung
            messageBody = "Your reset code is " + RandomCode;
            mailMessage.To.Add(staticdata.To);
            mailMessage.From = new MailAddress(from);
            mailMessage.Body = messageBody;
            mailMessage.Subject = "Recover Password ";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(mailMessage);
                MessageBox.Show("Gửi Mã Code Thành Công!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnVerycode_Click(object sender, EventArgs e)
        {
            if(txtCode.Text.Length!=6)
            {
                MessageBox.Show("Mã Code Phải Đủ 6 Số!");
            }

            if(txtCode.Text != RandomCode)
            {
                MessageBox.Show("Mã Code Không Chính Xác!");
                return;
            }
            MessageBox.Show("Mã Code Chính Xác!");
            staticdata.To=txtEmail.Text;
            RecoverPassword rp = new RecoverPassword();
            this.Hide();
            rp.ShowDialog();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Mã Code Phải Là Số");
                e.Handled = true;
            }
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            txtEmail.Text = "";
        }

        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.Text = "";
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(255, 128, 255);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }
    }
}
