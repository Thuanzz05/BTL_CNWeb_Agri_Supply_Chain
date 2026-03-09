using System;
using System.Collections.Generic;

namespace SieuThiService.Models;

public partial class KiemDinh
{
    public int MaKiemDinh { get; set; }

    public int MaLo { get; set; }

    public string NguoiKiemDinh { get; set; } = null!;

    public DateTime? NgayKiemDinh { get; set; }

    public string KetQua { get; set; } = null!;

    public string? BienBanKiemTra { get; set; }

    public string? ChuKySo { get; set; }

    public virtual LoNongSan MaLoNavigation { get; set; } = null!;
}
