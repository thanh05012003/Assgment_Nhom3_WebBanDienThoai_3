namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class GioHangChiTiet
{
    public Guid Id { get; set; }

    public Guid IdTaiKhoan { get; set; }
    public Guid IdChiTietSp { get; set; }

    public int SoLuong { get; set; }

    public int TrangThai { get; set; }

    public virtual ChiTietSanPham? ChiTietSanPhams { get; set; }

    public virtual GioHang? GioHangs { get; set; }
}