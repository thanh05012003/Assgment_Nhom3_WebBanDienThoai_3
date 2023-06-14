using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers;
[Area("Admin")]
public class MauSacController : Controller
    {
    private ApiService _apiService = new();
    private string domain = "https://localhost:7151/";
    private HttpClient client = new();

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var requestUrl = "https://localhost:7151/api/MauSac/get-all-mausac";
        var ms = _apiService.ApiGetService<MauSac>(requestUrl);
        return View(ms);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MauSac msdt)
    {
        var requestUrl = "https://localhost:7151/api/MauSac/create-mausac";
        if (await _apiService.ApiPostService(msdt, requestUrl)) return RedirectToAction("Index");
        return View();
    }

    public async Task<IActionResult> Update(Guid id)
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync($"api/MauSac/{id}");
        var ms = JsonConvert.DeserializeObject<MauSac>(datajson);
        return View(ms);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Guid id, MauSac msdt)
    {
        var requestUrl = $"https://localhost:7151/api/MauSac/update-mausac-{id}";
        if (await _apiService.ApiPutService(msdt, requestUrl)) return RedirectToAction("Index");
        return View();
    }


    public async Task<IActionResult> Delete(Guid id)
    {
        var requestUrl = $"https://localhost:7151/api/MauSac/delete-mausac-{id}";
        await _apiService.ApiDeleteService(requestUrl);
        return RedirectToAction("Index");
    }
}

