using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
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
        public SanPham_NhaCungCap _SelectedItem;
        public SanPham_NhaCungCap SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    soluongsp = SelectedItem.SoLuong;
                }
            }
        }

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

        private int _soluongsp;
        public int soluongsp { get => _soluongsp; set { _soluongsp = value; OnPropertyChanged(); } }


        private ObservableCollection<SanPham_NhaCungCap> _kinhdolist;
        public ObservableCollection<SanPham_NhaCungCap> kinhdolist { get => _kinhdolist; set { _kinhdolist = value; OnPropertyChanged(); } }

        public ICommand BtnPepsicoCommand { get; set; }
        public ICommand BtnCocaColaCommand { get; set; }
        public ICommand BtnInterFoodCommand { get; set; }
        public ICommand BtnRedBullCommand { get; set; }
        public ICommand BtnTanHiepPhatCommand { get; set; }
        public ICommand BtnUniversalRobinaCommand { get; set; }
        public ICommand BtnKinhDoCommand { get; set; }
        public ICommand nhapUR { get; set; }
        public ICommand nhapKinhDo { get; set; }
        public ICommand nhapTanHiepPhat { get; set; }
        public ICommand nhapRedBull { get; set; }
        public ICommand nhapInter { get; set; }
        public ICommand nhapCoca { get; set; }
        public ICommand nhapPepsi { get; set; }
        public ICommand editsoluongpes { get; set; }
        public ICommand editsoluongcoca { get; set; }
        public ICommand editsoluonginter { get; set; }
        public ICommand editsoluongredbull { get; set; }
        public ICommand editsoluongthp { get; set; }
        public ICommand editsoluongur { get; set; }
        public ICommand editsoluongkinhdo { get; set; }
        public ICommand load { get; set; }

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
         
            load= new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {

                LoadPepsi();
                LoadCoca();
                LoadKinhdo();
                LoadInterfood();
                LoadRedbull();
                LoadTanhiepphat();
                LoadUR();
            });
            editsoluongpes = new RelayCommand<TextBox>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;
                
            }, (p) =>
            {
                try
                {
                    foreach (var od in pepsilist)
                    {
                        if (SelectedItem.barcode== od.barcode)
                        {
                           
                            od.SoLuong = soluongsp;    
                            pepsilist.Remove(od);
                            pepsilist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            return;
                        }
                    }
                }
                catch { }


            });
            editsoluongcoca = new RelayCommand<TextBox>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                try
                {
                    foreach (var od in cocalist)
                    {
                        if (SelectedItem.barcode == od.barcode)
                        {

                            od.SoLuong = soluongsp;
                            cocalist.Remove(od);
                            cocalist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            return;
                        }
                    }
                }
                catch { }


            });
            editsoluonginter = new RelayCommand<TextBox>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                try
                {       
                    foreach (var od in interfoodlist)
                    {
                        if (SelectedItem.barcode == od.barcode)
                        {

                            od.SoLuong = soluongsp;
                            interfoodlist.Remove(od);
                            interfoodlist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            return;
                        }
                    }
                }
                catch { }


            });
            editsoluongredbull = new RelayCommand<TextBox>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                try
                {
                    foreach (var od in redbulllist)
                    {
                        if (SelectedItem.barcode == od.barcode)
                        {

                            od.SoLuong = soluongsp;
                            redbulllist.Remove(od);
                            redbulllist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            return;
                        }
                    }
                }
                catch { }


            });
            editsoluongthp = new RelayCommand<TextBox>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                try
                {
                    foreach (var od in tanhiepphatlist)
                    {
                        if (SelectedItem.barcode == od.barcode)
                        {

                            od.SoLuong = soluongsp;
                            tanhiepphatlist.Remove(od);
                            tanhiepphatlist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            return;
                        }
                    }
                }
                catch { }


            });
            editsoluongur = new RelayCommand<TextBox>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                try
                {
                    foreach (var od in URlist)
                    {
                        if (SelectedItem.barcode == od.barcode)
                        {

                            od.SoLuong = soluongsp;
                            URlist.Remove(od);
                            URlist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            return;
                        }
                    }
                }
                catch { }


            });
            editsoluongkinhdo = new RelayCommand<TextBox>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                try
                {
                    foreach (var od in kinhdolist)
                    {
                        if (SelectedItem.barcode == od.barcode)
                        {

                            od.SoLuong = soluongsp;
                            kinhdolist.Remove(od);
                            kinhdolist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            return;
                        }
                    }
                }
                catch { }


            });
           /* thanhtoanpes = new RelayCommand<Window>((p) =>
            {
                if ( pepsilist == null)
                    return false;
                return true;
            }, (p) =>
            {
                var db = new qlbhContext();
                int? idch = MainViewModel.TaiKhoan.Idcuahang;
                int idnv = MainViewModel.TaiKhoan.IdNhanvien;
                var xchd = db.HoaDon.Where(p => p.IdCuahang == idch && p.IdKhachhang == null).FirstOrDefault();

                if (xchd == null)
                {
                    db.HoaDon.Add(new HoaDon
                    {
                        MaHoadon = 1,
                        NgayTao = DateTime.Now,
                        ThanhTien = ,
                        IdNhanvien = idnv,
                        IdKhachhang = 1,
                        IdCuahang = Int32.Parse(idch.ToString())

                    });
                    db.SaveChanges();
                    long mahdln = db.HoaDon.Where(p => p.IdCuahang == idch).Max(p => p.MaHoadon);
                    var h = db.HoaDon.Where(p => p.MaHoadon == mahdln).FirstOrDefault();
                    foreach (var od in orderlist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.soluong,
                            GiaTien = od.dongia,
                            IdKhachhang = 1
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong");
                    orderlist.Clear();
                    Orderxl odl = new Orderxl();
                    odl = null;
                    total = 0;
                    p.Close();
                    return;
                }
                else
                {
                    long mahdl = db.HoaDon.Where(p => p.IdCuahang == idch).Max(p => p.MaHoadon);
                    db.HoaDon.Add(new HoaDon
                    {
                        MaHoadon = long.Parse((mahdl + 1).ToString()),
                        NgayTao = ngaytao,
                        ThanhTien = total,
                        IdNhanvien = idnv,
                        IdKhachhang = 1,
                        IdCuahang = Int32.Parse(idch.ToString())

                    });
                    db.SaveChanges();
                    long mahdln = db.HoaDon.Where(p => p.IdCuahang == idch).Max(p => p.MaHoadon);
                    var h = db.HoaDon.Where(p => p.MaHoadon == mahdln).FirstOrDefault();
                    foreach (var od in orderlist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.soluong,
                            GiaTien = od.dongia,
                            IdKhachhang = 1
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong 1 ");
                    orderlist.Clear();
                    Orderxl odl = new Orderxl();
                    odl = null;
                    total = 0;
                    p.Close();
                }

            });*/
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
                        sanpham.barcode = item.IdSanpham;
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
                        sanpham.barcode = item.IdSanpham;
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
                        sanpham.barcode = item.IdSanpham;
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
                        sanpham.barcode = item.IdSanpham;
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
                        sanpham.barcode = item.IdSanpham;
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
                        sanpham.barcode = item.IdSanpham;
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
                        sanpham.barcode = item.IdSanpham;
                        sanpham.SoLuong = 0;
                        kinhdolist.Add(sanpham);
                    }
                }
            }
        }
    }
}
