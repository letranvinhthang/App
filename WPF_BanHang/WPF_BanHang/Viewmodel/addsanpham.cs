using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;
namespace WPF_BanHang.Viewmodel
{
   public class addsanpham :BaseViewModel
    {
        public ObservableCollection<DanhmucSanpham> _lsplist;

        public ObservableCollection<DanhmucSanpham> lsplist { get => _lsplist; set { _lsplist = value; OnPropertyChanged(); } }
        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private long _barcode;

        public long barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }
        private double _dongia;

        public double dongia { get => _dongia; set { _dongia = value; OnPropertyChanged(); } }
        private bool _spmoi;

        public bool spmoi { get => _spmoi; set { _spmoi = value; OnPropertyChanged(); } }
        private int _loaispseleted;

        public int loaispseleted { get => _loaispseleted; set { _loaispseleted = value; OnPropertyChanged(); } }
        private bool _sphot;

        public bool sphot { get => _sphot; set { _sphot = value; OnPropertyChanged(); } }
        public ICommand addcommand { get; set; }
        public ICommand exitcommand { get; set; }
        public addsanpham()
        {
            var db = new qlbhContext();
            lsplist = new ObservableCollection<DanhmucSanpham>(db.DanhmucSanpham);
            addcommand = new RelayCommand<object>((p) =>
            {

                if (string.IsNullOrEmpty(ten) || barcode == null || dongia == null)
                    return false;
                return true;
            },
                   (p) =>
                   {
                       int idch = MainViewModel.TaiKhoan.Idcuahang;
                       db.SanPham.Add(new SanPham
                       {
                            TenSanpham = ten,
                           IdSanpham = barcode,
                           IdLoaisp = loaispseleted + 1,
                           SanphamHot = sphot,
                           SanphamMoi = spmoi

                   }); ;
                       db.CuahangSanpham.Add(new CuahangSanpham
                       {
                           IdSanpham = barcode,
                           IdCuahang= idch,
                           GiaTheoQuan=dongia

                       }); ;
                       db.SaveChanges();
                       MessageBox.Show("them thanh cong");


                   });

        }
        
    }
}
