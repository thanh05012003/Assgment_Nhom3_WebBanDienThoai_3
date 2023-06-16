using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class HoaDonServices : IHoaDonServices
{
    private ShoppingDbContext _context;

    public HoaDonServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool CreateHoaDon(HoaDon ms)
    {
        try
        {
            ms.Id = Guid.NewGuid();
            _context.HoaDons.Add(ms);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool DeleteHoaDon(Guid id)
    {
        try
        {
            var obj = _context.HoaDons.FirstOrDefault(x => x.Id == id);
            _context.HoaDons.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public IEnumerable<HoaDon> GetAllHoaDons()
    {
        return _context.HoaDons.ToList();
    }

    public HoaDon GetHoaDonsById(Guid id)
    {
        return _context.HoaDons.FirstOrDefault(c => c.Id == id);
    }

    public List<HoaDon> GetHoaDonsByName(string name)
    {
        return _context.HoaDons.Where(c => c.HoVaTen == name).ToList();
    }

    public bool UpdateHoaDon(HoaDon ms)
    {
        try
        {
            _context.HoaDons.Update(ms);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}