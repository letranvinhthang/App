using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public int IdNhanvien { get; set; }
        public string PassNhanvien { get; set; }
        public string TenNhanvien { get; set; }
        public DateTime NgaySinh { get; set; }
        public int IdChucvu { get; set; }
        public string DiachiNhanvien { get; set; }
        public string Sdt { get; set; }
        public bool Disable { get; set; }

        public virtual QuyenHan IdChucvuNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
