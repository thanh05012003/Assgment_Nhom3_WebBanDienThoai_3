namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class DanhGia
{
    public Guid Id { get; set; }

    public DateTime NgayDanhGia { get; set; }

    public string NoiDung { get; set; }

    public Guid IdSpct { get; set; }

    public Guid IdTaiKhoan { get; set; }

    public virtual ChiTietSanPham? ChiTietSanPhams { get; set; }

    public virtual TaiKhoan? TaiKhoans { get; set; }
}