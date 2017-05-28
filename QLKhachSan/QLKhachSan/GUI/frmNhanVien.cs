using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QLKhachSan.DAL;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKhachSan.BLL;
using QLKhachSan.DLL;
using System.Data.SqlClient;

namespace QLKhachSan.GUI
{
    public partial class frmNhanVien : Form
    {
        KetNoiDB kn = new KetNoiDB();
        BUS_Emp emp = new BUS_Emp();
        public frmNhanVien()
        {
            
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtEmp.Text == "")
            {
                MessageBox.Show("Chọn nhân viên để xóa !");
            }
            else
            {
                emp.xoaNV(txtEmp.Text);
                MessageBox.Show("Xóa thành công!");
                textBox1_TextChanged( sender,  e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            ds = emp.timkiem(textBox1.Text);
            Gv.DataSource = ds;
            Gv.DataMember = "emp";
        }

        private void Gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.Gv.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtEmp .Text = row.Cells[0].Value.ToString();
                txtEmp_nm .Text = row.Cells[1].Value.ToString();
                txtEmp_add .Text = row.Cells[2].Value.ToString();
                txtEmp_ctc .Text = row.Cells[3].Value.ToString();
                txtEmp_pos .Text = row.Cells[4].Value.ToString();
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql ="";
            if (txtEmp.Text != "") {
                sql = @"update nhanvien set manhanvien = N'" + txtEmp.Text + "' ,tennhanvien = N'" + txtEmp_nm.Text + "' ,diachi = N'" + txtEmp_add.Text + "' ,phone = N'" + txtEmp_ctc.Text + "' ,chucvu = N'" + txtEmp_pos.Text + "'where manhanvien = N'" + txtEmp.Text + "'";
            }
            else
            {
                if (txtEmp_new.Text  == "") {
                    MessageBox.Show("Nhận mã nhân viên mới!");
                }
                else {
                    sql = @"insert into nhanvien (manhanvien,tennhanvien,diachi,phone,chucvu) values (N'" + txtEmp_new.Text + "',N'" + txtEmp_nm.Text + "',N'" + txtEmp_add.Text + "',N'" + txtEmp_ctc.Text + "',N'" + txtEmp_pos.Text + "')";
                }
            }
            try
            {
                kn.ExcuteNonQuery(sql);
                MessageBox.Show("Save successful");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}
