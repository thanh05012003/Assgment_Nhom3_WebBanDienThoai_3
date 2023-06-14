namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class Imei
{
    public Guid Id { get; set; }

    public string imei { get; set; }

    public int TrangThai { get; set; }

    public Guid IdCtsp { get; set; }

    public virtual ChiTietSanPham? ChiTietSanPhams { get; set; }
}