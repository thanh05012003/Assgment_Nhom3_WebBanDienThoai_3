using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class HoaDonChiTietServices : IHoaDonChiTietServices
{
    private ShoppingDbContext _context;

    public HoaDonChiTietServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool CreateHoaDonChiTiet(HoaDonChiTiet ms)
    {
        try
        {
            _context.HoaDonChiTiets.Add(ms);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool DeleteHoaDonChiTiet(Guid id)
    {
        try
        {
            var obj = _context.HoaDonChiTiets.FirstOrDefault(x => x.Id == id);
            _context.HoaDonChiTiets.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<HoaDonChiTiet> GetAllHoaDonChiTiets()
    {
        return _context.HoaDonChiTiets.ToList();
    }

    public HoaDonChiTiet GetHoaDonChiTietsById(Guid id)
    {
        return _context.HoaDonChiTiets.FirstOrDefault(c => c.Id == id);
    }

    public List<HoaDonChiTiet> GetHoaDonChiTietsByName(string name)
    {
        throw new NotImplementedException();
    }

    public bool UpdateHoaDonChiTiet(HoaDonChiTiet ms)
    {
        try
        {
            _context.HoaDonChiTiets.Update(ms);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}