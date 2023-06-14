using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IHoaDonChiTietServices
{
    public bool CreateHoaDonChiTiet(HoaDonChiTiet ms);
    public bool UpdateHoaDonChiTiet(HoaDonChiTiet ms);
    public bool DeleteHoaDonChiTiet(Guid id);
    public List<HoaDonChiTiet> GetAllHoaDonChiTiets();
    public HoaDonChiTiet GetHoaDonChiTietsById(Guid id);

    public List<HoaDonChiTiet> GetHoaDonChiTietsByName(string name);
}