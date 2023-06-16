using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IHoaDonServices
{
    public bool CreateHoaDon(HoaDon ms);
    public bool UpdateHoaDon(HoaDon ms);
    public bool DeleteHoaDon(Guid id);
    public IEnumerable<HoaDon> GetAllHoaDons();
    public HoaDon GetHoaDonsById(Guid id);

    public List<HoaDon> GetHoaDonsByName(string name);
}