using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class BoNhoTrongConfiguration : IEntityTypeConfiguration<BoNhoTrong>
{
    public void Configure(EntityTypeBuilder<BoNhoTrong> builder)
    {
        builder.HasKey(p => p.Id);
    }
}