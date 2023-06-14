using Assgment_Nhom3_WebBanDienThoai.Models;
using Newtonsoft.Json;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class SessionCartcs
    {
        public static void SetobjTojson(ISession session, object value, string key)
        {
            //Convert sang json

            var jsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonString);
        }
        public static List<QuantityModel> GetObjFromSession(ISession session, string key)
        {
            var data = session.GetString(key); // doc du lieu tu ss
            if (data != null)
            {
                var listobj = JsonConvert.DeserializeObject<List<QuantityModel>>(data);
                return listobj;
            }
            else
            {
                return new List<QuantityModel>();
            }
        }

        public static bool CheckProductIncart(Guid Id, List<QuantityModel> cartpd)
        {
            return cartpd.Any(p => p.ctsp.Id == Id);
        }
    }
}
