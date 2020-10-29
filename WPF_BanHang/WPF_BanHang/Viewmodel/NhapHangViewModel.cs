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

        private ObservableCollection<SanPham_NhaCungCap> _pepsilist;
        public ObservableCollection<SanPham_NhaCungCap> pepsilist { get => _pepsilist; set { _pepsilist = value; OnPropertyChanged(); } }

        private ObservableCollection<SanPham_NhaCungCap> _cocalist;
        public ObservableCollection<SanPham_NhaCungCap> cocalist { get => _cocalist; set { _cocalist = value; OnPropertyChanged(); } }

        private ObservableCollection<SanPham_NhaCungCap> _interfoodlist;
        public ObservableCollection<SanPham_NhaCungCap> interfoodlist { get => _interfoodlist; set { _interfoodlist = value; OnPropertyChanged(); } }

        private ObservableCollection<SanPham_NhaCungCap> _redbulllist;
        public ObservableCollection<SanPham_NhaCungCap> redbulllist { get => _redbulllist; set { _redbulllist = value; OnPropertyChanged(); } }

        private ObservableCollection<SanPham_NhaCungCap> _tanhiepphatlist;
        public ObservableCollection<SanPham_NhaCungCap> tanhiepphatlist { get => _tanhiepphatlist; set { _tanhiepphatlist = value; OnPropertyChanged(); } }

        private ObservableCollection<SanPham_NhaCungCap> _URlist;
        public ObservableCollection<SanPham_NhaCungCap> URlist { get => _URlist; set { _URlist = value; OnPropertyChanged(); } }

        private ObservableCollection<SanPham_NhaCungCap> _kinhdolist;
        public ObservableCollection<SanPham_NhaCungCap> kinhdolist { get => _kinhdolist; set { _kinhdolist = value; OnPropertyChanged(); } }

        public ICommand BtnPepsicoCommand { get; set; }
        public ICommand BtnCocaColaCommand { get; set; }
        public ICommand BtnInterFoodCommand { get; set; }
        public ICommand BtnRedBullCommand { get; set; }
        public ICommand BtnTanHiepPhatCommand { get; set; }
        public ICommand BtnUniversalRobinaCommand { get; set; }
        public ICommand BtnKinhDoCommand { get; set; }
        public ICommand loadpepsi { get; set; }
        public ICommand loadcoca { get; set; }
        public ICommand loadinterfood { get; set; }
        public ICommand loadredbull { get; set; }
        public ICommand loadtanhiepphat { get; set; }
        public ICommand loadUR { get; set; }
        public ICommand loadkinhdo { get; set; }

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
            loadpepsi = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                LoadPepsi();
            });
            loadcoca = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                LoadCoca();
            });
            loadinterfood = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                LoadInterfood();
            });
            loadredbull = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                LoadRedbull();
            });
            loadtanhiepphat = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                LoadTanhiepphat();
            });
            loadUR = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                LoadUR();
            });
            loadkinhdo = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                LoadKinhdo();
            });

            void LoadPepsi()
            {
                var db = new qlbhContext();
                pepsilist = new ObservableCollection<SanPham_NhaCungCap>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var sp = db.SanPham;

                    foreach (var item in sp.Where(p => p.IdNhacc == 1).ToList())
                    {
                        SanPham_NhaCungCap sanpham = new SanPham_NhaCungCap();

                        sanpham.IdNhaCC = item.IdNhacc;
                        sanpham.TenSP = item.TenSanpham;
                        sanpham.SoLuong = 0;
                        pepsilist.Add(sanpham);
                    }
                }
            }
            void LoadCoca()
            {
                var db = new qlbhContext();
                cocalist = new ObservableCollection<SanPham_NhaCungCap>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var sp = db.SanPham;

                    foreach (var item in sp.Where(p => p.IdNhacc == 2).ToList())
                    {
                        SanPham_NhaCungCap sanpham = new SanPham_NhaCungCap();

                        sanpham.IdNhaCC = item.IdNhacc;
                        sanpham.TenSP = item.TenSanpham;
                        sanpham.SoLuong = 0;
                        cocalist.Add(sanpham);
                    }
                }
            }
            void LoadInterfood()
            {
                var db = new qlbhContext();
                interfoodlist = new ObservableCollection<SanPham_NhaCungCap>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var sp = db.SanPham;

                    foreach (var item in sp.Where(p => p.IdNhacc == 3).ToList())
                    {
                        SanPham_NhaCungCap sanpham = new SanPham_NhaCungCap();

                        sanpham.IdNhaCC = item.IdNhacc;
                        sanpham.TenSP = item.TenSanpham;
                        sanpham.SoLuong = 0;
                        interfoodlist.Add(sanpham);
                    }
                }
            }
            void LoadRedbull()
            {
                var db = new qlbhContext();
                redbulllist = new ObservableCollection<SanPham_NhaCungCap>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var sp = db.SanPham;

                    foreach (var item in sp.Where(p => p.IdNhacc == 4).ToList())
                    {
                        SanPham_NhaCungCap sanpham = new SanPham_NhaCungCap();

                        sanpham.IdNhaCC = item.IdNhacc;
                        sanpham.TenSP = item.TenSanpham;
                        sanpham.SoLuong = 0;
                        redbulllist.Add(sanpham);
                    }
                }
            }
            void LoadTanhiepphat()
            {
                var db = new qlbhContext();
                tanhiepphatlist = new ObservableCollection<SanPham_NhaCungCap>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var sp = db.SanPham;

                    foreach (var item in sp.Where(p => p.IdNhacc == 5).ToList())
                    {
                        SanPham_NhaCungCap sanpham = new SanPham_NhaCungCap();

                        sanpham.IdNhaCC = item.IdNhacc;
                        sanpham.TenSP = item.TenSanpham;
                        sanpham.SoLuong = 0;
                        tanhiepphatlist.Add(sanpham);
                    }
                }
            }
            void LoadUR()
            {
                var db = new qlbhContext();
                URlist = new ObservableCollection<SanPham_NhaCungCap>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var sp = db.SanPham;

                    foreach (var item in sp.Where(p => p.IdNhacc == 6).ToList())
                    {
                        SanPham_NhaCungCap sanpham = new SanPham_NhaCungCap();

                        sanpham.IdNhaCC = item.IdNhacc;
                        sanpham.TenSP = item.TenSanpham;
                        sanpham.SoLuong = 0;
                        URlist.Add(sanpham);
                    }
                }
            }
            void LoadKinhdo()
            {
                var db = new qlbhContext();
                kinhdolist = new ObservableCollection<SanPham_NhaCungCap>();
                if (MainViewModel.TaiKhoan != null)
                {
                    var sp = db.SanPham;

                    foreach (var item in sp.Where(p => p.IdNhacc == 7).ToList())
                    {
                        SanPham_NhaCungCap sanpham = new SanPham_NhaCungCap();

                        sanpham.IdNhaCC = item.IdNhacc;
                        sanpham.TenSP = item.TenSanpham;
                        sanpham.SoLuong = 0;
                        kinhdolist.Add(sanpham);
                    }
                }
            }
        }
    }
}
