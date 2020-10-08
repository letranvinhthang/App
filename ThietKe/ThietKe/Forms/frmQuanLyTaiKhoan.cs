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
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
            for(int i= 1; i <= 10; ++i)
            {
                dataGridView1.Rows.Add(i, "1", "Tên nhân viên");
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmThemNhanVien frm = new frmThemNhanVien();
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "ColSua")
            {
                frmSuaNhanVien frm = new frmSuaNhanVien();
                frm.ShowDialog();
            }
            else if (colName == "ColXoa")
            {
                MessageBox.Show("Bạn chắc chứ?", "Xóa nhân viên", MessageBoxButtons.YesNo);
                if (DialogResult==DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);                                     
                }
                
            }
        }
    }
}
