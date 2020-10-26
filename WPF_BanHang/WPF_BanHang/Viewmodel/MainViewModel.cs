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
        private NhanVien _TaiKhoanHienThi;
        public NhanVien TaiKhoanHienThi { get => _TaiKhoanHienThi; set { _TaiKhoanHienThi = value; OnPropertyChanged(); } }
        public enum QuyenTaiKhoan
        {
            Quanly, NhanVien
        };
        private int _QuyenTK;
        public int QuyenTK { get => _QuyenTK; set { _QuyenTK = value; OnPropertyChanged(); } }
        private int? _cuahang;
        public int? cuahang { get => _cuahang; set { _cuahang = value; OnPropertyChanged(); } }
        static public NhanVien TaiKhoan { get; set; }
        private int _ChucNang;
        public int ChucNang { get => _ChucNang; set { _ChucNang = value; OnPropertyChanged(); } }

        static public nhanvien Nhanvien { get; set; }

        #region Items Source
        //đổ dữ liệu bên tồn kho
        private ObservableCollection<tonkhoxl> _tonkhoxlist;
        public ObservableCollection<tonkhoxl> tonkhoxlist { get => _tonkhoxlist; set { _tonkhoxlist = value; OnPropertyChanged(); } }
        //xử lý order
        private ObservableCollection<tonkhoxl> _orderlist;
        public ObservableCollection<tonkhoxl> orderlist { get => _orderlist; set { _orderlist = value; OnPropertyChanged(); } }
        //xử lý bên nhân viên
        public ObservableCollection<nvxl> _nhanvienlist;
        public ObservableCollection<nvxl> nhanvienlist { get => _nhanvienlist; set { _nhanvienlist = value; OnPropertyChanged(); } }
        public ObservableCollection<QuyenHan> _cvlist;
        public ObservableCollection<QuyenHan> cvlist { get => _cvlist; set { _cvlist = value; OnPropertyChanged(); } }


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

        private string _hinh;

        public string hinh { get => _hinh; set { _hinh = value; OnPropertyChanged(); } }
        #endregion

        //bắt  command
        #region Command ẩn hiện grid
        public ICommand loadedwindowcommand { get; set; }

        public ICommand themsanphamcommand { get; set; }
        public ICommand suasanphamcommand { get; set; }
        public ICommand BtnNhanVienCommand { get; set; }
        public ICommand BtnOrderCommand { get; set; }
        #region Set quyền command
        public ICommand SetupQuyenCommand { get; set; }
        #endregion
        public ICommand BtnThongKeCommand { get; set; }
        public ICommand BtnNhapKhoCommand { get; set; }
        public ICommand exitcommand { get; set; }
        public ICommand closecommand { get; set; }
        public ICommand xoacommand { get; set; }
        public ICommand dmkcommand { get; set; }

        #endregion

        public MainViewModel()
        {
            var db = new qlbhContext();
            SetupQuyenCommand = new RelayCommand<Grid>((p) =>
            {
                return true;
            }, (p) =>
            {
                SetupQuyenTaiKhoan();
            });
         
            closecommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn đăng xuất khỏi hệ thống không?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    p.Hide();
                    loginwindow loginWindow = new loginwindow();
                    loginWindow.ShowDialog();
                    p.Close();
                }

            });

            BtnNhanVienCommand = new RelayCommand<Grid>((p) => 
            { 
             if (QuyenTK == (int)QuyenTaiKhoan.NhanVien)
            {
                MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
                return true;
            }, 
            (p) =>
            {
                ChucNang = (int)ChucNangQL.NhanVien;
            });
            BtnOrderCommand = new RelayCommand<Grid>((p) =>
            { return true; }, (p) =>
            {
                ChucNang = (int)ChucNangQL.Order;
            });
            BtnNhapKhoCommand = new RelayCommand<Grid>((p) =>
            {
                if (QuyenTK == (int)QuyenTaiKhoan.NhanVien)
                {
                    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true; }, (p) =>
            {
                ChucNang = (int)ChucNangQL.NhapKho;
            });
            BtnThongKeCommand = new RelayCommand<Grid>((p) =>
            {
                if (QuyenTK == (int)QuyenTaiKhoan.NhanVien)
                {
                    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true; }, (p) =>
            {
                ChucNang = (int)ChucNangQL.ThongKe;
            });
            themsanphamcommand = new RelayCommand<ThemSanPhamWindow>((k) => { return true; }, (k) => { themsanpham(k); });
            suasanphamcommand = new RelayCommand<SuaSanPhamWindow>((l) => { return true; }, (l) => { suasanpham(l); });               
            themsanphamcommand = new RelayCommand<ThemSanPhamWindow>((k) => { return true; }, (k) => { themsanpham(k); });
            suasanphamcommand = new RelayCommand<SuaSanPhamWindow>((l) => { return true; }, (l) => { suasanpham(l); });
            dmkcommand = new RelayCommand<Window>((l) => { return true; }, (l) => { doimatkhau(l); });
            exitcommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });         
            //xử lý sửa thông tin


            //thống kê
            void loadsappham()
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
                    if (xuat != null)
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
                    if (xuat != null)
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

                foreach (var item in nv.Where(p => p.Idcuahang == TaiKhoan.Idcuahang).ToList())
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
            void doimatkhau(Window l)
            {
                DoiMatKhauWindow window4 = new DoiMatKhauWindow();
                window4.ShowDialog();
            }
        }
        public void SetupQuyenTaiKhoan()
        {
            if (TaiKhoan.IdChucvu == 2)
            {
                QuyenTK = (int)QuyenTaiKhoan.Quanly;
            }
            else if (TaiKhoan.IdChucvu == 3)
            {
                QuyenTK = (int)QuyenTaiKhoan.NhanVien;
            }
            cuahang = TaiKhoan.Idcuahang;
        }
    }
}
