using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    public class sanpham : BaseViewModel
    {

        public ObservableCollection<DanhmucSanpham> _lsplist;

        public ObservableCollection<DanhmucSanpham> lsplist { get => _lsplist; set { _lsplist = value; OnPropertyChanged(); } }
        public ObservableCollection<spxl> _sanphamlist;
        public ObservableCollection<spxl> sanphamlist { get => _sanphamlist; set { _sanphamlist = value; OnPropertyChanged(); } }
        public spxl _SelectedItem;
        public spxl SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    ten = SelectedItem.TenSanpham;
                    barcode = SelectedItem.IdSanpham;
                    loaispseleted = SelectedItem.IdLoaisp - 1;
                    sphot = SelectedItem.SanphamHot;
                    spmoi = SelectedItem.SanphamMoi;
                }
            }
        }
        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private byte[] _hinh;

        public byte[] hinh { get => _hinh; set { _hinh = value; OnPropertyChanged(); } }
        private long  _barcode;

        public long barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }
        private int _soluong;

        public int soluong { get => _soluong; set { _soluong = value; OnPropertyChanged(); } }
        private int _gia;

        public int gia { get => _gia; set { _gia = value; OnPropertyChanged(); } }


        private bool _spmoi;

        public bool spmoi { get => _spmoi; set { _spmoi = value; OnPropertyChanged(); } }
        private int _loaispseleted;

        public int loaispseleted { get => _loaispseleted; set { _loaispseleted = value; OnPropertyChanged(); } }
        private bool _sphot;

        public bool sphot { get => _sphot; set { _sphot = value; OnPropertyChanged(); } }



        public ICommand themsanphamcommand { get; set; }
        public ICommand suasanphamcommand { get; set; }
        public ICommand loadcomannd { get; set; }
        public ICommand editcommand { get; set; }

        public sanpham()
        {
            var db = new qlbhContext();
            loadcomannd = new RelayCommand<Object>((k) => { return true; }, (k) => { loadsanpham(); });
            themsanphamcommand = new RelayCommand<ThemSanPhamWindow>((k) => { return true; }, (k) => { themsanpham(k); });
            suasanphamcommand = new RelayCommand<SuaSanPhamWindow>((l) => { return true; }, (l) => { suasanpham(l); });
            editcommand = new RelayCommand<object>((p) =>
            {
                
                    return true;
            },
                    (p) =>
                    {
          /*              if (string.IsNullOrEmpty(password))
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
                        }*/
                    });
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
        void loadsanpham()
        {
            var db = new qlbhContext();
            sanphamlist = new ObservableCollection<spxl>();
            lsplist = new ObservableCollection<DanhmucSanpham>(db.DanhmucSanpham);
            var sp = db.SanPham;
            var lsp = db.DanhmucSanpham;

            if (MainViewModel.TaiKhoan != null)
            {
                int? idch = MainViewModel.TaiKhoan.Idcuahang;
                var spch = db.CuahangSanpham.Where(p => p.IdCuahang == idch);
                foreach (var item in sp.ToList())
                {
                    var chsp = spch.Where(p => p.IdSanpham == item.IdSanpham).FirstOrDefault();
                    var loaisp = lsp.Where(p => p.IdLoaisp == item.IdLoaisp).FirstOrDefault();
                    spxl spl= new spxl();
                   // spl.HinhSanpham = item.HinhSanpham;
                    spl.IdSanpham = item.IdSanpham;
                    spl.TenSanpham = item.TenSanpham;
                    spl.Loaisp = loaisp.TenLoai;
                    spl.SanphamHot = item.SanphamHot;
                    spl.SanphamMoi = item.SanphamMoi;
                    spl.IdLoaisp = item.IdLoaisp;
                    spl.Gia = chsp.GiaTheoQuan;
                    sanphamlist.Add(spl);
                }

            }
            else
            {
                return;
            }
        }
    }
}


           