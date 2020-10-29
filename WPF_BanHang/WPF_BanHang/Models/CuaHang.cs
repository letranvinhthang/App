using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class CuaHang
    {
        public CuaHang()
        {
            CuahangSanpham = new HashSet<CuahangSanpham>();
            HoaDon = new HashSet<HoaDon>();
        }

        public int IdCuahang { get; set; }
        public string TenCuahang { get; set; }
        public string DiachiCuahang { get; set; }

        public virtual ICollection<CuahangSanpham> CuahangSanpham { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
