using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class BoNhoTrongServices : IBoNhoTrongServices
{
    private readonly ShoppingDbContext _dbContext;

    public BoNhoTrongServices()
    {
        _dbContext = new ShoppingDbContext();
    }

    public bool CreateBoNhoTrong(BoNhoTrong p)
    {
        try
        {
            _dbContext.BoNhoTrongs.Add(p);
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
            var p = _dbContext.BoNhoTrongs.Find(id);
            _dbContext.BoNhoTrongs.Remove(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<BoNhoTrong> GetAllBoNhoTrongs()
    {
        return _dbContext.BoNhoTrongs.ToList();
    }

    public BoNhoTrong GetBoNhoTrongsById(Guid id)
    {
        return _dbContext.BoNhoTrongs.FirstOrDefault(p => p.Id == id);
    }

    public List<BoNhoTrong> GetBoNhoTrongsByName(string name)
    {
        return _dbContext.BoNhoTrongs.Where(p => p.Ten.Contains(name)).ToList();
    }

    public bool UpdateChatLieu(BoNhoTrong p)
    {
        try
        {
            var a = _dbContext.BoNhoTrongs.Find(p.Id);
            a.Ten = p.Ten;
            _dbContext.BoNhoTrongs.Update(a);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}