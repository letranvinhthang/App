using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WPF_BanHang.Models;

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
            dongho1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int index = Int32.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(49 + (140 * index), 40, 0, 0);

            
        }

    }
}
