using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GioHangController : ControllerBase
{
    // GET: api/<GioHangController>
    public readonly IGioHangServices gioHangServices;

    public GioHangController()
    {
        gioHangServices = new GioHangServices();
    }

    // GET api/<GioHangController>/5
    [HttpGet("{get-all-GioHang}")]
    public List<GioHang> Get()
    {
        return gioHangServices.GetAll();
    }

    // POST api/<GioHangController>
    [HttpPost]
    [HttpPost("create-GioHang")]
    public bool Create(Guid idtaikhoan, string mota)
    {
        var a = new GioHang()
        {
            IdTaiKhoan = idtaikhoan,
            Mota = mota
        };
        return gioHangServices.Create(a);
    }
}