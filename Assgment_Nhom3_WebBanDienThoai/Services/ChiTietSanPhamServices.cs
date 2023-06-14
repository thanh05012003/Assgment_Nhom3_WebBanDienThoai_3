using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class ChiTietSanPhamServices : IChiTietSanPhamServices
{
    private ShoppingDbContext _dbContext;

    public ChiTietSanPhamServices()
    {
        _dbContext = new ShoppingDbContext();
    }

    public bool Create(ChiTietSanPham obj)
    {
        try
        {
            _dbContext.ChiTietSanPhams.Add(obj);
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
            var obj = _dbContext.ChiTietSanPhams.FirstOrDefault(x => x.Id == id);
            _dbContext.ChiTietSanPhams.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public List<ChiTietSanPham> GetAll()
    {
        return _dbContext.ChiTietSanPhams.ToList();
    }

    public ChiTietSanPham GetById(Guid id)
    {
        return _dbContext.ChiTietSanPhams.FirstOrDefault(p => p.Id == id);
    }

    public bool Update(ChiTietSanPham obj)
    {
        try
        {
            var x = _dbContext.ChiTietSanPhams.Find(obj.Id);
            x.IdSanPham = obj.IdSanPham;
            x.IdGiamGia = obj.IdGiamGia;
            x.IdChatLieu = obj.IdChatLieu;
            x.IdBoNhoTrong = obj.IdBoNhoTrong;
            x.IdHeDieuHanh = obj.IdHeDieuHanh;
            x.IdCongSac = obj.IdCongSac;
            x.IdPin = obj.IdPin;
            x.IdSim = obj.IdSim;
            x.IdRam = obj.IdRam;
            x.IdChipCPU = obj.IdChipCPU;
            x.IdChipGPU = obj.IdChipGPU;
            x.IdMauSac = obj.IdMauSac;
            x.TrongLuong = obj.TrongLuong;
            x.CameraSau = obj.CameraSau;
            x.CameraTruoc = obj.CameraTruoc;
            x.DoPhanGiaiManHinh = obj.DoPhanGiaiManHinh;
            x.KichThuoc = obj.KichThuoc;
            x.DonGia = obj.DonGia;
            x.TrangThai = obj.TrangThai;
            _dbContext.ChiTietSanPhams.Update(x);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}