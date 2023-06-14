namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class TaiKhoan
{
    public Guid Id { get; set; }

    public string TenDN { get; set; }

    public string MatKhau { get; set; }

    public string HoVaTen { get; set; }

    public string? Email { get; set; }

    public string SDT { get; set; }

    public string DiaChi { get; set; }

    public string? LinkAnh { get; set; }

    public int TrangThai { get; set; }

    public Guid IdCv { get; set; }

    public virtual GioHang? GioHangs { get; set; }

    public virtual PhanQuyen? PhanQuyens { get; set; }
}