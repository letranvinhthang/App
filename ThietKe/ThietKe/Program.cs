using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThietKe.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ThietKe
{

  



    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmThongKe());
        }
    }
}
