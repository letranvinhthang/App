using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{

    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public ICommand logincommand { get; set; }
        public ICommand exitcommand { get; set; }
        public ICommand PasswordChangedcommand { get; set; }
        //public ICommand unitcommand { get; set; }
        private string _username;
        public string usename { get => _username; set { _username= value;OnPropertyChanged(); } }
        private string _password;
        public string password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public LoginViewModel()
        {
            //usename = "";
            password = "";
            IsLogin = false;
            logincommand = new RelayCommand<Window>((p) => { return true; }, (p) => { login(p); });
            PasswordChangedcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { password = p.Password; });
            exitcommand = new RelayCommand<Window>((e) => { return true; }, (e) => { exit(e); });

        }
        void login(Window p)
        {
            var db = new qlbhContext();
            if (p == null)
                return;
            if (usename == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            else 
            {
                int id = Int32.Parse(usename);
                string pass = MD5Hash(Base64Encode(password));
                var account = db.NhanVien.Where(x => x.IdNhanvien == id && x.PassNhanvien == pass).Count();
                if (account > 0)
                {
                    IsLogin = true;
                    p.Close();
                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("sai tài khoản mật khẩu");
                }
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
