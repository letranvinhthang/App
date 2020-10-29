using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class CuahangSanpham
    {
        public int IdCuahang { get; set; }
        public long IdSanpham { get; set; }
        public double GiaTheoQuan { get; set; }
        public double Gianhap { get; set; }
        public int Dem { get; set; }

        public virtual CuaHang IdCuahangNavigation { get; set; }
        public virtual SanPham IdSanphamNavigation { get; set; }
    }
}
