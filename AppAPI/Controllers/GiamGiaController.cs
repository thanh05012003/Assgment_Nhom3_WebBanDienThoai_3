using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GiamGiaController : ControllerBase
{
    public readonly IGiamGiaServices giamGiaServices;

    public GiamGiaController()
    {
        giamGiaServices = new GiamGiaServices();
    }

    // GET: api/<GiamGiaController>
    [HttpGet("get-all-MaGiamGia")]
    public List<GiamGia> Get()
    {
        return giamGiaServices.GetAll();
    }

    // GET api/<GiamGiaController>/5
    [HttpGet("{id}")]
    public GiamGia Get(Guid id)
    {
        return giamGiaServices.GetById(id);
    }

    // POST api/<GiamGiaController>
    [HttpPost("create-MaGiamGia")]
    public bool Create(GiamGia gg)
    {
        var a = new GiamGia()
        {
            Id = Guid.NewGuid(),
            SoPhanTramGiam = gg.SoPhanTramGiam,
            NgayBatDau = gg.NgayBatDau,
            NgayKetThuc = gg.NgayKetThuc,
            GhiChu = gg.GhiChu,
            TrangThai = gg.TrangThai
        };
        return giamGiaServices.Create(a);
    }

    // PUT api/<GiamGiaController>/5
    [HttpPut("update-MaGiamGia-{id}")]
    public bool update(Guid id, GiamGia gg)
    {
        var a = new GiamGia()
        {
            Id = id,
            SoPhanTramGiam = gg.SoPhanTramGiam,
            NgayBatDau = gg.NgayBatDau,
            NgayKetThuc = gg.NgayKetThuc,
            GhiChu = gg.GhiChu,
            TrangThai = gg.TrangThai
        };
        return giamGiaServices.Update(a);
    }

    // DELETE api/<GiamGiaController>/5
    [HttpDelete("delete-MaGiamGia-{id}")]
    public bool Delete(Guid id)
    {
        return giamGiaServices.Delete(id);
    }
}