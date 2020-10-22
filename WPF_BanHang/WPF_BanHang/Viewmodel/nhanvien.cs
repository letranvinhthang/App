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
   public class nhanvien:BaseViewModel
    {
        #region DataContext
        public ObservableCollection<nvxl> _nhanvienlist;
        public ObservableCollection<nvxl> nhanvienlist { get => _nhanvienlist; set { _nhanvienlist = value; OnPropertyChanged(); } }
        //đổ dữ liệu qh vô combobox
        public ObservableCollection<QuyenHan> _cvlist;
        public ObservableCollection<QuyenHan> cvlist { get => _cvlist; set { _cvlist = value; OnPropertyChanged(); } }
        #endregion

        //lấy dữ liệu đc selected
        #region Thuộc tính binding
        public nvxl _SelectedItem;
        public nvxl SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value; OnPropertyChanged();
                if (SelectedItem != null)
                {
                    ten = SelectedItem.ten;
                    pass = SelectedItem.Pass;
                    ngaysinh = SelectedItem.ngaysinh;
                    diachi = SelectedItem.diachi;
                    sdt = SelectedItem.sdt;
                    chuvuseleted = SelectedItem.IdChucvu - 2;
                    manv = SelectedItem.Manv;
                }
            }
        }
        private string _ten;

        public string ten { get => _ten; set { _ten = value; OnPropertyChanged(); } }
        private int _manv;

        public int manv { get => _manv; set { _manv = value; OnPropertyChanged(); } }
        private string _pass;

        public string pass { get => _pass; set { _pass = value; OnPropertyChanged(); } }
        private DateTime _ngaysinh;

        public DateTime ngaysinh { get => _ngaysinh; set { _ngaysinh = value; OnPropertyChanged(); } }
        private string _diachi;

        public string diachi { get => _diachi; set { _diachi = value; OnPropertyChanged(); } }
        private string _sdt;

        public string sdt { get => _sdt; set { _sdt = value; OnPropertyChanged(); } }
        private int _chuvuseleted;

        public int chuvuseleted { get => _chuvuseleted; set { _chuvuseleted = value; OnPropertyChanged(); } }
        private bool _disa;

        public bool disa { get => _disa; set { _disa = value; OnPropertyChanged(); } }

        private string _password;

        public string password { get => _password; set { _password = value; OnPropertyChanged(); } }
        private string _sodt;

        public string sodt { get => _sodt; set { _sodt = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand themnhanviencommand { get; set; }
        public ICommand suanhanviencommand { get; set; }
        public ICommand loadednvcommand { get; set; }
        public ICommand editcommand { get; set; }
        public ICommand PassChangedcommand { get; set; }
        public ICommand TextChangedcommand { get; set; }
        public ICommand exitcommand { get; set; }
        public ICommand disablecommand { get; set; }
        public ICommand xoacommand { get; set; }
        public ICommand enablecommand { get; set; }
        public ICommand loadcommand { get; set; }
        #endregion
        public nhanvien()
        {
            var db = new qlbhContext();
            loadcommand = new RelayCommand<Object>((p) => { return true; }, (p) =>
            {
                loadnhanvien();
            });
            suanhanviencommand = new RelayCommand<SuaNhanVienWindow>((c) => {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            }, (c) => { suanhanvien(c); });
            themnhanviencommand = new RelayCommand<ChinhSuaWindow>((a) => { return true; }, (a) => {
                themnhanvien(a); });
                 loadednvcommand = new RelayCommand<ChinhSuaWindow>((a) => { return true; }, (a) => { loadnhanvien(); });
            xoacommand = new RelayCommand<object>((a) => { return true; }, (a) => {
                var dis = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                dis.XoaNhanVien = true;
                db.SaveChanges();
                MessageBox.Show("xoa thanh cong ");
                loadnhanvien();

            });
            disablecommand = new RelayCommand<object>((p) =>
            {
                bool a = db.NhanVien.Where(p => p.IdNhanvien == SelectedItem.Manv).FirstOrDefault().Disable;

                if (a == true)
                    return false;
                return true;

            }, (p) =>
            {
                var dis = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                dis.Disable = true;
                db.SaveChanges();
                disa = SelectedItem.Disable;

            });
            enablecommand = new RelayCommand<object>((p) =>
            {
                /* bool a = db.NhanVien.Where(p => p.IdNhanvien == SelectedItem.Manv).FirstOrDefault().Disable;
                   if (a != true)
                       return false;*/
                return true;
            }, (p) =>
            {
                var dis = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                dis.Disable = false;
                db.SaveChanges();
                disa = SelectedItem.Disable;
            });
            //xử lý sửa thông tin
            PassChangedcommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { password = p.Password; });
            TextChangedcommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { sodt = p.Text; });
            editcommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(password))
                {
                    if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(sdt))
                        return false;
                    return true;
                }
                else
                {
                    if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(sdt))
                        return false;
                    pass = MD5Hash(Base64Encode(password));
                    return true;
                }
            },
                    (p) =>
                    {
                        if (string.IsNullOrEmpty(password))
                        {
                            var editnp = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                            editnp.TenNhanvien = ten;
                            editnp.Sdt = sdt;
                            editnp.DiachiNhanvien = diachi;
                            editnp.IdChucvu = chuvuseleted + 2;
                            db.SaveChanges();
                            MessageBox.Show("sua thanh cong");
                            SelectedItem.ten = ten;
                            SelectedItem.sdt = sdt;
                            SelectedItem.diachi = diachi;
                            SelectedItem.IdChucvu = chuvuseleted + 2;
                        }
                        else
                        {
                            var edit = db.NhanVien.Where(x => x.IdNhanvien == SelectedItem.Manv).SingleOrDefault();
                            edit.TenNhanvien = ten;
                            edit.PassNhanvien = pass;
                            edit.Sdt = sdt;
                            edit.DiachiNhanvien = diachi;
                            edit.IdChucvu = chuvuseleted + 2;
                            db.SaveChanges();
                            MessageBox.Show("sua thanh cong");
                            SelectedItem.ten = ten;
                            SelectedItem.sdt = sdt;
                            SelectedItem.diachi = diachi;
                            SelectedItem.IdChucvu = chuvuseleted + 2;
                        }
                    });
            void themnhanvien(ChinhSuaWindow a)
            {
                ChinhSuaWindow window1 = new ChinhSuaWindow();
                window1.ShowDialog();
                loadnhanvien();
            }

            //mo win sua nv
            void suanhanvien(SuaNhanVienWindow c)
            {
                SuaNhanVienWindow window2 = new SuaNhanVienWindow();
                window2.ShowDialog();
                loadnhanvien();
            }
            //mã hóa base 64
     

        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        //mã hóa md5
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
        void themsanpham(ThemSanPhamWindow k)
        {
            ThemSanPhamWindow window3 = new ThemSanPhamWindow();
            window3.ShowDialog();
        }
        void loadnhanvien()
        {
            var db = new qlbhContext();
            nhanvienlist = new ObservableCollection<nvxl>();
            cvlist = new ObservableCollection<QuyenHan>(db.QuyenHan.Where(p => p.IdChucvu != 1));
            var nv = db.NhanVien;
            var qh = db.QuyenHan;

            if(MainViewModel.TaiKhoan != null)
            {
                int? idch = MainViewModel.TaiKhoan.Idcuahang;
                foreach (var item in nv.Where(p => p.Idcuahang == idch && p.XoaNhanVien == false ).ToList())
                {
                    var tencv = qh.Where(p => p.IdChucvu == item.IdChucvu).FirstOrDefault();
                    nvxl nvl = new nvxl();
                    nvl.Manv = item.IdNhanvien;
                    nvl.ten = item.TenNhanvien;
                    nvl.Pass = item.PassNhanvien;
                    nvl.ngaysinh = item.NgaySinh;
                    nvl.diachi = item.DiachiNhanvien;
                    nvl.chucvu = tencv.TenChucvu;
                    nvl.IdChucvu = item.IdChucvu;
                    nvl.sdt = item.Sdt;
                    nhanvienlist.Add(nvl);
                }
            }
            else
            {
                return;
            }
        }
    }
 }
