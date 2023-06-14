using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assgment_Nhom3_WebBanDienThoai.Controllers
{
    public class LoginController : Controller
    {
        ShoppingDbContext shopingBDContext = new ShoppingDbContext();
        private readonly ILogger<GioHangController> _logger;
        private readonly IChiTietSanPhamServices _sanphamServices;
        private readonly ITaiKhoanServices _tkServices;
        private readonly IGioHangServices _cartServices;
        private readonly IGioHangChiTietServices _cartDetailService;
        private readonly IPhanQuyenServices _roleServices;
        private ApiService _apiService = new();
        string domain = "https://localhost:7151/";
        HttpClient client = new HttpClient();
        ShoppingDbContext _context;
        ShoppingDbContext ShoppingDbContext;
        IGioHangServices GioHangServices;

        public LoginController(ILogger<GioHangController> logger)
        {
            _logger = logger;
            _sanphamServices = new ChiTietSanPhamServices();
            _tkServices = new TaiKhoanServices();
            _cartServices = new GioHangServices();
            _cartDetailService = new GioHangChiTietServices();
            _roleServices = new PhanQuyenServices();
            GioHangServices = new GioHangServices();


        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Show
        public ActionResult Show(int id)
        {
            var User = shopingBDContext.TaiKhoans.Include("Role").ToList();
            return View(User);
        }

        // GET: LoginController/Detail
        public IActionResult Detail(Guid id)
        {
            var User = shopingBDContext.TaiKhoans.Find(id);
            return View(User);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TaiKhoan tk)
        {
            var data = shopingBDContext.TaiKhoans.Where(a => a.TenDN == tk.TenDN && a.MatKhau == tk.MatKhau).ToList();
            var products = SessionCartcs.GetObjFromSession(HttpContext.Session, "Cart");

            if (data.Count > 0)
            {
                #region Lấy thông tin người dùng khi login lưu vào session

                var nguoiDung = shopingBDContext.TaiKhoans.FirstOrDefault(a => a.TenDN == tk.TenDN && a.MatKhau == tk.MatKhau);
                if (nguoiDung != null)
                {
                    SessionServices.SetobjTojson(HttpContext.Session, nguoiDung, "nguoiDung");
                }

                #endregion

                var user = shopingBDContext.TaiKhoans.Where(a => a.TenDN == tk.TenDN && a.MatKhau == tk.MatKhau).ToList();

                SessionServices.SetobjTojson(HttpContext.Session, user, "username");
                var usernames = SessionServices.GetObjFromSession(HttpContext.Session, "username");
                var idus = usernames.FirstOrDefault().Id;
                if (products.Count > 0)
                {

                    var idcartss = GioHangServices.GetCartById(idus);
                    if (idcartss == null)
                    {
                        GioHang cart = new GioHang();
                        cart.IdTaiKhoan = idus;
                        cart.Mota = "1";
                        GioHangServices.Create(cart);

                        foreach (var item in products)
                        {

                            var iddetail = _cartDetailService.GetAll().FirstOrDefault(a => a.IdChiTietSp == item.ctsp.Id && a.IdTaiKhoan == idus);
                            if (iddetail.IdChiTietSp == item.ctsp.Id)
                            {
                                iddetail.SoLuong += item.quantity;
                                _cartDetailService.Update(iddetail);
                            }
                            else
                            {
                                GioHangChiTiet cartDetail = new GioHangChiTiet();
                                cartDetail.Id = new Guid();
                                cartDetail.IdTaiKhoan = idus;
                                cartDetail.IdChiTietSp = item.ctsp.Id;
                                cartDetail.SoLuong = item.quantity;
                                _cartDetailService.Create(cartDetail);
                            }

                        }

                    }
                    else
                    {
                        foreach (var item in products)
                        {

                            var iddetail = _cartDetailService.GetAll().FirstOrDefault(a => a.IdChiTietSp == item.ctsp.Id && a.IdTaiKhoan == idus);

                            if (iddetail != null)
                            {
                                iddetail.SoLuong += item.quantity;
                                _cartDetailService.Update(iddetail);
                            }
                            else
                            {
                                GioHangChiTiet cartDetail = new GioHangChiTiet();
                                cartDetail.Id = new Guid();
                                cartDetail.IdTaiKhoan = idus;
                                cartDetail.IdChiTietSp = item.ctsp.Id;
                                cartDetail.SoLuong = item.quantity;
                                _cartDetailService.Create(cartDetail);
                            }

                        }
                    }

                    HttpContext.Session.Remove("Cart");
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Role = new SelectList(_roleServices.GetAllQuyens(), "Id", "RoleName");
            return View();
        }
        // POST: LoginController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaiKhoan User)
        {
            User.IdCv = Guid.Parse("CB564DDE-2B08-49EA-9AFA-27DCB8D26CCB");
            User.TrangThai = 1;
            User.LinkAnh = "Null";
            if (ModelState.IsValid)
            {
                string requestUrl = "https://localhost:7151/api/TaiKhoan/create-taikhoan";
                bool response = await _apiService.ApiPostService(User, requestUrl);
                if (response)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        [HttpGet]

        // GET: LoginController/Edit/5
        public IActionResult Edit(Guid id)
        {
            ViewBag.Role = new SelectList(_roleServices.GetAllQuyens(), "Id", "RoleName");
            TaiKhoan User = _tkServices.GetSanPhamById(id);
            return View(User);
        }

        // POST: LoginController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(TaiKhoan user)
        {
            ViewBag.Role = new SelectList(_roleServices.GetAllQuyens(), "Id", "RoleName");
            if (_tkServices.UpdateTaiKhoan(user))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }




        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
