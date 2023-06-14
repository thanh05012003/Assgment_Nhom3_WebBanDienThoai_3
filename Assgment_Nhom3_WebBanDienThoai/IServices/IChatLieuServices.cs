using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IChatLieuServices
{
    public bool CreateChatLieu(ChatLieu p);
    public bool UpdateChatLieu(ChatLieu p);
    public bool DeleteChatLieu(Guid id);
    public List<ChatLieu> GetAllChatLieus();
    public ChatLieu GetChatLieusById(Guid id);

    public List<ChatLieu> GetChatLieusByName(string name);
}