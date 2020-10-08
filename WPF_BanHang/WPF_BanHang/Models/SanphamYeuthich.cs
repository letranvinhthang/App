using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class SanphamYeuthich
    {
        public int IdKhachhang { get; set; }
        public long IdSanpham { get; set; }

        public virtual KhachHang IdKhachhangNavigation { get; set; }
        public virtual SanPham IdSanphamNavigation { get; set; }
    }
}
