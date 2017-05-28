using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.BLL;
namespace QLKhachSan.GUI
{
    public partial class frmLogin : Form
    {
        BUS_tblUser user = new BUS_tblUser();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.ToString() == "" || txtPass.Text.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin đăng nhập!");
            }
            else
            {
                if (user.CheckLogin(txtUser.Text.ToString(), txtPass.Text.ToString()) == 1)
                {
                    this.Visible = false;
                    frmMain main = new frmMain(txtUser.Text.ToString());
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập sai");
                }
            }
        }
    }
}
