    using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers;
[Area("Admin")]
public class ChipCPUController : Controller
    {
    private ApiService _apiService = new();
    private string domain = "https://localhost:7151/";
    private HttpClient client = new();

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var requestUrl = "https://localhost:7151/api/ChipCPU/get-all-Chip";
        var ms = _apiService.ApiGetService<ChipCPU>(requestUrl);
        return View(ms);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ChipCPU chipCPU)
    {
        var requestUrl = "https://localhost:7151/api/ChipCPU/create-chip";
        if (await _apiService.ApiPostService(chipCPU, requestUrl)) return RedirectToAction("Index");
        return View();
    }

    public async Task<IActionResult> Update(Guid id)
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync($"api/ChipCPU/{id}");
        var cpu = JsonConvert.DeserializeObject<ChipCPU>(datajson);
        return View(cpu);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Guid id, ChipCPU chipCPU)
    {
        var requestUrl = $"https://localhost:7151/api/ChipCPU/update-chip-{id}";
        if (await _apiService.ApiPutService(chipCPU, requestUrl)) return RedirectToAction("Index");
        return View();
    }


    public async Task<IActionResult> Delete(Guid id)
    {
        var requestUrl = $"https://localhost:7151/api/ChipCPU/delete-chip-{id}";
        await _apiService.ApiDeleteService(requestUrl);
        return RedirectToAction("Index");
    }
}

