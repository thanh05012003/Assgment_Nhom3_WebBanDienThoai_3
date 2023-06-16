using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeController : Controller
    {
        ShoppingDbContext dbContext;

        private ApiService _apiService = new();
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        public ThongKeController()
        {
            dbContext = new ShoppingDbContext();
        }
        public ActionResult Index()
        {
            var hoadons = dbContext.HoaDons.ToList();
            var dataThongke = (from s in dbContext.HoaDons
                               join x in dbContext.TaiKhoans on s.IdTaiKhoan equals x.Id
                               //join e in dbContext.HoaDonChiTiets on s.IdThanhToan equals e.Id
                               group s by s.IdTaiKhoan into g
                               select new ThongKeViewcs
                               {
                                   Tennguoidung = g.FirstOrDefault().TaiKhoans.HoVaTen,
                                   Tongtien = g.Sum(x => x.TongTien),
                                   Dienthoai = g.FirstOrDefault().TaiKhoans.SDT,
                                   Soluong = g.Count(),
                               });
            var dataFinal = dataThongke.OrderByDescending(s => s.Tongtien).Take(5).ToList();
            return View(dataFinal);
        }
        public async Task<IActionResult> showhd()
        {
            ViewBag.domain = domain;
            client.BaseAddress = new Uri(domain);
            string datajson = await client.GetStringAsync("api/HoaDon/Get-all-hoaDon");
            List<HoaDon> sp = JsonConvert.DeserializeObject<List<HoaDon>>(datajson);
            return View(sp);
        }

        public ActionResult Statistics(DateTime startDate, DateTime endDate)
        {
            var dataThongkes = (from s in dbContext.HoaDons
                                where s.NgayTao >= startDate && s.NgayThanhToan <= endDate
                                join x in dbContext.TaiKhoans on s.IdTaiKhoan equals x.Id
                                group s by s.IdTaiKhoan into g
                                select new ThongKeViewcs
                                {
                                    Tennguoidung = g.FirstOrDefault().TaiKhoans.HoVaTen,
                                    Tongtien = g.Sum(x => x.TongTien),
                                    Dienthoai = g.FirstOrDefault().TaiKhoans.SDT,
                                    Soluong = g.Count()
                                });

            var dataFinal = dataThongkes.OrderByDescending(s => s.Tongtien).Take(5).ToList();

            return View(dataFinal);
        }
    }
}
