using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimController : ControllerBase
{
    public ISimServices simServices;

    public SimController()
    {
        simServices = new SimServices();
    }

    // GET: api/<SimController>
    [HttpGet("get-all-sim")]
    public List<Sim> Get()
    {
        return simServices.GetAll();
    }

    // GET api/<SimController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    // POST api/<SimController>
    [HttpPost("create-sim")]
    public bool Create(string ten)
    {
        var a = new Sim()
        {
            Id = Guid.NewGuid(),
            Ten = ten
        };
        return simServices.Create(a);
    }

    // PUT api/<SimController>/5
    [HttpPut("update-sim-{id}")]
    public bool Update(Guid id, [FromBody] string ten)
    {
        var a = new Sim()
        {
            Id = id,
            Ten = ten
        };
        return simServices.Update(a);
    }

    // DELETE api/<SimController>/5
    [HttpDelete("delete-sim-{id}")]
    public bool Delete(Guid id)
    {
        return simServices.Delete(id);
    }
}