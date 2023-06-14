using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class SimServices : ISimServices
{
    private ShoppingDbContext _context;

    public SimServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool Create(Sim obj)
    {
        try
        {
            _context.Sims.Add(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Delete(Guid id)
    {
        try
        {
            var obj = _context.Sims.FirstOrDefault(x => x.Id == id);
            _context.Sims.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<Sim> GetAll()
    {
        return _context.Sims.ToList();
    }

    public bool Update(Sim obj)
    {
        try
        {
            var sim = _context.Sims.Find(obj.Id);
            sim.Ten = obj.Ten;
            _context.Sims.Update(sim);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}