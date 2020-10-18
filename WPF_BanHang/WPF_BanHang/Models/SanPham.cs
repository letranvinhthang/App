using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class SanPham
    {
        public long IdSanpham { get; set; }
        public string TenSanpham { get; set; }
        public int SoluongTonkho { get; set; }
        public int IdLoaisp { get; set; }
        public bool SanphamHot { get; set; }
        public bool SanphamMoi { get; set; }
        public string HinhSanpham { get; set; }
<<<<<<< HEAD
        public bool XoaSanPham { get; set; }
=======
>>>>>>> 8ea80d40b17f1638b2148bb17efcd140e825c3df

        public virtual DanhmucSanpham IdLoaispNavigation { get; set; }
    }
}
