using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListAnhController : ControllerBase
    {
        IListAnhServices listAnhServices;
        public ListAnhController()
        {
            listAnhServices = new ListServices();
        }
        // GET: api/<ListAnhController>
        [HttpGet("all-Anh")]
        public List<ListAnh> Get()
        {
            return listAnhServices.GetAnhList();
        }

        // GET api/<ListAnhController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ListAnhController>
        [HttpPost("create-Anh")]
        public bool Post(ListAnh anh)
        {
            ListAnh a = new ListAnh() 
            { 
                Id = Guid.NewGuid(),
                IdCtsp = anh.IdCtsp,
                Anh = anh.Anh,
                Anh1 = anh.Anh1,
                Anh2 = anh.Anh2,
                Anh3 = anh.Anh3
            };
            return listAnhServices.Create(a);
        }

        // PUT api/<ListAnhController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListAnhController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
