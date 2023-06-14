using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers;

[Area("Admin")]
public class GiamGiaController : Controller
{
    private ApiService _apiService = new();
    private string domain = "https://localhost:7151/";
    private HttpClient client = new();

    public async Task<IActionResult> Index()
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync("api/GiamGia/get-all-MaGiamGia");
        var giamGias = JsonConvert.DeserializeObject<List<GiamGia>>(datajson);
        return View(giamGias);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GiamGia gg)
    {
        try
        {
            var jsonData = JsonConvert.SerializeObject(gg);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7151/api/GiamGia/create-MaGiamGia", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Them thanh cong";
                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return View();
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync($"api/GiamGia/{id}");
        var gg = JsonConvert.DeserializeObject<GiamGia>(datajson);
        return View(gg);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, GiamGia gg)
    {
        var requestUrl = $"https://localhost:7151/api/GiamGia/update-MaGiamGia-{id}";
        if (await _apiService.ApiPutService(gg, requestUrl)) return RedirectToAction("Index");
        return View();
    }
}