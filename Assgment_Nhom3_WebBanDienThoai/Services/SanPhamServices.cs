using System.Diagnostics.Eventing.Reader;
using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class SanPhamServices : ISanPhamServices
{
    private ShoppingDbContext _context;

    public SanPhamServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool createSanPham(SanPham obj)
    {
        try
        {
            _context.SanPhams.Add(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool deleteSanPham(Guid id)
    {
        try
        {
            var obj = _context.SanPhams.FirstOrDefault(x => x.Id == id);
            _context.SanPhams.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool updateSanPham(SanPham obj)
    {
        try
        {
            _context.SanPhams.Update(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<SanPham> GetAll()
    {
        return _context.SanPhams.ToList();
    }

    public SanPham GetSanPhamById(Guid id)
    {
        return _context.SanPhams.FirstOrDefault(c => c.Id == id);
    }

    public List<SanPham> GetSanPhamByName(string name)
    {
        return _context.SanPhams.Where(c => c.TenSp == name).ToList();
    }
}