using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private ApiService _apiService = new();
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        public SanPhamController()
        {

        }
        public async Task<IActionResult> Index()
        {
            ViewBag.domain = domain;
            client.BaseAddress = new Uri(domain);
            string datajson = await client.GetStringAsync("api/SanPham/get-all-sanpham");
            List<SanPham> sp = JsonConvert.DeserializeObject<List<SanPham>>(datajson);
            return View(sp);
        }

        public async Task<IActionResult> Create()
        {
            client.BaseAddress = new Uri(domain);
            string nhaSanXuat = await client.GetStringAsync("api/NhaSanXuat/get-all-nhasanxuat");
            List<NhaSanXuat> nsx = JsonConvert.DeserializeObject<List<NhaSanXuat>>(nhaSanXuat);
            ViewBag.IdHsx = new SelectList(nsx, "Id", "Ten");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SanPham sp, IFormFile file)
        {
            if (file != null && file.Length > 0) // khong null va khong trong 
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                sp.Anh = "~/img/" + fileName;
            }
            var requestUrl = $"https://localhost:7151/api/SanPham/create-SanPhams";
            var jsonData = JsonConvert.SerializeObject(sp);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return BadRequest(response.Content.ReadAsStringAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            client.BaseAddress = new Uri(domain);

            string nhaSanXuat = await client.GetStringAsync("api/NhaSanXuat/get-all-nhasanxuat");
            List<NhaSanXuat> nsx = JsonConvert.DeserializeObject<List<NhaSanXuat>>(nhaSanXuat);
            ViewBag.IdHsx = new SelectList(nsx, "Id", "Ten");

            var datajson = await client.GetStringAsync($"api/SanPham/{id}");
            var sp = JsonConvert.DeserializeObject<SanPham>(datajson);
            return View(sp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, SanPham sp, IFormFile file)
        {
            if (file != null && file.Length > 0) // khong null va khong trong 
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                sp.Anh = "/img/" + fileName;
            }
            var requestUrl = $"https://localhost:7151/api/SanPham/update-SanPham-{id}";
            var jsonData = JsonConvert.SerializeObject(sp);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(requestUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return BadRequest(response.Content.ReadAsStringAsync());
        }


    }
}
