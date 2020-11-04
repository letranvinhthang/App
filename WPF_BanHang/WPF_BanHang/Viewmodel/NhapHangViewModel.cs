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
        private ObservableCollection<SanPham_NhaCungCap> _nhaplist;
        public ObservableCollection<SanPham_NhaCungCap> nhaplist { get => _nhaplist; set { _nhaplist = value; OnPropertyChanged(); } }

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
        private double _total;
        public double total { get => _total; set { _total = value; OnPropertyChanged(); } }
        private DateTime _ngaytao;
        public DateTime ngaytao { get => _ngaytao; set { _ngaytao = value; OnPropertyChanged(); } }
        private int? _idncc;
        public int? idncc { get => _idncc; set { _idncc = value; OnPropertyChanged(); } }

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
        public ICommand thanhtoan { get; set; }
        public ICommand xacnhancommand { get; set; }
        public ICommand exitcommand { get; set; }
        public ICommand load { get; set; }

        public NhapHangViewModel()
        {
            BtnPepsicoCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.Pepsico;
                foreach (var od in pepsilist)
                {
                    total += od.tongtien;
                }

            });
            BtnCocaColaCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.CocaCola;
                foreach (var od in cocalist)
                {
                    total += od.tongtien;
                }
            });
            BtnInterFoodCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.InterFood;
                foreach (var od in interfoodlist)
                {
                    total += od.tongtien;
                }
            });
            BtnRedBullCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.RedBull;
                foreach (var od in redbulllist)
                {
                    total += od.tongtien;
                }
            });
            BtnTanHiepPhatCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.TanHiepPhat;
                foreach (var od in tanhiepphatlist)
                {
                    total += od.tongtien;
                }
            });
            BtnUniversalRobinaCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.UniversaUniversalRobina;
                foreach (var od in URlist)
                {
                    total += od.tongtien;
                }
            });
            BtnKinhDoCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNangNhapHang = (int)ChucNangQL.KinhDo;
                foreach (var od in kinhdolist)
                {
                    total += od.tongtien;
                }
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
            exitcommand = new RelayCommand<Window>((p) =>
            { return true; }, (p) =>
            {
                p.Close();
            });
            xacnhancommand = new RelayCommand<Object>((p) => {
                if (total == 0)
                    return false;
                return true;
            }, (p) =>
            {
                int? idch = MainViewModel.TaiKhoan.Idcuahang;

                //ten = MainViewModel.TaiKhoan.TenNhanvien;
                ngaytao = DateTime.Now;
                if (ChucNangNhapHang== (int)ChucNangQL.Pepsico)
                {
                    total = 0;
                    nhaplist = new ObservableCollection<SanPham_NhaCungCap>();
                    foreach( var od in pepsilist.Where(p => p.SoLuong != 0))
                    {
                        nhaplist.Add(od);
                        total += od.tongtien;
                        idncc = od.IdNhaCC;
                    }
                }
               else if (ChucNangNhapHang == (int)ChucNangQL.CocaCola)
                {
                    total = 0;
                    nhaplist = new ObservableCollection<SanPham_NhaCungCap>();
                    foreach (var od in cocalist.Where(p => p.SoLuong != 0))
                    {
                        nhaplist.Add(od);
                        total += od.tongtien;
                        idncc = od.IdNhaCC;
                    }
                }
               else if (ChucNangNhapHang == (int)ChucNangQL.InterFood)
                {
                    total = 0;
                    nhaplist = new ObservableCollection<SanPham_NhaCungCap>();
                    foreach (var od in interfoodlist.Where(p => p.SoLuong != 0))
                    {
                        nhaplist.Add(od);
                        total += od.tongtien;
                        idncc = od.IdNhaCC;
                    }
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.TanHiepPhat)
                {
                    total = 0;
                    nhaplist = new ObservableCollection<SanPham_NhaCungCap>();
                    foreach (var od in tanhiepphatlist.Where(p => p.SoLuong != 0))
                    {
                        nhaplist.Add(od);
                        total += od.tongtien;
                    }
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.RedBull)
                {
                    total = 0;
                    nhaplist = new ObservableCollection<SanPham_NhaCungCap>();
                    foreach (var od in redbulllist.Where(p => p.SoLuong != 0))
                    {
                        nhaplist.Add(od);
                        total += od.tongtien;
                        idncc = od.IdNhaCC;
                    }
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.UniversaUniversalRobina)
                {
                    total = 0;
                    nhaplist = new ObservableCollection<SanPham_NhaCungCap>();
                    foreach (var od in URlist.Where(p => p.SoLuong != 0))
                    {
                        nhaplist.Add(od);
                        total += od.tongtien;
                        idncc = od.IdNhaCC;
                    }
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.KinhDo)
                {
                    total = 0;
                    nhaplist = new ObservableCollection<SanPham_NhaCungCap>();
                    foreach (var od in kinhdolist
                    .Where(p => p.SoLuong != 0))
                    {
                        nhaplist.Add(od);
                        total += od.tongtien;
                        idncc = od.IdNhaCC;
                    }
                }
                XacNhanNhapHangWindow xn = new XacNhanNhapHangWindow();
                xn.ShowDialog();


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
                            total = 0;
                            od.SoLuong = soluongsp;
                            od.tongtien = od.SoLuong * od.GiaNhap;
                            pepsilist.Remove(od);
                            pepsilist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            foreach (var odl in pepsilist)
                            {
                                total += odl.tongtien;
                            }

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
                            total = 0;
                            od.SoLuong = soluongsp;
                            od.tongtien = od.SoLuong * od.GiaNhap;
                            cocalist.Remove(od);
                            cocalist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            foreach (var odl in cocalist)
                            {
                                total += odl.tongtien;
                            }
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

                      
                            total = 0;
                            od.SoLuong = soluongsp;
                            od.tongtien = od.SoLuong * od.GiaNhap;
                            interfoodlist.Remove(od);
                            interfoodlist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            foreach (var odl in interfoodlist)
                            {
                                total += odl.tongtien;
                            }
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
                            total = 0;
                            od.SoLuong = soluongsp;
                            od.tongtien = od.SoLuong * od.GiaNhap;
                            redbulllist.Remove(od);
                            redbulllist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            foreach (var odl in redbulllist)
                            {
                                total += odl.tongtien;
                            }
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
                            total = 0;
                            od.SoLuong = soluongsp;
                            od.tongtien = od.SoLuong * od.GiaNhap;
                            tanhiepphatlist.Remove(od);
                            tanhiepphatlist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            foreach (var odl in tanhiepphatlist)
                            {
                                total += odl.tongtien;
                            }
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
                            total = 0;
                            od.SoLuong = soluongsp;
                            od.tongtien = od.SoLuong * od.GiaNhap;
                            URlist.Remove(od);
                            URlist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            foreach (var odl in URlist)
                            {
                                total += odl.tongtien;
                            }
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
                            total = 0;
                            od.SoLuong = soluongsp;
                            od.tongtien = od.SoLuong * od.GiaNhap;
                            kinhdolist.Remove(od);
                            kinhdolist.Add(od);
                            p.Text = null;
                            soluongsp = 0;
                            foreach (var odl in kinhdolist)
                            {
                                total += odl.tongtien;
                            }
                            return;
                        }
                    }
                }
                catch { }


            });
            thanhtoan = new RelayCommand<Window>((p) =>
            {
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
                        NgayTao = ngaytao,
                        ThanhTien = total,
                        IdNhanvien = idnv,
                        IdNhacc = idncc,
                        IdCuahang = Int32.Parse(idch.ToString())

                    });
                    db.SaveChanges();
                }
                else
                {
                    long mahdl = db.HoaDon.Where(p => p.IdCuahang == idch && p.IdKhachhang == null).Max(p => p.MaHoadon);
                    db.HoaDon.Add(new HoaDon
                    {
                        MaHoadon = long.Parse((mahdl + 1).ToString()),
                        NgayTao = DateTime.Now,
                        ThanhTien = total,
                        IdNhanvien = idnv,
                        IdNhacc = idncc,
                        IdCuahang = Int32.Parse(idch.ToString())

                    });
                    db.SaveChanges();
                }
                long mahdln = db.HoaDon.Where(p => p.IdCuahang == idch && p.IdKhachhang == null).Max(p => p.MaHoadon);
                    var h = db.HoaDon.Where(p => p.MaHoadon == mahdln).FirstOrDefault();
                if (ChucNangNhapHang == (int)ChucNangQL.Pepsico)
                {
                    foreach (var od in pepsilist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.SoLuong,
                            GiaTien = od.GiaNhap,
                            IdNhacc = idncc
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong");
                    LoadPepsi();
                    SanPham_NhaCungCap odl = new SanPham_NhaCungCap();
                    odl = null;
                    total = 0;
                    p.Close();
                    return;
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.CocaCola)
                {
                    foreach (var od in cocalist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.SoLuong,
                            GiaTien = od.GiaNhap,
                            IdNhacc = idncc
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong");
                    LoadCoca();
                    SanPham_NhaCungCap odl = new SanPham_NhaCungCap();
                    odl = null;
                    total = 0;
                    p.Close();
                    return;
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.InterFood)
                {
                    foreach (var od in interfoodlist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.SoLuong,
                            GiaTien = od.GiaNhap,
                            IdNhacc = idncc
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong");
                    LoadInterfood();
                    SanPham_NhaCungCap odl = new SanPham_NhaCungCap();
                    odl = null;
                    total = 0;
                    p.Close();
                    return;
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.RedBull)
                {
                    foreach (var od in redbulllist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.SoLuong,
                            GiaTien = od.GiaNhap,
                            IdNhacc = idncc
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong");
                    LoadRedbull();
                    SanPham_NhaCungCap odl = new SanPham_NhaCungCap();
                    odl = null;
                    total = 0;
                    p.Close();
                    return;
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.TanHiepPhat)
                {
                    foreach (var od in tanhiepphatlist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.SoLuong,
                            GiaTien = od.GiaNhap,
                            IdNhacc = idncc
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong");
                    LoadTanhiepphat();
                    SanPham_NhaCungCap odl = new SanPham_NhaCungCap();
                    odl = null;
                    total = 0;
                    p.Close();
                    return;
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.UniversaUniversalRobina)
                {
                    foreach (var od in URlist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.SoLuong,
                            GiaTien = od.GiaNhap,
                            IdNhacc = idncc
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong");
                    LoadUR();
                    SanPham_NhaCungCap odl = new SanPham_NhaCungCap();
                    odl = null;
                    total = 0;
                    p.Close();
                    return;
                }
                else if (ChucNangNhapHang == (int)ChucNangQL.KinhDo)
                {
                    foreach (var od in kinhdolist)
                    {
                        db.HoaDonChitiet.Add(new HoaDonChitiet
                        {
                            IdHoadon = h.IdHoadon,
                            IdSanpham = od.barcode,
                            SoLuong = od.SoLuong,
                            GiaTien = od.GiaNhap,
                            IdNhacc = idncc
                        });
                        db.SaveChanges();
                    }
                    MessageBox.Show("thanh toan thanh cong");
                    LoadKinhdo();
                    SanPham_NhaCungCap odl = new SanPham_NhaCungCap();
                    odl = null;
                    total = 0;
                    p.Close();
                    return;
                }
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
                        sanpham.barcode = item.IdSanpham;
                        sanpham.SoLuong = 0;
                        sanpham.GiaNhap = item.GiaNhap;
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
                        sanpham.GiaNhap = item.GiaNhap;
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
                        sanpham.GiaNhap = item.GiaNhap;
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
                        sanpham.GiaNhap = item.GiaNhap;
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
                        sanpham.GiaNhap = item.GiaNhap;
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
                        sanpham.GiaNhap = item.GiaNhap;
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
                        sanpham.GiaNhap = item.GiaNhap;
                        kinhdolist.Add(sanpham);
                    }
                }
            }
        }
    }
}
