using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SanPhamController : ControllerBase
{
    private ISanPhamServices sanPhamServices;

    public SanPhamController()
    {
        sanPhamServices = new SanPhamServices();
    }

    // GET: api/<SanPhamController>
    [HttpGet("get-all-sanpham")]
    public IEnumerable<SanPham> Get()
    {
        return sanPhamServices.GetAll();
    }

    // GET api/<SanPhamController>/5
    [HttpGet("{id}")]
    public SanPham Get(Guid id)
    {
        return sanPhamServices.GetSanPhamById(id);
    }

    // POST api/<SanPhamController>
    [HttpPost("create-SanPhams")]
    public bool createSanPham(SanPham a)
    {
        var sp = new SanPham()
        {
            Id = Guid.NewGuid(),
            TenSp = a.TenSp,
            MoTa = a.MoTa,
            Anh = a.Anh,
            IdHsx = a.IdHsx
        };
        return sanPhamServices.createSanPham(sp);
    }

    // PUT api/<SanPhamController>/5
    [HttpPut("update-SanPham-{id}")]
    public bool Put(Guid id, SanPham a)
    {
        var sp = new SanPham()
        {
            Id = id,
            TenSp = a.TenSp,
            MoTa = a.MoTa,
            Anh = a.Anh,
            IdHsx = a.IdHsx
        };
        return sanPhamServices.updateSanPham(sp);
    }

    // DELETE api/<SanPhamController>/5
    [HttpDelete("delete-SanPham-{id}")]
    public bool Delete(Guid id)
    {
        return sanPhamServices.deleteSanPham(id);
    }
}