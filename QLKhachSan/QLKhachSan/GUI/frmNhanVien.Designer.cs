namespace QLKhachSan.GUI
{
    partial class frmNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.Gv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.txtEmp_add = new System.Windows.Forms.TextBox();
            this.txtEmp_nm = new System.Windows.Forms.TextBox();
            this.txtEmp_ctc = new System.Windows.Forms.TextBox();
            this.txtEmp_pos = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmp_new = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 36);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(675, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "Lưu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(779, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(98, 30);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // Gv
            // 
            this.Gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gv.GridColor = System.Drawing.Color.White;
            this.Gv.Location = new System.Drawing.Point(12, 202);
            this.Gv.Name = "Gv";
            this.Gv.RowTemplate.Height = 24;
            this.Gv.Size = new System.Drawing.Size(886, 234);
            this.Gv.TabIndex = 1;
            this.Gv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã nhân viên: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(499, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số điện thoại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(499, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Chức vụ:";
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(153, 59);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(209, 22);
            this.txtEmp.TabIndex = 3;
            // 
            // txtEmp_add
            // 
            this.txtEmp_add.Location = new System.Drawing.Point(153, 128);
            this.txtEmp_add.Name = "txtEmp_add";
            this.txtEmp_add.Size = new System.Drawing.Size(209, 22);
            this.txtEmp_add.TabIndex = 3;
            // 
            // txtEmp_nm
            // 
            this.txtEmp_nm.Location = new System.Drawing.Point(153, 91);
            this.txtEmp_nm.Name = "txtEmp_nm";
            this.txtEmp_nm.Size = new System.Drawing.Size(209, 22);
            this.txtEmp_nm.TabIndex = 3;
            // 
            // txtEmp_ctc
            // 
            this.txtEmp_ctc.Location = new System.Drawing.Point(600, 92);
            this.txtEmp_ctc.Name = "txtEmp_ctc";
            this.txtEmp_ctc.Size = new System.Drawing.Size(209, 22);
            this.txtEmp_ctc.TabIndex = 3;
            // 
            // txtEmp_pos
            // 
            this.txtEmp_pos.Location = new System.Drawing.Point(600, 124);
            this.txtEmp_pos.Name = "txtEmp_pos";
            this.txtEmp_pos.Size = new System.Drawing.Size(209, 22);
            this.txtEmp_pos.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tìm kiếm:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(471, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mã nhân viên mới:";
            // 
            // txtEmp_new
            // 
            this.txtEmp_new.Location = new System.Drawing.Point(600, 59);
            this.txtEmp_new.Name = "txtEmp_new";
            this.txtEmp_new.Size = new System.Drawing.Size(209, 22);
            this.txtEmp_new.TabIndex = 3;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 448);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmp_nm);
            this.Controls.Add(this.txtEmp_ctc);
            this.Controls.Add(this.txtEmp_pos);
            this.Controls.Add(this.txtEmp_add);
            this.Controls.Add(this.txtEmp_new);
            this.Controls.Add(this.txtEmp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Gv);
            this.Controls.Add(this.panel1);
            this.Name = "frmNhanVien";
            this.Text = "Nhân viên";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView Gv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmp;
        private System.Windows.Forms.TextBox txtEmp_add;
        private System.Windows.Forms.TextBox txtEmp_nm;
        private System.Windows.Forms.TextBox txtEmp_ctc;
        private System.Windows.Forms.TextBox txtEmp_pos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmp_new;
    }
}