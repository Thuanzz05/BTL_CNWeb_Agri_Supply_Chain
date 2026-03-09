using System;
using System.Collections.Generic;

namespace NongDanService.Models;

public partial class DonHang
{
    public int MaDonHang { get; set; }

    public string LoaiDon { get; set; } = null!;

    public int MaNguoiBan { get; set; }

    public string LoaiNguoiBan { get; set; } = null!;

    public int MaNguoiMua { get; set; }

    public string LoaiNguoiMua { get; set; } = null!;

    public DateTime? NgayDat { get; set; }

    public string? TrangThai { get; set; }

    public decimal? TongGiaTri { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();
}
