using System;
using System.Collections.Generic;
using System.Text;
using WPF_BanHang.Viewmodel;

namespace WPF_BanHang.Models
{
    public class SanPham_NhaCungCap :BaseViewModel
    {
     
        private int _IdNhaCC;
        public int IdNhaCC { get => _IdNhaCC; set { _IdNhaCC = value; OnPropertyChanged(); } }
        private string _TenSP;
        public string TenSP { get => _TenSP; set { _TenSP = value; OnPropertyChanged(); } }
        private int _SoLuong;
        public int SoLuong { get => _SoLuong; set { _SoLuong = value; OnPropertyChanged(); } }
        private long _barcode;
        public long barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }
        private double _GiaNhap;
        public double GiaNhap { get => _GiaNhap; set { _GiaNhap = value; OnPropertyChanged(); } }

        private double _tongtien;
        public double tongtien { get => _tongtien; set { _tongtien = value; OnPropertyChanged(); } }
    }
}
