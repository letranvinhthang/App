using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WPF_BanHang.Models
{
    public partial class qlbhContext : DbContext
    {
        public qlbhContext()
        {
        }

        public qlbhContext(DbContextOptions<qlbhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CuaHang> CuaHang { get; set; }
        public virtual DbSet<CuahangSanpham> CuahangSanpham { get; set; }
        public virtual DbSet<DanhmucSanpham> DanhmucSanpham { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<HoaDonChitiet> HoaDonChitiet { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<NhaCungcap> NhaCungcap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<QuangCao> QuangCao { get; set; }
        public virtual DbSet<QuyenHan> QuyenHan { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<SanphamYeuthich> SanphamYeuthich { get; set; }
        public virtual DbSet<TonKho> TonKho { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=192.168.10.225;database=qlbh;user=root", x => x.ServerVersion("10.4.14-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuaHang>(entity =>
            {
                entity.HasKey(e => e.IdCuahang)
                    .HasName("PRIMARY");

                entity.ToTable("cua_hang");

                entity.Property(e => e.IdCuahang)
                    .HasColumnName("ID_cuahang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DiachiCuahang)
                    .IsRequired()
                    .HasColumnName("Diachi_cuahang")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.TenCuahang)
                    .IsRequired()
                    .HasColumnName("Ten_cuahang")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<CuahangSanpham>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cuahang_sanpham");

                entity.HasIndex(e => e.IdCuahang)
                    .HasName("ID_cuahang");

                entity.HasIndex(e => e.IdSanpham)
                    .HasName("ID_sanpham");

                entity.Property(e => e.GiaTheoQuan).HasColumnName("Gia_theo_quan");

                entity.Property(e => e.IdCuahang)
                    .HasColumnName("ID_cuahang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSanpham)
                    .HasColumnName("ID_sanpham")
                    .HasColumnType("bigint(13)");

                entity.HasOne(d => d.IdCuahangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCuahang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cuahang_sanpham_ibfk_1");

                entity.HasOne(d => d.IdSanphamNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSanpham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cuahang_sanpham_ibfk_2");
            });

            modelBuilder.Entity<DanhmucSanpham>(entity =>
            {
                entity.HasKey(e => e.IdLoaisp)
                    .HasName("PRIMARY");

                entity.ToTable("danhmuc_sanpham");

                entity.Property(e => e.IdLoaisp)
                    .HasColumnName("ID_loaisp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasColumnName("Ten_loai")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.IdHoadon)
                    .HasName("PRIMARY");

                entity.ToTable("hoa_don");

                entity.HasIndex(e => e.IdChuongtrinh)
                    .HasName("ID_Chuongtrinh");

                entity.HasIndex(e => e.IdCuahang)
                    .HasName("ID_cuahang");

                entity.HasIndex(e => e.IdKhachhang)
                    .HasName("ID_Khachhang");

                entity.HasIndex(e => e.IdNhacc)
                    .HasName("ID_nhacc");

                entity.HasIndex(e => e.IdNhanvien)
                    .HasName("ID_nhanvien");

                entity.Property(e => e.IdHoadon)
                    .HasColumnName("ID_hoadon")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdChuongtrinh)
                    .HasColumnName("ID_Chuongtrinh")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdCuahang)
                    .HasColumnName("ID_cuahang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdKhachhang)
                    .HasColumnName("ID_Khachhang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdNhacc)
                    .HasColumnName("ID_nhacc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdNhanvien)
                    .HasColumnName("ID_nhanvien")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NgayTao)
                    .HasColumnName("Ngay_tao")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ThanhTien).HasColumnName("Thanh_tien");

                entity.HasOne(d => d.IdChuongtrinhNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.IdChuongtrinh)
                    .HasConstraintName("hoa_don_ibfk_5");

                entity.HasOne(d => d.IdCuahangNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.IdCuahang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hoa_don_ibfk_1");

                entity.HasOne(d => d.IdKhachhangNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.IdKhachhang)
                    .HasConstraintName("hoa_don_ibfk_3");

                entity.HasOne(d => d.IdNhaccNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.IdNhacc)
                    .HasConstraintName("hoa_don_ibfk_4");

                entity.HasOne(d => d.IdNhanvienNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.IdNhanvien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hoa_don_ibfk_2");
            });

            modelBuilder.Entity<HoaDonChitiet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hoa_don_chitiet");

                entity.HasIndex(e => e.IdHoadon)
                    .HasName("ID_hoadon");

                entity.HasIndex(e => e.IdKhachhang)
                    .HasName("ID_Khachhang");

                entity.HasIndex(e => e.IdNhacc)
                    .HasName("ID_nhacc");

                entity.HasIndex(e => e.IdSanpham)
                    .HasName("ID_sanpham");

                entity.Property(e => e.GiaTien).HasColumnName("Gia_tien");

                entity.Property(e => e.IdHoadon)
                    .HasColumnName("ID_hoadon")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdKhachhang)
                    .HasColumnName("ID_Khachhang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdNhacc)
                    .HasColumnName("ID_nhacc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSanpham)
                    .HasColumnName("ID_sanpham")
                    .HasColumnType("bigint(11)");

                entity.Property(e => e.SoLuong)
                    .HasColumnName("So_luong")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdHoadonNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHoadon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hoa_don_chitiet_ibfk_1");

                entity.HasOne(d => d.IdKhachhangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdKhachhang)
                    .HasConstraintName("hoa_don_chitiet_ibfk_2");

                entity.HasOne(d => d.IdNhaccNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdNhacc)
                    .HasConstraintName("ID_nhacc");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.IdKhachhang)
                    .HasName("PRIMARY");

                entity.ToTable("khach_hang");

                entity.HasIndex(e => e.IdChucvu)
                    .HasName("ID_chucvu");

                entity.Property(e => e.IdKhachhang)
                    .HasColumnName("ID_Khachhang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AvatarKhachhang)
                    .IsRequired()
                    .HasColumnName("Avatar_khachhang")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.DiachiKhachhang)
                    .IsRequired()
                    .HasColumnName("Diachi_khachhang")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.DiemKhachhang)
                    .HasColumnName("Diem_khachhang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmailKhachhang)
                    .IsRequired()
                    .HasColumnName("Email_khachhang")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.GioitinhKhachhang).HasColumnName("Gioitinh_khachhang");

                entity.Property(e => e.IdChucvu)
                    .HasColumnName("ID_chucvu")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PassKhachhang)
                    .IsRequired()
                    .HasColumnName("Pass_khachhang")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.TenKhachhang)
                    .IsRequired()
                    .HasColumnName("Ten_khachhang")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdChucvuNavigation)
                    .WithMany(p => p.KhachHang)
                    .HasForeignKey(d => d.IdChucvu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("khach_hang_ibfk_2");
            });

            modelBuilder.Entity<NhaCungcap>(entity =>
            {
                entity.HasKey(e => e.IdNhacc)
                    .HasName("PRIMARY");

                entity.ToTable("nha_cungcap");

                entity.Property(e => e.IdNhacc)
                    .HasColumnName("ID_nhacc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DiachiNhacc)
                    .IsRequired()
                    .HasColumnName("Diachi_nhacc")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.TenNhacc)
                    .IsRequired()
                    .HasColumnName("Ten_nhacc")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.IdNhanvien)
                    .HasName("PRIMARY");

                entity.ToTable("nhan_vien");

                entity.HasIndex(e => e.IdChucvu)
                    .HasName("ID_chucvu");

                entity.Property(e => e.IdNhanvien)
                    .HasColumnName("ID_nhanvien")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DiachiNhanvien)
                    .IsRequired()
                    .HasColumnName("Diachi_nhanvien")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdChucvu)
                    .HasColumnName("ID_chucvu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idcuahang).HasColumnType("int(11)");

                entity.Property(e => e.NgaySinh)
                    .HasColumnName("Ngay_sinh")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PassNhanvien)
                    .IsRequired()
                    .HasColumnName("Pass_Nhanvien")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("sdt")
                    .HasColumnType("char(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.TenNhanvien)
                    .IsRequired()
                    .HasColumnName("Ten_nhanvien")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.XoaNhanVien).HasColumnName("Xoa_NhanVien");

                entity.HasOne(d => d.IdChucvuNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.IdChucvu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nhan_vien_ibfk_1");
            });

            modelBuilder.Entity<QuangCao>(entity =>
            {
                entity.HasKey(e => e.IdChuongtrinh)
                    .HasName("PRIMARY");

                entity.ToTable("quang_cao");

                entity.Property(e => e.IdChuongtrinh)
                    .HasColumnName("ID_Chuongtrinh")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.HinhanhChuongtrinh)
                    .IsRequired()
                    .HasColumnName("Hinhanh_Chuongtrinh")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.MotaChuongtrinh)
                    .IsRequired()
                    .HasColumnName("Mota_Chuongtrinh")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.TenChuongtrinh)
                    .IsRequired()
                    .HasColumnName("Ten_Chuongtrinh")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<QuyenHan>(entity =>
            {
                entity.HasKey(e => e.IdChucvu)
                    .HasName("PRIMARY");

                entity.ToTable("quyen_han");

                entity.Property(e => e.IdChucvu)
                    .HasColumnName("ID_chucvu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DisTaikhoan).HasColumnName("Dis_taikhoan");

                entity.Property(e => e.HuyOrder).HasColumnName("Huy_order");

                entity.Property(e => e.SuaOrder).HasColumnName("Sua_order");

                entity.Property(e => e.SuaTaikhoan).HasColumnName("Sua_taikhoan");

                entity.Property(e => e.TaoOrder).HasColumnName("Tao_order");

                entity.Property(e => e.TaoTaikhoan).HasColumnName("Tao_taikhoan");

                entity.Property(e => e.TenChucvu)
                    .IsRequired()
                    .HasColumnName("Ten_chucvu")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.TonKho).HasColumnName("Ton_kho");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.IdSanpham)
                    .HasName("PRIMARY");

                entity.ToTable("san_pham");

                entity.HasIndex(e => e.IdLoaisp)
                    .HasName("ID_loaisp");

                entity.Property(e => e.IdSanpham)
                    .HasColumnName("ID_sanpham")
                    .HasColumnType("bigint(13)")
                    .ValueGeneratedNever();

                entity.Property(e => e.HinhSanpham)
                    .IsRequired()
                    .HasColumnName("Hinh_sanpham")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdLoaisp)
                    .HasColumnName("ID_loaisp")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SanphamHot).HasColumnName("Sanpham_hot");

                entity.Property(e => e.SanphamMoi).HasColumnName("Sanpham_moi");

                entity.Property(e => e.SoluongTonkho)
                    .HasColumnName("Soluong_tonkho")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TenSanpham)
                    .IsRequired()
                    .HasColumnName("Ten_sanpham")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.XoaSanPham).HasColumnName("Xoa_SanPham");

                entity.HasOne(d => d.IdLoaispNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.IdLoaisp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("san_pham_ibfk_1");
            });

            modelBuilder.Entity<SanphamYeuthich>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sanpham_yeuthich");

                entity.HasIndex(e => e.IdKhachhang)
                    .HasName("ID_Khachhang");

                entity.HasIndex(e => e.IdSanpham)
                    .HasName("ID_sanpham");

                entity.Property(e => e.IdKhachhang)
                    .HasColumnName("ID_Khachhang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSanpham)
                    .HasColumnName("ID_sanpham")
                    .HasColumnType("bigint(13)");

                entity.HasOne(d => d.IdKhachhangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdKhachhang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sanpham_yeuthich_ibfk_1");

                entity.HasOne(d => d.IdSanphamNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSanpham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sanpham_yeuthich_ibfk_2");
            });

            modelBuilder.Entity<TonKho>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ton_kho");

                entity.HasIndex(e => e.IdCuahang)
                    .HasName("ID_cuahang");

                entity.HasIndex(e => e.IdSanpham)
                    .HasName("ID_sanpham");

                entity.Property(e => e.IdCuahang)
                    .HasColumnName("ID_cuahang")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSanpham)
                    .HasColumnName("ID_sanpham")
                    .HasColumnType("bigint(13)");

                entity.Property(e => e.NgayTon)
                    .HasColumnName("Ngay_Ton")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.SoluongTon)
                    .HasColumnName("Soluong_Ton")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCuahangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCuahang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ton_kho_ibfk_2");

                entity.HasOne(d => d.IdSanphamNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSanpham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ton_kho_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
