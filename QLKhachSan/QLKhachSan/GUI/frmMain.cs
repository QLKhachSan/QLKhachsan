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
using System.IO;

namespace QLKhachSan.GUI
{
    public partial class frmMain : Form
    {
        BUS_Main main = new BUS_Main();
        
        public frmMain(string user)
        {  InitializeComponent();
            DataSet ds = new DataSet();
            ds = main.inf(user);
            lblnguoidung.Text = user ;

            lblnguoidung.Text = ds.Tables[0].Rows[0]["tennhanvien"].ToString();
            lblmanhanvien.Text = ds.Tables[0].Rows[0]["idEmp"].ToString();
            lblngaysinh.Text = ds.Tables[0].Rows[0]["ngaysinh"].ToString ().Substring (0,10);
            lblchucvu.Text = ds.Tables[0].Rows[0]["chucvu"].ToString();
            temp.Text = ds.Tables[0].Rows[0]["urlImage"].ToString();
            string a = Directory.GetCurrentDirectory() + "\\image\\" + temp.Text ;
            picUser.Image = Image.FromFile(a);


        }
        public frmMain() {
            
        }
        private void quảnLíKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhach khach = new frmKhach();
            khach.Show();
        }

        private void quảnLíNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien nhanvien = new frmNhanVien();
            nhanvien.Show();
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHuongdan huongdan = new frmHuongdan();
            huongdan.Show();
        }

        private void quảnLíPhòngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPhong phong = new frmPhong();
            phong.Show();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThanhtoan thanhtoan = new frmThanhtoan();
            thanhtoan.Show();
        }

        private void sửDụngDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichvu dichvu = new frmDichvu();
            dichvu.Show();
        }

        private void quảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuephong thuephong = new frmThuephong();
            thuephong.Show();
        }

        private void vậtDụngTheoPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVatdung vatdung = new frmVatdung();
            vatdung.Show();
        }


    }
}
