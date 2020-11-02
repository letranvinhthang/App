using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WPF_BanHang.Models;
namespace WPF_BanHang.Viewmodel
{
    public class lichsudh : BaseViewModel
    {
        public ObservableCollection<hdxl> _hoadonlist;
        public ObservableCollection<hdxl> hoadonlist { get => _hoadonlist; set { _hoadonlist = value; OnPropertyChanged(); } }
        public ObservableCollection<cthdxl> _cthdxlist;
        public ObservableCollection<cthdxl> cthdxlist { get => _cthdxlist;  set { _cthdxlist = value; OnPropertyChanged(); } }
        public hdxl _SelectedItem;
        public hdxl SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    idhoadon = SelectedItem.IdHoadon;
                    mahoadon = SelectedItem.MaHoadon;
                    tenkh = SelectedItem.bennhan;
                    ngaytao = SelectedItem.NgayTao;
                    ten = SelectedItem.TenNhanvien;
                    tongtien = SelectedItem.ThanhTien;
                }
            }
        }
        private int _idhoadon;
        public int idhoadon { get => _idhoadon; set { _idhoadon = value; OnPropertyChanged(); } }

        private long _mahoadon;
        public long mahoadon { get => _mahoadon; set { _mahoadon = value; OnPropertyChanged(); } }
        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private string _tenkh;

        public string tenkh { get => _tenkh; set { _tenkh = value; OnPropertyChanged(); } }
        private DateTime _ngaytao;

        public DateTime ngaytao { get => _ngaytao; set { _ngaytao = value; OnPropertyChanged(); } }
        private double _tongtien;

        public double tongtien { get => _tongtien; set { _tongtien = value; OnPropertyChanged(); } }

        public ICommand loadcommannd { get; set; }
        public ICommand loadcscommannd { get; set; }
        public ICommand xemhdcommand { get; set; }
        public ICommand exitcommand { get; set; }
        public lichsudh()
        {
            loadcommannd = new RelayCommand<Object>((k) => { return true; }, (k) => {
                Loadhoadon();
            });
            xemhdcommand = new RelayCommand<Object>((k) => {
                if (SelectedItem == null)
                    return false;
                return true; }, (k) => {
                cshd();
            });
            exitcommand = new RelayCommand<Window>((k) => { return true; }, (k) => {
                exithoadon(k);
            });
        }
        void exithoadon(Window k)
        {
            k.Close();
        }
        void cshd()
        {
            cthdxlist= new ObservableCollection<cthdxl>();

            var db = new qlbhContext();
            var hdct = db.HoaDonChitiet;
            var ncc = db.NhaCungcap;
            var sp = db.SanPham;
            var chsp = db.CuahangSanpham;
            var ch = db.CuaHang;
            int? idch = MainViewModel.TaiKhoan.Idcuahang;
     
                //MessageBox.Show("nuull" + SelectedItem.IdHoadon ) ;
            foreach (var item in hdct.Where(p => p.IdHoadon == SelectedItem.IdHoadon).ToList())
            {
                cthdxl hoadonxulys = new cthdxl();
                var tensp = sp.Where(p => p.IdSanpham == item.IdSanpham).FirstOrDefault();
                var gia = chsp.Where(p => p.IdSanpham == item.IdSanpham && p.IdCuahang == idch).FirstOrDefault();
                //var tench= ch.Where(p=> p.IdCuahang)
                hoadonxulys.TenSanpham = tensp.TenSanpham;
                hoadonxulys.soluong = item.SoLuong;
                hoadonxulys.GiaTheoQuan = gia.GiaTheoQuan;
                hoadonxulys.ThanhTien = item.SoLuong * gia.GiaTheoQuan;
                cthdxlist.Add(hoadonxulys);
            }

            HoaDonWindow window = new HoaDonWindow();
            window.ShowDialog();
        }
        void Loadhoadon()
        {
            var db = new qlbhContext();
            hoadonlist = new ObservableCollection<hdxl>();
            var hd = db.HoaDon;
            var kh = db.KhachHang;
            var ncc = db.NhaCungcap;
            var nv = db.NhanVien;
            var qc = db.QuangCao;
            int? idch = MainViewModel.TaiKhoan.Idcuahang;
            foreach (var item in hd.Where(p => p.IdCuahang == idch).ToList())
            {
                var bennhan = "";
                var nvhd = nv.Where(p => p.IdNhanvien == item.IdNhanvien).FirstOrDefault();
                var kmhd = qc.Where(p => p.IdChuongtrinh == item.IdChuongtrinh).FirstOrDefault();
                var khhd = kh.Where(p => p.IdKhachhang == item.IdKhachhang).FirstOrDefault();
                var ncchd = ncc.Where(p => p.IdNhacc == item.IdNhacc).FirstOrDefault();
                hdxl hoadonxuly = new hdxl();

                hoadonxuly.IdHoadon = item.IdHoadon;
                hoadonxuly.MaHoadon = item.MaHoadon;

                hoadonxuly.NgayTao = item.NgayTao;
               hoadonxuly.ThanhTien = item.ThanhTien;
                hoadonxuly.TenNhanvien = nvhd.TenNhanvien;
                if (item.IdKhachhang == null)
                {
                    hoadonxuly.bennhan = ncchd.TenNhacc;
                }
                else
                {
                    hoadonxuly.bennhan = khhd.TenKhachhang;
                }
                if (item.IdChuongtrinh == null)
                {
                    hoadonxuly.TenChuongtrinh = "Không";
                }
                else
                {
                    hoadonxuly.TenChuongtrinh = kmhd.TenChuongtrinh;
                }

                if (item.HuyHoaDon == true)
                {
                    hoadonxuly.trangthai = "Hủy";
                }

                hoadonxuly.trangthai = "Hoàn thành";

                hoadonlist.Add(hoadonxuly);
            }
            }
        }

}
