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
    public partial class frm_dangky : Form
    {
        public frm_dangky()
        {
            InitializeComponent();
        }

        private void lb_dangky_Click(object sender, EventArgs e)
        {
            frm_dangky i = new frm_dangky();
            i.MdiParent = this;
            this.Show();
            MessageBox.Show("Success");
        }
    }
}
