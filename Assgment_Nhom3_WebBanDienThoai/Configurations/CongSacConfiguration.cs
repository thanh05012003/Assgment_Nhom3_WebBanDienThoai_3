using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class CongSacConfiguration : IEntityTypeConfiguration<CongSac>
{
    public void Configure(EntityTypeBuilder<CongSac> builder)
    {
        builder.HasKey(p => p.Id);
    }
}