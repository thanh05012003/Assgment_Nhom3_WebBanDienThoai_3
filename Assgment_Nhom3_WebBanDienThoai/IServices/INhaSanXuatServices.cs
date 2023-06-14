using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface INhaSanXuatServices
{
    public bool createNhaSanXuat(NhaSanXuat obj);
    public bool deleteSanPham(Guid id);
    public bool updateNhaSanXuat(NhaSanXuat obj);
    public List<NhaSanXuat> GetAll();
    public NhaSanXuat GetNhaSanXuatByName(string ten);
    public NhaSanXuat GetNhaSanXuatById(Guid id);
}