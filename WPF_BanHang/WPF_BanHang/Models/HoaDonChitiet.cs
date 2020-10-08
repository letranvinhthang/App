using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class HoaDonChitiet
    {
        public int IdHoadon { get; set; }
        public int IdSanpham { get; set; }
        public int SoLuong { get; set; }
        public double GiaTien { get; set; }

        public virtual HoaDon IdHoadonNavigation { get; set; }
    }
}
