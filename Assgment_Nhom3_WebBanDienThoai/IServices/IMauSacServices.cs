using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IMauSacServices
{
    public bool CreateMauSac(MauSac ms);
    public bool UpdateMauSac(MauSac ms);
    public bool DeleteMauSac(Guid id);
    public List<MauSac> GetAllMauSacs();
    public MauSac GetMauSacsById(Guid id);

    public List<MauSac> GetMauSacsByName(string name);
}