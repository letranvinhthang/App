using System.Windows;
using System.Windows.Input;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.ObjectModel;
using WPF_BanHang.Models;
using Google.Protobuf.WellKnownTypes;
using System.Linq;
=======
>>>>>>> trung

namespace WPF_BanHang.Viewmodel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<tonkhoxl> _tonkhoxlist;
        public ObservableCollection<tonkhoxl> tonkhoxlist { get=> _tonkhoxlist; set { _tonkhoxlist = value;OnPropertyChanged(); } }
        //xử lý
        public ICommand loadedwindowcommand { get; set; }
        public ICommand unitcommand { get; set; }
        public bool isloaded = false;
        public MainViewModel()
        {
            loadedwindowcommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                isloaded = true;
                p.Hide();
                loginwindow login = new loginwindow();
                login.ShowDialog();
                if (login.DataContext == null)
                    return;
                var loginnVM = login.DataContext as LoginViewModel;
                if (loginnVM.IsLogin)
                {
                    p.Show();
                    loadtonkho();
                }
                else
                {
                    p.Close();
                }
            });
           /* unitcommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Unitwindow wd = new Unitwindow();
                wd.ShowDialog();
            });*/
        }
        void loadtonkho()
        {
            var db = new qlbhContext();
            tonkhoxlist = new ObservableCollection<tonkhoxl>();
            var tk = db.TonKho;
            var sp = db.SanPham;
            var cthd = db.HoaDonChitiet;
            int i = 1;
            foreach(var item in sp.ToList())
            {
               var nhap= cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc != null);
               var xuat = cthd.Where(p => p.IdSanpham == item.IdSanpham && p.IdNhacc == null);
                int sumnhap = 0;
                int sumxuat = 0;
                if (nhap != null)
                    sumnhap = nhap.Sum(p => p.SoLuong);
                if (xuat != null) ;
                sumxuat = xuat.Sum(p => p.SoLuong);
                tonkhoxl tonKho = new tonkhoxl();
                tonKho.STT = i;
                tonKho.ten = item.TenSanpham;
                tonKho.soluong =sumnhap - sumxuat;
                tonkhoxlist.Add(tonKho);
                i++;
            }
        }
    }
}
