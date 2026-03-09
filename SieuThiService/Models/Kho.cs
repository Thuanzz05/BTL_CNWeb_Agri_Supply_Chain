using System;
using System.Collections.Generic;

namespace SieuThiService.Models;

public partial class Kho
{
    public int MaKho { get; set; }

    public string TenKho { get; set; } = null!;

    public string LoaiKho { get; set; } = null!;

    public int MaChuSoHuu { get; set; }

    public string LoaiChuSoHuu { get; set; } = null!;

    public string? DiaChi { get; set; }

    public virtual ICollection<TonKho> TonKhos { get; set; } = new List<TonKho>();
}
