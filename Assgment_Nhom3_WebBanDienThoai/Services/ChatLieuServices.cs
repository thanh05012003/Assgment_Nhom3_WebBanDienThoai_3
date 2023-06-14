using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class ChatLieuServices : IChatLieuServices
{
    private readonly ShoppingDbContext _dbContext;

    public ChatLieuServices()
    {
        _dbContext = new ShoppingDbContext();
    }

    public bool CreateChatLieu(ChatLieu p)
    {
        try
        {
            _dbContext.ChatLieus.Add(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteChatLieu(Guid id)
    {
        try
        {
            var p = _dbContext.Rams.Find(id);
            _dbContext.Rams.Remove(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<ChatLieu> GetAllChatLieus()
    {
        return _dbContext.ChatLieus.ToList();
    }

    public ChatLieu GetChatLieusById(Guid id)
    {
        return _dbContext.ChatLieus.FirstOrDefault(p => p.Id == id);
    }

    public List<ChatLieu> GetChatLieusByName(string name)
    {
        return _dbContext.ChatLieus.Where(p => p.Ten.Contains(name)).ToList();
    }

    public bool UpdateChatLieu(ChatLieu p)
    {
        try
        {
            var a = _dbContext.ChatLieus.Find(p.Id);
            a.Ten = p.Ten;
            _dbContext.ChatLieus.Update(a);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}