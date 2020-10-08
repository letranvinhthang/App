using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class DanhmucSanpham
    {
        public DanhmucSanpham()
        {
            SanPham = new HashSet<SanPham>();
        }

        public int IdLoaisp { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
