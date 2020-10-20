using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    public class NhapkhoViewModel : BaseViewModel

    {
        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private int _manv;

        public int manv { get => _manv; set { _manv = value; OnPropertyChanged(); } }
        private string _pass;

        public string pass { get => _pass; set { _pass = value; OnPropertyChanged(); } }
        private DateTime _ngaysinh;

        public DateTime ngaysinh { get => _ngaysinh; set { _ngaysinh = value; OnPropertyChanged(); } }
        private string _diachi;
        private ObservableCollection<tonkhoxl> _tonkhoxlist;
        public ObservableCollection<tonkhoxl> tonkhoxlist { get => _tonkhoxlist; set { _tonkhoxlist = value; OnPropertyChanged(); } }
        public NhapkhoViewModel()
        {
            loadtonkho();
        }

        void loadtonkho()
        {
            var db = new qlbhContext();
            tonkhoxlist = new ObservableCollection<tonkhoxl>();
            var tk = db.TonKho;
            var sp = db.SanPham;
            var cthd = db.HoaDonChitiet;
            int i = 1;
            foreach (var item in sp.ToList())
            {
                var nhap = cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc != null);
                var xuat = cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc == null);
                int sumnhap = 0;
                int sumxuat = 0;
                if (nhap != null)
                    sumnhap = nhap.Sum(p => p.SoLuong);
                if (xuat != null)
                    sumxuat = xuat.Sum(p => p.SoLuong);
                tonkhoxl tonKho = new tonkhoxl();
                tonKho.hinh = item.HinhSanpham;
                tonKho.ten = item.TenSanpham;
                tonKho.soluong = sumnhap - sumxuat;
                tonKho.STT = i;

                tonkhoxlist.Add(tonKho);
                i++;
            }
        }

    } 
    
    
}
