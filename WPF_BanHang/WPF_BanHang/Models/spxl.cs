using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_BanHang.Models
{
    public class spxl
    {
        public long IdSanpham { get; set; }
        public string TenSanpham { get; set; }
        public string Loaisp { get; set; }
        public bool SanphamHot { get; set; }
        public bool SanphamMoi { get; set; }
        public byte[] HinhSanpham { get; set; }
        public int IdLoaisp { get; set; }
        public bool XoaSanPham { get; set; }

    }
}
