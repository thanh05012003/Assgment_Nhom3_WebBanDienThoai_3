using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers;

[Area("Admin")]
public class NhaSansXuatsController : Controller
{
    private ApiService _apiService = new();
    private string domain = "https://localhost:7151/";
    private HttpClient client = new();

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var requestUrl = "https://localhost:7151/api/NhaSanXuat/get-all-nhasanxuat";
        var nhaSanXuat = _apiService.ApiGetService<NhaSanXuat>(requestUrl);
        return View(nhaSanXuat);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NhaSanXuat nsx)
    {
        var requestUrl = "https://localhost:7151/api/NhaSanXuat/create-nhasanxuat";
        if (await _apiService.ApiPostService(nsx, requestUrl)) return RedirectToAction("Index");
        return View();
    }

    public async Task<IActionResult> Update(Guid id)
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync($"api/NhaSanXuat/{id}");
        var nhaSanXuat = JsonConvert.DeserializeObject<NhaSanXuat>(datajson);
        return View(nhaSanXuat);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Guid id, NhaSanXuat nsx)
    {
        var requestUrl = $"https://localhost:7151/api/NhaSanXuat/update-nhasanxuat-{id}";
        if (await _apiService.ApiPutService(nsx, requestUrl)) return RedirectToAction("Index");
        return View();
    }


    public async Task<IActionResult> Delete(Guid id)
    {
        var requestUrl = $"https://localhost:7151/api/NhaSanXuat/delete-nhasanxuat-{id}";
        await _apiService.ApiDeleteService(requestUrl);
        return RedirectToAction("Index");
    }
}