using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class CuahangSanpham
    {
        public int IdCuahang { get; set; }
        public long IdSanpham { get; set; }
        public double GiaTheoQuan { get; set; }
<<<<<<< HEAD
        public double Gianhap { get; set; }
=======
>>>>>>> d23be53639ed4562d88b16d1d58b1a720103d3c1
        public int Dem { get; set; }

        public virtual CuaHang IdCuahangNavigation { get; set; }
        public virtual SanPham IdSanphamNavigation { get; set; }
    }
}
