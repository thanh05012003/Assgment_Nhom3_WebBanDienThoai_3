using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IThanhToanServices
{
    public bool CreateThanhToan(ThanhToan tt);
    public bool DeleteThanhToan(Guid id);
    public bool UpdateThanhToan(ThanhToan tt);
    public List<ThanhToan> GetAll();
}