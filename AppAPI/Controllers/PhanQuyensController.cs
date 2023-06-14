using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhanQuyensController : ControllerBase
{
    private IPhanQuyenServices _phanQuyenServices;

    public PhanQuyensController()
    {
        _phanQuyenServices = new PhanQuyenServices();
    }

    // GET: api/<PhanQuyensController>
    [HttpGet]
    public IEnumerable<PhanQuyen> Get()
    {
        return _phanQuyenServices.GetAllQuyens();
    }

    // GET api/<PhanQuyensController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PhanQuyensController>
    [HttpPost]
    public bool CreateQuyen(string ten, int trangThai)
    {
        var pq = new PhanQuyen()
        {
            Id = Guid.NewGuid(),
            TenQuyen = ten,
            TrangThai = trangThai
        };
        return _phanQuyenServices.CreateQuyen(pq);
    }

    // PUT api/<PhanQuyensController>/5
    [HttpPut("{id}")]
    public bool UpdateQuyens(Guid id, string ten, int trangThai)
    {
        var pq = _phanQuyenServices.GetQuyensById(id);
        pq.TenQuyen = ten;
        pq.TrangThai = trangThai;
        return _phanQuyenServices.UpdateQuyen(pq);
    }

    // DELETE api/<PhanQuyensController>/5
    [HttpDelete("{id}")]
    public bool Delete(Guid id)
    {
        return _phanQuyenServices.DeleteQuyen(id);
    }
}