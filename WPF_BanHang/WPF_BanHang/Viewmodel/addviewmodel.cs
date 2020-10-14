using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{

    public class addviewmodel : BaseViewModel
    {
        public ICommand addcommand { get; set; }
        public ICommand exitcommand { get; set; }
        public ICommand PasswordChangedcommand { get; set; }

        public ObservableCollection<QuyenHan> _cvlist;

        public ObservableCollection<QuyenHan> cvlist { get => _cvlist; set { _cvlist = value; OnPropertyChanged(); } }
        public nvxl _SelectedItem;

        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private string _password;
        public string password { get => _password; set { _password = value; OnPropertyChanged(); } }
        private int _manv;

        public int manv { get => _manv; set { _manv = value; OnPropertyChanged(); } }
       
        private DateTime _ngaysinh;

        public DateTime ngaysinh { get => _ngaysinh; set { _ngaysinh = value; OnPropertyChanged(); } }
        private string _diachi;

        public string diachi { get => _diachi; set { _diachi = value; OnPropertyChanged(); } }
        private string _sdt;

        public string sdt { get => _sdt; set { _sdt = value; OnPropertyChanged(); } }
        private int _chuvuseleted;

        public int chuvuseleted { get => _chuvuseleted; set { _chuvuseleted = value; OnPropertyChanged(); } }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public addviewmodel()
        {
            // 
            string pass = "";
            var db = new qlbhContext();
            cvlist = new ObservableCollection<QuyenHan>(db.QuyenHan);
            PasswordChangedcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { password = p.Password; }); 
                addcommand = new RelayCommand<object>((p) =>
                    {
                        if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(password))
                            return false;
                        pass = MD5Hash(Base64Encode(password));
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
                            IdChucvu = chuvuseleted+1,
                            Sdt=sdt
                            
                        });
                        db.SaveChanges();
                        MessageBox.Show("them thanh cong");
                    });
                exitcommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
        }
        
    }

}