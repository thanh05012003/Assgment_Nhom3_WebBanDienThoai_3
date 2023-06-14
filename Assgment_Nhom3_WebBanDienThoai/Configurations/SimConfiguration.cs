using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class SimConfiguration : IEntityTypeConfiguration<Sim>
{
    public void Configure(EntityTypeBuilder<Sim> builder)
    {
        builder.HasKey(p => p.Id);
    }
}