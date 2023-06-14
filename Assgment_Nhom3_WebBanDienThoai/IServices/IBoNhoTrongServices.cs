using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IBoNhoTrongServices
{
    public bool CreateBoNhoTrong(BoNhoTrong p);
    public bool UpdateChatLieu(BoNhoTrong p);
    public bool DeleteChatLieu(Guid id);
    public List<BoNhoTrong> GetAllBoNhoTrongs();
    public BoNhoTrong GetBoNhoTrongsById(Guid id);

    public List<BoNhoTrong> GetBoNhoTrongsByName(string name);
}