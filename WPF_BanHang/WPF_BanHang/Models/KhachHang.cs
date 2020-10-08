using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public int IdKhachhang { get; set; }
        public int TenKhachhang { get; set; }
        public string EmailKhachhang { get; set; }
        public string PassKhachhang { get; set; }
        public bool GioitinhKhachhang { get; set; }
        public int DiemKhachhang { get; set; }
        public int IdChucvu { get; set; }
        public string DiachiKhachhang { get; set; }
        public string AvatarKhachhang { get; set; }

        public virtual QuyenHan IdChucvuNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
