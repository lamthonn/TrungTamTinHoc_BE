using Microsoft.EntityFrameworkCore;
using TrungTamTinHoc_BE.Models;

namespace TrungTamTinHoc_BE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<GiangVien> GiangViens { get; set;}
        public DbSet<Admin> Admin { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set;}
        public DbSet<CTKhoaHoc> CTKhoaHocs { get; set; }
        public DbSet<LichHoc> LichHocs { get; set; }
        public DbSet<Role> Roles { get; set; }  
        public DbSet<PhanQuyen> PhanQuyen { get; set;}
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }    
        public DbSet<Post> BaiViets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id);

            //gán khóa chính, kết nối bảng<Học viên>
            modelBuilder.Entity<HocVien>()
                .HasKey(k => k.maHV);


            //gán khóa chính, kết nối bảng<giảng viên>
            modelBuilder.Entity<GiangVien>()
                .HasKey(k => k.maGV);


            //gán khóa chính, kết nối bảng<Tài khoản>
            modelBuilder.Entity<TaiKhoan>()
                .HasKey(tk => tk.Account);

            //gán khóa chính, kết nối bảng<Roles>
            modelBuilder.Entity<Role>()
                .HasKey(role => role.RoleId);

            //gán khóa chính, kết nối bảng<Phân quyền>
            modelBuilder.Entity<PhanQuyen>()
                .HasKey(role => new { role.RoleId, role.Account });
            //modelBuilder.Entity<PhanQuyen>()
            //    .HasOne(pq => pq.Role)
            //    .WithMany()
            //    .HasForeignKey(pq => pq.RoleId);
            //modelBuilder.Entity<PhanQuyen>()
            //    .HasOne(pq => pq.TaiKhoan)
            //    .WithMany()
            //    .HasForeignKey(pq => pq.AccountId);

            //gán khóa chính, kết nối bảng<Khóa học>
            modelBuilder.Entity<KhoaHoc>()
                .HasKey(kh => kh.maKH);
            //modelBuilder.Entity<KhoaHoc>()
            //    .HasOne(kh => kh.GiangVien)
            //    .WithMany()
            //    .HasForeignKey(kh => kh.maGV);

            //gán khóa chính, kết nối bảng<CT khóa học>
            modelBuilder.Entity<CTKhoaHoc>()
                .HasKey(ctkh => new { ctkh.maKH, ctkh.maHV });
            //modelBuilder.Entity<CTKhoaHoc>()//1- nhiều với bảng học viên
            //    .HasOne(CTkhoahoc => CTkhoahoc.HocVien)
            //    .WithMany()
            //    .HasForeignKey(ctkh => ctkh.maHV);
            //modelBuilder.Entity<CTKhoaHoc>()//1- nhiều với bảng khóa học
            //    .HasOne(CTkhoahoc => CTkhoahoc.KhoaHoc)
            //    .WithMany()
            //    .HasForeignKey(ctkh => ctkh.maKH);

            //gán khóa chính, kết nối bảng<Lịch học>
            modelBuilder.Entity<LichHoc>()
                .HasKey(l => new { l.maKH, l.ngay, l.DiaDiem });
        }
    }
}
