using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class ShoppingDbContext : DbContext
{
    public ShoppingDbContext()
    {
    }

    public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options)
    {
    }

    public DbSet<BoNhoTrong> BoNhoTrongs { get; set; }

    public DbSet<ChatLieu> ChatLieus { get; set; }

    public DbSet<ChipCPU> ChipCPUs { get; set; }

    public DbSet<ChipGPU> ChipGPUs { get; set; }

    public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public DbSet<CongSac> CongSacs { get; set; }

    public DbSet<DanhGia> DanhGias { get; set; }

    public DbSet<GiamGia> GiamGias { get; set; }

    public DbSet<GioHang> GioHangs { get; set; }

    public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }

    public DbSet<HeDieuHanh> HeDieuHanhs { get; set; }

    public DbSet<HinhThucThanhToan> HinhThucThanhToans { get; set; }

    public DbSet<HoaDon> HoaDons { get; set; }

    public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }

    public DbSet<Imei> Imeis { get; set; }

    public DbSet<ListAnh> ListAnhs { get; set; }

    public DbSet<MauSac> MauSacs { get; set; }

    public DbSet<NhaSanXuat> NhaSanXuats { get; set; }

    public DbSet<PhanQuyen> PhanQuyens { get; set; }

    public DbSet<Pin> Pins { get; set; }

    public DbSet<Ram> Rams { get; set; }

    public DbSet<SanPham> SanPhams { get; set; }

    public DbSet<Sim> Sims { get; set; }

    public DbSet<TaiKhoan> TaiKhoans { get; set; }

    public DbSet<ThanhToan> ThanhToans { get; set; }

    public DbSet<TinTuc> TinTucs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=MSI;Initial Catalog=BanDienThoai_Nhom2_C5;User ID=thanhnxph20424;Password=05012003;TrustServerCertificate=True;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GioHang>().HasOne(c => c.TaiKhoans).WithOne(p => p.GioHangs).HasForeignKey<GioHang>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}