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
    public delegate void passData(DataGridView text);

    public partial class frmKhach : Form
    {
        public frmKhach()
        {
            InitializeComponent();
        }

        private void frmKhach_Load(object sender, EventArgs e)
        {
            KetNoiDB doit = new KetNoiDB();
            DataSet ds = new DataSet();
            string tableName = "KHACHHANG";
            int ret;
            ret = doit.getSQL(ref ds, tableName, "SELECT * FROM KHACHHANG");
            doit.Close();
            if (ret < 0)
            {
                MessageBox.Show("Loi Thuc Hien", "Thong Bao");
            }
            else
            {
                dataGridView1.DataSource = ds.Tables[tableName].DefaultView;
                dataGridView1.Refresh();
            }
            dataGridView1.Columns["makhachhang"].HeaderText = "Mã Khách Hàng";
            dataGridView1.Columns["tenkhachhang"].HeaderText = "Tên Khách Hàng";
            dataGridView1.Columns["gioitinh"].HeaderText = "Giới Tính";
            dataGridView1.Columns["cmnd_passport"].HeaderText = "CMND";
            dataGridView1.Columns["diachi"].HeaderText = "Địa Chỉ";
            dataGridView1.Columns["coquan"].HeaderText = "Cơ Quan";
            dataGridView1.Columns["sodienthoai"].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns["email"].HeaderText = "Email";
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKhach_Them them = new frmKhach_Them();
            them.ShowDialog();
            frmKhach_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.CurrentRow;
            if (dgvr == null)
            {
                MessageBox.Show("Chưa chọn bản ghi1");
                return;
            }

            DataRowView drv = (DataRowView)dgvr.DataBoundItem;
            if (drv == null)
            {
                MessageBox.Show("Chưa chọn bản ghi2");
                return;
            }

            DataRow dr = (DataRow)drv.Row;
            if (dr == null)
            {
                MessageBox.Show("Chưa chọn bản ghi3");
                return;
            }

            frmKhach_Sua sua = new frmKhach_Sua();


            passData deleg = new passData(sua.takeData);
            deleg(this.dataGridView1);

            sua.ShowDialog();
            frmKhach_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Chưa chọn bản ghi để xóa", "Thông Báo");
                return;
            }
            DataGridViewRow drv = dataGridView1.SelectedRows[0];
            DataRowView drview = (DataRowView)drv.DataBoundItem;
            if (drview == null)
            {
                MessageBox.Show("Không lấy được dữ liệu để xóa", "Thông Báo");
                return;
            }

            DataRow dr = drview.Row;
            if (dr == null)
            {
                MessageBox.Show("Không lấy được dữ liệu để xóa");
                return;
            }
            string ma = dr["makhachhang"].ToString();

            KetNoiDB doit = new KetNoiDB();
            int ret = 0;

            List<SqlParameter> li = new List<SqlParameter>();
            SqlParameter a;
            a = new SqlParameter("@ma", SqlDbType.VarChar);
            a.Value = ma;
            li.Add(a);

            DialogResult dlr = MessageBox.Show("Bạn muốn xóa thông tin không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                ret = doit.doStoredProceduce("xoaKhach", li.ToArray());
                doit.Close();
                if (ret < 0)
                {
                    MessageBox.Show("Lỗi xóa dữ liệu");
                }
                else
                {
                    MessageBox.Show("Xóa thành công", "Thông Báo");
                    frmKhach_Load(sender, e);
                }
            }
            else if (dlr == DialogResult.No)
            {

            }
        }
    }
}
