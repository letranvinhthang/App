using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class HoaDonChitiet
    {
        public int IdHoaDonChitiet { get; set; }
        public int IdHoadon { get; set; }
        public long IdSanpham { get; set; }
        public int SoLuong { get; set; }
        public double GiaTien { get; set; }
        public int? IdNhacc { get; set; }
        public int? IdKhachhang { get; set; }
        public int IdCuaHang { get; set; }

        public virtual HoaDon IdHoadonNavigation { get; set; }
        public virtual KhachHang IdKhachhangNavigation { get; set; }
        public virtual NhaCungcap IdNhaccNavigation { get; set; }
    }
}
