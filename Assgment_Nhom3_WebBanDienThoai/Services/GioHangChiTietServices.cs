using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class GioHangChiTietServices : IGioHangChiTietServices
{
    private ShoppingDbContext _context;

    public GioHangChiTietServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool Create(GioHangChiTiet obj)
    {
        try
        {
            _context.GioHangChiTiets.Add(obj);
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
            var obj = _context.GioHangChiTiets.FirstOrDefault(x => x.Id == id);
            _context.GioHangChiTiets.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<GioHangChiTiet> GetAll()
    {
        return _context.GioHangChiTiets.ToList();
    }

    public bool Update(GioHangChiTiet obj)
    {
        try
        {
            var x = _context.GioHangChiTiets.Find(obj.Id);
            x.IdTaiKhoan = obj.IdTaiKhoan;
            x.IdChiTietSp = obj.IdChiTietSp;
            x.SoLuong = obj.SoLuong;
            x.TrangThai = obj.TrangThai;
            _context.GioHangChiTiets.Update(x);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}