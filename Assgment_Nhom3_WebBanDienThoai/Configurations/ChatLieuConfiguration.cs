using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class ChatLieuConfiguration : IEntityTypeConfiguration<ChatLieu>
{
    public void Configure(EntityTypeBuilder<ChatLieu> builder)
    {
        builder.HasKey(p => p.Id);
    }
}