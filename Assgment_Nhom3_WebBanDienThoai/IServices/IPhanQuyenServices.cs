using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IPhanQuyenServices
{
    public bool CreateQuyen(PhanQuyen p);
    public bool UpdateQuyen(PhanQuyen p);
    public bool DeleteQuyen(Guid id);
    public List<PhanQuyen> GetAllQuyens();
    public PhanQuyen GetQuyensById(Guid id);

    public List<PhanQuyen> GetQuyenByName(string name);
}