using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
{
    public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.ChiTietSanPhams).WithMany().HasForeignKey(p => p.IdChiTietSp);

        builder.HasOne(p => p.HoaDons).WithMany().HasForeignKey(p => p.IdHoaDon);
    }
}