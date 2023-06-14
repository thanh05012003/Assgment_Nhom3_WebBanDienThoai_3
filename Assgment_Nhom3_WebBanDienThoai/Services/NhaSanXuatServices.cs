using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class NhaSanXuatServices : INhaSanXuatServices
{
    private ShoppingDbContext _context;

    public NhaSanXuatServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool createNhaSanXuat(NhaSanXuat obj)
    {
        try
        {
            _context.NhaSanXuats.Add(obj);
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
            var obj = _context.NhaSanXuats.FirstOrDefault(x => x.Id == id);
            _context.NhaSanXuats.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool updateNhaSanXuat(NhaSanXuat obj)
    {
        try
        {
            var nsx = _context.NhaSanXuats.Find(obj.Id);
            nsx.Ten = obj.Ten;
            _context.NhaSanXuats.Update(nsx);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<NhaSanXuat> GetAll()
    {
        return _context.NhaSanXuats.ToList();
    }

    public NhaSanXuat GetNhaSanXuatByName(string ten)
    {
        return _context.NhaSanXuats.FirstOrDefault(c => c.Ten == ten);
    }

    public NhaSanXuat GetNhaSanXuatById(Guid id)
    {
        return _context.NhaSanXuats.FirstOrDefault(c => c.Id == id);
    }
}