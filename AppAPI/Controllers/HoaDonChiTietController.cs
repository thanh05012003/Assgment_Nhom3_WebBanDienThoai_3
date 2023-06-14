using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HoaDonChiTietController : ControllerBase
{
    private readonly IHoaDonChiTietServices _hoaDonChiTiet;
    private ShoppingDbContext context = new();

    public HoaDonChiTietController()
    {
        _hoaDonChiTiet = new HoaDonChiTietServices();
    }

    // GET: api/<HoaDonChiTietController>
    [HttpGet("Get-all-hoaDonChiTiet")]
    public IEnumerable<HoaDonChiTiet> GetAll()
    {
        return _hoaDonChiTiet.GetAllHoaDonChiTiets();
    }

    // GET api/<HoaDonChiTietController>/5
    [HttpPost("Create-HoaDonChiTiet")]
    public bool CreateHoaDonChiTiet(Guid IdHoaDon, Guid IdChiTietSp, int SoLuong, decimal Gia, int TrangThai)
    {
        var hoaDonChiTiet = new HoaDonChiTiet();
        hoaDonChiTiet.Id = Guid.NewGuid();
        hoaDonChiTiet.IdHoaDon = IdHoaDon;
        hoaDonChiTiet.IdChiTietSp = IdChiTietSp;
        hoaDonChiTiet.SoLuong = SoLuong;
        hoaDonChiTiet.TrangThai = TrangThai;

        hoaDonChiTiet.Gia = Gia;

        return _hoaDonChiTiet.CreateHoaDonChiTiet(hoaDonChiTiet);
    }

    // POST api/<HoaDonChiTietController>
    [HttpDelete("Delete-HoaDonChiTiet-{id}")]
    public bool Post(Guid id)
    {
        return _hoaDonChiTiet.DeleteHoaDonChiTiet(id);
    }

    // PUT api/<HoaDonChiTietController>/5
    [HttpPut("Update-HoaDonChiTiet-{id}")]
    public bool Put(Guid id, Guid IdHoaDon, Guid IdChiTietSp, int SoLuong, long Gia, int TrangThai)
    {
        var hoaDonChiTiet = new HoaDonChiTiet();
        hoaDonChiTiet.Id = id;
        hoaDonChiTiet.IdHoaDon = IdHoaDon;
        hoaDonChiTiet.IdChiTietSp = IdChiTietSp;
        hoaDonChiTiet.SoLuong = SoLuong;
        hoaDonChiTiet.TrangThai = TrangThai;
        hoaDonChiTiet.Gia = Gia;
        return _hoaDonChiTiet.UpdateHoaDonChiTiet(hoaDonChiTiet);
    }

    // DELETE api/<HoaDonChiTietController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}