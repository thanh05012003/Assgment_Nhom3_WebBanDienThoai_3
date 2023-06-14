using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class PhanQuyenServices : IPhanQuyenServices
{
    private ShoppingDbContext _context;

    public PhanQuyenServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool CreateQuyen(PhanQuyen p)
    {
        try
        {
            _context.PhanQuyens.Add(p);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool UpdateQuyen(PhanQuyen p)
    {
        try
        {
            var quyen = _context.PhanQuyens.Find(p.Id);
            quyen.TenQuyen = p.TenQuyen;
            quyen.TrangThai = p.TrangThai;
            _context.PhanQuyens.Update(p);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool DeleteQuyen(Guid id)
    {
        try
        {
            var quyen = _context.PhanQuyens.Find(id);
            _context.Remove(quyen);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<PhanQuyen> GetAllQuyens()
    {
        return _context.PhanQuyens.ToList();
    }

    public PhanQuyen GetQuyensById(Guid id)
    {
        return _context.PhanQuyens.Find(id);
    }

    public List<PhanQuyen> GetQuyenByName(string name)
    {
        return _context.PhanQuyens.Where(c => c.TenQuyen.ToLower() == name.ToLower()).ToList();
    }
}