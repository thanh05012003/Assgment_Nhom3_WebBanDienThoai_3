using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class ChipCPUServices : IChipCPUServices
{
    private ShoppingDbContext _context;

    public ChipCPUServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool Create(ChipCPU obj)
    {
        try
        {
            _context.ChipCPUs.Add(obj);
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
            var obj = _context.ChipCPUs.FirstOrDefault(x => x.Id == id);
            _context.ChipCPUs.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<ChipCPU> GetAll()
    {
        return _context.ChipCPUs.ToList();
    }

    public ChipCPU GetChipCPUById(Guid id)
    {
        return _context.ChipCPUs.FirstOrDefault(c => c.Id == id);
    }

    public bool Update(ChipCPU obj)
    {
        try
        {
            var x = _context.ChipCPUs.Find(obj.Id);
            x.Ten = obj.Ten;
            _context.ChipCPUs.Update(x);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}