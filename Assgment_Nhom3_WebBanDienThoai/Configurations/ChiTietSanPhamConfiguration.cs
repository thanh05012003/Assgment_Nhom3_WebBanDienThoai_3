using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assgment_Nhom3_WebBanDienThoai.Configurations;

public class ChiTietSanPhamConfiguration : IEntityTypeConfiguration<ChiTietSanPham>
{
    public void Configure(EntityTypeBuilder<ChiTietSanPham> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.BoNhoTrongs).WithMany().HasForeignKey(p => p.IdBoNhoTrong);

        builder.HasOne(p => p.ChatLieus).WithMany().HasForeignKey(p => p.IdChatLieu);

        builder.HasOne(p => p.ChipCPUs).WithMany().HasForeignKey(p => p.IdChipCPU);

        builder.HasOne(p => p.ChipGPUs).WithMany().HasForeignKey(p => p.IdChipGPU);

        builder.HasOne(p => p.CongSacs).WithMany().HasForeignKey(p => p.IdCongSac);

        builder.HasOne(p => p.GiamGias).WithMany().HasForeignKey(p => p.IdGiamGia);

        builder.HasOne(p => p.HeDieuHanhs).WithMany().HasForeignKey(p => p.IdHeDieuHanh);

        builder.HasOne(p => p.MauSacs).WithMany().HasForeignKey(p => p.IdMauSac);

        builder.HasOne(p => p.Pins).WithMany().HasForeignKey(p => p.IdPin);

        builder.HasOne(p => p.Rams).WithMany().HasForeignKey(p => p.IdRam);

        builder.HasOne(p => p.Sims).WithMany().HasForeignKey(p => p.IdSim);

        builder.HasOne(p => p.SanPhams).WithMany().HasForeignKey(p => p.IdSanPham);
    }
}