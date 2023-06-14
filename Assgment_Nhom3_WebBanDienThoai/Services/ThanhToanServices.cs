using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class ThanhToanServices : IThanhToanServices
{
    private ShoppingDbContext _context;

    public ThanhToanServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool CreateThanhToan(ThanhToan tt)
    {
        try
        {
            _context.ThanhToans.Add(tt);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteThanhToan(Guid id)
    {
        var obj = _context.ThanhToans.FirstOrDefault(x => x.Id == id);
        _context.ThanhToans.Remove(obj);
        _context.SaveChanges();
        return true;
    }

    public List<ThanhToan> GetAll()
    {
        return _context.ThanhToans.ToList();
    }

    public bool UpdateThanhToan(ThanhToan tt)
    {
        try
        {
            var x = _context.ThanhToans.Find(tt.Id);
            x.TenPhuongThuc = tt.TenPhuongThuc;
            x.MaSoThe = tt.MaSoThe;
            x.NgayHetHan = DateTime.Now;
            x.MaCvv = tt.MaCvv;
            _context.ThanhToans.Update(x);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}