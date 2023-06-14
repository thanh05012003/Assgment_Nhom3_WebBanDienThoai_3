using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeDieuHanhController : ControllerBase
{
    private readonly IHeDieuHanhServices _heDieuHanh;
    ShoppingDbContext context = new ShoppingDbContext();
    public HeDieuHanhController()
    {
        _heDieuHanh = new HeDieuHanhServices();
    }
    // GET: api/<HeDieuHanhController>
    [HttpGet("get-all-HeDieuHanh")]
    public IEnumerable<HeDieuHanh> Get()
    {
        return _heDieuHanh.GetHeDieuHanhs();
    }

    // GET api/<HeDieuHanhController>/5
    [HttpPost("Create-he-dieu-hanh")]
    public bool CreateHeDieuHanh(string name)
    {
        HeDieuHanh heDieuHanh = new HeDieuHanh();
        heDieuHanh.Id = Guid.NewGuid();
        heDieuHanh.Ten = name;
        return _heDieuHanh.CreateHeDieuHanh(heDieuHanh);
    }

    // POST api/<HeDieuHanhController>
    [HttpPut("Update-he-dieu-hanh")]
    public bool Post(Guid id, string name)
    {
        HeDieuHanh heDieuHanh = new HeDieuHanh();
        heDieuHanh.Id = id;
        heDieuHanh.Ten = name;
        return _heDieuHanh.UpdateHeDieuHanh(heDieuHanh);
    }

    // PUT api/<HeDieuHanhController>/5
    [HttpDelete("Delete-he-dieu-hanh")]
    public bool Put(Guid id)
    {
        return _heDieuHanh.DeleteHeDieuHanh(id);
    }

    // DELETE api/<HeDieuHanhController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}