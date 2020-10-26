using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    class ChiTietHoaDonViewModel : BaseViewModel
    {
        private string _ngaytao;
        public string ngaytao { get => _ngaytao; set { _ngaytao = value; OnPropertyChanged(); } }

        private int _mahoadon;
        public int mahoadon { get => _mahoadon; set { _mahoadon = value; OnPropertyChanged(); } }

        private string _tensp;
        public string tensp { get => _tensp; set { _tensp = value; OnPropertyChanged(); } }

        private int _soluong;
        public int soluong { get => _soluong; set { _soluong = value; OnPropertyChanged(); } }

        private int _dongia;
        public int dongia { get => _dongia; set { _dongia = value; OnPropertyChanged(); } }

        private int _thanhtien;
        public int thanhtien { get => _thanhtien; set { _thanhtien = value; OnPropertyChanged(); } }

        private ObservableCollection<HoaDonChitiet> _cthdList;
        public ObservableCollection<HoaDonChitiet> tonkhoxlist { get => _cthdList; set { _cthdList = value; OnPropertyChanged(); } }
        public ICommand cthdLoad { get; set; }
    }
}
