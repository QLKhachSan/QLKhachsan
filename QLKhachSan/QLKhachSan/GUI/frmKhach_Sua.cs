using QLKhachSan.DLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachSan.GUI
{
    public partial class frmKhach_Sua : Form
    {
        public frmKhach_Sua()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if ((txtMa.Text == "") ||
                (txtTen.Text == "") || (cmbSex.Text == "") ||
                (txtCMND.Text == "") || (txtDiaChi.Text == "") ||
                (txtCoQuan.Text == "") || (txtSDT.Text == "") || (txtEmail.Text == ""))
            {
                MessageBox.Show("Phải Điền Đủ Thông Tin Khách Hàng", "Thông Báo");
                return;
            }
            else
            {
                string ma = txtMa.Text;
                string ten = txtTen.Text;
                string gioitinh = cmbSex.Text;
                if (cmbSex.Text == "Nam")
                    cmbSex.Text = "true";
                else
                    cmbSex.Text = "false";
                string cmnd = txtCMND.Text;
                string diachi = txtDiaChi.Text;
                string coquan = txtCoQuan.Text;
                string sdt = txtSDT.Text;
                string email = txtEmail.Text;

                List<SqlParameter> li = new List<SqlParameter>();
                SqlParameter a;
                a = new SqlParameter("@ma", SqlDbType.VarChar);
                a.Value = ma;
                li.Add(a);
                a = new SqlParameter("@ten", SqlDbType.NVarChar);
                a.Value = ten;
                li.Add(a);
                a = new SqlParameter("@gioitinh", SqlDbType.Bit);
                a.Value = gioitinh;
                li.Add(a);
                a = new SqlParameter("@cmnd", SqlDbType.VarChar);
                a.Value = cmnd;
                li.Add(a);
                a = new SqlParameter("@diachi", SqlDbType.NVarChar);
                a.Value = diachi;
                li.Add(a);
                a = new SqlParameter("@coquan", SqlDbType.NVarChar);
                a.Value = coquan;
                li.Add(a);
                a = new SqlParameter("@sdt", SqlDbType.VarChar);
                a.Value = sdt;
                li.Add(a);
                a = new SqlParameter("@email", SqlDbType.VarChar);
                a.Value = email;
                li.Add(a);

                KetNoiDB doit = new KetNoiDB();
                int ret = 0;

                DialogResult dlr = MessageBox.Show("Bạn muốn lưu thông tin không ?", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    ret = doit.doStoredProceduce("themKhach", li.ToArray());
                    doit.Close();
                    if (ret < 0)
                    {
                        MessageBox.Show("Lỗi ghi dữ liệu", "Thông Báo");
                    }
                    else
                    {
                        MessageBox.Show("Lưu thành công", "Thông Báo");
                        this.Close();
                    }
                }
                else if (dlr == DialogResult.No)
                {

                }
                else if (dlr == DialogResult.Cancel)
                {
                    this.Close();
                }

            }
        }
    }
}
