using System;
using System.Collections.Generic;
using System.Text;
using WPF_BanHang.Viewmodel;

namespace WPF_BanHang.Models
{
 public   class Orderxl : BaseViewModel
    {
        public byte[] hinhsp { get; set; }
<<<<<<< HEAD
        public long barcode { get; set; }
        public string tensp { get; set; }
        public double dongia { get; set; }
        public int soluong { get; set; }
        public double tongtien {get; set; }
        public long mahoadon { get; set; }
=======
        private long _barcode;
        public long barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }
        private string _tensp;
        public string tensp { get => _tensp; set { _tensp = value; OnPropertyChanged(); } }
        private double _dongia;
        public double dongia { get => _dongia; set { _dongia = value; OnPropertyChanged(); } }
        private int _soluong;
        public int soluong { get => _soluong; set { _soluong = value; OnPropertyChanged(); } }
        private double _tongtien;
        public double tongtien { get => _tongtien; set { _tongtien = value; OnPropertyChanged(); } }
>>>>>>> origin/hao1

    }
}
