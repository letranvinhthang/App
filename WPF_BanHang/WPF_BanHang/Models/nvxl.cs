using System;
using System.Collections.Generic;
using System.Text;
using WPF_BanHang.Viewmodel;

namespace WPF_BanHang.Models
{
   public class nvxl :BaseViewModel
    {
        private string _ten;
        public string ten { get => _ten; set { _ten = value;OnPropertyChanged(); } }
        public int  Manv { get; set; }
        private string _pass;
        public string Pass { get => _pass; set { _pass = value; OnPropertyChanged(); } }
        private DateTime _ngaysinh;
        public DateTime ngaysinh { get => _ngaysinh; set { _ngaysinh = value; OnPropertyChanged(); } }
        private string _diachi;
        public string diachi { get => _diachi; set { _diachi = value; OnPropertyChanged(); } }
        private string _chucvu;
        public string chucvu { get => _chucvu; set { _chucvu = value; OnPropertyChanged(); } }
        private int _Idchucvu;
        public int IdChucvu { get => _Idchucvu; set { _Idchucvu = value; OnPropertyChanged(); } }
        private string _sdt;
        public string sdt { get => _sdt; set { _sdt = value; OnPropertyChanged(); } }
        public NhanVien cuahang { get; set; }
    }
}
