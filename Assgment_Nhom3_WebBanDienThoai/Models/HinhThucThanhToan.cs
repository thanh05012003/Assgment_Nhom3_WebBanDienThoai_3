namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class HinhThucThanhToan
{
    public Guid Id { get; set; }

    public string TenPhuongThuc { get; set; }

    public decimal? TongTien { get; set; }
    public int TrangThai { get; set; }

    public Guid IdThanhToan { get; set; }
    public Guid IdHd { get; set; }

    public virtual ThanhToan? ThanhToans { get; set; }

    public virtual HoaDon? HoaDons { get; set; }
}