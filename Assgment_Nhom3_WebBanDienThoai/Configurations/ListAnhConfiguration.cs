using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class ListAnhConfiguration : IEntityTypeConfiguration<ListAnh>
{
    public void Configure(EntityTypeBuilder<ListAnh> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.ChiTietSanPhams).WithMany().HasForeignKey(p => p.IdCtsp);
    }
}