using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IImeiServices
{
    public bool Create(Imei obj);
    public bool Delete(Guid id);
    public bool Update(Imei obj);
    public List<Imei> GetAll();
}