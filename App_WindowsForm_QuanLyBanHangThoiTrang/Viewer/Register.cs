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

namespace Viewer
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            MaximizeBox = false;
        }
        ControllerAccount da1 = new ControllerAccount();

        private void btnDangky_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pwa = da1.md5(txtPassword.Text);
            string pwa_hint = txtPassword.Text;
            string email = txtEmail.Text;
            string name = txtHovaten.Text;
            string phone = txtPhone.Text;
            if (txtUsername.Text.Length >= 6 && txtPassword.Text.Length >= 6 && txtHovaten.Text.Length >= 6 && txtEmail.Text.Length >= 6 && txtPhone.Text.Length >= 6)
            {
                if (da1.checkkytu(txtUsername.Text) == false && da1.checkkytu(txtHovaten.Text) == false && da1.checkkytu(txtPhone.Text) == false)
                {

                    /* if (txtUsername.Text != null || txtPassword.Text != null || txtHovaten.Text != null || txtEmail.Text != null || txtPhone.Text != null)
                     {*/
                    if (da1.Checkusername(username) == false)
                    {
                        if (da1.checkregister(username, pwa, pwa_hint, email, name, phone) == true)
                        {
                            MessageBox.Show("Đăng Ký Thành Công !!!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đăng Ký Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {     
                    MessageBox.Show("Tài khoản,Họ Tên và Số Điện Thoại không được chứa ký tự !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /*  else
              {
                  MessageBox.Show("Vui Lòng không được bỏ trống! "); // Viết xong mới thấy mình ngu :))

               }      */
            else
            {
                MessageBox.Show("Vui lòng nhập trên 6 ký tự !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
    }
}
