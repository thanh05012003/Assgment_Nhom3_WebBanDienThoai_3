namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class GioHang
{
    public Guid IdTaiKhoan { get; set; }

    public string? Mota { get; set; }

    public TaiKhoan TaiKhoans { get; set; }
}