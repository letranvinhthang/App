using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    class OrderViewModel : BaseViewModel
    {
        private string _hinhsp;
        public string hinhsp { get => _hinhsp; set { _hinhsp = value; OnPropertyChanged(); } }

        private string _tensp;
        public string tensp { get => _tensp; set { _tensp = value; OnPropertyChanged(); } }

        private string _soluongsp;
        public string soluongsp { get => _soluongsp; set { _soluongsp = value; OnPropertyChanged(); } }

        private string _dongia;
        public string dongia { get => _dongia; set { _dongia = value; OnPropertyChanged(); } }

        private string _tongtien;
        public string tongtien { get => _tongtien; set { _tongtien = value; OnPropertyChanged(); } }

        private ObservableCollection<Orderxl> _orderlist;
        public ObservableCollection<Orderxl> orderlist { get => _orderlist; set { _orderlist = value; OnPropertyChanged(); } }

        public ICommand loadcommand { get; set; }

        public OrderViewModel()
        {
            loadcommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                loadorder();
            });
        }

        void loadorder()
        {
            
        }
    }
}
