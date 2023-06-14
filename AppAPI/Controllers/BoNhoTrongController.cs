using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoNhoTrongController : ControllerBase
{
   
        public readonly IBoNhoTrongServices BoNhoTrongServices;
        public BoNhoTrongController()
        {
            BoNhoTrongServices = new BoNhoTrongServices();
        }

        // GET: api/<GiamGiaController>
        [HttpGet("get-all-BoNhoTrong")]
        public List<BoNhoTrong> Get()
        {
            return BoNhoTrongServices.GetAllBoNhoTrongs();
        }

        // GET api/<GiamGiaController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<GiamGiaController>
        [HttpPost("create-BoNhoTrong")]
        public bool Create(string ten)
        {
            BoNhoTrong a = new BoNhoTrong()
            {
                Id = Guid.NewGuid(),
                Ten = ten,
            };
            return BoNhoTrongServices.CreateBoNhoTrong(a);
        }

        // PUT api/<GiamGiaController>/5
        [HttpPut("update-BoNhoTrong-{id}")]
        public bool update(Guid id, string ten)
        {
            BoNhoTrong a = new BoNhoTrong()
            {
                Id = id,
                Ten = ten,
            };
            return BoNhoTrongServices.UpdateChatLieu(a);
        }

        // DELETE api/<GiamGiaController>/5
        [HttpDelete("delete-BoNhoTrong-{id}")]
        public bool Delete(Guid id)
        {
            return BoNhoTrongServices.DeleteChatLieu(id);
        }
}