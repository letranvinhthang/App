using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class HoaDon
    {
        public int IdHoadon { get; set; }
        public DateTime NgayTao { get; set; }
        public int? IdNhacc { get; set; }
        public double ThanhTien { get; set; }
        public int? IdKhachhang { get; set; }
        public int IdCuahang { get; set; }
        public int IdNhanvien { get; set; }
        public string IdChuongtrinh { get; set; }
        public bool? HuyHoaDon { get; set; }

        public virtual QuangCao IdChuongtrinhNavigation { get; set; }
        public virtual CuaHang IdCuahangNavigation { get; set; }
        public virtual KhachHang IdKhachhangNavigation { get; set; }
        public virtual NhaCungcap IdNhaccNavigation { get; set; }
        public virtual NhanVien IdNhanvienNavigation { get; set; }
    }
}
