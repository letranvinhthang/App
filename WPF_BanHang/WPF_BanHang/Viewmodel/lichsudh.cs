using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
                    tenkhachhang = SelectedItem.bennhan;
                    ngaytao = SelectedItem.NgayTao;
                    tennhanvien = SelectedItem.TenNhanvien;
                    tongtien = SelectedItem.ThanhTien;
                }
            }
        }
        private int _idhoadon;
        public int idhoadon { get => _idhoadon; set { _idhoadon = value; OnPropertyChanged(); } }

        private long _mahoadon;
        public long mahoadon { get => _mahoadon; set { _mahoadon = value; OnPropertyChanged(); } }
       
        private string _tennhanvien;
        public string tennhanvien { get => _tennhanvien; set { _tennhanvien = value; OnPropertyChanged(); } }

        private string _tenkhachhang;
        public string tenkhachhang { get => _tenkhachhang; set { _tenkhachhang = value; OnPropertyChanged(); } }
        
        private DateTime _ngaytao;
        public DateTime ngaytao { get => _ngaytao; set { _ngaytao = value; OnPropertyChanged(); } }

        private double _tongtien;
        public double tongtien { get => _tongtien; set { _tongtien = value; OnPropertyChanged(); } }

        private string _thongtintimkiem;
        public string thongtintimkiem { get => _thongtintimkiem; set { _thongtintimkiem = value; OnPropertyChanged(); } }

        private string _diachiacuahang;
        public string diachicuahang { get => _diachiacuahang; set { _diachiacuahang = value; OnPropertyChanged(); } }


        private ObservableCollection<hdxl> _ketuqatimkiem;
        public ObservableCollection<hdxl> ketquatimkiem { get => _ketuqatimkiem; set { _ketuqatimkiem = value; OnPropertyChanged(); } }

        public ICommand IDhoadonchangedcommand { get; set; }
        public ICommand loadcommannd { get; set; }
        public ICommand loadcscommannd { get; set; }
        public ICommand xemhdcommand { get; set; }
        public ICommand exitcommand { get; set; }

        
        public lichsudh()
        {
            var db = new qlbhContext();
            ketquatimkiem = new ObservableCollection<hdxl>();
            IDhoadonchangedcommand = new RelayCommand<TextBox>((p) => { return p == null ? false : true; }, (p) =>
            {
                try
                {
                    if (p.Text != null)
                    {
                        thongtintimkiem = p.Text;
                        if (MainViewModel.TaiKhoan != null)
                        {
                            hdxl list = new hdxl();
                            //var ketqua = from a in db.HoaDon where a.IdHoadon=int.Parse(thongtintimkiem)

                            ketquatimkiem.Remove(list);
                            ketquatimkiem.Add(ketqua);
                        }
                    }
                    else
                    {
                        Loadhoadon();
                    }
                }
                catch
                {

                }
            });

            loadcommannd = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
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
            int? idch = MainViewModel.TaiKhoan.Idcuahang;
     
                //MessageBox.Show("nuull" + SelectedItem.IdHoadon ) ;
            foreach (var item in hdct.Where(p => p.IdHoadon == SelectedItem.IdHoadon).ToList())
            {
                cthdxl hoadonxulys = new cthdxl();
                var tensp = sp.Where(p => p.IdSanpham == item.IdSanpham).FirstOrDefault();
                var gia = chsp.Where(p => p.IdSanpham == item.IdSanpham && p.IdCuahang == idch).FirstOrDefault();
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
            ketquatimkiem = new ObservableCollection<hdxl>();
            var hd = db.HoaDon;
            var kh = db.KhachHang;
            var ncc = db.NhaCungcap;
            var nv = db.NhanVien;
            var qc = db.QuangCao;
            int? idch = MainViewModel.TaiKhoan.Idcuahang;
            diachicuahang = db.CuaHang.Where(p => p.IdCuahang == idch).FirstOrDefault().DiachiCuahang;
            foreach (var item in hd.Where(p => p.IdCuahang == idch).ToList())
            {
                var bennhan = "";
                var nvhd = nv.Where(p => p.IdNhanvien == item.IdNhanvien).FirstOrDefault();
                var kmhd = qc.Where(p => p.IdChuongtrinh == item.IdChuongtrinh).FirstOrDefault();
                var khhd = kh.Where(p => p.IdKhachhang == item.IdKhachhang).FirstOrDefault();
                var ncchd = ncc.Where(p => p.IdNhacc == item.IdNhacc).FirstOrDefault();
                hdxl list = new hdxl();

                list.IdHoadon = item.IdHoadon;
                list.MaHoadon = item.MaHoadon;

                list.NgayTao = item.NgayTao;
                list.ThanhTien = item.ThanhTien;
                list.TenNhanvien = nvhd.TenNhanvien;
                if (item.IdKhachhang == null)
                {
                    list.bennhan = ncchd.TenNhacc;
                }
                else
                {
                    list.bennhan = khhd.TenKhachhang;
                }
                if (item.IdChuongtrinh == null)
                {
                    list.TenChuongtrinh = "Không";
                }
                else
                {
                    list.TenChuongtrinh = kmhd.TenChuongtrinh;
                }

                if (item.HuyHoaDon == true)
                {
                    list.trangthai = "Hủy";
                }

                list.trangthai = "Hoàn thành";

                ketquatimkiem.Add(list);
            }
        }


    }

}
