using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RamController : ControllerBase
{
    public readonly IRamServices _ramServices;

    public RamController()
    {
        _ramServices = new RamServices();
    }

    // GET: api/<GiamGiaController>
    [HttpGet("get-all-Ram")]
    public List<Ram> Get()
    {
        return _ramServices.GetAllRams();
    }


    [HttpPost("create-Ram")]
    public bool Create(string ten)
    {
        var a = new Ram()
        {
            Id = Guid.NewGuid(),
            Ten = ten
        };
        return _ramServices.CreateRam(a);
    }

    [HttpPut("update-Ram-{id}")]
    public bool update(Guid id, string ten)
    {
        var a = new Ram()
        {
            Id = id,
            Ten = ten
        };
        return _ramServices.UpdateRam(a);
    }

    // DELETE api/<GiamGiaController>/5
    [HttpDelete("delete-Ram-{id}")]
    public bool Delete(Guid id)
    {
        return _ramServices.DeleteRam(id);
    }
}