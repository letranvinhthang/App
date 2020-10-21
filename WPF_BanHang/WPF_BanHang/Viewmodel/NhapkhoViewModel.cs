using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    public class NhapkhoViewModel : BaseViewModel

    {
        private string _ten;
        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }

        private int _STT;
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }

        private int _barcode;

        public int barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }
        private int _soluong;

        public int soluong { get => _soluong; set { _soluong = value; OnPropertyChanged(); } }
        private ObservableCollection<tonkhoxl> _tonkhoxlist;
        public ObservableCollection<tonkhoxl> tonkhoxlist { get => _tonkhoxlist; set { _tonkhoxlist = value; OnPropertyChanged(); } }
        public ICommand loadcommand { get; set; }
        public NhapkhoViewModel()
        {
            loadcommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                loadtonkho();
            });

        }

        void loadtonkho()
        {
            var db = new qlbhContext();
            tonkhoxlist = new ObservableCollection<tonkhoxl>();
            var tk = db.TonKho;
            var sp = db.SanPham;
            var cthd = db.HoaDonChitiet;
            var hd = db.HoaDon;
            int i = 1;
            if (MainViewModel.TaiKhoan != null)
            {
                int? idch = MainViewModel.TaiKhoan.Idcuahang;
                foreach (var item in sp.ToList())
                {
                    var nhap = from p in cthd join b in hd on p.IdHoadon equals b.IdHoadon where (p.IdSanpham == item.IdSanpham && p.IdNhacc != null && b.IdCuahang == idch) select p;
                    var xuat = from p in cthd join b in hd on p.IdHoadon equals b.IdHoadon where (p.IdSanpham == item.IdSanpham && p.IdNhacc == null && b.IdCuahang == idch) select p;
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
                    tonKho.IdSanpham = item.IdSanpham;
                    tonkhoxlist.Add(tonKho);
                    i++;
                }
            }
            else
            {

                return;
            }
            
        }

    } 
    
    
}
