using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices
{
    public interface IChipCPUServices
    {
        public bool Create(ChipCPU obj);
        public bool Delete(Guid id);
        public bool Update(ChipCPU obj);

        public List<ChipCPU> GetAll();
        public ChipCPU GetChipCPUById(Guid id);
    }
}
