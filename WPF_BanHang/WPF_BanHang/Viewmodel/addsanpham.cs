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
        public ObservableCollection<NhaCungcap> _ncclist;

        public ObservableCollection<NhaCungcap> ncclist { get => _ncclist; set { _ncclist = value; OnPropertyChanged(); } }
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
        private int _nccseleted;

        public int nccseleted { get => _nccseleted; set { _nccseleted = value; OnPropertyChanged(); } }
        private bool _sphot;

        public bool sphot { get => _sphot; set { _sphot = value; OnPropertyChanged(); } }
        public ICommand addcommand { get; set; }
        public ICommand exitcommand { get; set; }
        public addsanpham()
        {
            var db = new qlbhContext();
            lsplist = new ObservableCollection<DanhmucSanpham>(db.DanhmucSanpham);
            ncclist = new ObservableCollection<NhaCungcap>(db.NhaCungcap);
            exitcommand = new RelayCommand<Window>((p)=>{ return true; },(p)=>{ p.Close();  });
            addcommand = new RelayCommand<object>((p) =>
            {

            if (string.IsNullOrEmpty(ten) || barcode == 0 || dongia == 0)
                {
                    return false;
                }
            
                return true;
            },
                   (p) =>
                   {
                       var sp = db.SanPham;
                       foreach (var item in sp.ToList())
                       {
                           if ( item.IdSanpham == barcode)
                           {
                               MessageBox.Show("barcode bi trung");
                           }
                       }
                       int idch = MainViewModel.TaiKhoan.Idcuahang;
                       db.SanPham.Add(new SanPham
                       {
                            TenSanpham = ten,
                           IdSanpham = barcode,
                           IdLoaisp = loaispseleted + 1,
                           IdNhacc= nccseleted +1,
                           SanphamHot = sphot,
                           SanphamMoi = spmoi

                   }); ;
                       db.SaveChanges();
                       var idsp = db.SanPham.Where(p => p.IdSanpham == barcode).FirstOrDefault();
                       db.CuahangSanpham.Add(new CuahangSanpham
                       {
                           IdSanpham = idsp.IdSanpham,
                           IdCuahang= idch,
                           GiaTheoQuan=dongia

                       }); ;
                       db.SaveChanges();
                       MessageBox.Show("them thanh cong");


                   });

        }
        
    }
}
