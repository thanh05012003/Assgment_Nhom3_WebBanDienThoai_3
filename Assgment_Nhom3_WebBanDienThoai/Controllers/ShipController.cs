using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.ModelsView;
using Assgment_Nhom3_WebBanDienThoai.ModelsView.ThanhToan;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using Assgment_Nhom3_WebBanDienThoai.Services;
using NuGet.Common;

namespace Assgment_Nhom3_WebBanDienThoai.Controllers
{
    public class ShipController : Controller
    {
        private ShoppingDbContext _context;
        private IGioHangChiTietServices GioHangChiTietServices;
        HttpClient _client = new HttpClient();
        string _apiProvince = "https://online-gateway.ghn.vn/shiip/public-api/master-data/province";
        string token = "a799ced2-febc-11ed-a967-deea53ba3605";

        public ShipController()
        {
            GioHangChiTietServices = new GioHangChiTietServices();
            _context = new ShoppingDbContext();
            _client.DefaultRequestHeaders.Add("token", token);
        }

        // GET: Shipview
        public async Task<ActionResult> Index()
        {
            #region Lấy thông tin tỉnh/Thành phố

            var response = await _client.GetAsync(_apiProvince);
            var data = await response.Content.ReadAsStringAsync();
            var tinh = JsonConvert.DeserializeObject<ApiResponse<Tinh>>(data);
            ViewBag.TenTinh = new SelectList(tinh.Data.OrderBy(c => c.ProvinceName), "ProvinceID", "ProvinceName");

            #endregion

            var jsonData = HttpContext.Session.GetString("nguoiDung");
            var nguoiDung = JsonConvert.DeserializeObject<TaiKhoan>(jsonData);
            List<HoaDonView> lstHd = new List<HoaDonView>();
            int tongtien = 0;

            var gioHangct = _context.GioHangChiTiets.Where(c => c.IdTaiKhoan.Equals(nguoiDung.Id)).ToList(); // list sản phẩm có trong giỏ hàng
            foreach (var it in gioHangct)
            {
                var idsp = _context.ChiTietSanPhams.FirstOrDefault(p => p.Id == it.IdChiTietSp).IdSanPham;
                var gia = _context.ChiTietSanPhams.FirstOrDefault(p => p.Id == it.IdChiTietSp).DonGia;
                var tensp = _context.SanPhams.FirstOrDefault(c => c.Id == idsp).TenSp;
                var tongtiensp = (Convert.ToInt32(gia) * it.SoLuong);
                HoaDonView hd = new HoaDonView();
                hd.DonGia = gia;
                hd.TenSp = tensp;
                lstHd.Add(hd);
                tongtien += tongtiensp;
            }
            ViewBag.tongTienHoaDon = tongtien;
            ViewBag.lstHdct = lstHd;
            return View();
        }
        [HttpPost]
        public IActionResult Index(HoaDonView hdv)
        {

            var usernames = SessionServices.GetObjFromSession(HttpContext.Session, "username");
            var tong = ViewBag.tongTienHoaDon;
            Guid idus = usernames.FirstOrDefault().Id;
            if (usernames.Count == 1)
            {
                HoaDon bill = new HoaDon();
                bill.Id = Guid.NewGuid();
                bill.NgayThanhToan = DateTime.Now;
                bill.IdTaiKhoan = usernames.FirstOrDefault().Id;
                bill.HoVaTen = hdv.HoTen;
                bill.DiaChi = hdv.district + " - " + hdv.ward;
                bill.TrangThai = 1;
                bill.IdThanhToan = Guid.Parse("8a5e642b-d928-4bac-81d9-0ea8d5472374");
                bill.TongTien = (hdv.TongTien + hdv.PhiShip);
                bill.SDT = hdv.Sdt;
                _context.HoaDons.Add(bill);
                Guid idhd = bill.Id;
                var product = GioHangChiTietServices.GetAll().Where(a => a.IdTaiKhoan == idus).ToList();
                List<HoaDonChiTiet> Listbill = new List<HoaDonChiTiet>();
                foreach (var item in product)
                {
                    HoaDonChiTiet billDetail = new HoaDonChiTiet();
                    billDetail.IdHoaDon = idhd;
                    billDetail.Id = new Guid();
                    billDetail.IdChiTietSp = item.IdChiTietSp;
                    billDetail.SoLuong = item.SoLuong;
                    billDetail.TrangThai = 1;
                    billDetail.Gia = _context.ChiTietSanPhams.Find(item.IdChiTietSp).DonGia;
                    Listbill.Add(billDetail);
                }
                foreach (var item in product)
                {
                    GioHangChiTietServices.Delete(item.Id);
                }
                _context.HoaDonChiTiets.AddRange(Listbill);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            return View();
        }
        //public IActionResult PlaceOrder()
        //{

        //}

    }
}
