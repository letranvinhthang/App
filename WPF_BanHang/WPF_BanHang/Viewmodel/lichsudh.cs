using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WPF_BanHang.Models;
namespace WPF_BanHang.Viewmodel
{
   public class lichsudh : BaseViewModel
    {
        public ObservableCollection<hdxl> _hoadonlist;
        public ObservableCollection<hdxl> hoadonlist { get => _hoadonlist; set { _hoadonlist = value; OnPropertyChanged(); } }
        public ICommand loadcommannd { get; set; }
        public lichsudh()
        {
            loadcommannd = new RelayCommand<Object>((k) => { return true; }, (k) => {
                Loadhoadon();
            });
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
                hoadonxuly.MaHoadon = item.MaHoaDon;
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
                    hoadonxuly.TenChuongtrinh = "Khong";
                }
                else
                {
                    hoadonxuly.TenChuongtrinh = kmhd.TenChuongtrinh;
                }

                if (item.HuyHoaDon == true)
                {
                    hoadonxuly.trangthai = "HUY";
                }

                hoadonxuly.trangthai = "hoan thanh";

                hoadonlist.Add(hoadonxuly);
            }
            }
        }

}
