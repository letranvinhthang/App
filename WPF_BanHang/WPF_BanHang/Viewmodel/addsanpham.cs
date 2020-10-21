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
        private int _barcode;

        public int barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }
        private int _soluong;

        public int soluong { get => _soluong; set { _soluong = value; OnPropertyChanged(); } }
        public ICommand addcommand { get; set; }
        public ICommand exitcommand { get; set; }
        public addsanpham()
        {
            var db = new qlbhContext();
            lsplist = new ObservableCollection<DanhmucSanpham>(db.DanhmucSanpham);

        }
    }
}
