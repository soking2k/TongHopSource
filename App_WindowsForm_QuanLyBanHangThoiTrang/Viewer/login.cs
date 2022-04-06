using System;
using Controller;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace Viewer
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
        

            MaximizeBox = false;        
         //   MinimizeBox = false;
        }

    

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            ControllerAccount da1 = new ControllerAccount();
            string username = txtTaikhoan.Text;
            string pwa = da1.md5(txtMatkhau.Text);
            if (da1.checkkytu(txtTaikhoan.Text) == true)
            {
                MessageBox.Show("Tài khoản không được chứa ký tự !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (da1.CheckAccount(username, pwa) == true)
                {
                    MessageBox.Show("Đăng Nhập Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (da1.CheckActivity(username) == true)
                    {
                        //MessageBox.Show("WelCome Administrator ");
                          
                        if (da1.CheckAdmin(username) == true)
                        {
                            //MessageBox.Show("WelCome Administrator ");
                            this.Hide();
                            admincp a = new admincp(username);
                            a.Show();

                        }
                        else
                        {
                            this.Hide();
                            ShowForm a = new ShowForm(username);
                            a.Show();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hiện chưa được duyệt ! ","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnQuenmatkhau_Click(object sender, EventArgs e)
        {
            ForgetPass b = new ForgetPass();
                b.Show();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
          
            //this.Hide();
            Register a = new Register();
            a.Show();  
        }
    }
}
