using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    class ThongKeViewModel : BaseViewModel
    {
        public ThongKeXL _SelectedItem;
        public ThongKeXL SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    
                }
            }
        }
        public enum ChucNangQL
        {
            DoanhThu, SanPham, LichSu
        };
        private int _ChucNangThongKe;
        public int ChucNangThongKe { get => _ChucNangThongKe; set { _ChucNangThongKe = value; OnPropertyChanged(); } }

        private ObservableCollection<ThongKeXL> _doanhthulist;
        public ObservableCollection<ThongKeXL> doanhthulist { get => _doanhthulist; set { _doanhthulist = value; OnPropertyChanged(); } }
        public ICommand BtnDoanhThuCommand { get; set; }
         public ICommand BtnSanPhamCommand { get; set; }
        public ICommand loadcommand { get; set; }
        public ICommand BtnLichSuCommand { get; set; }

        public ThongKeViewModel()
        {
            #region Nút chức năng thống kê
            BtnDoanhThuCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                ChucNangThongKe = (int)ChucNangQL.DoanhThu;
            });
            loadcommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                loaddoanhthu();
            });
            BtnSanPhamCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                ChucNangThongKe = (int)ChucNangQL.SanPham;
            });
            BtnLichSuCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                ChucNangThongKe = (int)ChucNangQL.LichSu;
            });
            #endregion
            void loaddoanhthu()
            {
                var db = new qlbhContext();
                doanhthulist = new ObservableCollection<ThongKeXL>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var hoadon = db.ViewThongke;
                    int? idch = MainViewModel.TaiKhoan.Idcuahang;
                    foreach (var item in hoadon.Where(p => p.IdCuahang == idch).ToList())
                    {
                        ThongKeXL thongke = new ThongKeXL();
                        thongke.SoLuongHoaDon = item.SoLuongHoaDon;
                        thongke.NgayTao = item.NgayTao;
                        thongke.TongDoanhThu = item.TongDoanhThu;
                        doanhthulist.Add(thongke);
                    }
                }
            }
        }
    }
    
}
