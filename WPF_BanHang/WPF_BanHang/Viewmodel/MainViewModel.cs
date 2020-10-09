using System.Windows;
using System.Windows.Input;

namespace WPF_BanHang.Viewmodel
{
    public class MainViewModel : BaseViewModel
    {
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
    }
}
