using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            CuahangSanpham = new HashSet<CuahangSanpham>();
        }

        public long IdSanpham { get; set; }
        public string TenSanpham { get; set; }
        public int SoluongTonkho { get; set; }
        public int IdLoaisp { get; set; }
        public int IdNhacc { get; set; }
        public bool SanphamHot { get; set; }
        public bool SanphamMoi { get; set; }
        public byte[] HinhSanpham { get; set; }
        public bool XoaSanPham { get; set; }

        public virtual DanhmucSanpham IdLoaispNavigation { get; set; }
        public virtual NhaCungcap IdNhaccNavigation { get; set; }
        public virtual ICollection<CuahangSanpham> CuahangSanpham { get; set; }
    }
}
