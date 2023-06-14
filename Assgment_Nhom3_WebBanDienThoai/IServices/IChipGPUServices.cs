using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices;

public interface IChipGPUServices
{
    public bool Create(ChipGPU obj);
    public bool Delete(Guid id);
    public bool Update(ChipGPU obj);
    public List<ChipGPU> GetAll();
    public ChipGPU GetChipGPUById(Guid id);
}