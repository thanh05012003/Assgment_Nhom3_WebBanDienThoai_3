using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DanhGiaController : ControllerBase
{
    private IDanhGiaServices _danhGiaServices;

    public DanhGiaController()
    {
        _danhGiaServices = new DanhGiaServices();
    }
    // GET: api/<DanhGiaController>
    [HttpGet]
    public IEnumerable<DanhGia> GetAll()
    {
        return _danhGiaServices.GetAll();
    }

    // GET api/<DanhGiaController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<DanhGiaController>
    [HttpPost]
    public bool CreateDanhGia(DateTime ngayDanhGia, string noiDung, Guid IdSpct, Guid IdTaiKhoan)
    {
        DanhGia dg = new DanhGia()
        {
            Id = Guid.NewGuid(),
            NgayDanhGia = ngayDanhGia,
            NoiDung = noiDung,
            IdSpct = IdSpct,
            IdTaiKhoan = IdTaiKhoan
        };
        return _danhGiaServices.Create(dg);
    }

    // PUT api/<DanhGiaController>/5
    [HttpPut("{id}")]
    public bool UpdateDanhGia(Guid id, [FromBody] DateTime ngayDanhGia, string noiDung, Guid IdSpct, Guid IdTaiKhoan)
    {
        DanhGia dg = new DanhGia()
        {
            Id = id,
            NgayDanhGia = ngayDanhGia,
            NoiDung = noiDung,
            IdSpct = IdSpct,
            IdTaiKhoan = IdTaiKhoan
        };
        return _danhGiaServices.Update(dg);
    }

    // DELETE api/<DanhGiaController>/5
    [HttpDelete("{id}")]
    public bool Delete(Guid id)
    {
        return _danhGiaServices.Delete(id);
    }
}