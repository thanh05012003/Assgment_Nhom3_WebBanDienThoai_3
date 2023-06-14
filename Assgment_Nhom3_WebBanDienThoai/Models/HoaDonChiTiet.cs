namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class HoaDonChiTiet
{
    public Guid Id { get; set; }

    public Guid IdHoaDon { get; set; }

    public Guid IdChiTietSp { get; set; }

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public int TrangThai { get; set; }

    public virtual HoaDon? HoaDons { get; set; }

    public virtual ChiTietSanPham? ChiTietSanPhams { get; set; }
}