using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_BanHang.Views
{
    //DB_BanHang connect = new DB_BanHang();
    public partial class frm_dangnhap : Form
    {
        public frm_dangnhap()
        {
            InitializeComponent();
        }

        private void bt_dangnhap_Click(object sender, EventArgs e)
        {
            if(tb_taikhoan.Text == "")
            {
                MessageBox.Show("Tài khoản không được để trống","Thông báo");
            }
            else if(tb_matkhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống","Thông báo");
            }
            int a = 0;
            //using var
            //if()
            string check = "";
            string user = tb_taikhoan.Text;
            string pass = tb_matkhau.Text;
            check = Controllers.DangNhap.CheckDangNhap(user, pass);
            if (check == "")
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng","Thông báo");
                
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo");
                frm_dangky frm = new frm_dangky();
                this.Hide();
                frm.Show();
                this.Close();
            }
        }

        private void lb_dangky_Click(object sender, EventArgs e)
        {
            frm_dangky i = new frm_dangky();
            i.MdiParent = this;
            this.Show();
            MessageBox.Show("Success");
        }

        private void frm_dangnhap_Load(object sender, EventArgs e)
        {
            //frm_dangky i = new frm_dangky();
            ////i.MdiParent = this;
            //i.Show();
            //MessageBox.Show("Success");
        }
    }
}
