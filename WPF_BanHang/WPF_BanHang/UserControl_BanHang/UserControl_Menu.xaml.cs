using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_BanHang.UserControl_BanHang
{
    /// <summary>
    /// Interaction logic for UserControl_Menu.xaml
    /// </summary>
    public partial class UserControl_Menu : UserControl
    {
        public UserControl_Menu()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int index = Int32.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index),0,0,0);

            switch (index)
            {
                case 0:
                    GridMain.Background = Brushes.AliceBlue;
                    break;
                case 1:
                    GridMain.Background = Brushes.Black;
                    break;
                case 2:
                    GridMain.Background = Brushes.Chocolate;
                    break;
                case 3:
                    GridMain.Background = Brushes.DarkBlue;
                    break;
            }
        }
    }
}
