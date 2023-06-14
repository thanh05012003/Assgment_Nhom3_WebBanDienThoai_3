using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IRamServices
{
    public bool CreateRam(Ram p);
    public bool UpdateRam(Ram p);
    public bool DeleteRam(Guid id);
    public List<Ram> GetAllRams();
    public Ram GetRamsById(Guid id);

    public List<Ram> GetRamsByName(string name);
}