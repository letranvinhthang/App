using System;
using System.Collections.Generic;

namespace WPF_BanHang.Models
{
    public partial class QuangCao
    {
        public QuangCao()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public string IdChuongtrinh { get; set; }
        public string TenChuongtrinh { get; set; }
        public string MotaChuongtrinh { get; set; }
        public string HinhanhChuongtrinh { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
