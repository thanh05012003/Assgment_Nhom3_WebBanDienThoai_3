using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HinhThucThanhToanController : ControllerBase
{
    // GET: api/<ValuesController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}
    public IHinhThucThanhToanServices ttServices;

    public HinhThucThanhToanController()
    {
        ttServices = new HinhThucThanhToanServices();
    }

    // GET api/<ValuesController>/5
    [HttpGet("get-all-httt")]
    public List<HinhThucThanhToan> Getall()
    {
        return ttServices.GetAll();
    }

    // POST api/<ValuesController>
    [HttpPost("create-htthanhtoan")]
    public bool Create(string tenpt, decimal tongtien, int trangthai)
    {
        var a = new HinhThucThanhToan()
        {
            Id = Guid.NewGuid(),
            TenPhuongThuc = tenpt,
            TongTien = tongtien,
            TrangThai = trangthai,
            IdThanhToan = Guid.NewGuid(),
            IdHd = Guid.NewGuid()
        };
        return ttServices.Create(a);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("update-httt-{id}")]
    public bool update(Guid id, Guid idtt, Guid idhd, string tenpt, decimal tongtien, int trangthai)
    {
        var a = new HinhThucThanhToan()
        {
            Id = Guid.NewGuid(),
            TenPhuongThuc = tenpt,
            TongTien = tongtien,
            TrangThai = trangthai,
            IdThanhToan = idtt,
            IdHd = idhd
        };
        return ttServices.Update(a);
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("delete-httt-{id}")]
    public bool Delete(Guid id)
    {
        return ttServices.Delete(id);
    }
}