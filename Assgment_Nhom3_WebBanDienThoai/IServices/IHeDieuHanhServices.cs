using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IHeDieuHanhServices
{
    public bool CreateHeDieuHanh(HeDieuHanh p);
    public bool UpdateHeDieuHanh(HeDieuHanh p);
    public bool DeleteHeDieuHanh(Guid id);
    public List<HeDieuHanh> GetHeDieuHanhs();
    public HeDieuHanh GetHeDieuHanhTrongsById(Guid id);

    public List<HeDieuHanh> GetHeDieuHanhsByName(string name);
}