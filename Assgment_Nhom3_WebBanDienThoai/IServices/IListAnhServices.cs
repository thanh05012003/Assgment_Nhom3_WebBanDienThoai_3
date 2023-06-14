using Assgment_Nhom3_WebBanDienThoai.Models;
using System.Drawing;

namespace Assgment_Nhom3_WebBanDienThoai.IServices
{
    public interface IListAnhServices
    {
        public bool Create(ListAnh img);
        public bool Delete(ListAnh img);
        public bool Update(ListAnh img);

        public List<ListAnh> GetAnhList();
    }
}
