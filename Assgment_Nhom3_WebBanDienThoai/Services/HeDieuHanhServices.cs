using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class HeDieuHanhServices : IHeDieuHanhServices
{
    private readonly ShoppingDbContext _dbContext;

    public HeDieuHanhServices()
    {
        _dbContext = new ShoppingDbContext();
    }

    public bool CreateHeDieuHanh(HeDieuHanh p)
    {
        try
        {
            _dbContext.HeDieuHanhs.Add(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteHeDieuHanh(Guid id)
    {
        try
        {
            var p = _dbContext.HeDieuHanhs.Find(id);
            _dbContext.HeDieuHanhs.Remove(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<HeDieuHanh> GetHeDieuHanhs()
    {
        return _dbContext.HeDieuHanhs.ToList();
    }

    public List<HeDieuHanh> GetHeDieuHanhsByName(string name)
    {
        return _dbContext.HeDieuHanhs.Where(p => p.Ten.Contains(name)).ToList();
    }

    public HeDieuHanh GetHeDieuHanhTrongsById(Guid id)
    {
        return _dbContext.HeDieuHanhs.FirstOrDefault(p => p.Id == id);
    }

    public bool UpdateHeDieuHanh(HeDieuHanh p)
    {
        try
        {
            var a = _dbContext.HeDieuHanhs.Find();
            _dbContext.HeDieuHanhs.Update(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}