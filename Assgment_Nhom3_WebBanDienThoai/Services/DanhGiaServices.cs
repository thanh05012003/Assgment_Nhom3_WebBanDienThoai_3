using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class DanhGiaServices : IDanhGiaServices
{
    private ShoppingDbContext _context;

    public DanhGiaServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool Create(DanhGia obj)
    {
        try
        {
            _context.DanhGias.Add(obj);
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
            var obj = _context.DanhGias.FirstOrDefault(x => x.Id == id);
            _context.DanhGias.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Update(DanhGia obj)
    {
        try
        {
            var dg = _context.DanhGias.FirstOrDefault(x => x.Id == obj.Id);
            dg.IdSpct = obj.IdSpct;
            dg.IdTaiKhoan = obj.IdTaiKhoan;
            dg.NgayDanhGia = obj.NgayDanhGia;
            dg.NoiDung = obj.NoiDung;
            _context.DanhGias.Update(dg);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<DanhGia> GetAll()
    {
        return _context.DanhGias.ToList();
    }
}