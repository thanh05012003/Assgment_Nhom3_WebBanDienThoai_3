using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IGiamGiaServices
{
    public bool Create(GiamGia obj);
    public bool Delete(Guid id);
    public bool Update(GiamGia obj);
    public List<GiamGia> GetAll();

    public GiamGia GetById(Guid id);
}