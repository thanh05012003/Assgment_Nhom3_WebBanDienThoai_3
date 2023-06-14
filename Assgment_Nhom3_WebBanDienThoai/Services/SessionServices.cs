using Assgment_Nhom3_WebBanDienThoai.Models;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class SessionServices
    {
        public static void SetobjTojson(ISession session, object value, string key)
        {
            //Convert sang json

            var jsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonString);
        }
        public static List<TaiKhoan> GetObjFromSession(ISession session, string key)
        {
            var data = session.GetString(key); // doc du lieu tu ss
            if (data != null)
            {
                var listobj = JsonConvert.DeserializeObject<List<TaiKhoan>>(data);
                return listobj;
            }
            else
            {
                return new List<TaiKhoan>();
            }
        }

        public static bool CheckProductInTK(Guid Id, List<TaiKhoan> cartpd)
        {
            return cartpd.Any(p => p.Id == Id);
        }
    }
}
