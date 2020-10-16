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
        private int? _username;
        public int? usename { get => _username; set { _username= value;OnPropertyChanged(); } }
        private string _password;
        public string password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public LoginViewModel()
        {
            usename = null;
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
            if(usename != null && password != null)                 
            {
                int? id = usename;
                string pass = MD5Hash(Base64Encode(password));
                var tk = db.NhanVien.Where(x => x.IdNhanvien == id && x.PassNhanvien == pass);
                var account = tk.Count();
                if (account > 0)
                {
                    if (tk.FirstOrDefault().Disable == true)
                    {
                        MessageBox.Show("tài khoản đã bị vô hiệu");
                    }
                    else
                    {
                        IsLogin = true;
                        p.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Sai thông tin!", "Thông báo");                   
                }
                
            }
            else
            {
                MessageBox.Show("nhập đủ thông tin !", "Thông báo");
            }
        }

        void exit(Window e)
        {
            e.Close();
            IsLogin = false;
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
