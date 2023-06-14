using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IGioHangChiTietServices
{
    public bool Create(GioHangChiTiet obj);
    public bool Delete(Guid id);
    public bool Update(GioHangChiTiet obj);
    public List<GioHangChiTiet> GetAll();
}