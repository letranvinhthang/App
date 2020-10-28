using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
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
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection DoanhThu { get; }
        private readonly ChartValues<double> _doanhthu;

        public SeriesCollection SoLuongDon { get; }
        private readonly ChartValues<double> _soluongdon;

        public SeriesCollection Ngay { get; }
        private readonly ChartValues<DateTime> _Ngay;

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
                        _doanhthu.Add(double.Parse(item.TongDoanhThu.ToString()));
                        _soluongdon.Add(item.SoLuongHoaDon);
                        _Ngay.Add(item.NgayTao);
                        doanhthulist.Add(thongke);
                    }
                }
            }

            _doanhthu = new ChartValues<double>();
            _Ngay = new ChartValues<DateTime>();
            _soluongdon = new ChartValues<double>();
            SeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Title="Doanh thu",
                    Values=_doanhthu
                },

                new LineSeries
                {
                    Title="Số lượng đơn",
                    Values=_soluongdon
                },
            };
        }

    }
    
    
}
