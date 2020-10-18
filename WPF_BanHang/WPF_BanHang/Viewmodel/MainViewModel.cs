using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.ObjectModel;
using WPF_BanHang.Models;
using System.Linq;
using System;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;

namespace WPF_BanHang.Viewmodel
{
    public class MainViewModel : BaseViewModel
    {
        public enum ChucNangQL
        {
            Order, ThongKe, NhapKho, NhanVien, DangXuat
        };
        private int _ChucNang;
        public int ChucNang { get => _ChucNang; set { _ChucNang = value; OnPropertyChanged(); } }

        static public nhanvien Nhanvien { get; set; }

        #region Items Source
        //đổ dữ liệu bên tồn kho
        private ObservableCollection<tonkhoxl> _tonkhoxlist;
<<<<<<< HEAD
        public ObservableCollection<tonkhoxl> tonkhoxlist { get => _tonkhoxlist; set { _tonkhoxlist = value; OnPropertyChanged(); } }

=======
        public ObservableCollection<tonkhoxl> tonkhoxlist { get=> _tonkhoxlist; set { _tonkhoxlist = value;OnPropertyChanged(); } }
        //xử lý order
        private ObservableCollection<tonkhoxl> _orderlist;
        public ObservableCollection<tonkhoxl> orderlist { get => _orderlist; set { _orderlist = value; OnPropertyChanged(); } }
        //xử lý bên nhân viên
>>>>>>> 8ea80d40b17f1638b2148bb17efcd140e825c3df
        public ObservableCollection<nvxl> _nhanvienlist;
        public ObservableCollection<nvxl> nhanvienlist { get => _nhanvienlist;set { _nhanvienlist = value; OnPropertyChanged(); } }
        public ObservableCollection<QuyenHan> _cvlist;
        public ObservableCollection<QuyenHan> cvlist { get => _cvlist; set { _cvlist = value; OnPropertyChanged(); } }

<<<<<<< HEAD
=======
        public ObservableCollection<QuyenHan> _lsplist;
        public ObservableCollection<QuyenHan> lsplist { get => _lsplist; set { _lsplist = value; OnPropertyChanged(); } }
        #endregion

        //lấy dữ liệu đc selected
        public nvxl _SelectedItem;

        public nvxl SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    ten = SelectedItem.ten;
                    pass = SelectedItem.Pass;
                    ngaysinh = SelectedItem.ngaysinh;
                    diachi = SelectedItem.diachi;
                    sdt = SelectedItem.sdt;
                    chuvuseleted = SelectedItem.IdChucvu - 1;
                    manv = SelectedItem.Manv;
                }
            }
        }
        //binding du lieu
        #region Thuộc tính binding
        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private int _manv;

        public int manv { get => _manv; set { _manv = value; OnPropertyChanged(); } }
        private string _pass;

        public string pass { get => _pass; set { _pass = value; OnPropertyChanged(); } }
        private DateTime _ngaysinh;

        public DateTime ngaysinh { get => _ngaysinh; set { _ngaysinh = value; OnPropertyChanged(); } }
        private string _diachi;

        public string diachi { get => _diachi; set { _diachi = value; OnPropertyChanged(); } }
        private string _sdt;

        public string sdt { get => _sdt; set { _sdt = value; OnPropertyChanged(); } }
        private int _chuvuseleted;

        public int chuvuseleted { get => _chuvuseleted; set { _chuvuseleted = value; OnPropertyChanged(); } }
        private bool _disa;

        public bool disa { get => _disa; set { _disa = value; OnPropertyChanged(); } }

        private string _password;

        public string password { get => _password; set { _password = value; OnPropertyChanged(); } }
        private string _sodt;

        public string sodt { get => _sodt; set { _sodt = value; OnPropertyChanged(); } }
        #endregion

>>>>>>> 8ea80d40b17f1638b2148bb17efcd140e825c3df
        //bắt  command
        #region Command ẩn hiện grid
        public ICommand loadedwindowcommand { get; set; }
        public bool isloaded = false;
<<<<<<< HEAD
=======
        public ICommand themsanphamcommand { get; set; }
        public ICommand suasanphamcommand { get; set; }
        public ICommand BtnNhanVienCommand { get; set; }
>>>>>>> 8ea80d40b17f1638b2148bb17efcd140e825c3df
        public ICommand exitcommand { get; set; }
        public ICommand closecommand { get; set; }
        #endregion

        public MainViewModel()
        {
            var db = new qlbhContext();
<<<<<<< HEAD
            closecommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
               {
                   FrameworkElement window = getwindowparent(p);
                   var w = window as Window;
                   if (w != null)
                   {
                       var lg = new MainWindow();
                       w.Close();
                       lg.Show();
                   }
               });
            FrameworkElement getwindowparent(UserControl p)
            {
                FrameworkElement parent = p;
                while (parent.Parent != null)
=======

            /* closecommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
              {
                  FrameworkElement window = getwindowparent(p);
                  var w = window as Window;
                  if (w != null)
                  {
                      var lg = new MainWindow();
                      w.Close();
                      lg.Show();
                  }
              });
             FrameworkElement getwindowparent(UserControl p)
             {
                 FrameworkElement parent = p;
                 while (parent.Parent != null)
                 {
                     parent = parent.Parent as FrameworkElement;

                 }
                 return parent;
             }*/
            BtnNhanVienCommand = new RelayCommand<Grid>((p) =>
            { return true;}, (p) =>
            {
                ChucNang = (int)ChucNangQL.NhanVien;
            });
            themsanphamcommand = new RelayCommand<ThemSanPhamWindow>((k) => { return true; }, (k) => { themsanpham(k); });
            suasanphamcommand = new RelayCommand<SuaSanPhamWindow>((l) => { return true; }, (l) => { suasanpham(l); });
            suanhanviencommand = new RelayCommand<SuaNhanVienWindow>((c) => {
                if (SelectedItem == null)
>>>>>>> 8ea80d40b17f1638b2148bb17efcd140e825c3df
                {
                    parent = parent.Parent as FrameworkElement;

                }
<<<<<<< HEAD
                return parent;
            }
            /*hanhtoancommand = new RelayCommand<HoaDonWindow>((w) => { return true; }, (w) => { Thanhtoan(w); });*/
=======
                return true;
            }, (c) => { suanhanvien(c); });
            themnhanviencommand = new RelayCommand<ChinhSuaWindow>((a) => { return true; }, (a) => { themnhanvien(a); });
            thanhtoancommand = new RelayCommand<HoaDonWindow>((w) => { return true; }, (w) => { Thanhtoan(w); });
            disablecommand = new RelayCommand<object>((p) =>
            {
                bool a = db.NhanVien.Where(p => p.IdNhanvien == SelectedItem.Manv).FirstOrDefault().Disable;
            
                       if (a == true)
                return false;
            return true;
          
            }, (p) =>
            {
                var dis = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                dis.Disable = true;
                db.SaveChanges();
                disa = SelectedItem.Disable;
  
            });
            enablecommand = new RelayCommand<object>((p) =>
            {
             /* bool a = db.NhanVien.Where(p => p.IdNhanvien == SelectedItem.Manv).FirstOrDefault().Disable;
                if (a != true)
                    return false;*/
                return true;
            }, (p) =>
            {
                var dis = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                dis.Disable = false;
                db.SaveChanges();
                disa = SelectedItem.Disable;
            });
>>>>>>> 8ea80d40b17f1638b2148bb17efcd140e825c3df
            exitcommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            loadedwindowcommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                isloaded = true;
                p.Hide();
                loginwindow login = new loginwindow();
                login.ShowDialog();
                if (login.DataContext == null)
                    return;
                var loginnVM = login.DataContext as LoginViewModel;
                if (loginnVM.IsLogin)
                {
                    p.Show();
                    loadtonkho();
                    loadnhanvien();
                }
                else
                {
                    p.Close();
                }
            });
            //xử lý sửa thông tin

            //thống kê
            void loadtonkho()
            {
                var db = new qlbhContext();
                tonkhoxlist = new ObservableCollection<tonkhoxl>();
                var tk = db.TonKho;
                var sp = db.SanPham;
                var cthd = db.HoaDonChitiet;
                int i = 1;
                foreach (var item in sp.ToList())
                {
                    var nhap = cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc != null);
                    var xuat = cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc == null);
                    int sumnhap = 0;
                    int sumxuat = 0;
                    if (nhap != null)
                        sumnhap = nhap.Sum(p => p.SoLuong);
                    if (xuat != null) ;
                    sumxuat = xuat.Sum(p => p.SoLuong);
                    tonkhoxl tonKho = new tonkhoxl();
                    tonKho.hinh = Int64.Parse(item.HinhSanpham);
                    tonKho.ten = item.TenSanpham;
                    tonKho.soluong = sumnhap - sumxuat;
                    tonKho.STT = i;

                    tonkhoxlist.Add(tonKho);
                    i++;
                }
<<<<<<< HEAD
=======
            },
                    (p) =>
                    {
                        if (string.IsNullOrEmpty(password))
                        {
                            var editnp = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                            editnp.TenNhanvien = ten;
                            editnp.Sdt = sdt;
                            editnp.DiachiNhanvien = diachi;
                            editnp.IdChucvu = chuvuseleted + 1;
                            db.SaveChanges();
                            MessageBox.Show("sua thanh cong");
                            SelectedItem.ten = ten;
                            SelectedItem.sdt = sdt;
                            SelectedItem.diachi = diachi;
                            SelectedItem.IdChucvu = chuvuseleted + 1;
                        }
                        else
                        {
                            var edit = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                            edit.TenNhanvien = ten;
                            edit.PassNhanvien = pass;
                            edit.Sdt = sdt;
                            edit.DiachiNhanvien = diachi;
                            edit.IdChucvu = chuvuseleted + 1;
                            db.SaveChanges();
                            MessageBox.Show("sua thanh cong");
                            SelectedItem.ten = ten;
                            SelectedItem.sdt = sdt;
                            SelectedItem.diachi = diachi;
                            SelectedItem.IdChucvu = chuvuseleted + 1;
                        }
                    });


        }
        //thống kê
        void loadtonkho()
        {
            var db = new qlbhContext();
            tonkhoxlist = new ObservableCollection<tonkhoxl>();
            var tk = db.TonKho;
            var sp = db.SanPham;
            var cthd = db.HoaDonChitiet;
            int i = 1;
            foreach (var item in sp.ToList())
            {
                var nhap = cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc != null);
                var xuat = cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc == null);
                int sumnhap = 0;
                int sumxuat = 0;
                if (nhap != null)
                    sumnhap = nhap.Sum(p => p.SoLuong);
                if (xuat != null) ;
                sumxuat = xuat.Sum(p => p.SoLuong);
                tonkhoxl tonKho = new tonkhoxl();
                tonKho.hinh = item.HinhSanpham;
                tonKho.ten = item.TenSanpham;
                tonKho.soluong = sumnhap - sumxuat;
                tonKho.STT = i;

                tonkhoxlist.Add(tonKho);
                i++;
>>>>>>> 8ea80d40b17f1638b2148bb17efcd140e825c3df
            }
            //
            //nhân viên
            void loadnhanvien()
            {
                var db = new qlbhContext();
                nhanvienlist = new ObservableCollection<nvxl>();
                cvlist = new ObservableCollection<QuyenHan>(db.QuyenHan);
                var nv = db.NhanVien;
                var qh = db.QuyenHan;

                foreach (var item in nv.ToList())
                {
                    var tencv = qh.Where(p => p.IdChucvu == item.IdChucvu).FirstOrDefault();
                    nvxl nvl = new nvxl();
                    nvl.Manv = item.IdNhanvien;
                    nvl.ten = item.TenNhanvien;
                    nvl.Pass = item.PassNhanvien;
                    nvl.ngaysinh = item.NgaySinh;
                    nvl.diachi = item.DiachiNhanvien;
                    nvl.chucvu = tencv.TenChucvu;
                    nvl.IdChucvu = item.IdChucvu;
                    nvl.sdt = item.Sdt;
                    nhanvienlist.Add(nvl);
                }
            }
            //
            void Thanhtoan(HoaDonWindow w)
            {
                HoaDonWindow window = new HoaDonWindow();
                window.ShowDialog();
            }
<<<<<<< HEAD
       
            //mã hóa base 64
          
        }
=======
            return hash.ToString();
        }
        void themsanpham(ThemSanPhamWindow k)
        {
                ThemSanPhamWindow window3 = new ThemSanPhamWindow();
                window3.ShowDialog();
        }

        void suasanpham(SuaSanPhamWindow l)
        {
                SuaSanPhamWindow window4 = new SuaSanPhamWindow();
                window4.ShowDialog();
        }     
>>>>>>> 8ea80d40b17f1638b2148bb17efcd140e825c3df
    }
}
