using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup.Localizer;

namespace WPF_BanHang.DB_BanHang
{
    class SanPhamDBcontext : DbContext
    {
        public SanPhamDBcontext(DbContextOptions<SanPhamDBcontext> options) : base(options)
        {

        }
        public DbSet<SanPham> SanPhams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>().HasData(GetSanPhams());
            base.OnModelCreating(modelBuilder);
        }

        private SanPham[] GetSanPhams()
        {
            return new SanPham[]
            {
                new SanPham {Id=1, Ten = "Nước", Gia=10000, Soluong=10}
            };
        }
    }
}
