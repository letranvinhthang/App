using System;
using System.Windows;
using System.Windows.Threading;

namespace WPF_BanHang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Startlock();
        }

        private void Startlock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            dongho1.Text = DateTime.Now.ToString();
            dongho2.Text = DateTime.Now.ToString();
            dongho3.Text = DateTime.Now.ToString();
            dongho4.Text = DateTime.Now.ToString();
        }
    }
}
