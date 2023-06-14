using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongTinSanPhamController : Controller
    {
        private ApiService _apiService = new();
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        public ThongTinSanPhamController()
        {
            
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Domain = domain;
            client.BaseAddress = new Uri(domain);
            string datajson = await client.GetStringAsync("api/ChiTietSanPham/get-all-thongTin-SanPham");
            List<ChiTietSanPham> ctsp = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(datajson);
            return View(ctsp);
            
        }

        public async Task<IActionResult> Create()
        {
            client.BaseAddress = new Uri(domain);
            string sanpham = await client.GetStringAsync("api/SanPham/get-all-sanpham");
            List<SanPham> sps = JsonConvert.DeserializeObject<List<SanPham>>(sanpham);
            ViewBag.IdSanPham = new SelectList(sps, "Id", "TenSp");

            string giamgia = await client.GetStringAsync("api/GiamGia/get-all-MaGiamGia");
            List<GiamGia> gh = JsonConvert.DeserializeObject<List<GiamGia>>(giamgia);
            ViewBag.IdGiamGia = new SelectList(gh, "Id", "SoPhanTramGiam");

            string chatlieu = await client.GetStringAsync("api/ChatLieu/get-all-MaChatLieu");
            List<ChatLieu> cl = JsonConvert.DeserializeObject<List<ChatLieu>>(chatlieu);
            ViewBag.IdChatLieu = new SelectList(cl, "Id", "Ten");

            string bonhotrong = await client.GetStringAsync("api/BoNhoTrong/get-all-BoNhoTrong");
            List<BoNhoTrong> bnt = JsonConvert.DeserializeObject<List<BoNhoTrong>>(bonhotrong);
            ViewBag.IdBoNhoTrong = new SelectList(bnt, "Id", "Ten");

            string hedieuhanh = await client.GetStringAsync("api/HeDieuHanh/get-all-HeDieuHanh");
            List<HeDieuHanh> hdh = JsonConvert.DeserializeObject<List<HeDieuHanh>>(hedieuhanh);
            ViewBag.IdHeDieuHanh = new SelectList(hdh, "Id", "Ten");

            string congsac = await client.GetStringAsync("api/CongSac/get-all-congsac");
            List<CongSac> cs = JsonConvert.DeserializeObject<List<CongSac>>(congsac);
            ViewBag.IdCongSac = new SelectList(cs, "Id", "Ten");

            string pin = await client.GetStringAsync("api/Pin/Get-all-pin");
            List<Pin> p = JsonConvert.DeserializeObject<List<Pin>>(pin);
            ViewBag.IdPin = new SelectList(p, "Id", "Ten");

            string sim = await client.GetStringAsync("api/Sim/get-all-sim");
            List<Sim> s = JsonConvert.DeserializeObject<List<Sim>>(sim);
            ViewBag.IdSim = new SelectList(s, "Id", "Ten");

            string ram = await client.GetStringAsync("api/Ram/get-all-Ram");
            List<Ram> r = JsonConvert.DeserializeObject<List<Ram>>(ram);
            ViewBag.IdRam = new SelectList(r, "Id", "Ten");

            string chipcpu = await client.GetStringAsync("api/ChipCPU/get-all-Chip");
            List<ChipCPU> cpu = JsonConvert.DeserializeObject<List<ChipCPU>>(chipcpu);
            ViewBag.IdChipCPU = new SelectList(cpu, "Id", "Ten");

            string chipgpu = await client.GetStringAsync("api/ChipGPU/get-all-ChipGPU");
            List<ChipGPU> gpu = JsonConvert.DeserializeObject<List<ChipGPU>>(chipgpu);
            ViewBag.IdChipGPU = new SelectList(gpu, "Id", "Ten");

            string mausac = await client.GetStringAsync("api/MauSac/get-all-mausac");
            List<MauSac> ms = JsonConvert.DeserializeObject<List<MauSac>>(mausac);
            ViewBag.IdMauSac = new SelectList(ms, "Id", "Ten");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ChiTietSanPham ctsp)
        {
            var requestUrl = "https://localhost:7151/api/ChiTietSanPham/create-ThongTin-SanPham";
            if (await _apiService.ApiPostService(ctsp, requestUrl)) 
                return RedirectToAction("Index");
            else return View();
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            client.BaseAddress = new Uri(domain);

            string sanpham = await client.GetStringAsync("api/SanPham/get-all-sanpham");
            List<SanPham> sps = JsonConvert.DeserializeObject<List<SanPham>>(sanpham);
            ViewBag.IdSanPham = new SelectList(sps, "Id", "TenSp");

            string giamgia = await client.GetStringAsync("api/GiamGia/get-all-MaGiamGia");
            List<GiamGia> gh = JsonConvert.DeserializeObject<List<GiamGia>>(giamgia);
            ViewBag.IdGiamGia = new SelectList(gh, "Id", "SoPhanTramGiam");

            string chatlieu = await client.GetStringAsync("api/ChatLieu/get-all-MaChatLieu");
            List<ChatLieu> cl = JsonConvert.DeserializeObject<List<ChatLieu>>(chatlieu);
            ViewBag.IdChatLieu = new SelectList(cl, "Id", "Ten");

            string bonhotrong = await client.GetStringAsync("api/BoNhoTrong/get-all-BoNhoTrong");
            List<BoNhoTrong> bnt = JsonConvert.DeserializeObject<List<BoNhoTrong>>(bonhotrong);
            ViewBag.IdBoNhoTrong = new SelectList(bnt, "Id", "Ten");

            string hedieuhanh = await client.GetStringAsync("api/HeDieuHanh/get-all-HeDieuHanh");
            List<HeDieuHanh> hdh = JsonConvert.DeserializeObject<List<HeDieuHanh>>(hedieuhanh);
            ViewBag.IdHeDieuHanh = new SelectList(hdh, "Id", "Ten");

            string congsac = await client.GetStringAsync("api/CongSac/get-all-congsac");
            List<CongSac> cs = JsonConvert.DeserializeObject<List<CongSac>>(congsac);
            ViewBag.IdCongSac = new SelectList(cs, "Id", "Ten");

            string pin = await client.GetStringAsync("api/Pin/Get-all-pin");
            List<Pin> p = JsonConvert.DeserializeObject<List<Pin>>(pin);
            ViewBag.IdPin = new SelectList(p, "Id", "Ten");

            string sim = await client.GetStringAsync("api/Sim/get-all-sim");
            List<Sim> s = JsonConvert.DeserializeObject<List<Sim>>(sim);
            ViewBag.IdSim = new SelectList(s, "Id", "Ten");

            string ram = await client.GetStringAsync("api/Ram/get-all-Ram");
            List<Ram> r = JsonConvert.DeserializeObject<List<Ram>>(ram);
            ViewBag.IdRam = new SelectList(r, "Id", "Ten");

            string chipcpu = await client.GetStringAsync("api/ChipCPU/get-all-Chip");
            List<ChipCPU> cpu = JsonConvert.DeserializeObject<List<ChipCPU>>(chipcpu);
            ViewBag.IdChipCPU = new SelectList(cpu, "Id", "Ten");

            string chipgpu = await client.GetStringAsync("api/ChipGPU/get-all-ChipGPU");
            List<ChipGPU> gpu = JsonConvert.DeserializeObject<List<ChipGPU>>(chipgpu);
            ViewBag.IdChipGPU = new SelectList(gpu, "Id", "Ten");

            string mausac = await client.GetStringAsync("api/MauSac/get-all-mausac");
            List<MauSac> ms = JsonConvert.DeserializeObject<List<MauSac>>(mausac);
            ViewBag.IdMauSac = new SelectList(ms, "Id", "Ten");



            var datajson = await client.GetStringAsync($"api/ChiTietSanPham/{id}");
            var ctsp = JsonConvert.DeserializeObject<ChiTietSanPham>(datajson);
            return View(ctsp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ChiTietSanPham ctsp)
        {
            var requestUrl = $"https://localhost:7151/api/ChiTietSanPham/update-ThongTinSanPham-{id}";
            if (await _apiService.ApiPutService(ctsp, requestUrl)) return RedirectToAction("Index");
            return View();
        }



    }
}
