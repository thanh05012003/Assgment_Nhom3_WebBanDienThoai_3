using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PinController : ControllerBase
{
    private readonly IPinServices _pinService;
    private ShoppingDbContext context = new();

    public PinController()
    {
        _pinService = new PinServices();
    }

    // GET: api/<PinController>
    [HttpGet("Get-all-pin")]
    public IEnumerable<Pin> GetAllPin()
    {
        return _pinService.GetAllPins();
    }

    // GET api/<PinController>/5
    [HttpPost("CreatePin")]
    public bool CreatePin(string ten)
    {
        var pin = new Pin();
        pin.Id = Guid.NewGuid();
        pin.Ten = ten;
        return _pinService.CreatePin(pin);
    }

    // POST api/<PinController>
    [HttpPut("UpdatePin")]
    public bool Post(Guid id, string ten)
    {
        var pin = new Pin();
        pin.Id = id;
        pin.Ten = ten;
        return _pinService.UpdatePin(pin);
    }

    // PUT api/<PinController>/5
    [HttpDelete("DeletePin")]
    public bool Put(Guid id)
    {
        return _pinService.DeletePin(id);
    }

    // DELETE api/<PinController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}