using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class QuyenHan
    {
        public QuyenHan()
        {
            KhachHang = new HashSet<KhachHang>();
            NhanVien = new HashSet<NhanVien>();
        }

        public int IdChucvu { get; set; }
        public string TenChucvu { get; set; }
        public bool TaoOrder { get; set; }
        public bool SuaOrder { get; set; }
        public bool HuyOrder { get; set; }
        public bool TaoTaikhoan { get; set; }
        public bool SuaTaikhoan { get; set; }
        public bool DisTaikhoan { get; set; }
        public bool TonKho { get; set; }

        public virtual ICollection<KhachHang> KhachHang { get; set; }
        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
