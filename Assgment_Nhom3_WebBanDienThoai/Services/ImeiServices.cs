using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class ImeiServices : IImeiServices
{
    private ShoppingDbContext _dbContext;

    public ImeiServices()
    {
        _dbContext = new ShoppingDbContext();
    }

    public bool Create(Imei obj)
    {
        try
        {
            var x = obj;
            _dbContext.Imeis.Add(obj);
            _dbContext.SaveChanges();
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
            var obj = _dbContext.Imeis.FirstOrDefault(x => x.Id == id);
            _dbContext.Imeis.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<Imei> GetAll()
    {
        return _dbContext.Imeis.ToList();
    }

    public bool Update(Imei obj)
    {
        try
        {
            var a = _dbContext.Imeis.Find(obj.Id);
            a.imei = obj.imei;
            a.TrangThai = obj.TrangThai;
            a.IdCtsp = obj.IdCtsp;
            _dbContext.Imeis.Update(a);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}