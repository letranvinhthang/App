using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{

    class ThongKeViewModel : BaseViewModel
    {
        private ChartValues<double> _doanhthu;

        public ChartValues<double> DoanhThu
        {
            get
            {
                return _doanhthu;
            }
            private set
            {
                _doanhthu = value;
                OnPropertyChanged(nameof(DoanhThu));
            }
        }


        public ObservableCollection<DateTime?> Ngay { get; }

        public enum ChucNangQL
        {
            DoanhThu, SanPham, LichSu
        };
        private int _ChucNangThongKe;
        public int ChucNangThongKe { get => _ChucNangThongKe; set { _ChucNangThongKe = value; OnPropertyChanged(); } }

        private ObservableCollection<ViewThongke> _doanhthulist;
        public ObservableCollection<ViewThongke> doanhthulist { get => _doanhthulist; set { _doanhthulist = value; OnPropertyChanged(); } }
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
            _doanhthu = new ChartValues<double>();
            DoanhThu = new ChartValues<double>(_doanhthu);
            Ngay = new ObservableCollection<DateTime?>();
            

            void loaddoanhthu()
            {
                
                var db = new qlbhContext();
                doanhthulist = new ObservableCollection<ViewThongke>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var hoadon = db.ViewThongke;
                    int? idch = MainViewModel.TaiKhoan.Idcuahang;
                    foreach (var item in hoadon.Where(p => p.IdCuahang == idch).ToList())
                    {
                        ViewThongke thongke = new ViewThongke();

                        thongke.SoLuongHoaDon = item.SoLuongHoaDon;
                      //  thongke.NgayTao = item.NgayTao;
                        thongke.TongDoanhThu = item.TongDoanhThu;
                        _doanhthu.Add(double.Parse(item.TongDoanhThu.ToString()));
<<<<<<< HEAD
                        Ngay.Add(item.NgayTao);
=======
                        _soluongdon.Add(item.SoLuongHoaDon);
                    //    _Ngay.Add(double.Parse(item.NgayTao.ToString("dd")));
>>>>>>> 5e87d8c371dc6bb5880446ae7e89eba54c20d8e7
                        doanhthulist.Add(thongke);
                    }
                }
            }
            
            
        }

    }
    
    
}
