using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChatLieuController : Controller
    {
        private ApiService _apiService = new();
        string domain = "https://localhost:7151/";
        private HttpClient client = new();

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            ViewBag.Domain = domain;
            client.BaseAddress = new Uri(domain);
            var datajson = await client.GetStringAsync("api/ChatLieu/get-all-ChatLieu");
            var chatlieu = JsonConvert.DeserializeObject<List<ChatLieu>>(datajson);
            return View(chatlieu);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ChatLieu chatlieu)
        {
            try
            {
                var requestUrl = "https://localhost:7151/api/ChatLieu/create-ChatLieu";
                if (await _apiService.ApiPostService(chatlieu, requestUrl)) return RedirectToAction("Index");
                return View();
            }catch (Exception ex) { return View(); }
           
        }

        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.Domain = domain;
            client.BaseAddress = new Uri(domain);
            var datajson = await client.GetStringAsync($"api/ChatLieu/update-ChatLieu-{id}");
            var chatlieu = JsonConvert.DeserializeObject<ChatLieu>(datajson);
            return View(chatlieu);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id , ChatLieu chatlieu)
        {
            var requestUrl = $"https://localhost:7151/api/ChatLieu/update-ChatLieu-{id}";
            await _apiService.ApiPutService(chatlieu , requestUrl);
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var requestUrl = $"https://localhost:7151/api/ChatLieu/delete-ChatLieu-{id}";
            await _apiService.ApiDeleteService(requestUrl);
            return RedirectToAction("Index");
        }

    }
}
