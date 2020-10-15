using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.ObjectModel;
using WPF_BanHang.Models;
using Google.Protobuf.WellKnownTypes;
using System.Linq;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;
using System.IO;


namespace WPF_BanHang.Viewmodel
{
    public class MainViewModel : BaseViewModel
    {
        //đổ dữ liệu bên tồn kho
        private ObservableCollection<tonkhoxl> _tonkhoxlist;
        public ObservableCollection<tonkhoxl> tonkhoxlist { get => _tonkhoxlist; set { _tonkhoxlist = value; OnPropertyChanged(); } }
        //đổ dữ liệu bên nhân viên
        public ObservableCollection<nvxl> _nhanvienlist;

        public ObservableCollection<nvxl> nhanvienlist { get => _nhanvienlist; set { _nhanvienlist = value; OnPropertyChanged(); } }
        //đổ dữ liệu qh vô combobox
        public ObservableCollection<QuyenHan> _cvlist;

        public ObservableCollection<QuyenHan> cvlist { get => _cvlist; set { _cvlist = value; OnPropertyChanged(); } }
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

        private string _password;

        public string password { get => _password; set { _password = value; OnPropertyChanged(); } }
        private string _sodt;

        public string sodt { get => _sodt; set { _sodt = value; OnPropertyChanged(); } }
        //bắt  command
        public ICommand loadedwindowcommand { get; set; }
        public ICommand unitcommand { get; set; }
        public ICommand thanhtoancommand { get; set; }
        public ICommand themnhanviencommand { get; set; }
        public ICommand suanhanviencommand { get; set; }
        public ICommand editcommand { get; set; }
        public ICommand PassChangedcommand { get; set; }
        public ICommand TextChangedcommand { get; set; }
        public bool isloaded = false;
        public ICommand themsanphamcommand { get; set; }
        public ICommand suasanphamcommand { get; set; }
        public ICommand exitcommand { get; set; }
        public ICommand disablecommand { get; set; }
        public ICommand enablecommand { get; set; }
        public ICommand closecommand { get; set; }
        public MainViewModel()
        {
            var db = new qlbhContext();
            closecommand= new RelayCommand<UserControl>((p) => { return true; }, (p) => 
            {
                FrameworkElement window =getwindowparent(p);
                var w = window as Window;
                if(w != null)
                {
                    var lg = new MainWindow();
                    w.Close();
                    lg.Show();
                }
            });
            FrameworkElement getwindowparent(UserControl p)
            {
                FrameworkElement parent = p;
                while(parent.Parent != null)
                {
                    parent = parent.Parent as FrameworkElement;

                }
                return parent;
            }
            themsanphamcommand = new RelayCommand<ThemSanPhamWindow>((k) => { return true; }, (k) => { themsanpham(k); });
            suasanphamcommand = new RelayCommand<SuaSanPhamWindow>((l) => { return true; }, (l) => { suasanpham(l); });
            suanhanviencommand = new RelayCommand<SuaNhanVienWindow>((c) => { 
               if( SelectedItem==null)
                {
                    return false;
                }
                return true; 
            }, (c) => { suanhanvien(c); });
            themnhanviencommand = new RelayCommand<ChinhSuaWindow>((a) => { return true; }, (a) => { themnhanvien(a); });
            thanhtoancommand = new RelayCommand<HoaDonWindow>((w) => { return true; }, (w) => { Thanhtoan(w); });
            disablecommand= new RelayCommand<object>((p) => {
                bool a = db.NhanVien.Where(p => p.IdNhanvien == SelectedItem.Manv).FirstOrDefault().Disable;
                if (a == true)
                    return false;
                return true;
            }, (p) =>
            {
                var dis = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                dis.Disable = true;
                db.SaveChanges();
                loadnhanvien();
            });
            enablecommand = new RelayCommand<object>((p) => {
                bool a = db.NhanVien.Where(p => p.IdNhanvien == SelectedItem.Manv).FirstOrDefault().Disable;
                if (a != true)
                    return false;
                return true;
            }, (p) =>
            {
                var dis = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                dis.Disable = false;
                db.SaveChanges();
                loadnhanvien();
            });
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
            PassChangedcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => {password = p.Password;});
            TextChangedcommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { sodt = p.Text; });
            editcommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(password))
                {
                    if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(sdt))
                        return false;
                    return true;
                }
                else
                {
                    if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(sdt))
                        return false;
                    pass = MD5Hash(Base64Encode(password));
                    return true;
                }
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
            }
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
        //mơ win thêmnv
        void themnhanvien(ChinhSuaWindow a)
        {
            ChinhSuaWindow window1 = new ChinhSuaWindow();
            window1.ShowDialog();
            loadnhanvien();
        }

        //mo win sua nv
        void suanhanvien(SuaNhanVienWindow c)
        {
            SuaNhanVienWindow window2 = new SuaNhanVienWindow();
            window2.ShowDialog();
        }
        //mã hóa base 64
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        //mã hóa md5
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
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
        
    }
}
