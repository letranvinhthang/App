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
    class OrderViewModel : BaseViewModel
    {

        private long _barcode;
        public long barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }

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
        public ICommand BarcodeChangedcommand { get; set; }

        public OrderViewModel()
        { var db = new qlbhContext();
            orderlist = new ObservableCollection<Orderxl>();
            BarcodeChangedcommand = new RelayCommand<TextBox>((p) => {  return p == null? false: true; }, (p) =>
            {
                try
                {
                    if (p.Text != null)
                    {
                        barcode = long.Parse(p.Text);
                        if (MainViewModel.TaiKhoan != null)
                        {
                            int? idch = MainViewModel.TaiKhoan.Idcuahang;
                            var order = db.SanPham.Where(x => x.IdSanpham == barcode);
                            var chsp = db.CuahangSanpham.Where(x => x.IdSanpham == barcode && x.IdCuahang == idch).FirstOrDefault();
                            if (order.Count() > 0)
                            {
                                var dssp = order.FirstOrDefault();
                                Orderxl orderl = new Orderxl();
                                orderl.barcode = dssp.IdSanpham;
                                orderl.tensp = dssp.TenSanpham;
                                orderl.dongia = chsp.GiaTheoQuan;
                                orderl.soluong = 1;
                                orderl.tongtien = orderl.dongia * orderl.soluong;
                                orderlist.Add(orderl);
                            }
                        }

                    }
                }
                catch
                {
                    
                }
                });
        }

        public void loadorder()
        {
            
        }
    }
}
