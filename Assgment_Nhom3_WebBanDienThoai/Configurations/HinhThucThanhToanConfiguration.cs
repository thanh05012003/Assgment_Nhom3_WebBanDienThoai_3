using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class HinhThucThanhToanConfiguration : IEntityTypeConfiguration<HinhThucThanhToan>
{
    public void Configure(EntityTypeBuilder<HinhThucThanhToan> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.ThanhToans).WithMany().HasForeignKey(p => p.IdThanhToan);

        builder.HasOne(p => p.HoaDons).WithMany().HasForeignKey(p => p.IdHd);
    }
}