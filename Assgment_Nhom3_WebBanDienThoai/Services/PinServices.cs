using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class PinServices : IPinServices
{
    private readonly ShoppingDbContext _dbContext;

    public PinServices()
    {
        _dbContext = new ShoppingDbContext();
    }

    public bool CreatePin(Pin p)
    {
        try
        {
            _dbContext.Pins.Add(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeletePin(Guid id)
    {
        try
        {
            var p = _dbContext.Pins.Find(id);
            _dbContext.Pins.Remove(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    public List<Pin> GetAllPins()
    {
        return _dbContext.Pins.ToList();
    }

    public Pin GetPinsById(Guid id)
    {
        return _dbContext.Pins.FirstOrDefault(p => p.Id == id);
    }

    public List<Pin> GetPinsByName(string name)
    {
        return _dbContext.Pins.Where(p => p.Ten.Contains(name)).ToList();
    }

    public bool UpdatePin(Pin p)
    {
        try
        {
            var a = _dbContext.Pins.Find(p);
            _dbContext.Pins.Update(p);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}