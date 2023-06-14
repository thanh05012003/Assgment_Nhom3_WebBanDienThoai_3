using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaiKhoanController : ControllerBase
{
    private ITaiKhoanServices _taiKhoanServices;

    public TaiKhoanController()
    {
        _taiKhoanServices = new TaiKhoanServices();
    }

    // GET: api/<TaiKhoanController>
    [HttpGet]
    public List<TaiKhoan> Get()
    {
        return _taiKhoanServices.GetAll();
    }

    // GET api/<TaiKhoanController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<TaiKhoanController>
    [HttpPost("create-taikhoan")]
    public bool CreateTaiKhoan(TaiKhoan tk)
    {
        return _taiKhoanServices.CreateTaiKhoan(tk);
    }

    // PUT api/<TaiKhoanController>/5
    [HttpPut("update-taikhoan-{id}")]
    public bool UpdateTaiKhoan(string tendn, string matkhau, string hoten, string email, string sdt, string diachi,
        string anh, int trangthai, Guid idcv)
    {
        var tk = new TaiKhoan()
        {
            Id = Guid.NewGuid(),
            TenDN = tendn,
            MatKhau = matkhau,
            HoVaTen = hoten,
            Email = email,
            SDT = sdt,
            DiaChi = diachi,
            LinkAnh = anh,
            TrangThai = trangthai,
            IdCv = idcv
        };
        return _taiKhoanServices.UpdateTaiKhoan(tk);
    }

    // DELETE api/<TaiKhoanController>/5
    [HttpDelete("delete-taikhoan-{id}")]
    public bool DeleteTaiKhoan(Guid id)
    {
        return _taiKhoanServices.DeleteTaiKhoan(id);
    }
}