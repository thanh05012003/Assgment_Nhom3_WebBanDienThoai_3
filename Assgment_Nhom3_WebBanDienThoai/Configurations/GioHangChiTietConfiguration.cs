using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
{
    public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.ChiTietSanPhams).WithMany().HasForeignKey(p => p.IdChiTietSp);

        builder.HasOne(p => p.GioHangs).WithMany().HasForeignKey(p => p.IdTaiKhoan);
    }
}