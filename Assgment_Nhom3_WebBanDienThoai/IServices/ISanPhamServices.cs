using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface ISanPhamServices
{
    public bool createSanPham(SanPham obj);
    public bool deleteSanPham(Guid id);
    public bool updateSanPham(SanPham obj);
    public List<SanPham> GetAll();
    public SanPham GetSanPhamById(Guid id);
    public List<SanPham> GetSanPhamByName(string name);
}