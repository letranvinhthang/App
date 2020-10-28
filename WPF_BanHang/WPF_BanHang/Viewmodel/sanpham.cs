using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
                    dongia = SelectedItem.Gia;
                }
            }
        }
        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private byte[] _hinh;

        public byte[] hinh { get => _hinh; set { _hinh = value; OnPropertyChanged(); } }
        private long  _barcode;

        public long barcode { get => _barcode; set { _barcode = value; OnPropertyChanged(); } }
        private double _dongia;

        public double dongia { get => _dongia; set { _dongia = value; OnPropertyChanged(); } }

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
        public ICommand exitcommand { get; set; }
        public ICommand xoacommand { get; set; }
        public sanpham()
        {
            var db = new qlbhContext();
            xoacommand = new RelayCommand<object>((a) => { return true; }, (a) =>
            {
                var dis = db.SanPham.Where(x => x.IdSanpham == SelectedItem.IdSanpham).SingleOrDefault();
                dis.XoaSanPham = true;
                db.SaveChanges();
                MessageBox.Show("Xóa thành công!", "Thông báo");
                loadsanpham();

            });
                loadcomannd = new RelayCommand<Object>((k) => { return true; }, (k) => { loadsanpham(); });
            exitcommand = new RelayCommand<Window>((k) => { return true; }, (k) => { k.Close(); });
            themsanphamcommand = new RelayCommand<ThemSanPhamWindow>((k) => { return true; }, (k) => { themsanpham(k); });
            suasanphamcommand = new RelayCommand<Object>((l) => { 
                if(SelectedItem == null)
                {
                    return false;
                }
                return true; }, (l) => { suasanpham(); });
            editcommand = new RelayCommand<object>((p) =>
            {
                
                    return true;
            },
                    (p) =>
                    {
                    if (string.IsNullOrEmpty(ten) || barcode == null || dongia == null)
                        {
                            MessageBox.Show("vui long nhap day du thong tin");
                        }
                        else
                        {
                            int? idch = MainViewModel.TaiKhoan.Idcuahang;
                            var giasp = db.CuahangSanpham.Where(x => x.IdSanpham == SelectedItem.IdSanpham && x.IdCuahang == idch).SingleOrDefault();
                            var editsp = db.SanPham.Where(x => x.IdSanpham == SelectedItem.IdSanpham).SingleOrDefault();
                            editsp.TenSanpham = ten;
                            editsp.IdSanpham = barcode;
                            editsp.IdLoaisp = loaispseleted +1;
                            editsp.SanphamHot = sphot;
                            editsp.SanphamMoi = spmoi;
                            giasp.GiaTheoQuan = dongia;
                            db.SaveChanges();
                            MessageBox.Show("sua thanh cong");
                        }
                    });
        }

        void themsanpham(ThemSanPhamWindow k)
        {
            ThemSanPhamWindow window3 = new ThemSanPhamWindow();
            window3.ShowDialog();
            loadsanpham();
        }

        void suasanpham()
        {
            SuaSanPhamWindow window4 = new SuaSanPhamWindow();
            window4.ShowDialog();
            loadsanpham();
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
                foreach (var item in sp.Where(p => p.XoaSanPham == false).ToList())
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


           