using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CongSacController : ControllerBase
{
    private ICongSacServices congSacServices;
    // GET: api/<CongSacController>

    public CongSacController()
    {
        congSacServices = new CongSacServices();
    }
    [HttpGet("get-all-congsac")]
    public List<CongSac> Get()
    {
        return congSacServices.GetAllCongSacs();
    }


    [HttpPost("create-CongSac")]
    public bool CreateCongSac(string ten)
    {
        CongSac cs = new CongSac()
        {
            Id = Guid.NewGuid(),
            Ten = ten
        };
        return congSacServices.CreateCongSac(cs);
    }

    // PUT api/<CongSacController>/5
    [HttpPut("update-congsac-{id}")]
    public bool UpdateCongSac(Guid id, [FromBody] string ten)
    {
        CongSac cs = new CongSac()
        {
            Id = id,
            Ten = ten,
        };
        return congSacServices.UpdateCongSac(cs);
    }

    // DELETE api/<CongSacController>/5
    [HttpDelete("delete-congsac-{id}")]
    public bool Delete(Guid id)
    {
        return congSacServices.DeleteCongSac(id);
    }
}