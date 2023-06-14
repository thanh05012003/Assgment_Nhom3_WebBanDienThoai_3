using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ListAnhController : Controller
    {
        ShoppingDbContext dbContext;
        IListAnhServices listAnhServices;
        public ListAnhController()
        {
            dbContext = new ShoppingDbContext();
            listAnhServices = new ListServices();
        }
        private ApiService _apiService = new();
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            ViewBag.domain = domain;
            client.BaseAddress = new Uri(domain);
            string datajson = await client.GetStringAsync("api/ListAnh/all-Anh");
            List<ListAnh> img = JsonConvert.DeserializeObject<List<ListAnh>>(datajson);
            return View(img);
        }

        public IActionResult Create()
        {
            var tensp = dbContext.ChiTietSanPhams.Join(dbContext.
                SanPhams, ChiTietSanPham => ChiTietSanPham.IdSanPham, SanPham => SanPham.Id,
                (ChiTietSanPham, SanPham) => new TenSpViewModels
                {
                    Id = ChiTietSanPham.Id,
                    Tensp = SanPham.TenSp
                }).ToList();

            ViewBag.IdCtsp = new SelectList(tensp, "Id", "Tensp");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ListAnh Image)
        {
            var file1 = Request.Form.Files["image1"];
            var file2 = Request.Form.Files["image2"];
            var file3 = Request.Form.Files["image3"];
            var file4 = Request.Form.Files["image4"];
            string sourcePath1 = file1.FileName;
            string sourcePath2 = file2.FileName;
            string sourcePath3 = file3.FileName;
            string sourcePath4 = file4.FileName;
            Image.Anh = sourcePath1;
            Image.Anh1 = sourcePath2;
            Image.Anh2 = sourcePath3;
            Image.Anh3 = sourcePath4;
            if (listAnhServices.Create(Image))
            {
                string destinationPath = @"C:\Users\ADMIN\Desktop\XinDay\Assgment_Nhom3_WebBanDienThoai\Assgment_Nhom3_WebBanDienThoai\wwwroot\img\";
                string fileName1 = Path.GetFileName(sourcePath1);
                string fileName2 = Path.GetFileName(sourcePath2);
                string fileName3 = Path.GetFileName(sourcePath3);
                string fileName4 = Path.GetFileName(sourcePath4);
                string destinationFilePath1 = Path.Combine(destinationPath, fileName1);
                string destinationFilePath2 = Path.Combine(destinationPath, fileName2);
                string destinationFilePath3 = Path.Combine(destinationPath, fileName3);
                string destinationFilePath4 = Path.Combine(destinationPath, fileName4);
                using (var stream = new FileStream(destinationFilePath1, FileMode.Create))
                {
                    await file1.CopyToAsync(stream);

                }
                using (var stream = new FileStream(destinationFilePath2, FileMode.Create))
                {
                    await file2.CopyToAsync(stream);

                }
                using (var stream = new FileStream(destinationFilePath3, FileMode.Create))
                {
                    await file3.CopyToAsync(stream);

                }
                using (var stream = new FileStream(destinationFilePath4, FileMode.Create))
                {
                    await file4.CopyToAsync(stream);

                }
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
    }
}
