namespace Assgment_Nhom3_WebBanDienThoai.ModelsView
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}
