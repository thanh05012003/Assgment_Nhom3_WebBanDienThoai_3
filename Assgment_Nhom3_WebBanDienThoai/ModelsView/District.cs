namespace Assgment_Nhom3_WebBanDienThoai.ModelsView
{
    public class District
    {
        public int DistrictID { get; set; }
        public int ProvinceID { get; set; }
        public string DistrictName { get; set; }
        public string Code { get; set; }
        public int Type { get; set; }
        public int SupportType { get; set; }
        public List<string> NameExtension { get; set; }
        public int IsEnable { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public bool CanUpdateCOD { get; set; }
        public int Status { get; set; }
        public int PickType { get; set; }
        public int DeliverType { get; set; }
        public WhiteListClient WhiteListClient { get; set; }
        public WhiteListDistrict WhiteListDistrict { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonMessage { get; set; }
        public List<DateTime> OnDates { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
