using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class TonKho
    {
        public int NgayTon { get; set; }
        public long IdSanpham { get; set; }
        public int SoluongTon { get; set; }
        public int IdCuahang { get; set; }

        public virtual CuaHang IdCuahangNavigation { get; set; }
        public virtual SanPham IdSanphamNavigation { get; set; }
    }
}
