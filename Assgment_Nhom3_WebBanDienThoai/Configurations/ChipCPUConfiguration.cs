using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class ChipCPUConfiguration : IEntityTypeConfiguration<ChipCPU>
{
    public void Configure(EntityTypeBuilder<ChipCPU> builder)
    {
        builder.HasKey(p => p.Id);
    }
}