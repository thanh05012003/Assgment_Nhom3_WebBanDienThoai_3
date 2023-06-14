using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChiTietSanPhamController : ControllerBase
{
    public IChiTietSanPhamServices chiTietSanPhamServices;

    public ChiTietSanPhamController()
    {
        chiTietSanPhamServices = new ChiTietSanPhamServices();
    }
    // GET: api/<ChiTietSanPhamController>
    [HttpGet("get-all-thongTin-SanPham")]
    public List<ChiTietSanPham> Get()
    {
        return chiTietSanPhamServices.GetAll();
    }

    // GET api/<ChiTietSanPhamController>/5
    [HttpGet("{id}")]
    public ChiTietSanPham Get(Guid id)
    {
        return chiTietSanPhamServices.GetById(id);
    }

    // POST api/<ChiTietSanPhamController>
    [HttpPost("create-ThongTin-SanPham")]
    public bool Create(ChiTietSanPham obj)
    {
        ChiTietSanPham a = new ChiTietSanPham()
        {
            Id = Guid.NewGuid(),
            IdSanPham = obj.IdSanPham,
            IdGiamGia = obj.IdGiamGia,
            IdChatLieu = obj.IdChatLieu,
            IdBoNhoTrong = obj.IdBoNhoTrong,
            IdHeDieuHanh = obj.IdHeDieuHanh,
            IdCongSac = obj.IdCongSac,
            IdPin = obj.IdPin,
            IdSim = obj.IdSim,
            IdRam = obj.IdRam,
            IdChipCPU = obj.IdChipCPU,
            IdChipGPU = obj.IdChipGPU,
            IdMauSac = obj.IdMauSac,
            TrongLuong = obj.TrongLuong,
            CameraTruoc = obj.CameraTruoc,
            CameraSau = obj.CameraSau,
            DoPhanGiaiManHinh = obj.DoPhanGiaiManHinh,
            KichThuoc = obj.KichThuoc,
            DonGia = obj.DonGia,
            TrangThai = obj.TrangThai
        };
        return chiTietSanPhamServices.Create(a);
    }

    // PUT api/<ChiTietSanPhamController>/5
    [HttpPut("update-ThongTinSanPham-{id}")]
    public bool update(Guid id, ChiTietSanPham obj)
    {
        ChiTietSanPham a = new ChiTietSanPham()
        {
            Id = id,
            IdSanPham = obj.IdSanPham,
            IdGiamGia = obj.IdGiamGia,
            IdChatLieu = obj.IdChatLieu,
            IdBoNhoTrong = obj.IdBoNhoTrong,
            IdHeDieuHanh = obj.IdHeDieuHanh,
            IdCongSac = obj.IdCongSac,
            IdPin = obj.IdPin,
            IdSim = obj.IdSim,
            IdRam = obj.IdRam,
            IdChipCPU = obj.IdChipCPU,
            IdChipGPU = obj.IdChipGPU,
            IdMauSac = obj.IdMauSac,
            TrongLuong = obj.TrongLuong,
            CameraTruoc = obj.CameraTruoc,
            CameraSau = obj.CameraSau,
            DoPhanGiaiManHinh = obj.DoPhanGiaiManHinh,
            KichThuoc = obj.KichThuoc,
            DonGia = obj.DonGia,
            TrangThai = obj.TrangThai
        };
        return chiTietSanPhamServices.Update(a);
    }

    // DELETE api/<ChiTietSanPhamController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}