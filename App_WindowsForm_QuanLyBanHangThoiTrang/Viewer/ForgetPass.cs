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
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
            ControllerAccount da1 = new ControllerAccount();
            string tk = txtTaikhoan.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string newpass = da1.md5(txtNewPass.Text);
            string newpass_hint = txtNewPass.Text;
            if (txtTaikhoan.Text.Length >= 6 && txtEmail.Text.Length >= 6 && txtPhone.Text.Length >= 6 && txtNewPass.Text.Length >= 6 )
            {
                if (da1.checkkytu(txtTaikhoan.Text) == false && da1.checkkytu(txtPhone.Text) == false)
                {

                    if (da1.checkforget(tk, email, phone) == true)
                    {
                        if (da1.forget(tk, email, phone, newpass, newpass_hint) == true)
                        {
                            MessageBox.Show("Lấy lại mật khẩu thành công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Lấy lại mật khẩu Thất Bại !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thông Tin Không đúng !");                    }    
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
