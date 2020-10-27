using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class NhaCungcap
    {
        public NhaCungcap()
        {
            HoaDon = new HashSet<HoaDon>();
            SanPham = new HashSet<SanPham>();
        }

        public int IdNhacc { get; set; }
        public string TenNhacc { get; set; }
        public string DiachiNhacc { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
