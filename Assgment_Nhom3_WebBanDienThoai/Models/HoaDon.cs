namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class HoaDon
{
    public Guid Id { get; set; }

    public DateTime NgayTao { get; set; }

    public DateTime NgayThanhToan { get; set; }

    public string? HoVaTen { get; set; }

    public int? SDT { get; set; }

    public string? DiaChi { get; set; }

    public decimal? TongTien { get; set; }

    public int TrangThai { get; set; }

    public Guid IdThanhToan { get; set; }

    public Guid IdTaiKhoan { get; set; }

    public virtual TaiKhoan? TaiKhoans { get; set; }
}