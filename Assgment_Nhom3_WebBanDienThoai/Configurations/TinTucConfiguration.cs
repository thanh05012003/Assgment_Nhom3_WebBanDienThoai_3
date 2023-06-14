using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class TinTucConfiguration : IEntityTypeConfiguration<TinTuc>
{
    public void Configure(EntityTypeBuilder<TinTuc> builder)
    {
        builder.HasKey(p => p.Id);
    }
}