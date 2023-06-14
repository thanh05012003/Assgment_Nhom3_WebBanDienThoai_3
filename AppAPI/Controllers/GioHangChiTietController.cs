using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GioHangChiTietController : ControllerBase
{
    public readonly IGioHangChiTietServices gioHangServices;

    public GioHangChiTietController()
    {
        gioHangServices = new GioHangChiTietServices();
    }


    [HttpGet("get-all-GioHangChiTiet")]
    public List<GioHangChiTiet> Get()
    {
        return gioHangServices.GetAll();
    }

    // POST api/<GioHangChiTietController>
    [HttpPost("create-GioHangChiTiet")]
    public bool Create(Guid idTaiKhoan, Guid Idctsp, int soluong, int trangthai)
    {
        var car = gioHangServices.GetAll().FirstOrDefault(a => a.IdChiTietSp == Idctsp && a.IdTaiKhoan == idTaiKhoan);
        if (car == null)
        {
            var a = new GioHangChiTiet()
            {
                Id = Guid.NewGuid(),
                IdTaiKhoan = idTaiKhoan,
                IdChiTietSp = Idctsp,
                SoLuong = soluong,
                TrangThai = trangthai
            };
            return gioHangServices.Create(a);
        }
        else
        {
            var cars = gioHangServices.GetAll()
                .FirstOrDefault(a => a.IdChiTietSp == Idctsp && a.IdTaiKhoan == idTaiKhoan);
            cars.SoLuong += soluong;
            return gioHangServices.Update(cars);
        }
    }

    // PUT api/<GioHangChiTietController>/5
    [HttpPut("update-GioHangChiTiet-{id}")]
    public bool update(Guid idTaiKhoan, Guid Idctsp, int soluong, int trangthai)
    {
        var a = new GioHangChiTiet()
        {
            IdTaiKhoan = idTaiKhoan,
            IdChiTietSp = Idctsp,
            SoLuong = soluong,

            TrangThai = trangthai
        };
        return gioHangServices.Update(a);
    }

    // DELETE api/<GioHangChiTietController>/5
    [HttpDelete("delete-GioHangChiTiet-{id}")]
    public bool Delete(Guid id)
    {
        return gioHangServices.Delete(id);
    }
}