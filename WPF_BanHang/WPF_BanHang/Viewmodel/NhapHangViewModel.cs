using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    class NhapHangViewModel :BaseViewModel
    {
        public enum ChucNangQL
        {
            Pepsico, CocaCola, InterFood, RedBull, TanHiepPhat, UniversaUniversalRobina, KinhDo
        };

        private int _ChucNangNhapHang;
        public int ChucNangNhapHang { get => _ChucNangNhapHang; set { _ChucNangNhapHang = value; OnPropertyChanged(); } }

        private ObservableCollection<SanPham_NhaCungCap> _sanphamlist;
        public ObservableCollection<SanPham_NhaCungCap> sanphamlist { get => _sanphamlist; set { _sanphamlist = value; OnPropertyChanged(); } }

        public ICommand BtnPepsicoCommand { get; set; }
        public ICommand BtnCocaColaCommand { get; set; }
        public ICommand BtnInterFoodCommand { get; set; }
        public ICommand BtnRedBullCommand { get; set; }
        public ICommand BtnTanHiepPhatCommand { get; set; }
        public ICommand BtnUniversalRobinaCommand { get; set; }
        public ICommand BtnKinhDoCommand { get; set; }
        public ICommand loadcommand { get; set; }
        public NhapHangViewModel()
        {
            BtnPepsicoCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.Pepsico;
            });
            BtnCocaColaCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.CocaCola;
            });
            BtnInterFoodCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.InterFood;
            });
            BtnRedBullCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.RedBull;
            });
            BtnTanHiepPhatCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.TanHiepPhat;
            });
            BtnUniversalRobinaCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.UniversaUniversalRobina;
            });
            BtnKinhDoCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.KinhDo;
            });
            loadcommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                LoadPepsi();
            });

            void LoadPepsi()
            {
                var db = new qlbhContext();
                sanphamlist = new ObservableCollection<SanPham_NhaCungCap>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var sp = db.SanPham;

                    foreach (var item in sp.Where(p => p.IdNhacc == 1).ToList())
                    {
                        SanPham_NhaCungCap sanpham = new SanPham_NhaCungCap();

                        sanpham.IdNhaCC = item.IdNhacc;
                        sanpham.TenSP = item.TenSanpham;
                        sanpham.SoLuong = 0;
                        sanphamlist.Add(sanpham);
                    }
                }
            }
        }
    }
}
