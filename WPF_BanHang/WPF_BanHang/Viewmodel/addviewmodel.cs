using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{

    public class addviewmodel : BaseViewModel
    {
        public ICommand addcommand { get; set; }
        public ICommand exitcommand { get; set; }

        public ObservableCollection<QuyenHan> _cvlist;

        public ObservableCollection<QuyenHan> cvlist { get => _cvlist; set { _cvlist = value; OnPropertyChanged(); } }
        public nvxl _SelectedItem;

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
        private int _chuvuseleted;

        public int chuvuseleted { get => _chuvuseleted; set { _chuvuseleted = value; OnPropertyChanged(); } }
        public addviewmodel()
        {
            var db = new qlbhContext();
            addcommand = new RelayCommand<object>((p) =>
                {
                    if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(diachi) || chuvuseleted == null)
                        return false;
                    var ktnv = db.NhanVien.Where(x => x.IdNhanvien == manv);
                    if (ktnv.Count() != 0)
                        return false;

                    return true;
                },
                (p) =>
                {
                    db.NhanVien.Add(new NhanVien
                    {
                        TenNhanvien = ten,
                        PassNhanvien = pass,
                        DiachiNhanvien = diachi,
                        NgaySinh = DateTime.Now,
                        IdChucvu=chuvuseleted
                    });
                    db.SaveChanges();
                    MessageBox.Show("them thanh cong");
                });
            exitcommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
        }
    }

}