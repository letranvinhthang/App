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
using System.Diagnostics;

namespace WPF_BanHang.Viewmodel
{
    public class MainViewModel : BaseViewModel
    {
        //đổ dữ liệu bên tồn kho
        private ObservableCollection<tonkhoxl> _tonkhoxlist;
        public ObservableCollection<tonkhoxl> tonkhoxlist { get => _tonkhoxlist; set { _tonkhoxlist = value; OnPropertyChanged(); } }

        public ObservableCollection<nvxl> _nhanvienlist;

        public ObservableCollection<nvxl> nhanvienlist { get => _nhanvienlist; set { _nhanvienlist = value; OnPropertyChanged(); } }
        //đổ dữ liệu qh vô combobox
        public ObservableCollection<QuyenHan> _cvlist;

        public ObservableCollection<QuyenHan> cvlist { get => _cvlist; set { _cvlist = value; OnPropertyChanged(); } }

        //bắt  command
        public ICommand loadedwindowcommand { get; set; }
        public bool isloaded = false;
        public ICommand exitcommand { get; set; }
        public ICommand closecommand { get; set; }
        public MainViewModel()
        {
            var db = new qlbhContext();
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
                {
                    parent = parent.Parent as FrameworkElement;

                }
                return parent;
            }
            /*hanhtoancommand = new RelayCommand<HoaDonWindow>((w) => { return true; }, (w) => { Thanhtoan(w); });*/
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
       
            //mã hóa base 64
          
        }
    }
}
