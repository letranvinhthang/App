using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    public class sanpham : BaseViewModel
    {

        public ObservableCollection<DanhmucSanpham> _lsplist;

        public ObservableCollection<DanhmucSanpham> lsplist { get => _lsplist; set { _lsplist = value; OnPropertyChanged(); } }
        public ObservableCollection<sanpham> _sanphamlist;
        public ObservableCollection<sanpham> sanphamlist { get => _sanphamlist; set { _sanphamlist = value; OnPropertyChanged(); } }
        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private long  _barcode;

        public long barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }
        private int _soluong;

        public int soluong { get => _soluong; set { _soluong = value; OnPropertyChanged(); } }


        private bool _spmoi;

        public bool spmoi { get => _spmoi; set { _spmoi = value; OnPropertyChanged(); } }
        private bool _sphot;

        public bool sphot { get => _sphot; set { _sphot = value; OnPropertyChanged(); } }



        public ICommand themsanphamcommand { get; set; }
        public ICommand suasanphamcommand { get; set; }
        public ICommand editcommand { get; set; }

        public sanpham()
        {
            var db = new qlbhContext();
            themsanphamcommand = new RelayCommand<ThemSanPhamWindow>((k) => { return true; }, (k) => { themsanpham(k); });
            suasanphamcommand = new RelayCommand<SuaSanPhamWindow>((l) => { return true; }, (l) => { suasanpham(l); });
            editcommand = new RelayCommand<object>((p) =>
            { return true;},
                    (p) =>
                    {
                        
                    });

        }

        void themsanpham(ThemSanPhamWindow k)
        {
            ThemSanPhamWindow window3 = new ThemSanPhamWindow();
            window3.ShowDialog();
        }

        void suasanpham(SuaSanPhamWindow l)
        {
            SuaSanPhamWindow window4 = new SuaSanPhamWindow();
            window4.ShowDialog();
        }      
    }
}


           