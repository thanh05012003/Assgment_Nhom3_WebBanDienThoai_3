using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImeiController : Controller
    {
        private ApiService _apiService = new();
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        ShoppingDbContext dbContext;

        public ImeiController()
        {
            dbContext = new ShoppingDbContext();
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.domain = domain;
            client.BaseAddress = new Uri(domain);
            string datajson = await client.GetStringAsync("api/Imei/get-all-Imei");
            List<Imei> sp = JsonConvert.DeserializeObject<List<Imei>>(datajson);
            return View(sp);
        }

        public async Task<IActionResult> Create()
        {
            var tensp = dbContext.ChiTietSanPhams.Join(dbContext.
                SanPhams, ChiTietSanPham => ChiTietSanPham.IdSanPham, SanPham => SanPham.Id,
                (ChiTietSanPham, SanPham) => new TenSpViewModels
                {
                    Id = ChiTietSanPham.Id,
                    Tensp = SanPham.TenSp
                }).ToList();

            ViewBag.IdCtsp = new SelectList(tensp, "Id", "Tensp");

            //client.BaseAddress = new Uri(domain);
            //string sp = await client.GetStringAsync("api/ChiTietSanPham/get-all-thongTin-SanPham");
            //List<ChiTietSanPham> ctsp = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(sp);
            //ViewBag.IdCtsp = new SelectList(ctsp, "Id", "IdSanPham");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Imei imei)
        {
            var x = imei;
            var requestUrl = "https://localhost:7151/api/Imei/create-imei";
            if (await _apiService.ApiPostService(imei, requestUrl)) 
                return RedirectToAction("Index");
            return View();
        }
    }
}
