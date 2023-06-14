using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class GiamGiaServices : IGiamGiaServices
{
    private ShoppingDbContext _context;

    public GiamGiaServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool Create(GiamGia obj)
    {
        try
        {
            _context.GiamGias.Add(obj);
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
            var obj = _context.GiamGias.FirstOrDefault(x => x.Id == id);
            _context.GiamGias.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<GiamGia> GetAll()
    {
        return _context.GiamGias.ToList();
    }

    public GiamGia GetById(Guid id)
    {
        return _context.GiamGias.FirstOrDefault(p => p.Id == id);
    }

    public bool Update(GiamGia obj)
    {
        try
        {
            var x = _context.GiamGias.Find(obj.Id);
            x.SoPhanTramGiam = obj.SoPhanTramGiam;
            x.NgayBatDau = obj.NgayBatDau;
            x.NgayKetThuc = obj.NgayKetThuc;
            x.GhiChu = obj.GhiChu;
            x.TrangThai = obj.TrangThai;
            _context.GiamGias.Update(x);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}