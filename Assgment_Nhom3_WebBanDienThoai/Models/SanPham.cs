namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class SanPham
{
    public Guid Id { get; set; }

    public string TenSp { get; set; }

    public string MoTa { get; set; }

    public string Anh { get; set; }

    public Guid IdHsx { get; set; }

    public virtual NhaSanXuat? NhaSanXuats { get; set; }
}