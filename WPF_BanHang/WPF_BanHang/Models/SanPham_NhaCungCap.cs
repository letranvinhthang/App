using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_BanHang.Models
{
    public class SanPham_NhaCungCap
    {
        public int IdNhaCC { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public long barcode { get; set; }
        public double GiaNhap { get; set; }
        public double tongtien { get; set; }
    }
}
