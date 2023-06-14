using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatLieuController : ControllerBase
{
    public readonly IChatLieuServices ChatLieuServices;
    public ChatLieuController()
    {
        ChatLieuServices = new ChatLieuServices();
    }

    // GET: api/<GiamGiaController>
    [HttpGet("get-all-MaChatLieu")]
    public List<ChatLieu> Get()
    {
        return ChatLieuServices.GetAllChatLieus();
    }


    [HttpPost("create-ChatLieu")]
    public bool Create(string ten)
    {
        ChatLieu a = new ChatLieu()
        {
            Id = Guid.NewGuid(),
            Ten = ten,

        };
        return ChatLieuServices.CreateChatLieu(a);
    }


    [HttpPut("update-ChatLieu-{id}")]
    public bool update(Guid id, string ten)
    {
        ChatLieu a = new ChatLieu()
        {
            Id = id,
            Ten = ten,
        };
        return ChatLieuServices.UpdateChatLieu(a);
    }

    // DELETE api/<GiamGiaController>/5
    [HttpDelete("delete-ChatLieu-{id}")]
    public bool Delete(Guid id)
    {
        return ChatLieuServices.DeleteChatLieu(id);
    }
}