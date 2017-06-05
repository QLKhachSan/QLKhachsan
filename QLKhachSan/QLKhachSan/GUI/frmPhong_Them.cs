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
    public partial class frmPhong_Them : Form
    {
        public frmPhong_Them()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if ((txtMaPhong.Text == "") || (cmbMaLoai.Text == ""))
            {
                MessageBox.Show("Phải Điền Đủ Thông Tin Phòng", "Thông Báo");
                return;
            }
            else
            {
                string maphong = txtMaPhong.Text;
                string maloai = cmbMaLoai.Text;
                

                List<SqlParameter> li = new List<SqlParameter>();
                SqlParameter a;
                a = new SqlParameter("@maphong", SqlDbType.VarChar);
                a.Value = maphong;
                li.Add(a);
                a = new SqlParameter("@maloai", SqlDbType.NVarChar);
                a.Value = maloai;
                li.Add(a);

                KetNoiDB doit = new KetNoiDB();
                int ret = 0;

                DialogResult dlr = MessageBox.Show("Bạn muốn lưu thông tin không ?", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    ret = doit.doStoredProceduce("themPhong", li.ToArray());
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

        private void frmPhong_Them_Load(object sender, EventArgs e)
        {
            //cmbMaLoai
            int ret = 0;
            string tableName = "LOAIPHONG";
            KetNoiDB doit = new KetNoiDB();
            DataSet ds = new DataSet();
            ret = doit.getSQL(ref ds, tableName, "SELECT * FROM LOAIPHONG");
            doit.Close();
            if (ret < 0)
            {
                MessageBox.Show("Loi Thuc Hien", "Thông Báo");
            }
            else
            {
                cmbMaLoai.DataSource = ds.Tables[tableName].DefaultView;
                cmbMaLoai.DisplayMember = "";
                cmbMaLoai.ValueMember = "maloai";
            }
        }
    }
}
