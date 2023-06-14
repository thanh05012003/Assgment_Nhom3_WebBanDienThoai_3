using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class MauSacConfiguration : IEntityTypeConfiguration<MauSac>
{
    public void Configure(EntityTypeBuilder<MauSac> builder)
    {
        builder.HasKey(p => p.Id);
    }
}