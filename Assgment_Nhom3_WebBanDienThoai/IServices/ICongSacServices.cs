using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface ICongSacServices
{
    public bool CreateCongSac(CongSac cs);
    public bool UpdateCongSac(CongSac cs);
    public bool DeleteCongSac(Guid id);
    public List<CongSac> GetAllCongSacs();
    public CongSac GetCongSacsById(Guid id);

    public List<CongSac> GetCongSacsByName(string name);
}