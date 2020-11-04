using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using WPF_BanHang.Viewmodel;

namespace WPF_BanHang.Models
{
   public class hdxl : BaseViewModel
    {
        private int _IdHoadon;
        public int IdHoadon { get => _IdHoadon; set { _IdHoadon = value; OnPropertyChanged(); } }
       
        private long _MaHoadon;
        public long MaHoadon { get => _MaHoadon; set { _MaHoadon = value; OnPropertyChanged(); } }
   
        private DateTime _NgayTao;
        public DateTime NgayTao { get => _NgayTao; set { _NgayTao = value; OnPropertyChanged(); } }
        private double _ThanhTien;
        public double ThanhTien { get => _ThanhTien; set { _ThanhTien = value; OnPropertyChanged(); } }
        private string _bennhan;
        public string bennhan { get => _bennhan; set { _bennhan = value; OnPropertyChanged(); } }
        private string _trangthai;
        public string trangthai { get => _trangthai; set { _trangthai = value; OnPropertyChanged(); } }
        private string _TenNhanvien;
        public string TenNhanvien { get => _TenNhanvien; set { _TenNhanvien = value; OnPropertyChanged(); } }
        private string _TenChuongtrinh;
        public string TenChuongtrinh { get => _TenChuongtrinh; set { _TenChuongtrinh = value; OnPropertyChanged(); } }
        private string _DiaChiCuaHang;
        public string DiaChiCuaHang { get => _DiaChiCuaHang; set { _DiaChiCuaHang = value; OnPropertyChanged(); } }
        public long ThongTinTimKiem { get; set; }
    }
}
