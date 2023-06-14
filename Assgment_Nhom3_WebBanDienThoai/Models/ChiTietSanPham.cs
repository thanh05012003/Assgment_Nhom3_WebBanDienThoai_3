namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class ChiTietSanPham
{
    public Guid Id { get; set; }

    public Guid IdSanPham { get; set; }

    public Guid IdGiamGia { get; set; }

    public Guid IdChatLieu { get; set; }

    public Guid IdBoNhoTrong { get; set; }

    public Guid IdHeDieuHanh { get; set; }

    public Guid IdCongSac { get; set; }
    public Guid IdPin { get; set; }

    public Guid IdSim { get; set; }

    public Guid IdRam { get; set; }

    public Guid IdChipCPU { get; set; }

    public Guid IdChipGPU { get; set; }

    public Guid IdMauSac { get; set; }

    public double TrongLuong { get; set; }

    public string CameraTruoc { get; set; }

    public string CameraSau { get; set; }

    public int DoPhanGiaiManHinh { get; set; }

    public string KichThuoc { get; set; }

    public decimal DonGia { get; set; }

    public int TrangThai { get; set; }

    public virtual SanPham? SanPhams { get; set; }

    public virtual BoNhoTrong? BoNhoTrongs { get; set; }

    public virtual ChatLieu? ChatLieus { get; set; }

    public virtual ChipCPU? ChipCPUs { get; set; }

    public virtual ChipGPU? ChipGPUs { get; set; }
    public virtual CongSac? CongSacs { get; set; }

    public virtual HeDieuHanh? HeDieuHanhs { get; set; }

    public virtual MauSac? MauSacs { get; set; }

    public virtual GiamGia? GiamGias { get; set; }

    public virtual Pin? Pins { get; set; }

    public virtual Ram? Rams { get; set; }

    public virtual Sim? Sims { get; set; }
}