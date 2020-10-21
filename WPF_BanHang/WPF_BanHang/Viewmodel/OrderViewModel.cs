using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    class OrderViewModel : BaseViewModel
    {
        //lấy dự liệu
        public Orderxl _SelectedItem;
        public Orderxl SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    hinhsp = SelectedItem.hinhsp;
                    barcode = SelectedItem.barcode;
                    tensp = SelectedItem.tensp;                  
                }
            }
        }


        private string _barcode;
        public string barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }

        private byte[] _hinhsp;
        public byte[] hinhsp { get => _hinhsp; set { _hinhsp = value; OnPropertyChanged(); } }

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

        public ICommand BarcodeChangedCommand { get; set; }
        public ICommand BtnMuaHangCommand { get; set; }
        public ICommand HienThiCommand { get; set; }
        public OrderViewModel()
        {
            BarcodeChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { barcode = p.Text; });
            BtnMuaHangCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                loadorder();
            });
            HienThiCommand = new RelayCommand<Object>((p) =>
            {
                return SelectedItem == null ? false : true;
            }, (p) =>
            {
                tensp = SelectedItem.tensp;
                hinhsp = SelectedItem.hinhsp;                           
            });
        }

        public void loadorder()
        {
            var db = new qlbhContext();          
            if (barcode != null)
            {
                string bc = barcode;
                var sanpham = db.SanPham.Where(x => x.IdSanpham == Int32.Parse(bc));
                if (sanpham.Count() > 0)
                {
                    foreach (var item in sanpham.ToList())
                    {
                        Orderxl order = new Orderxl();
                        order.hinhsp = item.HinhSanpham;
                        order.tensp = item.TenSanpham;
                        orderlist.Add(order);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo");
                    return;
                }
            }
        }
    }
}
