using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ThanhToanController : ControllerBase
{
    // GET: api/<ValuesController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}
    public IThanhToanServices ttServices;

    public ThanhToanController()
    {
        ttServices = new ThanhToanServices();
    }

    // GET api/<ValuesController>/5
    [HttpGet("get-all-tt")]
    public List<ThanhToan> Getall()
    {
        return ttServices.GetAll();
    }

    // POST api/<ValuesController>
    [HttpPost("create-thanhtoan")]
    public bool Create(string tenpt, string mst, DateTime ngayhh, int Mavcvv)
    {
        var a = new ThanhToan()
        {
            Id = Guid.NewGuid(),
            TenPhuongThuc = tenpt,
            MaSoThe = mst,
            NgayHetHan = ngayhh,
            MaCvv = Mavcvv
        };
        return ttServices.CreateThanhToan(a);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("update-tt-{id}")]
    public bool update(Guid id, [FromBody] string tenpt, string mst, DateTime ngayhh, int Mavcvv)
    {
        var a = new ThanhToan()
        {
            Id = id,
            TenPhuongThuc = tenpt,
            MaSoThe = mst,
            NgayHetHan = ngayhh,
            MaCvv = Mavcvv
        };
        return ttServices.UpdateThanhToan(a);
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("delete-tt-{id}")]
    public bool Delete(Guid id)
    {
        return ttServices.DeleteThanhToan(id);
    }
}