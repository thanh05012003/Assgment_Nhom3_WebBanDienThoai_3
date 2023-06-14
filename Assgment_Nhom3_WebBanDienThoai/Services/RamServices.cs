using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class RamServices : IRamServices
{
    private readonly ShoppingDbContext _dbContext;

    public RamServices()
    {
        _dbContext = new ShoppingDbContext();
    }

    public bool CreateRam(Ram p)
    {
        try
        {
            _dbContext.Rams.Add(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteRam(Guid id)
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

    public List<Ram> GetAllRams()
    {
        return _dbContext.Rams.ToList();
    }

    public Ram GetRamsById(Guid id)
    {
        return _dbContext.Rams.FirstOrDefault(p => p.Id == id);
    }

    public bool UpdateRam(Ram p)
    {
        try
        {
            var a = _dbContext.Rams.Find(p.Id);
            a.Ten = p.Ten;


            _dbContext.Rams.Update(a);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<Ram> GetRamsByName(string name)
    {
        return _dbContext.Rams.Where(p => p.Ten.Contains(name)).ToList();
    }
}