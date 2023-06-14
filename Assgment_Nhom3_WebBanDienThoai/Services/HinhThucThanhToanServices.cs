using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class HinhThucThanhToanServices : IHinhThucThanhToanServices
{
    private ShoppingDbContext _context;

    public HinhThucThanhToanServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool Create(HinhThucThanhToan obj)
    {
        try
        {
            _context.HinhThucThanhToans.Add(obj);
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
            var obj = _context.HinhThucThanhToans.Find(id);
            _context.HinhThucThanhToans.Remove(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Update(HinhThucThanhToan obj)
    {
        try
        {
            var httt = _context.HinhThucThanhToans.FirstOrDefault(c => c.Id == obj.Id);
            httt.TenPhuongThuc = obj.TenPhuongThuc;
            httt.TongTien = obj.TongTien;
            httt.IdThanhToan = obj.IdThanhToan;
            httt.IdHd = obj.IdHd;
            _context.HinhThucThanhToans.Update(obj);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<HinhThucThanhToan> GetAll()
    {
        return _context.HinhThucThanhToans.ToList();
    }
}