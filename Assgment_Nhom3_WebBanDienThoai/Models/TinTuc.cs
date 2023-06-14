namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class TinTuc
{
    public Guid Id { get; set; }
    public string TieuDe { get; set; }

    public string NoiDung { get; set; }

    public DateTime NgayTao { get; set; }

    public int TrangThai { get; set; }
}