using System;
using System.Collections.Generic;

namespace AdminService.Models;

public partial class VanChuyen
{
    public int MaVanChuyen { get; set; }

    public int MaLo { get; set; }

    public string DiemDi { get; set; } = null!;

    public string DiemDen { get; set; } = null!;

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? TrangThai { get; set; }

    public virtual LoNongSan MaLoNavigation { get; set; } = null!;
}
