using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.ModelsView;
using Assgment_Nhom3_WebBanDienThoai.ModelsView.ThanhToan;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace Assgment_Nhom3_WebBanDienThoai.Controllers
{
    public class ShipController : Controller
    {
        private ShoppingDbContext _context;
        HttpClient _client = new HttpClient();
        string _apiProvince = "https://online-gateway.ghn.vn/shiip/public-api/master-data/province";
        string token = "a799ced2-febc-11ed-a967-deea53ba3605";

        public ShipController()
        {
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
            HoaDonView hd = new HoaDonView();


            var gioHangct = _context.GioHangChiTiets.Where(c => c.IdTaiKhoan.Equals(nguoiDung.Id)).ToList(); // list sản phẩm có trong giỏ hàng
            foreach (var it in gioHangct)
            {
                var idsp = _context.ChiTietSanPhams.FirstOrDefault(p => p.Id == it.IdChiTietSp).IdSanPham;
                var gia = _context.ChiTietSanPhams.FirstOrDefault(p => p.Id == it.IdChiTietSp).DonGia;
                var tensp = _context.SanPhams.FirstOrDefault(c => c.Id == idsp).TenSp;
                var tongtien = (Convert.ToInt32(gia) * it.SoLuong);
                //ViewBag.tongTienHoaDon = tongtien;

                hd.DonGia = gia;
                hd.TenSp = tensp;
                lstHd.Add(hd);
                hd = new HoaDonView();
            }
            ViewBag.lstHdct = lstHd;
            return View();
        }

        //public IActionResult PlaceOrder()
        //{

        //}

    }
}
