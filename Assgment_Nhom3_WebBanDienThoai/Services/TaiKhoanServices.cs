using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class TaiKhoanServices : ITaiKhoanServices
{
    private ShoppingDbContext _context;

    public TaiKhoanServices()
    {
        _context = new ShoppingDbContext();
    }

    public bool CreateTaiKhoan(TaiKhoan tk)
    {
        try
        {
            tk.Id = Guid.NewGuid();
            _context.TaiKhoans.Add(tk);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool DeleteTaiKhoan(Guid id)
    {
        var obj = _context.TaiKhoans.FirstOrDefault(x => x.Id == id);
        _context.TaiKhoans.Remove(obj);
        _context.SaveChanges();
        return true;
    }

    public List<TaiKhoan> GetAll()
    {
        return _context.TaiKhoans.ToList();
    }

    public TaiKhoan GetSanPhamById(Guid id)
    {
        return _context.TaiKhoans.FirstOrDefault(c => c.Id == id);
    }

    public List<TaiKhoan> GetTaiKhoanByName(string name)
    {
        return _context.TaiKhoans.Where(c => c.TenDN == name).ToList();
    }

    public bool UpdateTaiKhoan(TaiKhoan tk)
    {
        try
        {
            var x = _context.TaiKhoans.Find(tk.Id);
            x.TenDN = tk.TenDN;
            x.MatKhau = tk.MatKhau;
            x.HoVaTen = tk.HoVaTen;
            x.Email = tk.Email;
            x.SDT = tk.SDT;
            x.DiaChi = tk.DiaChi;
            x.LinkAnh = tk.LinkAnh;
            x.TrangThai = tk.TrangThai;
            x.IdCv = tk.IdCv;
            x.GioHangs = tk.GioHangs;
            _context.TaiKhoans.Update(x);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}