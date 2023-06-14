using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface ISimServices
{
    public bool Create(Sim obj);
    public bool Delete(Guid id);
    public bool Update(Sim obj);
    public List<Sim> GetAll();
}