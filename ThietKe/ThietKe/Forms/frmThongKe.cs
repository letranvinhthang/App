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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DatabaseConnection db = new DatabaseConnection();
            db.OpenConnection();
            dataGridView2.DataSource = dt;
            
            
            db.CloseConnection();
        }
    }
}
