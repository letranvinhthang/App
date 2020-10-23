using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class ViewThongke
    {
        public int IdHoadon { get; set; }
        public DateTime NgayTao { get; set; }
        public double? SumHoaDonThanhTien { get; set; }
        public string TenNhanvien { get; set; }
        public int IdCuahang { get; set; }
    }
}
