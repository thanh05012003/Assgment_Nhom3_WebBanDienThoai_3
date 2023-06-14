using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface ITaiKhoanServices
{
    public bool CreateTaiKhoan(TaiKhoan tk);
    public bool DeleteTaiKhoan(Guid id);
    public bool UpdateTaiKhoan(TaiKhoan tk);
    public List<TaiKhoan> GetAll();

    public TaiKhoan GetSanPhamById(Guid id);
    public List<TaiKhoan> GetTaiKhoanByName(string name);
}