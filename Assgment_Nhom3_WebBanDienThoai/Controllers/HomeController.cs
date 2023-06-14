using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using Assgment_Nhom3_WebBanDienThoai.ModelsView.ThanhToan;

namespace Assgment_Nhom3_WebBanDienThoai.Controllers;

public class HomeController : Controller
{
    private ApiService _apiService = new();
    string domain = "https://localhost:7151/";
    HttpClient client = new HttpClient();
    ShoppingDbContext _context;
    private readonly ILogger<HomeController> _logger;
    ShoppingDbContext ShoppingDbContext;
    IGioHangChiTietServices GioHangChiTietServices;
    IGioHangServices GioHangServices;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        GioHangServices = new GioHangServices();

        GioHangChiTietServices = new GioHangChiTietServices();

        _context = new ShoppingDbContext();
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        string datajson = await client.GetStringAsync("api/ChiTietSanPham/get-all-thongTin-SanPham");
        List<ChiTietSanPham> ctsp = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(datajson);
        return View(ctsp);
    }

    public async Task<IActionResult> PhoneDetail(Guid id)
    {
        client.BaseAddress = new Uri(domain);
        var datajson = await client.GetStringAsync($"api/ChiTietSanPham/{id}");
        var ctsp = JsonConvert.DeserializeObject<ChiTietSanPham>(datajson);
        return View(ctsp);
    }

    public async Task<IActionResult> ShowPhone()
    {
        ViewBag.Domain = domain;
        client.BaseAddress = new Uri(domain);
        string datajson = await client.GetStringAsync("api/ChiTietSanPham/get-all-thongTin-SanPham");
        List<ChiTietSanPham> ctsp = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(datajson);
        return View(ctsp);
    }

    public async Task<IActionResult> TimKiem(string searchString, string minPrice, string maxPrice)
    {
        var books = _context.ChiTietSanPhams.Select(b => b);
        var ten = _context.SanPhams.Select(b => b);

        if (!string.IsNullOrEmpty(searchString))
        {

            ten = ten.Where(b => b.TenSp.Contains(searchString));
        }

        if (!string.IsNullOrEmpty(minPrice))
        {
            var min = int.Parse(minPrice);
            books = books.Where(b => b.DonGia >= min);
        }

        if (!string.IsNullOrEmpty(maxPrice))
        {
            var max = int.Parse(maxPrice);
            books = books.Where(b => b.DonGia <= max);
        }

        return View(await books.ToListAsync());
    }
    public async Task<IActionResult> AddToCard(Guid id, int sl = 1)
    {
        var username = SessionServices.GetObjFromSession(HttpContext.Session, "username");
        var product = SessionCartcs.GetObjFromSession(HttpContext.Session, "Cart");
        if (username.Count == 0)
        {
            if (product.Count == 0)
            {
                product.Add(new QuantityModel { ctsp = _context.ChiTietSanPhams.Find(id), quantity = sl });
                SessionCartcs.SetobjTojson(HttpContext.Session, product, "Cart");
            }
            else
            {
                if (SessionCartcs.CheckProductIncart(id, product))
                {
                    foreach (var item in product)
                    {
                        if (item.ctsp.Id == id)
                        {
                            item.quantity += sl;
                        }
                    }
                }
                else
                {
                    product.Add(new QuantityModel { ctsp = _context.ChiTietSanPhams.Find(id), quantity = sl });
                }
                SessionServices.SetobjTojson(HttpContext.Session, product, "Cart");
            }
            return RedirectToAction("showcart");
        }
        else
        {
            var idus = username.FirstOrDefault().Id;
            var iddetail = GioHangChiTietServices.GetAll().FirstOrDefault(a => a.IdChiTietSp == id && a.IdTaiKhoan == idus);
            var idcartss = GioHangServices.GetCartById(idus);

            if (idcartss == null)
            {
                GioHang cart = new GioHang();
                cart.IdTaiKhoan = idus;
                cart.Mota = "lon";
                GioHangServices.Create(cart);
                if (iddetail == null)
                {
                    GioHangChiTiet cartDetail = new GioHangChiTiet();
                    cartDetail.Id = new Guid();
                    cartDetail.IdChiTietSp = id;
                    cartDetail.IdTaiKhoan = idus;
                    cartDetail.SoLuong = sl;
                    cartDetail.TrangThai = 1;
                    GioHangChiTietServices.Create(cartDetail);
                }
                if (iddetail != null)
                {
                    var ids = GioHangChiTietServices.GetAll().FirstOrDefault(a => a.IdTaiKhoan == idus && a.IdChiTietSp == id);
                    ids.SoLuong += sl;
                    GioHangChiTietServices.Update(ids);
                    return RedirectToAction("showcart");
                }
            }
            else
            {
                if (iddetail == null)
                {
                    GioHangChiTiet cartDetail = new GioHangChiTiet();
                    cartDetail.Id = new Guid();
                    cartDetail.IdChiTietSp = id;
                    cartDetail.IdTaiKhoan = idus;
                    cartDetail.SoLuong = sl;
                    cartDetail.TrangThai = 1;
                    GioHangChiTietServices.Create(cartDetail);
                }
                if (iddetail != null)
                {
                    var ids = GioHangChiTietServices.GetAll().FirstOrDefault(a => a.IdTaiKhoan == idus && a.IdChiTietSp == id);
                    ids.SoLuong += sl;
                    GioHangChiTietServices.Update(ids);

                }
            }
        }

        return RedirectToAction("showcart");
    }


    public async Task<IActionResult> Deletecart(Guid id)
    {
        var requestUrl = $"https://localhost:7151/api/GioHangChiTiet/delete-GioHangChiTiet-{id}";
        await _apiService.ApiDeleteService(requestUrl);

        return RedirectToAction("showcartCartdetal");
    }
    [HttpGet]
    public async Task<IActionResult> showcart()
    {
        var usernames = SessionServices.GetObjFromSession(HttpContext.Session, "username");
        if (usernames.Count == 0)
        {
            var products = SessionCartcs.GetObjFromSession(HttpContext.Session, "Cart");
            return View(products);
        }
        else
        {
            return RedirectToAction("showcartCartdetal");
        }


    }
    public async Task<IActionResult> showcartCartdetal()
    {
        var usernames = SessionServices.GetObjFromSession(HttpContext.Session, "username");
        client.BaseAddress = new Uri(domain);
        string datajson = await client.GetStringAsync("api/GioHangChiTiet/get-all-GioHangChiTiet");
        List<GioHangChiTiet> ghct = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(datajson);
        var tongtien = 0;
        var tongtien1sp = 0;
        var idus = usernames.FirstOrDefault().Id;
        var gh = ghct.Where(a => a.IdTaiKhoan == idus).ToList();
        foreach (var item in gh)
        {
            var idsp = _context.ChiTietSanPhams.FirstOrDefault(p => p.Id == item.IdChiTietSp).IdSanPham;
            var gia = _context.ChiTietSanPhams.FirstOrDefault(p => p.Id == item.IdChiTietSp);
            tongtien1sp = (Convert.ToInt32(gia.DonGia) * item.SoLuong);
            tongtien += tongtien1sp;
        }
        ViewBag.tongtien = tongtien;
        //HoaDonView hdV = new HoaDonView()
        //{
        //    district = 
        //}
        return View(gh);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}