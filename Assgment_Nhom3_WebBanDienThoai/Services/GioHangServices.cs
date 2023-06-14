using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class GioHangServices : IGioHangServices
{
    private ShoppingDbContext _context;

    public GioHangServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool Create(GioHang obj)
    {
        try
        {
            _context.GioHangs.Add(obj);
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
            var obj = _context.GioHangs.FirstOrDefault(x => x.IdTaiKhoan == id);
            _context.GioHangs.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<GioHang> GetAll()
    {
        return _context.GioHangs.ToList();
    }

    public bool Update(GioHang obj)
    {
        throw new NotImplementedException();
    }

    public GioHang GetCartById(Guid id)
    {
        return _context.GioHangs.FirstOrDefault(p => p.IdTaiKhoan == id);
    }
}