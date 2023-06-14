using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers;
[Area("Admin")]
public class ChipGPUController : Controller
    {
    private ApiService _apiService = new();
    private string domain = "https://localhost:7151/";
    private HttpClient client = new();

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var requestUrl = "https://localhost:7151/api/ChipGPU/get-all-Chip";
        var gpu = _apiService.ApiGetService<ChipGPU>(requestUrl);
        return View(gpu);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ChipGPU chipGPU)
    {
        var requestUrl = "https://localhost:7151/api/ChipGPU/create-chip";
        if (await _apiService.ApiPostService(chipGPU, requestUrl)) return RedirectToAction("Index");
        return View();
    }

    public async Task<IActionResult> Update(Guid id)
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync($"api/ChipGPU/{id}");
        var gpu = JsonConvert.DeserializeObject<ChipGPU>(datajson);
        return View(gpu);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Guid id, ChipGPU chipGPU)
    {
        var requestUrl = $"https://localhost:7151/api/ChipGPU/update-chip-{id}";
        if (await _apiService.ApiPutService(chipGPU, requestUrl)) return RedirectToAction("Index");
        return View();
    }


    public async Task<IActionResult> Delete(Guid id)
    {
        var requestUrl = $"https://localhost:7151/api/ChipGPU/delete-chip-{id}";
        await _apiService.ApiDeleteService(requestUrl);
        return RedirectToAction("Index");
    }
}

