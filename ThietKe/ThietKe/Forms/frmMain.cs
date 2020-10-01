using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThietKe.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }
        int kiemtraOrder = 0;
        int kiemtraQLTK = 0;
        int kiemtraThongKe = 0;
        int kiemtraNhapKho = 0;

        private void btnOrder_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {

                if (f.Name == "frmOrder")
                {
                    if (kiemtraOrder == 1)
                    {
                        f.BringToFront();
                        f.Show();
                        break;
                    }

                }
            }
            if (kiemtraOrder == 0)
            {
                frmOrder frm = new frmOrder();
                frm.TopLevel = false;
                panel3.Controls.Add(frm);
                frm.BringToFront();
                frm.Show();
                kiemtraOrder = 1;
            }


        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {

            foreach (Form f in Application.OpenForms)
            {

                if (f.Name == "frmQuanLyTaiKhoan")
                {
                    if (kiemtraQLTK == 1)
                    {
                        f.BringToFront();
                        f.Show();
                        break;
                    }

                }
            }
            if (kiemtraQLTK == 0)
            {
                frmQuanLyTaiKhoan frm = new frmQuanLyTaiKhoan();
                frm.TopLevel = false;
                panel3.Controls.Add(frm);
                frm.BringToFront();
                frm.Show();
                kiemtraQLTK = 1;
            }

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {

                if (f.Name == "frmThongKe")
                {
                    if (kiemtraThongKe == 1)
                    {
                        f.BringToFront();
                        f.Show();
                        break;
                    }

                }
            }
            if (kiemtraThongKe == 0)
            {
                frmThongKe frm = new frmThongKe();
                frm.TopLevel = false;
                panel3.Controls.Add(frm);
                frm.BringToFront();
                frm.Show();
                kiemtraThongKe = 1;
            }

        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {

            foreach (Form f in Application.OpenForms)
            {

                if (f.Name == "frmNhapKho")
                {
                    if (kiemtraNhapKho == 1)
                    {
                        f.BringToFront();
                        f.Show();
                        break;
                    }

                }
            }
            if (kiemtraNhapKho == 0)
            {
                frmNhapKho frm = new frmNhapKho();
                frm.TopLevel = false;
                panel3.Controls.Add(frm);
                frm.BringToFront();
                frm.Show();
                kiemtraNhapKho = 1;
            }

        }

        
    }
}
