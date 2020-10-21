using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_BanHang.Models
{
   public class tonkhoxl
    {
       public string ten { get; set; }
        public long IdSanpham { get; set; }
        public byte[] hinh { get; set; }

       public int soluong{ get; set; }
       public TonKho cuahang { get; set; }
       public int STT { get; set; }
    }
}
