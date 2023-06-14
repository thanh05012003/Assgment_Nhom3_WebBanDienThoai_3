namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class ThanhToan
{
    public Guid Id { get; set; }

    public string TenPhuongThuc { get; set; }

    public string MaSoThe { get; set; }

    public DateTime NgayHetHan { get; set; }

    public int? MaCvv { get; set; }
}