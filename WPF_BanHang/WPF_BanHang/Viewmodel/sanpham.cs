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

        public ObservableCollection<QuyenHan> _lsplist;

        public ObservableCollection<QuyenHan> lsplist { get => _lsplist; set { _lsplist = value; OnPropertyChanged(); } }
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
        public ICommand themsanphamcommand { get; set; }
        public ICommand suasanphamcommand { get; set; }
        public ICommand PassChangedcommand { get; set; }
        public ICommand TextChangedcommand { get; set; }
        public ICommand editcommand { get; set; }

        public sanpham()
        {
            var db = new qlbhContext();
            themsanphamcommand = new RelayCommand<ThemSanPhamWindow>((k) => { return true; }, (k) => { themsanpham(k); });
            suasanphamcommand = new RelayCommand<SuaSanPhamWindow>((l) => { return true; }, (l) => { suasanpham(l); });
            PassChangedcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { password = p.Password; });
            TextChangedcommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { sodt = p.Text; });
            editcommand = new RelayCommand<object>((p) =>
            { return true;},
                    (p) =>
                    {
                        if (string.IsNullOrEmpty(password))
                        {
                           /* var editnp = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                            editnp.TenNhanvien = ten;
                            editnp.Sdt = sdt;
                            editnp.DiachiNhanvien = diachi;
                            editnp.IdChucvu = chuvuseleted + 1;
                            db.SaveChanges();
                            MessageBox.Show("sua thanh cong");
                            SelectedItem.ten = ten;
                            SelectedItem.sdt = sdt;
                            SelectedItem.diachi = diachi;
                            SelectedItem.IdChucvu = chuvuseleted + 1;*/
                        }
                        else
                        {
                           /* var edit = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
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
                            SelectedItem.IdChucvu = chuvuseleted + 1;*/
                  
                        }
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


    }
}


           