using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.ObjectModel;
using WPF_BanHang.Models;
using Google.Protobuf.WellKnownTypes;
using System.Linq;
<<<<<<< HEAD
using System;
=======
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using MaterialDesignThemes.Wpf;
>>>>>>> 55fcaaa45584a97422351625c42891981c537179

namespace WPF_BanHang.Viewmodel
{
    public class MainViewModel : BaseViewModel
    {
        //xử lý bên tồn kho
        private ObservableCollection<tonkhoxl> _tonkhoxlist;
        public ObservableCollection<tonkhoxl> tonkhoxlist { get=> _tonkhoxlist; set { _tonkhoxlist = value;OnPropertyChanged(); } }
       //xử lý bên nhân viên
        public ObservableCollection<nvxl> _nhanvienlist;

        public ObservableCollection<nvxl> nhanvienlist { get => _nhanvienlist;set { _nhanvienlist = value; OnPropertyChanged(); } }
        public ObservableCollection<QuyenHan> _cvlist;

        public ObservableCollection<QuyenHan> cvlist { get => _cvlist; set { _cvlist = value; OnPropertyChanged(); } }
        public nvxl _SelectedItem;

        public nvxl SelectedItem 
        { 
            get => _SelectedItem; 
            set
            {
                _SelectedItem = value; OnPropertyChanged(); 
                if(SelectedItem!=null)
                {
                    ten = SelectedItem.ten;
                    pass = SelectedItem.Pass;
                    ngaysinh = SelectedItem.ngaysinh;
                    diachi = SelectedItem.diachi;
                    chuvuseleted = SelectedItem.chucvu;
                    manv = SelectedItem.Manv;
                }    
            }
        }
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
        private string _chuvuseleted;

        public string chuvuseleted { get => _chuvuseleted; set { _chuvuseleted = value; OnPropertyChanged(); } }

        public ICommand loadedwindowcommand { get; set; }
<<<<<<< HEAD
        public bool isloaded = false;
        public MainViewModel()
        {
            var db = new qlbhContext();
=======
        public ICommand unitcommand { get; set; }
        public ICommand thanhtoancommand { get; set; }
        public ICommand themnhanviencommand { get; set; }
        public bool isloaded = false;
        public MainViewModel()
        {
            themnhanviencommand = new RelayCommand<ChinhSuaWindow>((a) => { return true; }, (a) => { themnhanvien(a); });
            thanhtoancommand = new RelayCommand<HoaDonWindow>((w) => { return true; }, (w) => { Thanhtoan(w); });
>>>>>>> 55fcaaa45584a97422351625c42891981c537179
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
          
        }

        void loadtonkho()
        {
            var db = new qlbhContext();
            tonkhoxlist = new ObservableCollection<tonkhoxl>();
            var tk = db.TonKho;
            var sp = db.SanPham;
            var cthd = db.HoaDonChitiet;
            int i = 1;
            foreach(var item in sp.ToList())
            {
               var nhap= cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc != null);
               var xuat = cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc == null);
                int sumnhap = 0;
                int sumxuat = 0;
                if (nhap != null)
                    sumnhap = nhap.Sum(p => p.SoLuong);
                if (xuat != null) ;
                sumxuat = xuat.Sum(p => p.SoLuong);
                tonkhoxl tonKho = new tonkhoxl();
                tonKho.barcode = item.IdSanpham;
                tonKho.ten = item.TenSanpham;
                tonKho.soluong =sumnhap - sumxuat;
                tonKho.STT = i;
                tonkhoxlist.Add(tonKho);
                i++;
            }
        }
  
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
                nhanvienlist.Add(nvl);
            }
        }
        void Thanhtoan(HoaDonWindow w)
        {
            HoaDonWindow window = new HoaDonWindow();
            window.ShowDialog();
        }
        void themnhanvien(ChinhSuaWindow a)
        {
            ChinhSuaWindow window1 = new ChinhSuaWindow();
            window1.ShowDialog();
        }
    }
}
