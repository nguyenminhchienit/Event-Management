using ManagementCoffee.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ManagementCoffee
{
    public partial class fRegister : Form
    {
        public fRegister()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txUser.Text;
            string displayname = txShowName.Text;
            string password = txPass.Text;
            string Repass = txRePass.Text;

            if (!password.Equals(Repass))
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng!");
            }
            else
            {
                if (AccountDAO.Instance.RegisterAccount(username, displayname, password))
                {
                    MessageBox.Show("Bạn đã đăng ký tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Đăng ký tài khoản không thành công");
                }
                this.Close();
            }
        }
    }
}
