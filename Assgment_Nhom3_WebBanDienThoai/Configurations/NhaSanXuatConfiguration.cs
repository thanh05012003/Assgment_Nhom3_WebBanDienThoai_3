using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class NhaSanXuatConfiguration : IEntityTypeConfiguration<NhaSanXuat>
{
    public void Configure(EntityTypeBuilder<NhaSanXuat> builder)
    {
        builder.HasKey(p => p.Id);
    }
}