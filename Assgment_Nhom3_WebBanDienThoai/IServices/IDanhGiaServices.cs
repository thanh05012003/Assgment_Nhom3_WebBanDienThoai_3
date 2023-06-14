using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IDanhGiaServices
{
    public bool Create(DanhGia obj);
    public bool Delete(Guid id);
    public bool Update(DanhGia obj);
    public List<DanhGia> GetAll();
}