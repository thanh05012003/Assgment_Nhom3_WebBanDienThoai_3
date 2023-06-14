using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class GiamGiaConfiguration : IEntityTypeConfiguration<GiamGia>
{
    public void Configure(EntityTypeBuilder<GiamGia> builder)
    {
        builder.HasKey(p => p.Id);
    }
}