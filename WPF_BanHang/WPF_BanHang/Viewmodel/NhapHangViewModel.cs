using System;
using System.Collections.Generic;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Input;
using WPF_BanHang.Models;

namespace WPF_BanHang.Viewmodel
{
    class NhapHangViewModel :BaseViewModel
    {
        public enum ChucNangQL
        {
            Pepsico, CocaCola, InterFood, RedBull, TanHiepPhat, UniversaUniversalRobina, KinhDo
        };

        private int _ChucNangNhapHang;
        public int ChucNangNhapHang { get => _ChucNangNhapHang; set { _ChucNangNhapHang = value; OnPropertyChanged(); } }

        public ICommand BtnBtnPepsicoCommand { get; set; }
        public ICommand BtnCocaColaCommand { get; set; }
        public ICommand BtnInterFoodCommand { get; set; }
        public ICommand BtnRedBullCommand { get; set; }
        public ICommand BtnTanHiepPhatCommand { get; set; }
        public ICommand BtnUniversalRobinaCommand { get; set; }
        public ICommand BtnKinhDoCommand { get; set; }

    }
}
