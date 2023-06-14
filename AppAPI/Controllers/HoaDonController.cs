using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HoaDonController : ControllerBase
{
    private readonly IHoaDonServices _hoaDonServices;
    private ShoppingDbContext context = new();

    public HoaDonController()
    {
        _hoaDonServices = new HoaDonServices();
    }

    // GET: api/<ValuesController>
    [HttpGet("Get-all-hoaDon")]
    public IEnumerable<HoaDon> Get()
    {
        return _hoaDonServices.GetAllHoaDons();
    }

    // GET api/<ValuesController>/5
    [HttpPost("Create-HoaDon")]
    public bool CreateHoaDon(DateTime NgayTao, DateTime NgayThanhToan, string? HoVaTen, string SDT, string? DiaChi,
        decimal? TongTien, int TrangThai, Guid IdThanhToan, Guid IdTaiKhoan)
    {
        var hoaDon = new HoaDon();
        hoaDon.Id = Guid.NewGuid();
        hoaDon.NgayTao = NgayTao;
        hoaDon.NgayThanhToan = NgayThanhToan;
        hoaDon.HoVaTen = HoVaTen;
        hoaDon.SDT = SDT;
        hoaDon.DiaChi = DiaChi;
        hoaDon.TongTien = TongTien;
        hoaDon.TrangThai = TrangThai;
        hoaDon.IdTaiKhoan = IdTaiKhoan;
        hoaDon.IdThanhToan = IdThanhToan;
        return _hoaDonServices.CreateHoaDon(hoaDon);
    }

    // POST api/<ValuesController>
    [HttpDelete("Delete-HoaDon-{id}")]
    public bool Post(Guid id)
    {
        return _hoaDonServices.DeleteHoaDon(id);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("Update-HoaDon-{id}")]
    public bool Put(Guid id, DateTime NgayTao, DateTime NgayThanhToan, string? HoVaTen, string SDT, string? DiaChi,
        decimal? TongTien, int TrangThai, Guid IdThanhToan, Guid IdTaiKhoan)
    {
        var hoaDon = new HoaDon();
        hoaDon.Id = id;
        hoaDon.NgayTao = NgayTao;
        hoaDon.NgayThanhToan = NgayThanhToan;
        hoaDon.HoVaTen = HoVaTen;
        hoaDon.SDT = SDT;
        hoaDon.DiaChi = DiaChi;
        hoaDon.TongTien = TongTien;
        hoaDon.TrangThai = TrangThai;
        hoaDon.IdTaiKhoan = IdTaiKhoan;
        hoaDon.IdThanhToan = IdThanhToan;
        return _hoaDonServices.UpdateHoaDon(hoaDon);
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}