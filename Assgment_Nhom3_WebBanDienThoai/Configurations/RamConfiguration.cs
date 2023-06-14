using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class RamConfiguration : IEntityTypeConfiguration<Ram>
{
    public void Configure(EntityTypeBuilder<Ram> builder)
    {
        builder.HasKey(p => p.Id);
    }
}