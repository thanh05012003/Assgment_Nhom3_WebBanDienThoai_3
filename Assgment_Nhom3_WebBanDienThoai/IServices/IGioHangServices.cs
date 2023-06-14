using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IGioHangServices
{
    public bool Create(GioHang obj);
    public bool Delete(Guid id);
    public bool Update(GioHang obj);
    public GioHang GetCartById(Guid id);
    public List<GioHang> GetAll();

}