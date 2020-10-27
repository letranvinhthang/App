using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPF_BanHang.Models
{
    public partial class ViewThongke
    {
        public long SoLuongHoaDon { get; set; }
        public double? TongDoanhThu { get; set; }
        public DateTime NgayTao { get; set; }
        public int IdCuahang { get; set; }
    }
}
