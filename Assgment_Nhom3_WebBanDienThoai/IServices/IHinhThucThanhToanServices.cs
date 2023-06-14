using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IHinhThucThanhToanServices
{
    public bool Create(HinhThucThanhToan obj);
    public bool Delete(Guid id);
    public bool Update(HinhThucThanhToan obj);
    public List<HinhThucThanhToan> GetAll();
}