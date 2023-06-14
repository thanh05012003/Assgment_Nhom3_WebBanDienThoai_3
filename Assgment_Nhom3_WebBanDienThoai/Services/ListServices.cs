using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.EntityFrameworkCore;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class ListServices : IListAnhServices
    {
        ShoppingDbContext dbContext;
        public ListServices()
        {
            dbContext = new ShoppingDbContext();
        }
        public bool Create(ListAnh img)
        {
            try
            {
                dbContext.ListAnhs.Add(img);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(ListAnh img)
        {
            throw new NotImplementedException();
        }

        public List<ListAnh> GetAnhList()
        {
            return dbContext.ListAnhs.ToList();
        }

        public bool Update(ListAnh img)
        {
            throw new NotImplementedException();
        }
    }
}
