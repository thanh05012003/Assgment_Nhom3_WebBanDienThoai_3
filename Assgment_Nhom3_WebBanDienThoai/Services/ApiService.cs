using Newtonsoft.Json;
using System.Text;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services;

public class ApiService
{
    public async Task<List<T>> ApiGetService<T>(string requesturl)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(requesturl);
        var dataJson = response.Content.ReadAsStringAsync();
        var item = JsonConvert.DeserializeObject<List<T>>(await dataJson);
        return item;
    }

    public async Task<bool> ApiPostService(object item, string requestUrl)
    {
        var jsonData = JsonConvert.SerializeObject(item);
        HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var response = await client.PostAsync(requestUrl, content);
        if (response.IsSuccessStatusCode) return true;
        return false;
    }

    public async Task<bool> ApiPutService(object item, string requestUrl)
    {
        var jsonData = JsonConvert.SerializeObject(item);
        HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var response = await client.PutAsync(requestUrl, content);
        if (response.IsSuccessStatusCode) return true;

        return false;
    }

    public async Task<bool> ApiDeleteService(string requestUrl)
    {
        var client = new HttpClient();
        var response = await client.DeleteAsync(requestUrl);
        if (response.IsSuccessStatusCode) return true;

        return false;
    }
}