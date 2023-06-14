using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class DanhGiaConfiguration : IEntityTypeConfiguration<DanhGia>
{
    public void Configure(EntityTypeBuilder<DanhGia> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.ChiTietSanPhams).WithMany().HasForeignKey(p => p.IdSpct);

        builder.HasOne(p => p.TaiKhoans).WithMany().HasForeignKey(p => p.IdTaiKhoan);
    }
}