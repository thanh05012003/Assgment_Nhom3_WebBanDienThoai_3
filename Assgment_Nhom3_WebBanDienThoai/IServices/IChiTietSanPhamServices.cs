using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IChiTietSanPhamServices
{
    public bool Create(ChiTietSanPham obj);
    public bool Delete(Guid id);
    public bool Update(ChiTietSanPham obj);
    public List<ChiTietSanPham> GetAll();

    public ChiTietSanPham GetById(Guid id);
}