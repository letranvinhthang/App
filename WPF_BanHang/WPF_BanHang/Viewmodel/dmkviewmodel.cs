using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;
using WPF_BanHang.Viewmodel;

namespace WPF_BanHang.Viewmodel
{
   public class dmkviewmodel : BaseViewModel
    {
              private string _passwordcu;
        public string passwordcu { get => _passwordcu; set { _passwordcu = value; OnPropertyChanged(); } }
        private string _passwordmoi;
        public string passwordmoi { get => _passwordmoi; set { _passwordmoi = value; OnPropertyChanged(); } }
        private string _passwordmoilai;
        public string passwordmoilai { get => _passwordmoilai; set { _passwordmoilai = value; OnPropertyChanged(); } }
        public ICommand PasswordoldChangedcommand { get; set; }
        public ICommand PasswordmoiChangedcommand { get; set; }
        public ICommand PasswordmoilaiChangedcommand { get; set; }
        public ICommand domkcommand { get; set; }
        public ICommand exitcommand { get; set; }
        public dmkviewmodel()
        {
       
            PasswordoldChangedcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { passwordcu = p.Password; });
            PasswordmoiChangedcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { passwordmoi = p.Password; });
            PasswordmoilaiChangedcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { passwordmoilai = p.Password; });
            domkcommand = new RelayCommand<Window>((p) => { return true; }, (p) => { doimatkhau(p);  });
            exitcommand = new RelayCommand<Window>((e) => { return true; }, (e) => { exit(e); });



        }
        void doimatkhau(Window p)
        {
            var db = new qlbhContext();
            if (passwordmoi != null && passwordcu != null && passwordmoilai != null)
            {
                string passcu = MD5Hash(Base64Encode(passwordcu));
                string passmoi = MD5Hash(Base64Encode(passwordmoi));
                string passlai = MD5Hash(Base64Encode(passwordmoilai));
                var nv = db.NhanVien;

                if (MainViewModel.TaiKhoan != null)
                {
                    int? idnv = MainViewModel.TaiKhoan.IdNhanvien;
                    var item = nv.Where(p => p.IdNhanvien == idnv).FirstOrDefault();
                    if (item.PassNhanvien == passcu)
                    {
                        if (passmoi == passlai)
                        {
                            item.PassNhanvien = passmoi;
                            db.SaveChanges();
                
                            p.Close();
                            MessageBox.Show("doi mat khau thanh cong");
                        }
                        else
                        {
                            MessageBox.Show("mat khau nhap lai khong dung");
                        }
                    }
                    else
                    {
                        MessageBox.Show("mat khau khong dung");
                    }

                }
            }
            else
            {
                MessageBox.Show("vui long nap day du cac cot");
            }
        }
        void exit(Window e)
        {
            e.Close();
        }
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
    }
}
